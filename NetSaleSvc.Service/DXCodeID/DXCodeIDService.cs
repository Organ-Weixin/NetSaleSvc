using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetSaleSvc.Entity.Models;
using NetSaleSvc.Entity.Repository;
using NetSaleSvc.Entity.Repository.Impl;

namespace NetSaleSvc.Service
{
    public class DXCodeIDService
    {
        #region ctor
        private readonly IRepository<DXCodeIDEntity> _dxCodeIdRepository;

        public DXCodeIDService()
        {
            //TODO: 移除内部依赖
            _dxCodeIdRepository = new Repository<DXCodeIDEntity>();
        }
        #endregion

        public DXCodeIDEntity GetDXCodeByCinemaCode(string CinemaCode)
        {
            var dxCodeEntity = _dxCodeIdRepository.Query.Where(x => x.Code == CinemaCode).SingleOrDefault();
            if(dxCodeEntity==null)
            {
                return null;
            }
            return dxCodeEntity;
        }
    }
}
