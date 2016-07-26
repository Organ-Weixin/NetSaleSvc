using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Api.CTMS.NationalStandard;

namespace NetSaleSvc.Api.CTMS
{
    /// <summary>
    /// 影院票务管理接口工厂
    /// </summary>
    public static class CTMSInterfaceFactory
    {
        /// <summary>
        /// 根据影院系统类型创建相应接口
        /// </summary>
        /// <param name="cinema"></param>
        /// <returns></returns>
        public static ICTMSInterface Create(UserCinemaViewEntity userCinema)
        {
            switch (userCinema.CinemaType)
            {
                case CinemaTypeEnum.NationalStandard:
                    return new NsInterface();
                case CinemaTypeEnum.ChenXing:
                    return new DefaultCTMSInterface();
                case CinemaTypeEnum.DingXin:
                    return new DefaultCTMSInterface();
                case CinemaTypeEnum.ManTianXing:
                    return new DefaultCTMSInterface();
                case CinemaTypeEnum.HuoLieNiao:
                    return new DefaultCTMSInterface();
                case CinemaTypeEnum.DianYing1905:
                    return new DefaultCTMSInterface();
                default:
                    return new DefaultCTMSInterface();
            }
        }
    }
}
