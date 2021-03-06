﻿using NetSaleSvc.Entity.Enum;

namespace NetSaleSvc.Api.CTMS.Models
{
    public class CTMSBaseReply
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public StatusEnum Status { get; set; }

        /// <summary>
        /// 返回错误代码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 返回错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 鼎新获取影院Id时返回错误信息
        /// </summary>
        public void GetDingXinCinemaNotValidReply()
        {
            Status = StatusEnum.Failure;
            ErrorCode = "-1";
            ErrorMessage = "鼎新系统不存在该影院或鼎新未对当前合作伙伴开通该影院的权限";
        }

        /// <summary>
        /// 国标获取信息返回NULL
        /// </summary>
        public void GetNsInValidReply()
        {
            Status = StatusEnum.Failure;
            ErrorCode = "-2";
            ErrorMessage = "获取信息失败，请稍候重试。若重复提示此错误，请检查影院连接是否正常";
        }
    }
}
