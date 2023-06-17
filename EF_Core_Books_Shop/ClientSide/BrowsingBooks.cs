using EF_Core_Books_Shop.DataObject;
using EF_Core_Books_Shop.ProjectRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EF_Core_Books_Shop.ClientSide
{
	public class BrowsingBooks
	{
		public readonly DbApplicationContext _context;
		public readonly IBookRepository _bookRepository;
		public readonly IOrderRepository _orderRepository;
		public IEnumerable<Book> _dataBooks;

		public BrowsingBooks(DbApplicationContext context, IBookRepository bookRepository, IOrderRepository orderRepository)
		{
			_context = context;
			_bookRepository = bookRepository;
			_dataBooks = _bookRepository.GetAllBook();
			_orderRepository = orderRepository;
		}

		
		public void Booksbrowsing()
		{
			var DataBooks = _dataBooks;
			Console.WriteLine("Do you want to browse all books ?");
			Console.WriteLine("Enter (ENTER) or ESC");
			ConsoleKey button = Console.ReadKey().Key;
			if (button == ConsoleKey.Enter)
			{
				foreach (var book in DataBooks)
				{
					foreach (var author in book.Authors)
					{
						Console.WriteLine($"Book({book.Name}) -- Author({author.Name})-({author.LastName})");
					}
                }
                Console.WriteLine();
				Console.WriteLine("Do you want to order books ?");
			    button = Console.ReadKey().Key;
				if (button == ConsoleKey.Enter)
				{
				   OrderBook();
				}
				else if (button == ConsoleKey.Escape)
				{
					Console.WriteLine("You finish your sesion");
				}
			}
			else if (button == ConsoleKey.Escape)
			{
                Console.WriteLine("Do you want to browsing your cart ?");
				button = Console.ReadKey().Key;
				if (button == ConsoleKey.Enter)
				{
					CartOrder ordercart = new CartOrder(_context,_orderRepository);
					ordercart.BrowsingCart();
				}
				else if (button == ConsoleKey.Escape)
				{
                    Console.WriteLine("You finish your sesion");
                }
			}
		}
		private int NumberBook { get; set; }
		private string OrderName { get; set; }
		public void OrderBook()
		{
			var DataOrder = _dataBooks;
			Console.WriteLine("Select books which you want to choice ");
			foreach (var book in DataOrder)
			{
				foreach (var author in book.Authors)
				{
					Console.WriteLine($"Book({book.Name}) -- Author({author.Name})-({author.LastName}) -- Price({book.Price}) - Number {book.Id}");
				}
			}
			Console.WriteLine("Enter number book ");
			NumberBook = int.Parse(Console.ReadLine());
			foreach (var orderbook in DataOrder.Where(x => x.Id == NumberBook))
			{
				foreach (var orderauthor in orderbook.Authors)
				{
					Console.WriteLine($"Do you want really buy this books ({orderbook.Name}) -- Author({orderauthor.Name})-({orderauthor.LastName}) -- Price({orderbook.Price})");
					OrderName = orderbook.Name;
				}
			}
            Console.WriteLine("Confirm your action");
			ConsoleKey button = Console.ReadKey().Key;
			Random rand = new Random();
			if (button == ConsoleKey.Enter)
			{
                Console.WriteLine("Оrder successfully completed");
				_orderRepository.AddDataOrderRepositor(OrderName,rand.Next(1,5000));
			}
            
        }
	}
}
