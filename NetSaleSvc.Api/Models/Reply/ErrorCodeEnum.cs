using System.ComponentModel;
using System.Xml.Serialization;

namespace NetSaleSvc.Api.Models
{
    public enum ErrorCodeEnum : int
    {
        /// <summary>
        /// 异常
        /// </summary>
        [Description("本宝宝心情不好，出现了异常！（*+﹏+*）~~")]
        Exception = -1,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 0,

        /// <summary>
        /// 必要参数缺失
        /// </summary>
        [Description("参数缺失！")]
        NecessaryParamMiss = 10000001,

        /// <summary>
        /// 用户名/密码错误
        /// </summary>
        [Description("用户名或密码错误！")]
        UserCredentialInvalid = 10000002,

        /// <summary>
        /// 影院不存在或无权限访问
        /// </summary>
        [Description("影院不存在或无权限访问！")]
        CinemaInvalid = 10000003,

        /// <summary>
        /// 影厅不存在
        /// </summary>
        [Description("影厅不存在！")]
        ScreenInvalid = 10000004,

        /// <summary>
        /// 开始日期错误
        /// </summary>
        [Description("开始日期非法！")]
        StartDateInvalid = 10000005,

        /// <summary>
        /// 结束日期错误
        /// </summary>
        [Description("结束日期非法！")]
        EndDateInvalid = 10000006,

        /// <summary>
        /// 开始日期大于结束日期
        /// </summary>
        [Description("开始日期大于结束日期！")]
        DateInvalid = 10000007,

        /// <summary>
        /// 排期不存在
        /// </summary>
        [Description("排期不存在！")]
        SessionInvalid = 10000008,

        /// <summary>
        /// 排期座位状态不合法
        /// </summary>
        [Description("座位售出状态非法！合法取值包括：All，Available，Locked，Sold，Booked，Unavailable")]
        SessionSeatStatusInvalid = 10000009,

        /// <summary>
        /// XML解析失败
        /// </summary>
        [Description("解析失败")]
        XmlDeserializeFail = 10000010,

        /// <summary>
        /// 座位数量与实际座位不匹配
        /// </summary>
        [Description("座位数量与实际座位不匹配！")]
        SeatCountInvalid = 10000011,

        /// <summary>
        /// 订单不存在或状态不合法
        /// </summary>
        [Description("订单不存在或状态不合法！")]
        OrderNotExist = 10000012
    }
}
