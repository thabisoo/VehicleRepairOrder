using System;
using System.Collections.Generic;
using System.Text;
using VehicleRepairOrder.ApplicationLogic.Entities.Interfaces;
using VehicleRepairOrder.ApplicationLogic.Enums;
using VehicleRepairOrder.ApplicationLogic.Services.Interfaces;

namespace VehicleRepairOrder.ApplicationLogic.Services
{
    public class LargeRepairOrderNewCustomerService : IOrderService
    {
        public OrderStatus GetOrder(IOrderEntity orderEntity)
        {
            return OrderStatus.Closed;
        }
    }
}
