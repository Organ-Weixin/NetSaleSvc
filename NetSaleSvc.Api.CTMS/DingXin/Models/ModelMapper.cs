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
        public static ScreenInfoEntity MapToEntity(this DxQueryCinemaHallsReplyHall model, ScreenInfoEntity entity)
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
        public static ScreenSeatInfoEntity MapToEntity(this DxQueryHallSeatsReplySeat model, ScreenSeatInfoEntity entity)
        {
            entity.SeatCode = model.cineSeatId;
            entity.GroupCode = model.loveseats;//把情侣座标示放到组号里用来标识情侣座
            entity.RowNum = model.row;
            entity.ColumnNum = model.column;
            entity.XCoord = model.yCoord;
            entity.YCoord = model.xCoord;
            entity.Status = model.status == "ok" ? "Available" : "Unavailable";
            entity.UpdateTime = DateTime.Now;

            return entity;
        }

        /// <summary>
        /// 放映计划信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SessionInfoEntity MapToEntity(this DxQueryCinemaPlaysReplyPlay model, SessionInfoEntity entity)
        {
            entity.ScreenCode = model.hallId;
            entity.StartTime = model.startTime;

            var movie = model.movieInfo.FirstOrDefault() ?? new DxQueryCinemaPlaysReplyPlayMovie();
            entity.FilmCode = movie.cineMovieNum;
            entity.FilmName = movie.movieName;

            entity.Duration = (int)(model.endTime - entity.StartTime).TotalMinutes;
            entity.Language = movie.movieLanguage;
            entity.StandardPrice = model.partnerPrice ?? model.lowestPrice;
            entity.LowestPrice = model.lowestPrice;
            entity.IsAvalible = true;
            entity.PlaythroughFlag = "No";
            entity.Dimensional = movie.movieDimensional;
            entity.Sequence = 1;
            entity.DingXinUpdateTime = model.cineUpdateTime;

            return entity;
        }
    }
}
