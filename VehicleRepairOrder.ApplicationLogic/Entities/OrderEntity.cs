using System;
using System.Collections.Generic;
using System.Text;
using VehicleRepairOrder.ApplicationLogic.Entities.Interfaces;
using VehicleRepairOrder.ApplicationLogic.Enums;

namespace VehicleRepairOrder.ApplicationLogic.Entities
{
    public class OrderEntity : IOrderEntity
    {
        public OrderType OrderType { get; set; }
        public SubOrderType SubOrderType { get; set; }
    }
}
