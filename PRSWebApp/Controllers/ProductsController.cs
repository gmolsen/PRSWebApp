using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRSWebApp.Models;
using Utility;
using System.Web.Http;

namespace PRSWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private PRSWebAppContext db = new PRSWebAppContext();

		//performs Json call to return list of Products
		//this will always return an array
		//it may have 0, 1, or more items within the array
		public ActionResult List() {
			return Json(db.Products.ToList(), JsonRequestBehavior.AllowGet);
		}

		// Products/id
		// will return a product or an error message
		public ActionResult Get(int? id) {
			//if nothing is passed in for ID
			if (id == null) {
				return Json(new Msg { Result = "Failure", Message = "ID is null" }, JsonRequestBehavior.AllowGet);
			}

			//returns a product or an error message
			Product product = db.Products.Find(id);
			//if id is not found when find is issued, you get this message as an array
			if (product == null) {
				return Json(new Msg { Result = "Failure", Message = "ID not found" }, JsonRequestBehavior.AllowGet);
			}
			//no errors, we have a product
			return Json(product, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Add([FromBody] Product product) {
			Vendor vendor = db.Vendors.Find(product.VendorID);
			if (vendor == null) {
				return Json(new Msg { Result = "Failure", Message = "Product parameter is missing or invalid" });
			}
			// if we get here, add product
			db.Products.Add(product);
			//saves changes to database
			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Add successful" });
		}

		public ActionResult Change([FromBody] Product product) {
			Vendor vendor = db.Vendors.Find(product.VendorID);
			if (vendor == null) {
				return Json(new Msg { Result = "Failure", Message = "Invalid Vendor ID" });
			}
			Product products = db.Products.Find(product.ProductID);
			if (products == null) {
				return Json(new Msg { Result = "Failure", Message = "Invalid Product ID" });
			}
			// if we get here, update product
			// were choosing this because its consistent with other functions??
			Product oldProduct = db.Products.Find(product.ProductID);
			oldProduct.VendorID = product.VendorID;
			oldProduct.VendorPartNumber = product.VendorPartNumber;
			oldProduct.Name = product.Name;
			oldProduct.Price = product.Price;
			oldProduct.Unit = product.Unit;
			oldProduct.PhotoPath = product.PhotoPath;
			//saves changes to database
			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Change successful" });
		}

		public ActionResult Remove([FromBody] Product product) {
			if (product == null || product.VendorID <= 0) {
				return Json(new Msg { Result = "Failure", Message = "Product parameter is missing or invalid" });
			}
			//if we get here, delete the product
			Product removeProduct = db.Products.Find(product.ProductID);
			if (removeProduct == null) {
				return Json(new Msg { Result = "Failure", Message = "Product ID not found" });
			}
			db.Products.Remove(removeProduct);
			//saves changes to database
			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Remove successful" });
		}



		#region MVC Methods


		// GET: Products
		public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.VendorID = new SelectList(db.Products, "VendorID", "Code");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,VendorPartNumber,Name,Price,Unit,PhotoPath,VendorID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VendorID = new SelectList(db.Products, "VendorID", "Code", product.VendorID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorID = new SelectList(db.Products, "VendorID", "Code", product.VendorID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,VendorPartNumber,Name,Price,Unit,PhotoPath,VendorID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendorID = new SelectList(db.Products, "VendorID", "Code", product.VendorID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		#endregion
		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
