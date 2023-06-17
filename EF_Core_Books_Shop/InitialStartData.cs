using EF_Core_Books_Shop.DataObject;

namespace EF_Core_Books_Shop
{
	public class InitialStartData
	{
		public DbApplicationContext Context;
		public InitialStartData(DbApplicationContext context)
		{
			Context = context;
		}
		public void AddData()
		{

			var books = new Book
			{
				Name = "The Shining",
				Price = 10,
				Age = 18,
				Authors = new List<Author>
				{
					new Author
					{
						Name = "Stephen",
					   LastName = "King",
					}
				},
				Clients = new List<Client>
				{
					new Client
					{
						 Name = "John",
						LastName = "Doe",
						Age = 25,
						Gmail = "johndoe@gmail.com",
						Password = 123456,
					}
				}

			};

			var books1 = new Book
			{
				Name = "The Catcher in the Rye",
				Price = 12,
				Age = 16,
				Authors = new List<Author>
				{
				   new Author
				   {
					  Name = "J. D.",
					  LastName = "Salinger",
				   }
				},
				Clients = new List<Client>
				{
				   new Client
				   {
					  Name = "Emma",
					  LastName = "Watson",
					  Age = 31,
					  Gmail = "emmawatson@gmail.com",
					  Password = 654321,
				   }
				}
			};


			var books3 = new Book
			{
				Name = "Harry Potter and the Sorcerer's Stone",
				Price = 15,
				Age = 12,
				Authors = new List<Author>
				{
				   new Author
				   {
					  Name = "J.K.",
					  LastName = "Rowling",
				   }
				},
				Clients = new List<Client>
				  {
					 new Client
					 {
						Name = "Emma",
						LastName = "Watson",
						Age = 32,
						Gmail = "emmawatson@gmail.com",
						Password = 654321,
					 }
				  }
			};



			var order = new Order
			{
				Name = "First Order",
				Number = 1,
				Clients = new List<Client>
				{
					new Client
					{
					  Name = "Jane",
					  LastName = "Doe",
					  Age = 23,
					  Gmail = "janedoe@gmail.com",
					  Password = 654321,
					}
				}
			};
			Context.AddRange(order, books, books1, books3);
			Context.SaveChanges();
		}
	}
}
