// See https://aka.ms/new-console-template for more information
using SofaBioscoop.Domain;

Console.WriteLine("Hello, World!");

// Create movies
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

// Calculate price
double totalPrice = order.CalculatePrice();

// Output to console
Console.WriteLine("Order number: " + order.GetOrderNr());
Console.WriteLine("Total price: €" + totalPrice.ToString("0.00"));

Console.ReadLine();