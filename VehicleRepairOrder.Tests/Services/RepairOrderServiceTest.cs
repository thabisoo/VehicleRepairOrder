using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using VehicleRepairOrder.ApplicationLogic.Entities;
using VehicleRepairOrder.ApplicationLogic.Enums;
using VehicleRepairOrder.ApplicationLogic.Services;
using VehicleRepairOrder.ApplicationLogic.Services.Interfaces;
using VehicleRepairOrder.DotNetCoreDI;

namespace VehicleRepairOrder.Tests.Services
{
    public class RepairOrderServiceTest
    {
        private RepairOrderService _repairOrderService;

        [SetUp]
        public void Setup()
        {
            IServiceProvider _container = new ContainerBuilder().Build();
            Func<SubOrderType, IOrderService> _orderServiceResolver = (Func<SubOrderType, IOrderService>)_container.GetService(typeof(Func<SubOrderType, IOrderService>));
            _repairOrderService = new RepairOrderService(_orderServiceResolver);
        }

        [Test]
        public void GetOrder_LargeRepairOrder_NewCustomer_Returns_Closed()
        {
            
            var orderEntity = new OrderEntity
            {
                SubOrderType = SubOrderType.LargeRepairNewCustomer
            };

            var result = _repairOrderService.GetOrder(orderEntity);

            Assert.AreEqual(result, OrderStatus.Closed);
        }

        [Test]
        public void GetOrder_LargeRepairOrder_Returns_AuthorisationRequired()
        {
            var orderEntity = new OrderEntity
            {
                SubOrderType = SubOrderType.LargeRepair
            };

            var result = _repairOrderService.GetOrder(orderEntity);

            Assert.AreEqual(result, OrderStatus.AuthorisationRequired);
        }

        [Test]
        public void GetOrder_OrderTypeMissing_Throws()
        {
            OrderEntity orderEntity = null;

            Assert.Throws<ArgumentNullException>(() => _repairOrderService.GetOrder(orderEntity));
        }

        [Test]
        public void GetOrder_GenericOrder_Returns_Confirmed()
        {
            var orderEntity = new OrderEntity
            {
                SubOrderType = SubOrderType.Generic
            };

            var result = _repairOrderService.GetOrder(orderEntity);

            Assert.AreEqual(result, OrderStatus.Confirmed);
        }

        [Test]
        public void GetOrder_NewCustomerRushOrder_Returns_AuthorisationRequired()
        {
            var orderEntity = new OrderEntity
            {
                SubOrderType = SubOrderType.NewCustomerRush
            };

            var result = _repairOrderService.GetOrder(orderEntity);

            Assert.AreEqual(result, OrderStatus.AuthorisationRequired);
        }
    }
}
