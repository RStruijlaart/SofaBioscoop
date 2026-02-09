using System;
using System.Collections.Generic;
using Xunit;
using SofaBioscoop.Domain;
using SofaBioscoop.Domain.Order;

namespace SofaBioscoopTests
{
    public class OrderTests
    {
        // HULPMETHODE: Om code herhaling te voorkomen
        // Hiermee maken we snel een Order met tickets aan voor elke test
        private Order CreateTestOrder(bool isStudent, DateTime date, int amountOfTickets, bool isPremium)
        {
            // 1. Maak de basis objecten
            Movie movie = new Movie("James Bond");
            // We zetten de prijs standaard op 10.00 voor makkelijk rekenen
            MovieScreening screening = new MovieScreening(movie, date, 10.00);
            Order order = new Order(1, isStudent);

            // 2. Voeg tickets toe aan de order
            for (int i = 0; i < amountOfTickets; i++)
            {
                // Rij 1, Stoel i (maakt niet uit voor prijs)
                MovieTicket ticket = new MovieTicket(screening, isPremium, 1, i);
                order.AddSeatReservation(ticket);
            }

            return order;
        }

        [Fact]
        public void TC01_CalculatePrice_Student_1Ticket_ReturnsBasisPrijs()
        {
            // Arrange
            // Maandag (doordeweeks), Student, 1 ticket, geen premium
            var order = CreateTestOrder(true, new DateTime(2024, 2, 5), 1, false);

            // Act
            double price = order.CalculatePrice();

            // Assert
            Assert.Equal(10.00, price);
        }

        [Fact]
        public void TC02_CalculatePrice_Student_2Tickets_Returns2eGratis()
        {
            // Arrange
            // Maandag, Student, 2 tickets (dus 1 betalen, 1 gratis)
            var order = CreateTestOrder(true, new DateTime(2024, 2, 5), 2, false);

            // Act
            double price = order.CalculatePrice();

            // Assert
            Assert.Equal(10.00, price);
        }

        [Fact]
        public void TC03_CalculatePrice_Student_Premium_ReturnsPremiumMetKorting()
        {
            // Arrange
            // Maandag, Student, 1 ticket, WEL Premium
            // Prijs = 10 (basis) + 3 (premium) - 1 (studentenkorting) = 12
            var order = CreateTestOrder(true, new DateTime(2024, 2, 5), 1, true);

            // Act
            double price = order.CalculatePrice();

            // Assert
            Assert.Equal(12.00, price);
        }

        [Fact]
        public void TC04_CalculatePrice_Student_6Tickets_ReturnsGroepskorting()
        {
            // Arrange
            // Maandag, Student, 6 tickets
            // Logica: 3 betalen (30), 3 gratis. Totaal 30.
            // Groepskorting: 10% eraf. 30 * 0.9 = 27.
            var order = CreateTestOrder(true, new DateTime(2024, 2, 5), 6, false);

            // Act
            double price = order.CalculatePrice();

            // Assert
            Assert.Equal(27.00, price);
        }

        [Fact]
        public void TC05_CalculatePrice_NonStudent_Weekday_Returns2eGratis()
        {
            // Arrange
            // Maandag, NIET-student, 2 tickets
            // Logica: Doordeweeks is 2e kaartje gratis.
            var order = CreateTestOrder(false, new DateTime(2024, 2, 5), 2, false);

            // Act
            double price = order.CalculatePrice();

            // Assert
            Assert.Equal(10.00, price);
        }

        [Fact]
        public void TC06_CalculatePrice_NonStudent_Weekend_ReturnsVollePrijs()
        {
            // Arrange
            // Zaterdag, NIET-student, 2 tickets
            // Logica: Weekend = GEEN gratis kaartje. Dus 2x 10 betalen.
            // LET OP: Deze test gaat FALEN door de bug in je code!
            var order = CreateTestOrder(false, new DateTime(2024, 2, 3), 2, false);

            // Act
            double price = order.CalculatePrice();

            // Assert
            Assert.Equal(20.00, price);
        }

        [Fact]
        public void TC07_CalculatePrice_NonStudent_Weekend_Groep_ReturnsKorting()
        {
            // Arrange
            // Zaterdag, NIET-student, 6 tickets
            // Logica: 6 betalen = 60.
            // Groepskorting (want weekend): 10% eraf. 60 * 0.9 = 54.
            var order = CreateTestOrder(false, new DateTime(2024, 2, 3), 6, false);

            // Act
            double price = order.CalculatePrice();

            // Assert
            Assert.Equal(54.00, price);
        }
    }
}
