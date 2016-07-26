using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Util;

namespace NetSaleSvc.Api.CTMS.NationalStandard.Models
{
    public static class ModelMapper
    {
        /// <summary>
        /// 影厅信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ScreenInfoEntity MapToEntity(this nsQueryCinemaReplyScreen model, ScreenInfoEntity entity)
        {
            entity.SCode = model.Code;
            entity.SName = model.Name;
            entity.SeatCount = model.SeatCount;
            entity.Type = model.Type;
            entity.UpdateTime = DateTime.Now;

            return entity;
        }

        /// <summary>
        /// 影厅座位信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ScreenSeatInfoEntity MapToEntity(this nsQuerySeatReplySeat model, ScreenSeatInfoEntity entity)
        {
            entity.SeatCode = model.Code;
            entity.GroupCode = model.GroupCode;
            entity.RowNum = model.RowNum;
            entity.ColumnNum = model.ColumnNum;
            entity.XCoord = model.XCoord;
            entity.YCoord = model.YCoord;
            entity.Status = model.Status;
            entity.UpdateTime = DateTime.Now;

            return entity;
        }

        /// <summary>
        /// 影片信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FilmInfoEntity MapToEntity(this nsQueryFilmReplyFilm model, FilmInfoEntity entity)
        {
            entity.FilmCode = model.Code;
            entity.FilmName = model.Name;
            entity.Version = model.Version;
            entity.Duration = model.Duration;

            DateTime PublishDate;
            if (DateTime.TryParse(model.PublishDate, out PublishDate))
            {
                entity.PublishDate = PublishDate;
            }
            else
            {
                entity.PublishDate = null;
            }
            entity.Publisher = model.Publisher;
            entity.Producer = model.Producer;
            entity.Director = model.Director;
            entity.Cast = model.Cast;
            entity.Introduction = model.Introduction;

            return entity;
        }

        /// <summary>
        /// 放映计划信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SessionInfoEntity MapToEntity(this nsQuerySessionReplySession model, SessionInfoEntity entity)
        {
            entity.ScreenCode = model.ScreenCode;
            entity.StartTime = DateTime.Parse(model.StartTime);

            var filmInfo = model.Films.Film.FirstOrDefault() ?? new nsQuerySessionReplyFilm();
            entity.FilmCode = filmInfo.Code;
            entity.FilmName = filmInfo.Name;
            entity.Duration = filmInfo.Duration;
            entity.Language = FilmCodeUtil.GetFilmLanguage(filmInfo.Code);
            entity.StandardPrice = model.Price.StandardPrice;
            entity.LowestPrice = model.Price.LowestPrice;
            entity.IsAvalible = true;
            entity.PlaythroughFlag = model.PlaythroughFlag;
            entity.Dimensional = FilmCodeUtil.GetFilmDimensional(filmInfo.Code);
            entity.Sequence = filmInfo.Sequence;

            return entity;
        }
    }
}
