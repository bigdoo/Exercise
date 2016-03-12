using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication2.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.IsDeleted==true);
        }
                public IQueryable<Product> All(bool isAll)
         {
             if (isAll)
            {
                 return base.All();
             }
             else
             {
                 return this.All();
             }
         }
 
         public Product Find(int id)
         {
             return this.All().FirstOrDefault(p => p.ProductId == id);
         }

      //  public IQueryable<Product> Get超級複雜的資料集()
      //  {
      //      return this.All();
        //}
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}