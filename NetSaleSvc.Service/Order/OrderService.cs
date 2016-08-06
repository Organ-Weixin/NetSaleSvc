﻿using NetSaleSvc.Entity.Models;
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

        /// <summary>
        /// 只更新订单信息，不更新订单座位信息
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateOrderBaseInfo(OrderEntity entity)
        {
            _orderRepository.Update(entity);
        }
    }
}