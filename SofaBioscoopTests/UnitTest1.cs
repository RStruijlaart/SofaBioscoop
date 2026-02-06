using FluentAssertions;
using SofaBioscoop.Domain;

namespace SofaBioscoopTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Movie movie1 = new Movie("Inception");

            // Create screenings
            MovieScreening screening1 = new MovieScreening(
                movie1,
                new DateTime(2026, 3, 15, 20, 0, 0), // Saturday evening
                1
            );


            // Create tickets
            MovieTicket ticket1 = new MovieTicket(screening1, false, 5, 8); // Standard
            MovieTicket ticket2 = new MovieTicket(screening1, true, 5, 9);  // Premium
            MovieTicket ticket3 = new MovieTicket(screening1, false, 5, 10);
            MovieTicket ticket4 = new MovieTicket(screening1, true, 5, 11);
            MovieTicket ticket5 = new MovieTicket(screening1, false, 6, 1);
            MovieTicket ticket6 = new MovieTicket(screening1, false, 6, 2);

            // Create order (student order = true)
            Order order = new Order(1, true);

            // Add tickets to order
            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);
            order.AddSeatReservation(ticket3);
            order.AddSeatReservation(ticket4);
            order.AddSeatReservation(ticket5);
            order.AddSeatReservation(ticket6);

            order.CalculatePrice().Should().Be(2.7);
        }
    }
}