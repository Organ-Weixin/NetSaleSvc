using System;
using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxQueryCinemaPlaysReply
    {
        public DxQueryCinemaPlaysReplyRes res { get; set; }
    }

    public class DxQueryCinemaPlaysReplyRes : DxBaseReplyRes
    {
        public List<DxQueryCinemaPlaysReplyPlay> data { get; set; }
    }

    public class DxQueryCinemaPlaysReplyPlay
    {
        /// <summary>
        /// 场次编号
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 影片信息
        /// </summary>
        public List<DxQueryCinemaPlaysReplyPlayMovie> movieInfo { get; set; }

        /// <summary>
        /// 影院场次ID
        /// </summary>
        public string cinePlayId { get; set; }

        /// <summary>
        /// 影院影厅编号
        /// </summary>
        public string hallId { get; set; }

        /// <summary>
        /// 影厅名字
        /// </summary>
        public string hallName { get; set; }

        /// <summary>
        /// 场次营业日
        /// </summary>
        public string businessDate { get; set; }

        /// <summary>
        /// 放映开始时间（年-月-日时:分:秒）
        /// </summary>
        public DateTime startTime { get; set; }

        /// <summary>
        /// 放映结束时间（年-月-日时:分:秒）
        /// </summary>
        public DateTime endTime { get; set; }

        /// <summary>
        /// 价格类型（1-正价 2-优惠场次）priceType==2说明marketPrice是优惠后的价格
        /// </summary>
        public string priceType { get; set; }

        /// <summary>
        /// 原价(名义价格，主要用于显示，可不用)
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// 售卖价格（影院柜台售卖价）
        /// </summary>
        public decimal marketPrice { get; set; }

        /// <summary>
        /// 限制能卖的最低价格
        /// </summary>
        public decimal lowestPrice { get; set; }

        /// <summary>
        /// 该场次的总座位数
        /// </summary>
        public int seatTotalNum { get; set; }

        /// <summary>
        /// 该场次的剩余可售座位数
        /// </summary>
        public int seatAvailableNum { get; set; }

        /// <summary>
        /// 该场次的座位是否可预订。0-不可预订，1-可预订
        /// </summary>
        public int allowBook { get; set; }

        /// <summary>
        /// 场次最后更新时间
        /// </summary>
        public string cineUpdateTime { get; set; }

        /// <summary>
        /// 电商平台启用算出的价格，如果该值不为空，则售卖价格需大于等于该价格，如果为空继续沿用当前售卖的规则，无需关心该字段
        /// </summary>
        public decimal? partnerPrice { get; set; }
    }

    public class DxQueryCinemaPlaysReplyPlayMovie
    {
        /// <summary>
        /// 影片id
        /// </summary>
        public string cineMovieId { get; set; }

        /// <summary>
        /// 广电总局规定的影片全国唯一编码
        /// </summary>
        public string cineMovieNum { get; set; }

        /// <summary>
        /// 影片名称
        /// </summary>
        public string movieName { get; set; }

        /// <summary>
        /// 字幕
        /// </summary>
        public string movieSubtitle { get; set; }

        /// <summary>
        /// 配音
        /// </summary>
        public string movieLanguage { get; set; }

        /// <summary>
        /// 电影格式(如：胶片，数字)
        /// </summary>
        public string movieFormat { get; set; }

        /// <summary>
        /// 影片放映类型（如：3D，2D）
        /// </summary>
        public string movieDimensional { get; set; }

        /// <summary>
        /// 屏幕尺寸（如：IMAX，普通）
        /// </summary>
        public string movieSize { get; set; }

        /// <summary>
        /// 该影片放映开始时间（年-月-日 时:分:秒）
        /// </summary>
        public string joinStartTime { get; set; }

        /// <summary>
        /// 该影片放映结束时间（年-月-日 时:分:秒）
        /// </summary>
        public string joinEndTime { get; set; }
    }
}
