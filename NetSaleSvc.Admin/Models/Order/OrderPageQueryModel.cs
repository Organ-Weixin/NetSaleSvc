using NetSaleSvc.Entity.Enum;

namespace NetSaleSvc.Admin.Models
{
    public class OrderPageQueryModel : DynatablePageQueryModel
    {
        /// <summary>
        /// 接入商编号
        /// </summary>
        public int? ThirdUserId { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatusEnum? OrderStatus { get; set; }

        /// <summary>
        /// 时间范围
        /// </summary>
        public string OrderDateRange { get; set; }
    }
}