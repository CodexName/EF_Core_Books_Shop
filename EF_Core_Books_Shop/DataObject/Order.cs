using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Books_Shop.DataObject
{
	public class Order
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Number { get; set; }
		public int Data { get; set; }
		public ICollection<Client> Clients { get; set; }
	}
}
