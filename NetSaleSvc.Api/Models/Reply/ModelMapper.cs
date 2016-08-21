using System;
using System.Linq;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Util;
using NetSaleSvc.Entity.Enum;

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
            session.FeatureNo = entity.sessionInfo.FeatureNo;
            session.StartTime = entity.sessionInfo.StartTime.ToFormatStringWithT();
            session.PlaythroughFlag = entity.sessionInfo.PlaythroughFlag;

            session.Films = new QuerySessionReplyFilms();
            QuerySessionReplyFilm film = new QuerySessionReplyFilm();
            film.Code = entity.sessionInfo.FilmCode;
            film.Name = entity.sessionInfo.FilmName;
            film.Dimensional = entity.sessionInfo.Dimensional;
            film.Duration = entity.sessionInfo.Duration.HasValue ? entity.sessionInfo.Duration.Value.ToString() : string.Empty;
            film.Sequence = entity.sessionInfo.Sequence.ToString();
            film.Language = entity.sessionInfo.Language;
            session.Films.Film.Add(film);

            session.Price = new QuerySessionReplyPrice();
            session.Price.StandardPrice = entity.RealStandardPrice;
            session.Price.LowestPrice = entity.RealLowestPrice;
            session.Price.ListingPrice = entity.sessionInfo.ListingPrice?.ToString("0.##");

            return session;
        }

        /// <summary>
        /// map
        /// </summary>
        /// <param name="order"></param>
        /// <param name="userCinema"></param>
        /// <param name="queryXmlObj"></param>
        /// <returns></returns>
        public static OrderViewEntity MapFrom(this OrderViewEntity order, UserCinemaViewEntity userCinema,
            LockSeatQueryXml queryXmlObj, SessionInfoEntity sessionInfo)
        {
            //订单基本信息
            OrderEntity orderBaseInfo = new OrderEntity();
            orderBaseInfo.CinemaCode = userCinema.CinemaCode;
            orderBaseInfo.UserId = userCinema.UserId;
            orderBaseInfo.SessionCode = sessionInfo.SCode;
            orderBaseInfo.ScreenCode = sessionInfo.ScreenCode;
            orderBaseInfo.SessionTime = sessionInfo.StartTime;
            orderBaseInfo.FilmCode = sessionInfo.FilmCode;
            orderBaseInfo.FilmName = sessionInfo.FilmName;
            orderBaseInfo.TicketCount = queryXmlObj.Order.Count;
            orderBaseInfo.TotalPrice = queryXmlObj.Order.Seat.Sum(x => x.Price);
            orderBaseInfo.TotalFee = queryXmlObj.Order.Seat.Sum(x => x.Fee);
            orderBaseInfo.OrderStatus = OrderStatusEnum.Created;
            orderBaseInfo.Created = DateTime.Now;

            if (userCinema.CinemaType == CinemaTypeEnum.ManTianXing)
            {
                //数据库中会员及非会员支付类型以逗号分隔存于PayType字段中，会员在前
                if (queryXmlObj.Order.PayType == "1")
                {
                    orderBaseInfo.IsMemberPay = true;
                    orderBaseInfo.PayType = userCinema.PayType.Split(',')?.First();
                }
                else
                {
                    orderBaseInfo.IsMemberPay = false;
                    orderBaseInfo.PayType = userCinema.PayType.Split(',')?.Last();
                }
            }
            order.orderBaseInfo = orderBaseInfo;

            order.orderSeatDetails = queryXmlObj.Order.Seat.Select(
                x => new OrderSeatDetailEntity()
                {
                    SeatCode = x.SeatCode,
                    Price = x.Price,
                    Fee = x.Fee,
                    Created = DateTime.Now
                }).ToList();

            return order;
        }

        /// <summary>
        /// map
        /// </summary>
        /// <param name="order"></param>
        /// <param name="queryXmlObj"></param>
        public static OrderViewEntity MapFrom(this OrderViewEntity order, SubmitOrderQueryXml queryXmlObj)
        {
            order.orderBaseInfo.TotalPrice = queryXmlObj.Order.Seat.Sum(x => x.Price);
            order.orderBaseInfo.TotalSalePrice = queryXmlObj.Order.Seat.Sum(x => x.RealPrice);
            order.orderBaseInfo.TotalFee = queryXmlObj.Order.Seat.Sum(x => x.Fee);
            order.orderBaseInfo.MobilePhone = queryXmlObj.Order.MobilePhone;
            order.orderBaseInfo.PaySeqNo = queryXmlObj.Order.PaySeqNo;

            order.orderSeatDetails.ForEach(x =>
            {
                var newInfo = queryXmlObj.Order.Seat.Where(y => y.SeatCode == x.SeatCode).SingleOrDefault();
                if (newInfo != null)
                {
                    x.Price = newInfo.Price;
                    x.SalePrice = newInfo.RealPrice;
                    x.Fee = newInfo.Fee;
                }
            });

            return order;
        }
    }
}
