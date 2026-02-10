using System;
using Xunit;
using SofaBioscoop.Domain;
using SofaBioscoop.Domain.States;
using System.Reflection;

namespace SofaBioscoopTests
{
    public class OrderStateTests
    {
        // Helper om de huidige state van een Order uit te lezen via Reflection, 
        // omdat de 'state' variabele in Order private is.
        private OrderState GetCurrentState(Order order)
        {
            var field = typeof(Order).GetField("state", BindingFlags.NonPublic | BindingFlags.Instance);
            return (OrderState)field.GetValue(order);
        }

        [Fact]
        public void OrderCreated_Submit_ShouldChangeToOrderReserved()
        {
            // Arrange
            var order = new Order(1, false); // Begint standaard in OrderCreated

            // Act
            order.Submit();

            // Assert
            var state = GetCurrentState(order);
            Assert.IsType<OrderReserved>(state);
        }

        [Fact]
        public void OrderReserved_Cancel_ShouldChangeToOrderCanceled()
        {
            // Arrange
            var order = new Order(1, false);
            order.Submit(); // Eerst naar Reserved brengen

            // Act
            order.Cancel();

            // Assert
            var state = GetCurrentState(order);
            Assert.IsType<OrderCanceled>(state);
        }

        [Fact]
        public void OrderReserved_Pay_ShouldChangeToOrderProcessed()
        {
            // Arrange
            var order = new Order(1, false);
            order.Submit(); // Eerst naar Reserved brengen

            // Act
            order.Pay();

            // Assert
            var state = GetCurrentState(order);
            Assert.IsType<OrderProcessed>(state);
        }

        [Fact]
        public void OrderCanceled_Submit_ShouldStayCanceled()
        {
            // Arrange
            var order = new Order(1, false);
            order.Submit();
            order.Cancel(); // Nu is de order gecanceld

            // Act
            order.Submit(); // Probeer opnieuw te submitten

            // Assert
            var state = GetCurrentState(order);
            Assert.IsType<OrderCanceled>(state);
        }

        [Fact]
        public void OrderProvisional_Pay_ShouldChangeToOrderProcessed()
        {
            // Arrange
            var order = new Order(1, false);
            order.SetState(new OrderProvisional());

            // Act
            order.Pay();

            // Assert
            var state = GetCurrentState(order);
            Assert.IsType<OrderProcessed>(state);
        }

        [Fact]
        public void OrderCreated_Pay_ShouldRestrictPayment()
        {
            // Arrange
            var order = new Order(1, false);
            var initialState = GetCurrentState(order);

            // Act
            order.Pay();

            // Assert
            var state = GetCurrentState(order);
            Assert.IsType<OrderCreated>(state); // Mag niet veranderd zijn
        }
    }
}