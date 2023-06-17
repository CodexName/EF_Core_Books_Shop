using EF_Core_Books_Shop.DataObject;
using EF_Core_Books_Shop.ProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EF_Core_Books_Shop
{
	public class CartOrder
	{
		public DbApplicationContext ContextDb;
		private readonly IOrderRepository _orderRepository;
		private readonly IEnumerable<Order> _orderbook;
		public CartOrder(DbApplicationContext context, IOrderRepository repository)
		{
			_orderRepository = repository;
			_orderbook = _orderRepository.GetAllOrder();
			ContextDb = context;
		}

		public void BrowsingCart ()
		{
			var AllOrderData = _orderbook;
			foreach (var order in AllOrderData )
			{
				foreach (var client in order.Clients )
				{
                    Console.WriteLine($"All your order - Name({order.Name} -- Number({order.Number}) -- Client({client.Name}) )");
                }
			}
        }
	}
}
	