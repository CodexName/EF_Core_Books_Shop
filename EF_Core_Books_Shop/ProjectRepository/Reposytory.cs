using EF_Core_Books_Shop.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Books_Shop.ProjectRepository
{
	
	public interface IBookRepository
	{
		IEnumerable<Book> GetAllBook();
		void AddBook(string bookname, int bookprice, int bookage, string nameauthor, string lastnameauthor);
		void RemoveBook(int Id);
		void UptadeData(string booknameup, int bookpriceup, int bookageup, string nameauthorup, string lastnameauthorup, int id);
	}
	public interface IOrderRepository
	{
		void AddDataOrderRepositor(string name,int number);
		IEnumerable<Order> GetAllOrder();
	}
	
}
