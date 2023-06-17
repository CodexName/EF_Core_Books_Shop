using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Books_Shop.DataObject
{
	public class Client
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public string Gmail { get; set; }
		public long Password { get; set; }
		public ICollection<Order> Orders { get; set; }
		public ICollection<Book> Books { get; set; }
	}
}
