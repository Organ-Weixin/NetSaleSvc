using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Entity.Repository;
using NetSaleSvc.Entity.Repository.Impl;
using NetSaleSvc.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetSaleSvc.Service
{
    public class SessionInfoService
    {
        #region ctor
        private readonly IRepository<SessionInfoEntity> _sessionInfoRepository;

        public SessionInfoService()
        {
            //TODO: 移除内部依赖
            _sessionInfoRepository = new Repository<SessionInfoEntity>();
        }
        #endregion

        /// <summary>
        /// 获取影院在指定时间段内的排期
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public IList<SessionInfoEntity> GetSessions(string CinemaCode, int UserId, DateTime StartDate, DateTime EndDate)
        {
            EndDate = EndDate.AddDays(1);
            return _sessionInfoRepository.Query.Where(x => x.CCode == CinemaCode && x.UserID == UserId
                && x.StartTime > StartDate && x.StartTime < EndDate).OrderBy(x => x.StartTime).ToList();
        }

        /// <summary>
        /// 根据排期编码获取排期信息
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <param name="SessionCode"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public SessionInfoEntity GetSessionInfo(string CinemaCode, string SessionCode, int UserId)
        {
            return _sessionInfoRepository.Query.Where(x => x.CCode == CinemaCode && x.UserID == UserId
            && x.SCode == SessionCode).SingleOrDefault();
        }

        /// <summary>
        /// 根据接入商获取影院指定时间内的排期（包括影院给该接入商设置的价格）
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <param name="UserId"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public IList<SessionInfoWithCustomPrice> GetSessionWithUserPrice(string CinemaCode, int UserId,
            DateTime StartDate, DateTime EndDate)
        {
            const string sql = @"SELECT SessionInfo.*, PricePlan.* 
                FROM SessionInfo 
                LEFT JOIN PricePlan ON PricePlan.[CinemaCode] = SessionInfo.[CCode] and (PricePlan.Code = SessionInfo.SCode or PricePlan.Code = SessionInfo.FilmCode) and (PricePlan.UserID = @UserID or PricePlan.UserID = @CinemaCode)
                WHERE SessionInfo.CCode = @CinemaCode AND SessionInfo.UserId = @UserId AND SessionInfo.StartTime > @StartDate AND SessionInfo.StartTime < @EndDate
                ORDER BY StartTime";

            Dictionary<int, SessionInfoWithCustomPrice> resultDic = new Dictionary<int, SessionInfoWithCustomPrice>();

            _sessionInfoRepository.QueryDouble<SessionInfoEntity, PricePlanEntity, SessionInfoWithCustomPrice>(sql,
                (session, price) =>
                {
                    SessionInfoWithCustomPrice entity = default(SessionInfoWithCustomPrice);
                    if (session != null && !resultDic.TryGetValue(session.Id, out entity))
                    {
                        resultDic.Add(session.Id, entity = new SessionInfoWithCustomPrice { sessionInfo = session });
                    }
                    if (price != null)
                    {
                        if (price.Type == PricePlanTypeEnum.Film.GetDescription())
                        {
                            entity.customPrice.CustomFilmPrice = price.Price;
                        }
                        else if (price.Type == PricePlanTypeEnum.Session.GetDescription())
                        {
                            entity.customPrice.CustomSessionPrice = price.Price;
                        }
                        else if (price.Type == PricePlanTypeEnum.LowestPrice.GetDescription())
                        {
                            entity.customPrice.CustomLowestPrice = price.Price;
                        }
                    }
                    return entity;
                },
                param: new { CinemaCode = CinemaCode, UserId = UserId, StartDate = StartDate, EndDate = EndDate.AddDays(1) },
                commandType: CommandType.Text);

            return resultDic.Values.ToList();
        }

        /// <summary>
        /// 批量合并
        /// </summary>
        /// <param name="entities"></param>
        public void BulkMerge(IEnumerable<SessionInfoEntity> Entities, string CinemaCode,
            DateTime StartDate, DateTime EndDate)
        {
            if (StartDate < DateTime.Now)
            {
                StartDate = DateTime.Now;
            }
            EndDate = EndDate.AddDays(1);

            using (var connection = DbConnectionFactory.OpenSqlConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.MergeSession";
                cmd.Parameters.AddWithValue("@sessions", Entities.ToList().ToDataTable());
                cmd.Parameters.AddWithValue("@CinemaCode", CinemaCode);
                cmd.Parameters.AddWithValue("@StartTime", StartDate);
                cmd.Parameters.AddWithValue("@EndTime", EndDate);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
