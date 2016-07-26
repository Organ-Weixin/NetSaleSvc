using NetSaleSvc.Entity.Models;
using NetSaleSvc.Entity.Repository;
using NetSaleSvc.Entity.Repository.Impl;
using System;
using System.Collections.Generic;

namespace NetSaleSvc.Service
{
    public class UserCinemaService
    {
        #region ctor
        private readonly IRepository<UserCinemaViewEntity> _userCinemaViewRepository;

        public UserCinemaService()
        {
            //TODO: 移除内部依赖
            _userCinemaViewRepository = new Repository<UserCinemaViewEntity>();
        }
        #endregion

        /// <summary>
        /// 获取用户能访问的所有影院
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IList<UserCinemaViewEntity> GetUserCinemasByUserId(int UserId)
        {
            DateTime Now = DateTime.Now.Date;
            return _userCinemaViewRepository.Query.Where(x => x.UserId == UserId 
                && (x.ExpDate == null || x.ExpDate > Now)).ToList();
        }

        /// <summary>
        /// 根据用户Id和影院编码获取用户是否可访问
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="CinemaCode"></param>
        /// <returns></returns>
        public UserCinemaViewEntity GetUserCinema(int UserId, string CinemaCode)
        {
            DateTime Now = DateTime.Now.Date;
            return _userCinemaViewRepository.Query.Where(x => x.UserId == UserId
                && x.CinemaCode == CinemaCode && (x.ExpDate == null || x.ExpDate > Now)).SingleOrDefault();
        }
    }
}
