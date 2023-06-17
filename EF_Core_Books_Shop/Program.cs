using EF_Core_Books_Shop.AdminSide;
using EF_Core_Books_Shop.ClientSide;
using EF_Core_Books_Shop.ProjectRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Books_Shop
{
	public class Program
	{
		static void Main ()
		{
			var options = new DbContextOptions<DbApplicationContext>();
			var context = new DbApplicationContext(options);
			InitialStartData init = new InitialStartData(context);
			IBookRepository bookRepository = new RealizationReposytory(context);
			IOrderRepository orderAddRepository = new RealizationReposytory(context);
			init.AddData();

			void ClientSide ()
			{
				BrowsingBooks browsing = new BrowsingBooks(context, bookRepository,orderAddRepository);
				browsing.Booksbrowsing();
			}
			ClientSide();
			void AdminSide ()
			{
				OperationWithData adminside = new OperationWithData(context,bookRepository);
				adminside.CoiceAction();
			}
			AdminSide();
        }
	}
}
