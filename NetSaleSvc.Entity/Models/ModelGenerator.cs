// This file was automatically generated by the Dapper.SimpleCRUD T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `ModelGeneratorConnectionString`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=115.29.250.241;Initial Catalog=NetSaleSvc;User ID=sa;Password=80piao123`
//     Include Views:          `True`

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LambdaSqlBuilder;
using NetSaleSvc.Entity.Enum;

namespace NetSaleSvc.Entity.Models
{
    /// <summary>
    /// A class which represents the OrderSeatDetails table.
    /// </summary>
    [Table("OrderSeatDetails")]
    [SqlLamTable(Name = "OrderSeatDetails")]
    public partial class OrderSeatDetailEntity : EntityBase
    {
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>
        public virtual int OrderId { get; set; }
        /// <summary>
        /// 座位编码
        /// </summary>
        public virtual string SeatCode { get; set; }
        /// <summary>
        /// 行
        /// </summary>
        public virtual string RowNum { get; set; }
        /// <summary>
        /// 列
        /// </summary>
        public virtual string ColumnNum { get; set; }
        /// <summary>
        /// 上报票价
        /// </summary>
        public virtual decimal Price { get; set; }
        /// <summary>
        /// 接入商实际销售票价
        /// </summary>
        public virtual decimal SalePrice { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        public virtual decimal Fee { get; set; }
        /// <summary>
        /// 电影票编码
        /// </summary>
        public virtual string FilmTicketCode { get; set; }
        /// <summary>
        /// 电影票信息码（二维码内容）
        /// </summary>
        public virtual string TicketInfoCode { get; set; }
        /// <summary>
        /// 打印标识（0：未打印  1：已打印）
        /// </summary>
        public virtual byte? PrintFlag { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime Created { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime? Updated { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public virtual bool Deleted { get; set; }
    }

    /// <summary>
    /// A class which represents the Orders table.
    /// </summary>
    [Table("Orders")]
    [SqlLamTable(Name = "Orders")]
    public partial class OrderEntity : EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 影院编码
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 接入商Id
        /// </summary>
        public virtual int UserId { get; set; }
        /// <summary>
        /// 排期编码
        /// </summary>
        public virtual string SessionCode { get; set; }
        /// <summary>
        /// 影厅编码
        /// </summary>
        public virtual string ScreenCode { get; set; }
        /// <summary>
        /// 排期时间
        /// </summary>
        public virtual DateTime SessionTime { get; set; }
        /// <summary>
        /// 影片编码
        /// </summary>
        public virtual string FilmCode { get; set; }
        /// <summary>
        /// 影片名称
        /// </summary>
        public virtual string FilmName { get; set; }
        /// <summary>
        /// 影票数量
        /// </summary>
        public virtual int TicketCount { get; set; }
        /// <summary>
        /// 影票上报总价（不包含服务费）
        /// </summary>
        public virtual decimal TotalPrice { get; set; }
        /// <summary>
        /// 总服务费
        /// </summary>
        public virtual decimal TotalFee { get; set; }
        /// <summary>
        /// 接入商总售价
        /// </summary>
        public virtual decimal TotalSalePrice { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public virtual OrderStatusEnum OrderStatus { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string MobilePhone { get; set; }
        /// <summary>
        /// 锁座时间
        /// </summary>
        public virtual DateTime? LockTime { get; set; }
        /// <summary>
        /// 自动解锁时间
        /// </summary>
        public virtual DateTime? AutoUnlockDatetime { get; set; }
        /// <summary>
        /// 锁座订单号（主要用于13规范锁座返回的订单号并不是最终提交订单返回的订单号）
        /// </summary>
        public virtual string LockOrderCode { get; set; }
        /// <summary>
        /// 订单提交时间
        /// </summary>
        public virtual DateTime? SubmitTime { get; set; }
        /// <summary>
        /// 提交订单编号（即最终订单编号）
        /// </summary>
        public virtual string SubmitOrderCode { get; set; }
        /// <summary>
        /// 取票序号
        /// </summary>
        public virtual string PrintNo { get; set; }
        /// <summary>
        /// 取票验证码
        /// </summary>
        public virtual string VerifyCode { get; set; }
        /// <summary>
        /// 出票状态
        /// </summary>
        public virtual YesOrNoEnum? PrintStatus { get; set; }
        /// <summary>
        /// 出票时间
        /// </summary>
        public virtual DateTime? PrintTime { get; set; }
        /// <summary>
        /// 退票时间
        /// </summary>
        public virtual DateTime? RefundTime { get; set; }
        /// <summary>
        /// 订单创建时间
        /// </summary>
        public virtual DateTime Created { get; set; }
        /// <summary>
        /// 订单更新时间
        /// </summary>
        public virtual DateTime? Updated { get; set; }
        /// <summary>
        /// 订单删除标识
        /// </summary>
        public virtual bool Deleted { get; set; }
        /// <summary>
        /// 错误信息（锁座或提交订单失败错误信息）
        /// </summary>
        public virtual string ErrorMessage { get; set; }
        /// <summary>
        /// 供满天星和鼎新使用（满天星存储订单流水号，鼎新存储lockFlag）
        /// </summary>
        public virtual string SerialNum { get; set; }
        /// <summary>
        /// 标识订单是否使用会员卡支付
        /// </summary>
        public virtual bool IsMemberPay { get; set; }
        /// <summary>
        /// 满天星付费类型，其他系统一般为空
        /// </summary>
        public virtual string PayType { get; set; }
        /// <summary>
        /// 满天星取票密码（虽然现在根本没卵用，但先保存），其他系统一般为空
        /// </summary>
        public virtual string Printpassword { get; set; }
        /// <summary>
        /// 会员卡交易流水号
        /// </summary>
        public virtual string PaySeqNo { get; set; }
    }

    /// <summary>
    /// A class which represents the Middleware table.
    /// </summary>
    [Table("Middleware")]
    [SqlLamTable(Name = "Middleware")]
    public partial class MiddlewareEntity : EntityBase
    {
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 中间件名称
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// 中间件Url
        /// </summary>
        public virtual string Url { get; set; }
        /// <summary>
        /// 用户名或AppCode
        /// </summary>
        public virtual string UserName { get; set; }
        /// <summary>
        /// Password或VerifyInfo
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// 如果为空就搜索当前中间件下所有影院
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 1国标；2辰星；4鼎新；8满天星
        /// </summary>
        public virtual int Type { get; set; }
        /// <summary>
        /// 影院数
        /// </summary>
        public virtual int? CinemaCount { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public virtual int? IsDel { get; set; }
    }

    /// <summary>
    /// A class which represents the FilmInfo table.
    /// </summary>
    [Table("FilmInfo")]
    [SqlLamTable(Name = "FilmInfo")]
    public partial class FilmInfoEntity : EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 影片编码
        /// </summary>
        public virtual string FilmCode { get; set; }
        /// <summary>
        /// 影片名称
        /// </summary>
        public virtual string FilmName { get; set; }
        /// <summary>
        /// 发行版本
        /// </summary>
        public virtual string Version { get; set; }
        /// <summary>
        /// 影片时长
        /// </summary>
        public virtual string Duration { get; set; }
        /// <summary>
        /// 公映日期
        /// </summary>
        public virtual DateTime? PublishDate { get; set; }
        /// <summary>
        /// 发行商
        /// </summary>
        public virtual string Publisher { get; set; }
        /// <summary>
        /// 制作人
        /// </summary>
        public virtual string Producer { get; set; }
        /// <summary>
        /// 导演
        /// </summary>
        public virtual string Director { get; set; }
        /// <summary>
        /// 演员
        /// </summary>
        public virtual string Cast { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public virtual string Introduction { get; set; }
    }

    /// <summary>
    /// A class which represents the Cinema table.
    /// </summary>
    [Table("Cinema")]
    [SqlLamTable(Name = "Cinema")]
    public partial class CinemaEntity : EntityBase
    {
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 中间件ID
        /// </summary>
        public virtual int MId { get; set; }
        /// <summary>
        /// 影院编码
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 影院名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 影院地址
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 影厅数量
        /// </summary>
        public virtual int? ScreenCount { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public virtual int? IsDel { get; set; }
        /// <summary>
        /// 是否人工加入的影院
        /// </summary>
        public virtual int? ManualAdd { get; set; }
        /// <summary>
        /// 鼎新系统影院Id，其他系统忽略
        /// </summary>
        public virtual int? DingXinId { get; set; }
    }

    /// <summary>
    /// A class which represents the UserInfo table.
    /// </summary>
    [Table("UserInfo")]
    [SqlLamTable(Name = "UserInfo")]
    public partial class UserInfoEntity : EntityBase
    {
        /// <summary>
        /// 用户ID，新建自动加1
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public virtual string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// 公司名
        /// </summary>
        public virtual string Company { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string Tel { get; set; }
        /// <summary>
        /// 预付款，分为单位
        /// </summary>
        public virtual int? Advance { get; set; }
        /// <summary>
        /// 0有效；1已删除
        /// </summary>
        public virtual int? IsDel { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual DateTime? BeginDate { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual DateTime? EndDate { get; set; }
    }

    /// <summary>
    /// A class which represents the UserCinemaView view.
    /// </summary>
    [Table("UserCinemaView")]
    [SqlLamTable(Name = "UserCinemaView")]
    public partial class UserCinemaViewEntity : EntityBase
    {
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int UserId { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual DateTime? ExpDate { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string UserName { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string PayType { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string CinemaName { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string CinemaAddress { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int? DingXinId { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual CinemaTypeEnum CinemaType { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string Url { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string DefaultUserName { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string DefaultPassword { get; set; }
    }

    /// <summary>
    /// A class which represents the CinemaView view.
    /// </summary>
    [Table("CinemaView")]
    [SqlLamTable(Name = "CinemaView")]
    public partial class CinemaViewEntity : EntityBase
    {
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int MId { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int? ScreenCount { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int? IsDel { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int? ManualAdd { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int? DingXinId { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual CinemaTypeEnum CinemaType { get; set; }
    }

    /// <summary>
    /// A class which represents the SessionInfo table.
    /// </summary>
    [Table("SessionInfo")]
    [SqlLamTable(Name = "SessionInfo")]
    public partial class SessionInfoEntity : EntityBase
    {
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string CCode { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string SCode { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string ScreenCode { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual DateTime StartTime { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string FilmCode { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string FilmName { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int? Duration { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string Language { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual decimal StandardPrice { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual decimal LowestPrice { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual bool? IsAvalible { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string PlaythroughFlag { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string Dimensional { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int Sequence { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int? UserID { get; set; }
        /// <summary>
        /// 鼎新场次最后更新时间，其他系统忽略
        /// </summary>
        public virtual string DingXinUpdateTime { get; set; }
        /// <summary>
        /// 辰星门市价（应用于会员卡接口），其他系统忽略
        /// </summary>
        public virtual decimal? ListingPrice { get; set; }
        /// <summary>
        /// 满天星排期号（应用于会员卡接口），其他系统忽略
        /// </summary>
        public virtual string FeatureNo { get; set; }
    }

    /// <summary>
    /// A class which represents the ScreenSeatInfo table.
    /// </summary>
    [Table("ScreenSeatInfo")]
    [SqlLamTable(Name = "ScreenSeatInfo")]
    public partial class ScreenSeatInfoEntity : EntityBase
    {
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 影院编码
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 影厅编号
        /// </summary>
        public virtual string ScreenCode { get; set; }
        /// <summary>
        /// 座位编号
        /// </summary>
        public virtual string SeatCode { get; set; }
        /// <summary>
        /// 组号
        /// </summary>
        public virtual string GroupCode { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public virtual string RowNum { get; set; }
        /// <summary>
        /// 列号
        /// </summary>
        public virtual string ColumnNum { get; set; }
        /// <summary>
        /// 座位X坐标
        /// </summary>
        public virtual int XCoord { get; set; }
        /// <summary>
        /// 座位Y坐标
        /// </summary>
        public virtual int YCoord { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual string Status { get; set; }
        /// <summary>
        /// 是否情侣座
        /// </summary>
        public virtual string LoveFlag { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// A class which represents the ScreenInfo table.
    /// </summary>
    [Table("ScreenInfo")]
    [SqlLamTable(Name = "ScreenInfo")]
    public partial class ScreenInfoEntity : EntityBase
    {
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 影院编码
        /// </summary>
        public virtual string CCode { get; set; }
        /// <summary>
        /// 影厅编号
        /// </summary>
        public virtual string SCode { get; set; }
        /// <summary>
        /// 影厅名称
        /// </summary>
        public virtual string SName { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 座位数
        /// </summary>
        public virtual int? SeatCount { get; set; }
        /// <summary>
        /// 影厅类型
        /// </summary>
        public virtual string Type { get; set; }
    }

    /// <summary>
    /// A class which represents the User_Cinema table.
    /// </summary>
    [Table("User_Cinema")]
    [SqlLamTable(Name = "User_Cinema")]
    public partial class UserCinemaEntity : EntityBase
    {
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int UserId { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 用户名用于中间件访问，如果为空则用中间件自带的
        /// </summary>
        public virtual string UserName { get; set; }
        /// <summary>
        /// 用于中间件访问，如果为空则用中间件自带的
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// 每张票平台收取费用，从预付款里扣
        /// </summary>
        public virtual int? Fee { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int? CinemaFee { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual string PayType { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual int? RealPrice { get; set; }
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        public virtual DateTime? ExpDate { get; set; }
    }

    /// <summary>
    /// A class which represents the PricePlan table.
    /// </summary>
    [Table("PricePlan")]
    [SqlLamTable(Name = "PricePlan")]
    public partial class PricePlanEntity : EntityBase
    {
        /// <summary>
        /// 日了狗了，注释都不写？
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 影院编码
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 影片编号／排期编号
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 摘入商ID
        /// </summary>
        public virtual int UserID { get; set; }
        /// <summary>
        /// 类型，影片／排期
        /// </summary>
        public virtual string Type { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public virtual decimal Price { get; set; }
    }

}
