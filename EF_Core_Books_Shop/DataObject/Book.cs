using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Books_Shop.DataObject
{
	public class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public int Age { get; set; }
		public ICollection<Client> Clients { get; set; }
		public ICollection<Author> Authors { get; set; }
	}
}
