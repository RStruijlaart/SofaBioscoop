using SofaBioscoop.Interfaces;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace SofaBioscoop.Domain.Order
{
	public class Order
	{
		private int orderNr;
		private bool isStudentOrder;
		private List<MovieTicket> tickets;
		private OrderPricingBehaviour pricingBehaviour;

		public Order(int orderNr, bool isStudentOrder)
		{
			this.orderNr = orderNr;
			this.isStudentOrder = isStudentOrder;
			tickets = new List<MovieTicket>();

			if (this.isStudentOrder)
			{
				pricingBehaviour = new OrderPricingBehaviourStudent();
			}
			else
			{
                pricingBehaviour = new OrderPricingBehaviourRegular();
            }
		}

		public int GetOrderNr() => orderNr;

		public void AddSeatReservation(MovieTicket ticket)
		{
			tickets.Add(ticket);
		}

		public double CalculatePrice()
		{
            return this.pricingBehaviour.CalculatePrice(this.tickets);
		}

		public void Export(TicketExportFormat exportFormat)
		{
			if (exportFormat == TicketExportFormat.PLAINTEXT)
			{
				File.WriteAllText($"order_{orderNr}.txt", ToString());
			}
			else
			{
				var json = JsonSerializer.Serialize(this);
				File.WriteAllText($"order_{orderNr}.json", json);
			}
		}
	}
}