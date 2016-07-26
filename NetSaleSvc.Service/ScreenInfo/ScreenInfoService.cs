using NetSaleSvc.Entity.Models;
using NetSaleSvc.Entity.Repository;
using NetSaleSvc.Entity.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSaleSvc.Service
{
    public class ScreenInfoService
    {
        #region ctor
        private readonly IRepository<ScreenInfoEntity> _screenInfoRepository;

        public ScreenInfoService()
        {
            //TODO: 移除内部依赖
            _screenInfoRepository = new Repository<ScreenInfoEntity>();
        }
        #endregion

        /// <summary>
        /// 获取影厅信息
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <param name="ScreenCode"></param>
        /// <returns></returns>
        public ScreenInfoEntity GetScreenInfo(string CinemaCode, string ScreenCode)
        {
            return _screenInfoRepository.Query.Where(x => x.CCode == CinemaCode && x.SCode == ScreenCode).SingleOrDefault();
        }

        /// <summary>
        /// 获取影院影厅列表
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <returns></returns>
        public IList<ScreenInfoEntity> GetScreenListByCinemaCode(string CinemaCode)
        {
            return _screenInfoRepository.Query.Where(x => x.CCode == CinemaCode).ToList();
        }

        /// <summary>
        /// 新增影厅信息
        /// </summary>
        /// <param name="entity"></param>
        public void InsertScreenInfo(ScreenInfoEntity entity)
        {
            _screenInfoRepository.Insert(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateScreenInfo(ScreenInfoEntity entity)
        {
            _screenInfoRepository.Update(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteScreenInfo(ScreenInfoEntity entity)
        {
            _screenInfoRepository.Delete(entity);
        }

        /// <summary>
        /// 批量合并
        /// </summary>
        /// <param name="entities"></param>
        public void BulkMerge(IEnumerable<ScreenInfoEntity> entities)
        {
            _screenInfoRepository.BulkMerge(entities);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        public void BulkDelete(IEnumerable<ScreenInfoEntity> entities)
        {
            _screenInfoRepository.BulkDelete(entities);
        }
    }
}
