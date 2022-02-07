using System;
using System.Collections.Generic;
using System.Text;
using VehicleRepairOrder.ApplicationLogic.Enums;

namespace VehicleRepairOrder.ApplicationLogic.Entities.Interfaces
{
    public interface IOrderEntity
    {
        public OrderType OrderType { get; set; }
        public SubOrderType SubOrderType { get; set; }
    }
}
