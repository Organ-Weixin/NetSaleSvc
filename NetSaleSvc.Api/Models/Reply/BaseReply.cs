using NetSaleSvc.Entity.Enum;
using System.Xml.Serialization;
using NetSaleSvc.Util;
using NetSaleSvc.Api.CTMS.Models;

namespace NetSaleSvc.Api.Models
{
    /// <summary>
    /// Reply基类
    /// </summary>
    public class BaseReply
    {
        #region static reply Id
        /// <summary>
        /// 查询影院列表接口Id
        /// </summary>
        public static string ID_QueryCinemaListReply = nameof(ID_QueryCinemaListReply);
        /// <summary>
        /// 查询影院信息接口Id
        /// </summary>
        public static string ID_QueryCinemaReply = nameof(ID_QueryCinemaReply);
        /// <summary>
        /// 查询影院影厅信息接口Id
        /// </summary>
        public static string ID_QuerySeatReply = nameof(ID_QuerySeatReply);
        /// <summary>
        /// 查询影片信息接口Id
        /// </summary>
        public static string ID_QueryFilmReply = nameof(ID_QueryFilmReply);
        /// <summary>
        /// 查询排期接口Id
        /// </summary>
        public static string ID_QuerySessionReply = nameof(ID_QuerySessionReply);
        /// <summary>
        /// 查询排期座位状态接口Id
        /// </summary>
        public static string ID_QuerySessionSeatReply = nameof(ID_QuerySessionSeatReply);
        /// <summary>
        /// 锁座接口Id
        /// </summary>
        public static string ID_LockSeatReply = nameof(ID_LockSeatReply);
        /// <summary>
        /// 解锁接口Id
        /// </summary>
        public static string ID_ReleaseSeatReply = nameof(ID_ReleaseSeatReply);
        /// <summary>
        /// 提交订单接口Id
        /// </summary>
        public static string ID_SubmitOrderReply = nameof(ID_SubmitOrderReply);
        /// <summary>
        /// 退票接口Id
        /// </summary>
        public static string ID_RefundTicketReply = nameof(ID_RefundTicketReply);
        /// <summary>
        /// 查询影票打印状态接口Id
        /// </summary>
        public static string ID_QueryPrintReply = nameof(ID_QueryPrintReply);
        /// <summary>
        /// 查询订单接口Id
        /// </summary>
        public static string ID_QueryOrderReply = nameof(ID_QueryOrderReply);

        #endregion

        #region ctor
        public BaseReply()
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.Exception.GetValueString();
            ErrorMessage = ErrorCodeEnum.Exception.GetDescription();
        }
        #endregion

        #region public methods
        /// <summary>
        /// 从影院票务系统返回中获取错误信息
        /// </summary>
        /// <param name="CTMSReply"></param>
        public void GetErrorFromCTMSReply(CTMSBaseReply CTMSReply)
        {
            Status = CTMSReply.Status.GetDescription();
            ErrorCode = CTMSReply.ErrorCode;
            ErrorMessage = CTMSReply.ErrorMessage;
        }

        /// <summary>
        /// 成功返回
        /// </summary>
        public void SetSuccessReply()
        {
            Status = StatusEnum.Success.GetDescription();
            ErrorCode = ErrorCodeEnum.Success.GetValueString();
            ErrorMessage = ErrorCodeEnum.Success.GetDescription();
        }

        /// <summary>
        /// 参数缺失返回内容
        /// </summary>
        public void SetNecessaryParamMissReply(string ParamName)
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.NecessaryParamMiss.GetValueString();
            ErrorMessage = $"{ParamName}{ErrorCodeEnum.NecessaryParamMiss.GetDescription()}";
        }

        /// <summary>
        /// 设置用户名/密码错误时的返回内容
        /// </summary>
        public void SetUserCredentialInvalidReply()
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.UserCredentialInvalid.GetValueString();
            ErrorMessage = ErrorCodeEnum.UserCredentialInvalid.GetDescription();
        }

        /// <summary>
        /// 影院不存在或不可访问
        /// </summary>
        public void SetCinemaInvalidReply()
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.CinemaInvalid.GetValueString();
            ErrorMessage = ErrorCodeEnum.CinemaInvalid.GetDescription();
        }

        /// <summary>
        /// 影厅编码错误
        /// </summary>
        public void SetScreenInvalidReply()
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.ScreenInvalid.GetValueString();
            ErrorMessage = ErrorCodeEnum.ScreenInvalid.GetDescription();
        }

        /// <summary>
        /// 开始日期错误
        /// </summary>
        public void SetStartDateInvalidReply()
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.StartDateInvalid.GetValueString();
            ErrorMessage = ErrorCodeEnum.StartDateInvalid.GetDescription();
        }

        /// <summary>
        /// 结束日期错误
        /// </summary>
        public void SetEndDateInvalidReply()
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.EndDateInvalid.GetValueString();
            ErrorMessage = ErrorCodeEnum.EndDateInvalid.GetDescription();
        }

        /// <summary>
        /// 开始日期大于结束日期
        /// </summary>
        public void SetDateInvalidReply()
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.DateInvalid.GetValueString();
            ErrorMessage = ErrorCodeEnum.DateInvalid.GetDescription();
        }

        /// <summary>
        /// 排期不存在
        /// </summary>
        public void SetSessionInvalidReply()
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.SessionInvalid.GetValueString();
            ErrorMessage = ErrorCodeEnum.SessionInvalid.GetDescription();
        }

        /// <summary>
        /// 座位售出状态非法
        /// </summary>
        public void SetSessionSeatStatusInvalidReply()
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.SessionSeatStatusInvalid.GetValueString();
            ErrorMessage = ErrorCodeEnum.SessionSeatStatusInvalid.GetDescription();
        }

        /// <summary>
        /// XML解析失败
        /// </summary>
        /// <param name="ParamName"></param>
        public void SetXmlDeserializeFailReply(string ParamName)
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.XmlDeserializeFail.GetValueString();
            ErrorMessage = $"{ParamName}{ErrorCodeEnum.XmlDeserializeFail.GetDescription()}";
        }

        /// <summary>
        /// 座位数量错误
        /// </summary>
        public void SetSeatCountInvalidReply()
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.SeatCountInvalid.GetValueString();
            ErrorMessage = ErrorCodeEnum.SeatCountInvalid.GetDescription();
        }

        /// <summary>
        /// 订单不存在或不允许解锁座位
        /// </summary>
        public void SetOrderNotExistReply()
        {
            Status = StatusEnum.Failure.GetDescription();
            ErrorCode = ErrorCodeEnum.OrderNotExist.GetValueString();
            ErrorMessage = ErrorCodeEnum.OrderNotExist.GetDescription();
        }
        #endregion

        /// <summary>
        /// 状态
        /// </summary>
        [XmlAttribute]
        public string Status { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [XmlAttribute]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlAttribute]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 接口Id
        /// </summary>
        [XmlAttribute]
        public string Id { get; set; }
    }
}