using EF_Core_Books_Shop.DataObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Books_Shop.ProjectRepository
{
	public class RealizationReposytory : IBookRepository , IOrderRepository
	{
		public DbApplicationContext ContextDb;
		public RealizationReposytory (DbApplicationContext context)
		{
			ContextDb = context;
		}

		public void AddBook(string bookname,int bookprice,int bookage, string nameauthor,string lastnameauthor)
		{
			var AddNewBook = new Book
			{
				Name = bookname,
				Price = bookprice,
				Age = bookage,
				Authors = new List<Author>
				{
					new Author
					{
						Name = nameauthor,
						LastName = lastnameauthor
					}
				}
			};
			ContextDb.Add(AddNewBook);
			ContextDb.SaveChanges();
		}

		public void AddDataOrderRepositor(string name, int number)
		{
			var AddData = new Order
			{
				Name = name,
			    Number = number, 
			};
			ContextDb.Orders.Add(AddData);
			ContextDb.SaveChanges();
		}

		public IEnumerable<Book> GetAllBook()
		{
			return ContextDb.Books.AsNoTracking().Include(x => x.Authors).ToList();
		}

		public IEnumerable<Order> GetAllOrder()
		{
			return ContextDb.Orders.AsNoTracking().Include(x => x.Clients).ToList();
		}

		public void RemoveBook(int IdBook)
		{
			var removedata = ContextDb.Books.Single(x => x.Id == IdBook);
			ContextDb.Books.Remove(removedata);
			ContextDb.SaveChanges();
		}

		public void UptadeData(string booknameup, int bookpriceup, int bookageup, string nameauthorup, string lastnameauthorup,int id)
		{
			var getbook = ContextDb.Books.Include(x => x.Authors).Where(x => x.Id == id).ToList();
			foreach (var book in getbook)
			{
				foreach (var author in book.Authors)
				{
					book.Name = booknameup;
					book.Price = bookpriceup;
					book.Price = bookageup;
					author.Name = nameauthorup;
					author.LastName = lastnameauthorup;
				}
			}
			ContextDb.SaveChanges();
		}
	}
}
