using NetSaleSvc.Entity.Models;
using NetSaleSvc.Entity.Repository;
using NetSaleSvc.Entity.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSaleSvc.Service
{
    public class OrderService
    {
        #region ctor
        private readonly IRepository<OrderEntity> _orderRepository;
        private readonly IRepository<OrderSeatDetailEntity> _orderSeatRepository;

        public OrderService()
        {
            //TODO: 移除内部依赖
            _orderRepository = new Repository<OrderEntity>();
            _orderSeatRepository = new Repository<OrderSeatDetailEntity>();
        }
        #endregion

        /// <summary>
        /// 新增订单（包括订单座位信息）
        /// </summary>
        /// <param name="orderView"></param>
        public void Insert(OrderViewEntity orderView)
        {
            using (var connection = DbConnectionFactory.OpenConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int orderId = _orderRepository.InsertWithTransaction(orderView.orderBaseInfo,
                            connection, transaction);

                        orderView.orderSeatDetails.ForEach(x =>
                        {
                            x.OrderId = orderId;
                            _orderSeatRepository.InsertWithTransaction(x, connection, transaction);
                        });

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
