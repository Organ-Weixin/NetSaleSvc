using NetSaleSvc.Admin.Models;
using NetSaleSvc.Admin.Models.Order;
using NetSaleSvc.Admin.Properties;
using NetSaleSvc.Admin.Utils;
using NetSaleSvc.Entity.Enum;
using NetSaleSvc.Service;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NetSaleSvc.Admin.Controllers
{
    public class OrderController : RootExraController
    {
        private OrderService _orderService;
        private UserInfoService _userInfoService;

        #region ctor
        public OrderController()
        {
            _orderService = new OrderService();
            _userInfoService = new UserInfoService();
        }
        #endregion

        public async Task<ActionResult> Index()
        {
            await PrepareIndexViewData();

            return View();
        }

        /// <summary>
        /// 订单列表
        /// </summary>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public async Task<ActionResult> List(DynatablePageModel<OrderPageQueryModel> pageModel)
        {
            DateTime? startDate = null, endDate = null;
            if (!string.IsNullOrEmpty(pageModel.Query.OrderDateRange))
            {
                var dates = pageModel.Query.OrderDateRange.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                startDate = DateTime.Parse(dates[0]);
                endDate = DateTime.Parse(dates[1]);
            }


            var orders = await _orderService.GetOrdersPagedAsync(
                CurrentUser.CinemaCode == Resources.DEFAULT_CINEMACODE ? null : CurrentUser.CinemaCode,
                 pageModel.Offset,
                 pageModel.PerPage,
                 pageModel.Query.Search,
                 pageModel.Query.ThirdUserId,
                 pageModel.Query.OrderStatus,
                 startDate,
                 endDate);

            return DynatableResult(orders.ToDynatableModel(
                orders.TotalCount,
                pageModel.Offset,
                x => x.ToDynatableItem()));
        }

        /// <summary>
        /// 准备订单管理首页下拉框数据
        /// </summary>
        /// <returns></returns>
        private async Task PrepareIndexViewData()
        {
            var allThirdUsers = await _userInfoService.GetAllUserInfosAsync();
            ViewBag.ThirdUserId = allThirdUsers.Select(x => new SelectListItem { Text = x.Company, Value = x.Id.ToString() });

            ViewBag.OrderStatus = EnumUtil.GetSelectList<OrderStatusEnum>(OrderStatusEnum.Complete);
        }
    }
}