using SofaBioscoop.Domain.States;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace SofaBioscoop.Domain
{
	public class Order
	{
		private int orderNr;
		private bool isStudentOrder;
		private List<MovieTicket> tickets;

		private OrderState state;

		public Order(int orderNr, bool isStudentOrder)
		{
			this.orderNr = orderNr;
			this.isStudentOrder = isStudentOrder;
			this.tickets = new List<MovieTicket>();
			this.state = new OrderCreated();
		}

		public int GetOrderNr() => orderNr;

		public void AddSeatReservation(MovieTicket ticket)
		{
			tickets.Add(ticket);
		}

		public double CalculatePrice()
		{
			double price = 0;
            DateTime dateTime = this.tickets[0].GetMovieScreening().GetDateTime();

            if (isStudentOrder)
			{

				int counter = 1;
                foreach (MovieTicket ticket in this.tickets) 
				{
					if(counter % 2 == 0)
					{
						counter++;
						continue;
					}
					
					if (ticket.IsPremiumTicket())
					{
						price += ticket.GetPrice() - 1;
					}
					else
					{
						price += ticket.GetPrice();
					}
					counter++;
				}

				if (this.tickets.Count >= 6)
				{
					price = price * 0.9;
				}

			}
			else
			{
                int counter = 1;
                foreach (MovieTicket ticket in this.tickets)
                {
                    if (counter % 2 == 0 && (dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday))
                    {
                        counter++;
                        continue;
                    }
                    price += ticket.GetPrice();
                    counter++;
                }

                if (this.tickets.Count >= 6 && (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday))
                {
                    price = price * 0.9;
                }
            }

            return price;
		}

		public void Export(TicketExportFormat exportFormat)
		{
			if (exportFormat == TicketExportFormat.PLAINTEXT)
			{
				File.WriteAllText($"order_{orderNr}.txt", this.ToString());
			}
			else
			{
				var json = JsonSerializer.Serialize(this);
				File.WriteAllText($"order_{orderNr}.json", json);
			}
		}
	}
}