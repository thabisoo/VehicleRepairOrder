using System;
using System.Collections.Generic;
using System.Text;
using VehicleRepairOrder.ApplicationLogic.Entities.Interfaces;
using VehicleRepairOrder.ApplicationLogic.Enums;
using VehicleRepairOrder.ApplicationLogic.Services.Interfaces;

namespace VehicleRepairOrder.ApplicationLogic.Services
{
    public class HireOrderService : IOrderService
    {
        private readonly Func<SubOrderType, IOrderService> _orderServiceResolver;

        public HireOrderService(Func<SubOrderType, IOrderService> orderServiceResolver)
        {
            _orderServiceResolver = orderServiceResolver;
        }

        public OrderStatus GetOrder(IOrderEntity orderEntity)
        {
            if (orderEntity == null)
            {
                throw new ArgumentNullException("Missing order type.");
            }

            return _orderServiceResolver(orderEntity.SubOrderType).GetOrder(orderEntity);
        }
    }
}
