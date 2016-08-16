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

        /// <summary>
        /// 影厅座位信息转为entity
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ScreenSeatInfoEntity MapToEntity(this CxQuerySeatInfoResultScreenSite model, ScreenSeatInfoEntity entity)
        {
            entity.SeatCode = model.SeatCode;
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
        public static FilmInfoEntity MapToEntity(this CxQueryFilmInfoResultFilmInfoVO model, FilmInfoEntity entity)
        {
            entity.FilmCode = model.FilmCode;
            entity.FilmName = model.FilmName;
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
    }
}
