using System;
using System.Collections.Generic;
using System.Text;
using VehicleRepairOrder.ApplicationLogic.Entities.Interfaces;
using VehicleRepairOrder.ApplicationLogic.Enums;

namespace VehicleRepairOrder.ApplicationLogic.Services.Interfaces
{
    public interface IOrderService
    {
        public OrderStatus GetOrder(IOrderEntity orderEntity);
    }
}
