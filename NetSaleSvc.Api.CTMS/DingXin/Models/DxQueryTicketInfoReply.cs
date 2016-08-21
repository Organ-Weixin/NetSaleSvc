using System;
using System.Collections.Generic;

namespace NetSaleSvc.Api.CTMS.DingXin.Models
{
    public class DxQueryTicketInfoReply
    {
        public DxQueryTicketInfoReplyRes res { get; set; }
    }

    public class DxQueryTicketInfoReplyRes : DxBaseReplyRes
    {
        public DxQueryTicketInfoReplyData data { get; set; }
    }

    public class DxQueryTicketInfoReplyData
    {
        /// <summary>
        /// 影片信息
        /// </summary>
        public List<DxQueryTicketInfoReplyMovieInfo> movieInfo { get; set; }

        /// <summary>
        /// 放映开始时间（年-月-日时:分:秒）
        /// </summary>
        public string startTime { get; set; }

        /// <summary>
        /// 放映结束时间（年-月-日时:分:秒）
        /// </summary>
        public string endTime { get; set; }

        /// <summary>
        /// 放映影厅
        /// </summary>
        public string hallName { get; set; }

        /// <summary>
        /// 影院名称
        /// </summary>
        public string cinemaName { get; set; }

        /// <summary>
        /// 影票信息
        /// </summary>
        public List<DxQueryTicketInfoReplyTicketInfo> ticketInfo { get; set; }
    }

    public class DxQueryTicketInfoReplyMovieInfo
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
    }

    public class DxQueryTicketInfoReplyTicketInfo
    {
        /// <summary>
        /// 票号
        /// </summary>
        public string no { get; set; }

        /// <summary>
        /// 1 - 已出票，0 –未出票
        /// </summary>
        public string printed { get; set; }

        /// <summary>
        /// 出票时间
        /// </summary>
        public string printTime { get; set; }

        /// <summary>
        /// 座位排号
        /// </summary>
        public string row { get; set; }

        /// <summary>
        /// 座位列号
        /// </summary>
        public string column { get; set; }

        /// <summary>
        /// 影票类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 票价
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// 1：未出票，2:已出票，3：已退票(此状态时不能出票)
        /// </summary>
        public int ticketStatus { get; set; }

        /// <summary>
        /// 二维码字符串
        /// </summary>
        public string qrCode { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal handleFee { get; set; }
    }
}
