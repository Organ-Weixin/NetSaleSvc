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

        public CinemaService()
        {
            //TODO: 移除内部依赖
            _cinemaViewRepository = new Repository<CinemaViewEntity>();
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
    }
}
