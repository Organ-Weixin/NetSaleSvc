using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSaleSvc.Api.CTMS.ManTianXing.Models
{
    public static class ModelMapper
    {
        /// <summary>
        /// 影厅信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ScreenInfoEntity MapToEntity(this mtxGetHallResultHall model, ScreenInfoEntity entity)
        {
            entity.SCode = model.HallNo;
            entity.SName = model.HallName;
            entity.UpdateTime = DateTime.Now;

            return entity;
        }

        /// <summary>
        /// 影厅座位信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ScreenSeatInfoEntity MapToEntity(this mtxGetHallAllSeatHallSeat model, ScreenSeatInfoEntity entity)
        {
            entity.SeatCode = model.SeatNo;
            entity.GroupCode = model.SeatPieceNo;
            entity.RowNum = model.SeatRow;
            entity.ColumnNum = model.SeatCol;
            entity.XCoord = model.GraphCol;
            entity.YCoord = model.GraphRow;
            entity.Status = "Available";

            //情侣座标识（还未确定，需要确认）
            if (model.leftCount > 0)
            {
                entity.LoveFlag = LoveFlagEnum.RIGHT.GetDescription();
            }
            if (model.rightCount > 0)
            {
                entity.LoveFlag = LoveFlagEnum.LEFT.GetDescription();
            }
            entity.UpdateTime = DateTime.Now;

            return entity;
        }

        /// <summary>
        /// 放映计划信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SessionInfoEntity MapToEntity(this mtxGetCinemaPlanResultCinemaPlan model, SessionInfoEntity entity)
        {
            entity.ScreenCode = model.HallNo;
            entity.StartTime = DateTime.Parse($"{model.FeatureDate} {model.FeatureTime}");
            entity.FilmCode = model.FilmNo;
            entity.FilmName = model.FilmName;

            DateTime endTime = DateTime.Parse($"{model.FeatureDate} {model.TotalTime}");
            if (endTime < entity.StartTime)
            {
                endTime = endTime.AddDays(1);
            }
            entity.Duration = (int)(endTime - entity.StartTime).TotalMinutes;
            entity.Language = model.CopyLanguage;
            entity.StandardPrice = model.StandPric;
            entity.LowestPrice = model.ProtectPrice;
            entity.IsAvalible = true;
            entity.PlaythroughFlag = "No";
            entity.Dimensional = model.CopyType;
            entity.Sequence = 1;

            return entity;
        }
    }
}
