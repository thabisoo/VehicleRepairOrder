using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleRepairOrder.ApplicationLogic.Entities.Interfaces;
using VehicleRepairOrder.ApplicationLogic.Enums;
using VehicleRepairOrder.ApplicationLogic.Services.Interfaces;
using VehicleRepairOrder.DotNetCoreDI;
using VehicleRepairOrder.Helpers;

namespace VehicleRepairOrder
{
    class Program
    {
        private static readonly IServiceProvider _container = new ContainerBuilder().Build();
        private static Func<OrderType, IOrderService> _orderServiceResolver = (Func<OrderType, IOrderService>)_container.GetService(typeof(Func<OrderType, IOrderService>));
        private static readonly IOrderEntity _orderEntity = (IOrderEntity)_container.GetService(typeof(IOrderEntity));

        static void Main(string[] args)
        {
            var orderTypes = Enum.GetNames(typeof(OrderType));
            var subOrderTypes = Enum.GetNames(typeof(SubOrderType));

            var orderTypesDictionary = orderTypes
                .Select((value, key) => new { value, key })
                .ToDictionary(x => (int)Enum.Parse(typeof(OrderType), x.value), x => x.value);

            var subOrderTypesDictionary = subOrderTypes
                .Select((value, key) => new { value, key })
                .ToDictionary(x => (int)Enum.Parse(typeof(SubOrderType), x.value), x => x.value);


            Console.WriteLine("Please select an order type.");

            foreach(var orderType in orderTypesDictionary)
            {
                Console.WriteLine($"Enter {orderType.Key} for {orderType.Value}");
            }

            var selectedOrderType = int.Parse(Console.ReadLine());

            Console.WriteLine("Please choose your order.");
            var orderText = StringsHelper.GetSubOrderTypeStrings();
            foreach (var subOrderType in subOrderTypesDictionary)
            {
                Console.WriteLine($"Enter {subOrderType.Key} {orderText[(SubOrderType)subOrderType.Key]}");
            }

            var selectedSubOrderType = int.Parse(Console.ReadLine());

            _orderEntity.OrderType = (OrderType)selectedOrderType;
            _orderEntity.SubOrderType = (SubOrderType)selectedSubOrderType;

            var result = _orderServiceResolver(_orderEntity.OrderType).GetOrder(_orderEntity);

            Console.WriteLine($"Your order status: {result}");
        }
    }
}
