using System;
using System.Collections.Generic;
using System.Text;
using VehicleRepairOrder.ApplicationLogic.Enums;

namespace VehicleRepairOrder.Helpers
{
    public class StringsHelper
    {
        public static IDictionary<SubOrderType, string> GetSubOrderTypeStrings()
        {
            return new Dictionary<SubOrderType, string>
            {
                {SubOrderType.LargeRepairNewCustomer, "if you have a large repair order and you are a new customer" },
                {SubOrderType.LargeRushHire, "if you have a large rush hire order" },
                {SubOrderType.LargeRepair, "if you have a large repair order" },
                {SubOrderType.NewCustomerRush, "if you have a rush order and you are a new customers" },
                {SubOrderType.Generic, "if your order does not meet any of the above" },
            };
        }
    }
}
