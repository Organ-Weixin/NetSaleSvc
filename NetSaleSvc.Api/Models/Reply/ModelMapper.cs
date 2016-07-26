using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Util;

namespace NetSaleSvc.Api.Models
{
    public static class ModelMapper
    {
        /// <summary>
        /// map
        /// </summary>
        /// <param name="cinema"></param>
        /// <param name="userCinema"></param>
        /// <returns></returns>
        public static QueryCinemaListReplyCinema MapFrom(this QueryCinemaListReplyCinema cinema, UserCinemaViewEntity userCinema)
        {
            cinema.Code = userCinema.CinemaCode;
            cinema.Name = userCinema.CinemaName;
            cinema.Address = userCinema.CinemaAddress;
            cinema.Type = userCinema.CinemaType;

            return cinema;
        }

        /// <summary>
        /// map
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="screenInfo"></param>
        /// <returns></returns>
        public static QueryCinemaReplyScreen MapFrom(this QueryCinemaReplyScreen screen, ScreenInfoEntity screenInfo)
        {
            screen.Code = screenInfo.SCode;
            screen.Name = screenInfo.SName;
            screen.SeatCount = screenInfo.SeatCount.GetValueOrDefault(0);
            screen.Type = screenInfo.Type ?? string.Empty;

            return screen;
        }

        /// <summary>
        /// map
        /// </summary>
        /// <param name="seat"></param>
        /// <param name="seatInfo"></param>
        /// <returns></returns>
        public static QuerySeatReplySeat MapFrom(this QuerySeatReplySeat seat, ScreenSeatInfoEntity seatInfo)
        {
            seat.Code = seatInfo.SeatCode;
            seat.GroupCode = seatInfo.GroupCode;
            seat.RowNum = seatInfo.RowNum;
            seat.ColumnNum = seatInfo.ColumnNum;
            seat.XCoord = seatInfo.XCoord;
            seat.YCoord = seatInfo.YCoord;
            seat.Status = seatInfo.Status;
            seat.LoveFlag = seatInfo.LoveFlag;

            return seat;
        }

        /// <summary>
        /// map
        /// </summary>
        /// <param name="film"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static QueryFilmReplyFilm MapFrom(this QueryFilmReplyFilm film, FilmInfoEntity entity)
        {
            film.Code = entity.FilmCode;
            film.Name = entity.FilmName;
            film.Version = entity.Version;
            film.Duration = entity.Duration;
            film.PublishDate = entity.PublishDate.ToFormatDateString();
            film.Publisher = entity.Publisher;
            film.Producer = entity.Producer;
            film.Director = entity.Director;
            film.Cast = entity.Cast;
            film.Introduction = entity.Introduction;

            return film;
        }

        /// <summary>
        /// map
        /// </summary>
        /// <param name="session"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static QuerySessionReplySession MapFrom(this QuerySessionReplySession session, SessionInfoWithCustomPrice entity)
        {
            session.ScreenCode = entity.sessionInfo.ScreenCode;
            session.Code = entity.sessionInfo.SCode;
            session.StartTime = entity.sessionInfo.StartTime.ToFormatStringWithT();
            session.PlaythroughFlag = entity.sessionInfo.PlaythroughFlag;

            session.Films = new QuerySessionReplyFilms();
            QuerySessionReplyFilm film = new QuerySessionReplyFilm();
            film.Code = entity.sessionInfo.FilmCode;
            film.Name = entity.sessionInfo.FilmName;
            film.Dimensional = entity.sessionInfo.Dimensional;
            film.Duration = entity.sessionInfo.Duration.HasValue ? entity.sessionInfo.Duration.Value.ToString() : string.Empty;
            film.Sequence = entity.sessionInfo.Sequence;
            film.Language = entity.sessionInfo.Language;
            session.Films.Film.Add(film);

            session.Price = new QuerySessionReplyPrice();
            session.Price.StandardPrice = entity.RealStandardPrice;
            session.Price.LowestPrice = entity.RealLowestPrice;

            return session;
        }
    }
}
