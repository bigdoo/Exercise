using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductsController : BaseController
    {
        //private FabricsEntities1 db = new FabricsEntities1();
        //ProductRepository repo = RepositoryHelper.GetProductRepository();
        // GET: Products
        public ActionResult Index(int? ProductId, string type, bool? isActive, string keyword)
        {
            var repoL = RepositoryHelper.GetProductRepository(repo.UnitOfWork);
            // var data = repo.Get超級複雜的資料集();
            //var data = repo.All(true);
            var data = repo.All().Take(5);
            if (isActive.HasValue)
            {
                data = data.Where(p => p.Active.HasValue && p.Active.Value == isActive.Value);
            }
            if (!String.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.ProductName.Contains(keyword));
            }
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Value = "true", Text = "有效" });
            items.Add(new SelectListItem() { Value = "false", Text = "無效" });
            ViewData["isActive"] = new SelectList(items, "Value", "Text");

            //var repoOL = RepositoryHelper.GetOrderLineRepository(repo.UnitOfWork);

            ViewBag.type = type;
            if (ProductId.HasValue)
           {
             ViewBag.SelectedProductId = ProductId.Value;
                
           }
            //return View(repo.All().Take(5));
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(IList<ProductPatchModel> data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var product = repo.Find(item.ProductId);
                    product.Price = item.Price;
                    product.Stock = item.Stock;
                }
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(repo.All().Take(5));

        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,FormCollection formdata )
        {
            //[Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product produc
            var product = repo.Find(id);
            if(TryUpdateModel<IProduct>(product))
            {
                // var db = (FabricsEntities1)repo.UnitOfWork.Context;
                // db.Entry(product).State = EntityState.Modified;
                // db.SaveChanges();
                repo.UnitOfWork.Commit();
                TempData["EditSucess"]="編輯商品資料成功";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.Find(id);
            //db.Product.Remove(product);
            product.IsDeleted = true;
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var db = (FabricsEntities1)repo.UnitOfWork.Context;
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
