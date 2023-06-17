using EF_Core_Books_Shop.DataObject;
using EF_Core_Books_Shop.ProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EF_Core_Books_Shop.AdminSide
{
	public class OperationWithData
	{
		public DbApplicationContext ContextDb;
        public readonly IBookRepository _repositor;
		public readonly IEnumerable<Book> _allbook;
		public OperationWithData(DbApplicationContext context, IBookRepository repository)
		{
			_repositor = repository;
			_allbook = _repositor.GetAllBook();
			ContextDb = context;
		}
		public void CoiceAction ()
		{
            Console.WriteLine("Choice that you want do");
            Console.WriteLine("Uptade F1 _Delete F2 _Add F3 _Show F4");
			ConsoleKey key = Console.ReadKey().Key;
			if (key == ConsoleKey.F1)
			{
				UptadeData();
			}
			if (key == ConsoleKey.F2)
			{
				DeleteBook();
			}
			if (key == ConsoleKey.F3)
			{
				AddNewBook();
			}
			if (key == ConsoleKey.F4)
			{
				ShowAllBook();
			}
		}
		public void ShowAllBook ()
		{
            Console.WriteLine("All Book in DataBase");
            var GetAllBook = _allbook;
				foreach (var book in GetAllBook)
				{
					foreach (var author in book.Authors)
					{
					   Console.WriteLine($"Book Name({book.Name}) -- Price({book.Price}) - Authot({author.Name} - {author.LastName}) - Price {book.Price}");
					}
				}
            Console.WriteLine("Do you want Add new book ?");
        }
		public void AddNewBook()
		{
			Console.Clear();
			Console.WriteLine("Enter Name Book");
			string namebook = Console.ReadLine();
            Console.WriteLine("Enter Price Book");
			int pricebook = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Age Book");
			int agebook = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name Author");
            string authorname = Console.ReadLine();
            Console.WriteLine("Enter LastName Author");
			string authorlastname = Console.ReadLine();
			_repositor.AddBook(namebook,pricebook,agebook,authorname,authorlastname);
			
        }
		public void DeleteBook()
		{
			Console.Clear();
			Console.WriteLine("Enter Id book in order to remove it");
			int idbook = int.Parse(Console.ReadLine());
			_repositor.RemoveBook(idbook);
            Console.WriteLine("Data remove succsesful");
        }
		public void UptadeData()
		{
			Console.Clear();
			Console.WriteLine("Enter Id ");
			int Id = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter new Name Book");
			string upnamebook = Console.ReadLine();
			Console.WriteLine("Enter new Price Book");
			int uppricebook = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter new Age Book");
			int upagebook = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter new Name Author");
			string upauthorname = Console.ReadLine();
			Console.WriteLine("Enter new LastName Author");
			string upauthorlastname = Console.ReadLine();
			_repositor.UptadeData(upnamebook,uppricebook,upagebook,upauthorname,upauthorlastname,Id);
		}
	}
}
