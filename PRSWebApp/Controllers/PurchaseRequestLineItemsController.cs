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
	public class PurchaseRequestLineItemsController : Controller {
		private PRSWebAppContext db = new PRSWebAppContext();

		//Purchase request total is updated 
		private void UpdatePurchaseRequestTotal(int prid) {
			double total = 0.0;
			var purchaseRequestLineItems = db.PurchaseRequestLineItems.Where(p => p.PurchaseRequestID == prid);
			foreach (var purchaseRequestLineItem in purchaseRequestLineItems) { 
			var subTotal = purchaseRequestLineItem.Quantity * purchaseRequestLineItem.Product.Price;
				total += subTotal;
		}
			var purchaseRequest = db.PurchaseRequests.Find(prid);
			purchaseRequest.Total = total;
			db.SaveChanges();
	}

		//performs Json call to return list of PurchaseRequestLineItems
		//this will always return an array
		//it may have 0, 1, or more items within the array
		public ActionResult List() {
			//return Json(db.PurchaseRequestLineItems.ToList(), JsonRequestBehavior.AllowGet);
			//changes format of date data shipped down to JS
			return new JsonNetResult { Data = db.PurchaseRequestLineItems.ToList() };
		}

		// PurchaseRequestLineItems/id
		// will return a PurchaseRequestLineItem or an error message
		public ActionResult Get(int? id) {
			//if nothing is passed in for ID
			if (id == null) {
				return Json(new Msg { Result = "Failure", Message = "ID is null" }, JsonRequestBehavior.AllowGet);
			}

			//returns a PurchaseRequestLineItem or an error message
			PurchaseRequestLineItem PurchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
			//if id is not found when find is issued, you get this message as an array
			if (PurchaseRequestLineItem == null) {
				return Json(new Msg { Result = "Failure", Message = "ID not found" }, JsonRequestBehavior.AllowGet);
			}
			//no errors, we have a PurchaseRequestLineItem
			//return Json(PurchaseRequestLineItem, JsonRequestBehavior.AllowGet);

			//changes format of date data shipped down to JS
			return new JsonNetResult { Data = db.PurchaseRequestLineItems.ToList() };
		}

		public ActionResult Add([FromBody] PurchaseRequestLineItem PurchaseRequestLineItem) {
			PurchaseRequest purchaseRequests = db.PurchaseRequests.Find(PurchaseRequestLineItem.PurchaseRequestID);
			Product products = db.Products.Find(PurchaseRequestLineItem.ProductID);
			if (purchaseRequests == null || products == null) {
				return Json(new Msg { Result = "Failure", Message = "PurchaseRequestLineItem parameter is missing or invalid" });
			}
			// if we get here, add PurchaseRequestLineItem
			db.PurchaseRequestLineItems.Add(PurchaseRequestLineItem);
			//saves changes to database
			db.SaveChanges();
			// method to calculate new total is called 
			UpdatePurchaseRequestTotal(PurchaseRequestLineItem.PurchaseRequestID);
			return Json(new Msg { Result = "Success", Message = "Add successful" });
		}

		public ActionResult Change([FromBody] PurchaseRequestLineItem PurchaseRequestLineItem) {
			//validation (add more to other controllers)
			if (PurchaseRequestLineItem == null) {
				return Json(new Msg { Result = "Failure", Message = "Purchase Request is null" });
			}

			//more validation
			var purchaseRequest = db.PurchaseRequests.Find(PurchaseRequestLineItem.PurchaseRequestID);
			if (purchaseRequest == null) {
				return Json(new Msg { Result = "Failure", Message = "Purchase Request ID FK is invalid" });
			}
			//even more validation (doesn't it feel great to be validated?) 
			var oldPurchaseRequestLineItem = db.PurchaseRequestLineItems.Find(PurchaseRequestLineItem.PurchaseRequestLineItemID);
			if (oldPurchaseRequestLineItem == null) {
				return Json(new Msg { Result = "Failure", Message = "Purchase Request Line Item ID not found" });
			}

			// if we get here, update the Purchase Request
			// calls clone method from Purchase Request class
			oldPurchaseRequestLineItem.Clone(PurchaseRequestLineItem);
			//saves changes to database
			db.SaveChanges();
			UpdatePurchaseRequestTotal(PurchaseRequestLineItem.PurchaseRequestID);
			return Json(new Msg { Result = "Success", Message = "Change successful" });
		}

		public ActionResult Remove([FromBody] PurchaseRequestLineItem PurchaseRequestLineItem) {
			if (PurchaseRequestLineItem == null || PurchaseRequestLineItem.PurchaseRequestLineItemID <= 0) {
				return Json(new Msg { Result = "Failure", Message = "PurchaseRequestLineItem parameter is missing or invalid" });
			}
			//if we get here, delete the PurchaseRequestLineItem
			PurchaseRequestLineItem removePurchaseRequestLineItem = db.PurchaseRequestLineItems.Find(PurchaseRequestLineItem.PurchaseRequestLineItemID);
			if (removePurchaseRequestLineItem == null) {
				return Json(new Msg { Result = "Failure", Message = "PurchaseRequestLineItem ID not found" });
			}
			db.PurchaseRequestLineItems.Remove(removePurchaseRequestLineItem);
			//saves changes to database
			db.SaveChanges();
			UpdatePurchaseRequestTotal(removePurchaseRequestLineItem.PurchaseRequestID);
			return Json(new Msg { Result = "Success", Message = "Remove successful" });
		}

		#region MVC Methods

		// GET: PurchaseRequestLineItems
		public ActionResult Index()
        {
            var purchaseRequestLineItems = db.PurchaseRequestLineItems.Include(p => p.Product).Include(p => p.PurchaseRequest);
            return View(purchaseRequestLineItems.ToList());
        }

        // GET: PurchaseRequestLineItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (purchaseRequestLineItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequestLineItem);
        }

        // GET: PurchaseRequestLineItems/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "VendorPartNumber");
            ViewBag.PurchaseRequestID = new SelectList(db.PurchaseRequests, "PurchaseRequestID", "Description");
            return View();
        }

        // POST: PurchaseRequestLineItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseRequestLineItemID,Quantity,PurchaseRequestID,ProductID")] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRequestLineItems.Add(purchaseRequestLineItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "VendorPartNumber", purchaseRequestLineItem.ProductID);
            ViewBag.PurchaseRequestID = new SelectList(db.PurchaseRequests, "PurchaseRequestID", "Description", purchaseRequestLineItem.PurchaseRequestID);
            return View(purchaseRequestLineItem);
        }

        // GET: PurchaseRequestLineItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (purchaseRequestLineItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "VendorPartNumber", purchaseRequestLineItem.ProductID);
            ViewBag.PurchaseRequestID = new SelectList(db.PurchaseRequests, "PurchaseRequestID", "Description", purchaseRequestLineItem.PurchaseRequestID);
            return View(purchaseRequestLineItem);
        }

        // POST: PurchaseRequestLineItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseRequestLineItemID,Quantity,PurchaseRequestID,ProductID")] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequestLineItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "VendorPartNumber", purchaseRequestLineItem.ProductID);
            ViewBag.PurchaseRequestID = new SelectList(db.PurchaseRequests, "PurchaseRequestID", "Description", purchaseRequestLineItem.PurchaseRequestID);
            return View(purchaseRequestLineItem);
        }

        // GET: PurchaseRequestLineItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (purchaseRequestLineItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequestLineItem);
        }

        // POST: PurchaseRequestLineItems/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            db.PurchaseRequestLineItems.Remove(purchaseRequestLineItem);
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
