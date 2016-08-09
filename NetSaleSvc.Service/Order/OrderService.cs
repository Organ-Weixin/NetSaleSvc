using NetSaleSvc.Entity.Models;
using NetSaleSvc.Entity.Repository;
using NetSaleSvc.Entity.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Data;
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
        /// 根据影院编码和锁座返回的订单编码获取订单
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public OrderViewEntity GetOrderWithLockOrderCode(string CinemaCode, string LockOrderCode)
        {
            var order = _orderRepository.Query.Where(x => x.CinemaCode == CinemaCode
                && x.LockOrderCode == LockOrderCode).SingleOrDefault();
            if (order == null)
            {
                return null;
            }

            var orderSeats = _orderSeatRepository.Query.Where(x => x.OrderId == order.Id).ToList();
            return new OrderViewEntity
            {
                orderBaseInfo = order,
                orderSeatDetails = orderSeats.ToList()
            };
        }

        /// <summary>
        /// 根据订单编码（可以是LockOrderCode，也可以是SubmitOrderCode）获取订单信息
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public OrderViewEntity GetOrderWithOrderCode(string CinemaCode, string OrderCode)
        {
            var order = _orderRepository.Query.Where(x => x.CinemaCode == CinemaCode
                && (x.LockOrderCode == OrderCode || x.SubmitOrderCode == OrderCode)).SingleOrDefault();
            if (order == null)
            {
                return null;
            }

            var orderSeats = _orderSeatRepository.Query.Where(x => x.OrderId == order.Id).ToList();
            return new OrderViewEntity
            {
                orderBaseInfo = order,
                orderSeatDetails = orderSeats.ToList()
            };
        }

        /// <summary>
        /// 根据取票信息获取订单
        /// </summary>
        /// <param name="CinemaCode"></param>
        /// <param name="PrintNo"></param>
        /// <param name="VerifyCode"></param>
        /// <returns></returns>
        public OrderViewEntity GetOrderWithPrintNo(string CinemaCode, string PrintNo, string VerifyCode)
        {
            var order = _orderRepository.Query.Where(x => x.CinemaCode == CinemaCode
                && x.PrintNo == PrintNo && x.VerifyCode == VerifyCode).SingleOrDefault();
            if (order == null)
            {
                return null;
            }
            var orderSeats = _orderSeatRepository.Query.Where(x => x.OrderId == order.Id).ToList();
            return new OrderViewEntity
            {
                orderBaseInfo = order,
                orderSeatDetails = orderSeats.ToList()
            };
        }

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
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 更新订单（包括座位信息）
        /// </summary>
        /// <param name="orderView"></param>
        public void Update(OrderViewEntity orderView)
        {
            using (var connection = DbConnectionFactory.OpenConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        orderView.orderBaseInfo.Updated = DateTime.Now;
                        _orderRepository.UpdateWithTransaction(orderView.orderBaseInfo,
                            connection, transaction);

                        orderView.orderSeatDetails.ForEach(x =>
                        {
                            x.Updated = DateTime.Now;
                            _orderSeatRepository.UpdateWithTransaction(x, connection, transaction);
                        });

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 只更新订单信息，不更新订单座位信息
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateOrderBaseInfo(OrderEntity entity)
        {
            entity.Updated = DateTime.Now;
            _orderRepository.Update(entity);
        }
    }
}
