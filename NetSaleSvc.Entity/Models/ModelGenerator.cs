// This file was automatically generated by the Dapper.SimpleCRUD T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `ModelGeneratorConnectionString`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=121.41.73.199;Initial Catalog=WeiXin;User ID=sa;Password=80piao123`
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
        /// 程序猿只想做个安静的美男子，不想写注释
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
    /// A class which represents the SysUser table.
    /// </summary>
    [Table("SysUser")]
    [SqlLamTable(Name = "SysUser")]
    public partial class SysUserEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string UserName { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Type { get; set; }
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
        /// 程序猿只想做个安静的美男子，不想写注释
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
    }

    /// <summary>
    /// A class which represents the Middleware table.
    /// </summary>
    [Table("Middleware")]
    [SqlLamTable(Name = "Middleware")]
    public partial class MiddlewareEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
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
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? IsDel { get; set; }
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
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? BeginDate { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? EndDate { get; set; }
    }

    /// <summary>
    /// A class which represents the Ticket table.
    /// </summary>
    [Table("Ticket")]
    [SqlLamTable(Name = "Ticket")]
    public partial class TicketEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? UserId { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Count { get; set; }
        /// <summary>
        /// 总费用
        /// </summary>
        public virtual int? Fee { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? Time { get; set; }
    }

    /// <summary>
    /// A class which represents the log_Function table.
    /// </summary>
    [Table("log_Function")]
    [SqlLamTable(Name = "log_Function")]
    public partial class logFunctionEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? UserId { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Func { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Msg { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Time { get; set; }
    }

    /// <summary>
    /// A class which represents the log_Advance table.
    /// </summary>
    [Table("log_Advance")]
    [SqlLamTable(Name = "log_Advance")]
    public partial class logAdvanceEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? SysUserId { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? UserId { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Amount { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? Time { get; set; }
    }

    /// <summary>
    /// A class which represents the Cinema table.
    /// </summary>
    [Table("Cinema")]
    [SqlLamTable(Name = "Cinema")]
    public partial class CinemaEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 中间件ID
        /// </summary>
        public virtual int? MId { get; set; }
        /// <summary>
        /// 影院编码
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? ScreenCount { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? IsDel { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? ManualAdd { get; set; }
    }

    /// <summary>
    /// A class which represents the Order_Seat table.
    /// </summary>
    [Table("Order_Seat")]
    [SqlLamTable(Name = "Order_Seat")]
    public partial class OrderSeatEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? OrderID { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SeatCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string FilmTicketCode { get; set; }
    }

    /// <summary>
    /// A class which represents the DXCodeID table.
    /// </summary>
    [Table("DXCodeID")]
    [SqlLamTable(Name = "DXCodeID")]
    public partial class DXCodeIDEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Code { get; set; }
    }

    /// <summary>
    /// A class which represents the OrderInfo table.
    /// </summary>
    [Table("OrderInfo")]
    [SqlLamTable(Name = "OrderInfo")]
    public partial class OrderInfoEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 接入商ID
        /// </summary>
        public virtual int? UserId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public virtual string OrderCode { get; set; }
        /// <summary>
        /// 影院编码
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 场次编码
        /// </summary>
        public virtual string SessionCode { get; set; }
        /// <summary>
        /// 取票序号
        /// </summary>
        public virtual string PrintNo { get; set; }
        /// <summary>
        /// 取票验证码
        /// </summary>
        public virtual string VerifyCode { get; set; }
        /// <summary>
        /// 状态1:订票成功；0退票成功；
        /// </summary>
        public virtual int? Status { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public virtual DateTime? SubmitTime { get; set; }
        /// <summary>
        /// 退票时间
        /// </summary>
        public virtual DateTime? RefundTime { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SubmitXml { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string RefundXml { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? SeatCount { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Fee { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SubmitQueryXml { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Amount { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? RealAmount { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string FilmName { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string QueryOrderReplyXml { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? QueryOrderTime { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string MobilePhone { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string PaySeqNo { get; set; }
    }

    /// <summary>
    /// A class which represents the LockSeatInfo table.
    /// </summary>
    [Table("LockSeatInfo")]
    [SqlLamTable(Name = "LockSeatInfo")]
    public partial class LockSeatInfoEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? UserId { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SessionCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string OrderCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SeatXml { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? VTime { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? IsLock { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SerialNum { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Paid { get; set; }
    }

    /// <summary>
    /// A class which represents the ScreenInfo table.
    /// </summary>
    [Table("ScreenInfo")]
    [SqlLamTable(Name = "ScreenInfo")]
    public partial class ScreenInfoEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SName { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? SeatCount { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
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
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int UserId { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
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
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? CinemaFee { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string PayType { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? RealPrice { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? ExpDate { get; set; }
    }

    /// <summary>
    /// A class which represents the ComboInfo table.
    /// </summary>
    [Table("ComboInfo")]
    [SqlLamTable(Name = "ComboInfo")]
    public partial class ComboInfoEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Stock { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? EndDate { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? OPrice { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? SPrice { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string ImgExt { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Del { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Recommend { get; set; }
    }

    /// <summary>
    /// A class which represents the LSOrderCode table.
    /// </summary>
    [Table("LSOrderCode")]
    [SqlLamTable(Name = "LSOrderCode")]
    public partial class LSOrderCodeEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string LOrderCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SOrderCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? tm { get; set; }
    }

    /// <summary>
    /// A class which represents the PrintInfo table.
    /// </summary>
    [Table("PrintInfo")]
    [SqlLamTable(Name = "PrintInfo")]
    public partial class PrintInfoEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string PrintNo { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? Tm { get; set; }
    }

    /// <summary>
    /// A class which represents the SessionInfo table.
    /// </summary>
    [Table("SessionInfo")]
    [SqlLamTable(Name = "SessionInfo")]
    public partial class SessionInfoEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string ScreenCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime StartTime { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string FilmCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string FilmName { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Duration { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Language { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual decimal StandardPrice { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual decimal LowestPrice { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual bool? IsAvalible { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string PlaythroughFlag { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Dimensional { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Sequence { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? UserID { get; set; }
    }

    /// <summary>
    /// A class which represents the PricePlan table.
    /// </summary>
    [Table("PricePlan")]
    [SqlLamTable(Name = "PricePlan")]
    public partial class PricePlanEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int UserID { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Type { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual decimal Price { get; set; }
    }

    /// <summary>
    /// A class which represents the ComboOrder table.
    /// </summary>
    [Table("ComboOrder")]
    [SqlLamTable(Name = "ComboOrder")]
    public partial class ComboOrderEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// CinemaCode
        /// </summary>
        public virtual string CCode { get; set; }
        /// <summary>
        /// OrderCode
        /// </summary>
        public virtual string OCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? TCId { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Cnt { get; set; }
        /// <summary>
        /// 当时销售价格
        /// </summary>
        public virtual int? SPrice { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? Tm { get; set; }
    }

    /// <summary>
    /// A class which represents the Cinema_Pwd table.
    /// </summary>
    [Table("Cinema_Pwd")]
    [SqlLamTable(Name = "Cinema_Pwd")]
    public partial class CinemaPwdEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Pwd { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? CTime { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? VTime { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? Opened { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string alp_partner { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string alp_seller_email { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string alp_key { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string wxp_appid { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string wxp_mchid { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string wxp_key { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string ftip { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string ftport { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string ftname { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string ftpwd { get; set; }
    }

    /// <summary>
    /// A class which represents the ScreenSeatInfo table.
    /// </summary>
    [Table("ScreenSeatInfo")]
    [SqlLamTable(Name = "ScreenSeatInfo")]
    public partial class ScreenSeatInfoEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string ScreenCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SeatCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string GroupCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string RowNum { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string ColumnNum { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int XCoord { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int YCoord { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Status { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string LoveFlag { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// A class which represents the UserCinemaView view.
    /// </summary>
    [Table("UserCinemaView")]
    [SqlLamTable(Name = "UserCinemaView")]
    public partial class UserCinemaViewEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int UserId { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? ExpDate { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string UserName { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string PayType { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaName { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaAddress { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual CinemaTypeEnum CinemaType { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Url { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string DefaultUserName { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
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
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? MId { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? ScreenCount { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? IsDel { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual int? ManualAdd { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual CinemaTypeEnum CinemaType { get; set; }
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
    /// A class which represents the DXSessionUpdateTime table.
    /// </summary>
    [Table("DXSessionUpdateTime")]
    [SqlLamTable(Name = "DXSessionUpdateTime")]
    public partial class DXSessionUpdateTimeEntity : EntityBase
    {
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string CinemaCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual string SessionCode { get; set; }
        /// <summary>
        /// 程序猿只想做个安静的美男子，不想写注释
        /// </summary>
        public virtual DateTime? UpdateTime { get; set; }
    }

}
