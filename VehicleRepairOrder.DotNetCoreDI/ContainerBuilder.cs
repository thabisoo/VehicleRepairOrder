using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleRepairOrder.ApplicationLogic.Entities;
using VehicleRepairOrder.ApplicationLogic.Entities.Interfaces;
using VehicleRepairOrder.ApplicationLogic.Enums;
using VehicleRepairOrder.ApplicationLogic.Services;
using VehicleRepairOrder.ApplicationLogic.Services.Interfaces;

namespace VehicleRepairOrder.DotNetCoreDI
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            var container = new ServiceCollection();

            container.AddScoped<IOrderEntity, OrderEntity>();
            container.AddScoped<RepairOrderService>();
            container.AddScoped<HireOrderService>();

            container.AddScoped<LargeRepairOrderNewCustomerService>();
            container.AddScoped<LargeRushHireOrderService>();
            container.AddScoped<LargeRepairOrderService>();
            container.AddScoped<NewCustomerRushOrderService>();
            container.AddScoped<GenericOrderService>();
      

            container.AddTransient<Func<OrderType, IOrderService>>(serviceProvider => serviceTypeName =>
            {
                switch (serviceTypeName)
                {
                    case OrderType.Hire:
                        return serviceProvider.GetService<HireOrderService>();
                    case OrderType.Repair:
                        return serviceProvider.GetService<RepairOrderService>();
                    default:
                        return null;
                }
            });

            container.AddTransient<Func<SubOrderType, IOrderService>>(serviceProvider => serviceTypeName =>
            {
                switch (serviceTypeName)
                {
                    case SubOrderType.LargeRepairNewCustomer:
                        return serviceProvider.GetService<LargeRepairOrderNewCustomerService>();
                    case SubOrderType.LargeRushHire:
                        return serviceProvider.GetService<LargeRushHireOrderService>();
                    case SubOrderType.LargeRepair:
                        return serviceProvider.GetService<LargeRepairOrderService>();
                    case SubOrderType.NewCustomerRush:
                        return serviceProvider.GetService<NewCustomerRushOrderService>();
                    case SubOrderType.Generic:
                        return serviceProvider.GetService<GenericOrderService>();
                    default:
                        return null;
                }
            });

            return container.BuildServiceProvider();
        }
    }
}
