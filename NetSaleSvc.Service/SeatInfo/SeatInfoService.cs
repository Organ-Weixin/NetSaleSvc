﻿using NetSaleSvc.Entity.Models;
using NetSaleSvc.Entity.Repository;
using NetSaleSvc.Entity.Repository.Impl;
using System.Collections.Generic;

namespace NetSaleSvc.Service
{
    public class SeatInfoService
    {
        #region ctor
        private readonly IRepository<ScreenSeatInfoEntity> _screenSeatInfoRepository;

        public SeatInfoService()
        {
            //TODO: 移除内部依赖
            _screenSeatInfoRepository = new Repository<ScreenSeatInfoEntity>();
        }
        #endregion

        /// <summary>
        /// 获取影厅座位信息
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <param name="ScreenCode"></param>
        /// <returns></returns>
        public IList<ScreenSeatInfoEntity> GetScreenSeats(string CinemaCode, string ScreenCode)
        {
            return _screenSeatInfoRepository.Query.Where(x => x.CinemaCode == CinemaCode
            && x.ScreenCode == ScreenCode).OrderBy(x => x.SeatCode).ToList();
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entities"></param>
        public void BulkInsert(IEnumerable<ScreenSeatInfoEntity> entities)
        {
            _screenSeatInfoRepository.BulkInsert(entities);
        }

        /// <summary>
        /// 根据主键合并
        /// </summary>
        /// <param name="entities"></param>
        public void BulkMerge(IEnumerable<ScreenSeatInfoEntity> entities)
        {
            _screenSeatInfoRepository.BulkMerge(entities);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        public void BulkDelete(IEnumerable<ScreenSeatInfoEntity> entities)
        {
            _screenSeatInfoRepository.BulkDelete(entities);
        }

        /// <summary>
        /// 新增影厅座位信息
        /// </summary>
        /// <param name="entity"></param>
        public void InsertScreenSeatInfo(ScreenSeatInfoEntity entity)
        {
            _screenSeatInfoRepository.Insert(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateScreenSeatInfo(ScreenSeatInfoEntity entity)
        {
            _screenSeatInfoRepository.Update(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteScreenSeatInfo(ScreenSeatInfoEntity entity)
        {
            _screenSeatInfoRepository.Delete(entity);
        }
    }
}