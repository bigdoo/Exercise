using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class EFController : Controller
    {
        // GET: EF
        FabricsEntities1 db = new FabricsEntities1();
        public ActionResult Index(bool? IsActive, String Keyword)
        {

            var product = new Product()
            {
                ProductName = "BMW",
                Price = 2,
                Stock = 1,
                Active = true

            };
            var Client = new Client()
            {


            };

            //var db = new FabricsEntities1();
            //db.Product.Add(product);


            //SaveChange();
            var pkey = product.ProductId;
            //p => p.ProductId;
            var data = db.Product.OrderByDescending(p => p.ProductId).AsQueryable();
            if (IsActive.HasValue)
            {
                data = data.Where(p => p.Active.HasValue ? p.Active.Value == IsActive.Value : false);
            }

            if (!String.IsNullOrEmpty(Keyword))
            {
                data = data.Where(p => p.ProductName.Contains(Keyword));
            }
            foreach (var item in data)
            {
                item.Price = item.Price + 1;
            }
            SaveChange();
            //var data = db.Product.Where(p => p.ProductId == pkey);


            return View(data);
        }

        private void SaveChange()
        {
            try
            {
                db.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult var in GetEntityValidationErrors(ex))
                {
                    foreach (DbValidationError item in var.ValidationErrors)
                    {
                        throw new Exception(item.ErrorMessage);
                    }


                }
                throw;
            }
        }

        private IEnumerable<DbEntityValidationResult> GetEntityValidationErrors(DbEntityValidationException ex)
        {
            throw new NotImplementedException();
        }

        public ActionResult Detail(int id)
        {
            //var data =  db.Product.Find(id);
            //var data = db.Product.Where(p => p.ProductId == id).FirstOrDefault();
            var data = db.Product.FirstOrDefault(p => p.ProductId == id);
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var Product = db.Product.Find(id);


            foreach (var ol in Product.OrderLine.ToList())
            {
                db.OrderLine.Remove(ol);
            }

            //db.OrderLine.RemoveRange(Product.OrderLine);

            db.Product.Remove(Product);
            SaveChange();

            return RedirectToAction("Index");
        }

        public ActionResult QueryPlan(int? num=10)
        {
            var data = db.Product
                .Include(t => t.OrderLine)
                .OrderBy(p => p.ProductId)
                .AsQueryable();

            var date2 = db.Database.SqlQuery<Product>(@"
                 SELECT * 
                    FROM dbo.Product p 
                      WHERE p.ProductId < @p0", num
                );
            //db.upXXX
            return View(date2);

        }
    }
}