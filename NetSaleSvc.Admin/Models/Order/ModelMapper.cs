using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Entity.Models;
using NetSaleSvc.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetSaleSvc.Admin.Models.Order
{
    public static class ModelMapper
    {
        /// <summary>
        /// 转为Dynatable内容
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static dynamic ToDynatableItem(this AdminOrderViewEntity order)
        {
            return new
            {
                id = order.Id,
                cinemaName = order.CinemaName,
                filmName = order.FilmName,
                sessionTime = order.SessionTime.ToString("yyyy-MM-dd HH:mm"),
                ticketCount = order.TicketCount,
                price = order.TotalPrice.ToString("0.##"),
                fee = order.TotalFee.ToString("0.##"),
                thirdUserName = order.ThirdUserName,
                orderCode = order.SubmitOrderCode ?? order.LockOrderCode,
                orderTime = order.Created.ToFormatString(),
                mobile = order.MobilePhone,
                orderStatus = order.OrderStatus.GetDescription(),
                statusClass = GetStatusClass(order.OrderStatus)
            };
        }

        /// <summary>
        /// 获取状态样式
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetStatusClass(OrderStatusEnum status)
        {
            switch (status)
            {
                case OrderStatusEnum.Created:
                case OrderStatusEnum.Locked:
                case OrderStatusEnum.Released:
                case OrderStatusEnum.Submited:
                case OrderStatusEnum.Refund:
                    return "darkorange";
                case OrderStatusEnum.LockFail:
                case OrderStatusEnum.ReleaseFail:
                case OrderStatusEnum.SubmitFail:
                    return "red";
                case OrderStatusEnum.Complete:
                    return "green";
                default:
                    return "darkorange";
            }
        }
    }
}