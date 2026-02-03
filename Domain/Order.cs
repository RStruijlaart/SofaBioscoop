using System.Text.Json;

namespace SofaBioscoop.Domain
{
	public class Order
	{
		private int orderNr;
		private bool isStudentOrder;
		private List<MovieTicket> tickets;

		public Order(int orderNr, bool isStudentOrder)
		{
			this.orderNr = orderNr;
			this.isStudentOrder = isStudentOrder;
			this.tickets = new List<MovieTicket>();
		}

		public int GetOrderNr() => orderNr;

		public void AddSeatReservation(MovieTicket ticket)
		{
			tickets.Add(ticket);
		}

		public double CalculatePrice()
		{
			return 0.0;
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