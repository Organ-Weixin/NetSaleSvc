using NetSaleSvc.Entity.Models;
using System;

namespace NetSaleSvc.Api.CTMS.ChenXing.Models
{
    public static class ModelMapper
    {

        /// <summary>
        /// 影厅信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ScreenInfoEntity MapToEntity(this CxQueryCinemaInfoResultScreenVO model, ScreenInfoEntity entity)
        {
            entity.SCode = model.ScreenCode;
            entity.SName = model.ScreenName;
            entity.SeatCount = model.SeatCount;
            entity.Type = model.Type;
            entity.UpdateTime = DateTime.Now;

            return entity;
        }
    }
}
