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
    public class CinemaService
    {
        #region ctor
        private readonly IRepository<CinemaViewEntity> _cinemaViewRepository;
        private readonly IRepository<CinemaEntity> _cinemaRepository;

        public CinemaService()
        {
            //TODO: 移除内部依赖
            _cinemaViewRepository = new Repository<CinemaViewEntity>();
            _cinemaRepository = new Repository<CinemaEntity>();
        }
        #endregion

        /// <summary>
        /// 根据影院编码获取影院信息
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <returns></returns>
        public CinemaViewEntity GetCinemaViewByCinemaCode(string CinemaCode)
        {
            return _cinemaViewRepository.Query.Where(x => x.Code == CinemaCode).SingleOrDefault();
        }

        /// <summary>
        /// 获取所有影院列表
        /// </summary>
        /// <returns></returns>
        public async Task<IList<CinemaEntity>> GetAllCinemasAsync()
        {
            return await _cinemaRepository.Query.Where(x => !x.IsDel).ToListAsync();
        }

        /// <summary>
        /// 获取Cinema实体
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <returns></returns>
        public CinemaEntity GetCinemaByCinemaCode(string CinemaCode)
        {
            return _cinemaRepository.Query.Where(x => x.Code == CinemaCode).SingleOrDefault();
        }

        /// <summary>
        /// 获取Cinema实体
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <returns></returns>
        public async Task<CinemaEntity> GetCinemaByCinemaCodeAsync(string CinemaCode)
        {
            return await _cinemaRepository.Query.Where(x => x.Code == CinemaCode).SingleOrDefaultAsync();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(CinemaEntity entity)
        {
            _cinemaRepository.Update(entity);
        }
    }
}
