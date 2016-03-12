using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication2.Models
{   
	public  class vwClientOrderRepository : EFRepository<vwClientOrder>, IvwClientOrderRepository
	{

	}

	public  interface IvwClientOrderRepository : IRepository<vwClientOrder>
	{

	}
}