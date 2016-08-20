using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetSaleSvc.Entity.Models;
using NetSaleSvc.Util;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public static class ModelMapper
    {
        /// <summary>
        /// 影厅信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ScreenInfoEntity MapToEntity(this DxQueryCinemaReplyItem model, ScreenInfoEntity entity)
        {
            entity.SCode = model.id;
            entity.SName = model.name;
            entity.SeatCount = model.seatNum;
            entity.Type = model.type;
            entity.UpdateTime = DateTime.Now;

            return entity;
        }

        /// <summary>
        /// 影厅座位信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ScreenSeatInfoEntity MapToEntity(this DxQuerySeatReplyItem model, ScreenSeatInfoEntity entity)
        {
            entity.SeatCode = model.cineSeatId;
            entity.GroupCode = model.loveseats;//把情侣座标示放到组号里用来标识情侣座
            entity.RowNum = model.row;
            entity.ColumnNum = model.column;
            entity.XCoord = model.xCoord;
            entity.YCoord = model.yCoord;
            entity.Status = model.status;
            entity.UpdateTime = DateTime.Now;

            return entity;
        }
    }
}
