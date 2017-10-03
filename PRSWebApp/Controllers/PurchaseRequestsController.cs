using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRSWebApp.Models;
using System.Web.Http;
using Utility;

namespace PRSWebApp.Controllers
{
    public class PurchaseRequestsController : Controller
    {
        private PRSWebAppContext db = new PRSWebAppContext();

		//performs Json call to return list of PurchaseRequests
		//this will always return an array
		//it may have 0, 1, or more items within the array
		public ActionResult List() {
			//return Json(db.PurchaseRequests.ToList(), JsonRequestBehavior.AllowGet);
			//changes format of date data shipped down to JS
			return new JsonNetResult { Data = db.PurchaseRequests.ToList() };
		}

		// PurchaseRequests/UsersID
		// will return a purchaseRequest or an error message
		public ActionResult Get(int? id) {
			//if nothing is passed in for ID
			if (id == null) {
				return Json(new Msg { Result = "Failure", Message = "ID is null" }, JsonRequestBehavior.AllowGet);
			}

			//returns a purchaseRequest or an error message
			PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
			//if id is not found when find is issued, you get this message as an array
			if (purchaseRequest == null) {
				return Json(new Msg { Result = "Failure", Message = "ID not found" }, JsonRequestBehavior.AllowGet);
			}
			//no errors, we have a purchaseRequest
			//return Json(purchaseRequest, JsonRequestBehavior.AllowGet);

			//changes format of date data shipped down to JS
			return new JsonNetResult { Data = db.PurchaseRequests.ToList() };
		}

		public ActionResult Add([FromBody] PurchaseRequest purchaseRequest) {
			User users = db.Users.Find(purchaseRequest.UserID);
			if (users == null) {
				return Json(new Msg { Result = "Failure", Message = "PurchaseRequest parameter is missing or invalid" });
			}
			// if we get here, add purchaseRequest
			db.PurchaseRequests.Add(purchaseRequest);
			//saves changes to database
			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Add successful" });
		}

		public ActionResult Change([FromBody] PurchaseRequest purchaseRequest) {
			User users = db.Users.Find(purchaseRequest.UserID);
			//need more checks
			if (users == null) {
				return Json(new Msg { Result = "Failure", Message = "Invalid User ID" });
			}
			// if we get here, update purchaseRequest
			// calls clone method
			User oldPurchaseRequest = db.PurchaseRequests.Find(purchaseRequest.PurchaseRequestID);
			//need more checks
			if (oldPurchaseRequest == null) {
				return Json(new Msg { Result = "Failure", Message = "Purchase Request ID not found" });
			}
				oldPurchaseRequest.Clone(purchaseRequest);
			//saves changes to database
			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Change successful" });
		}

		public ActionResult Remove([FromBody] PurchaseRequest purchaseRequest) {
			if (purchaseRequest == null || purchaseRequest.UserID <= 0) {
				return Json(new Msg { Result = "Failure", Message = "PurchaseRequest parameter is missing or invalid" });
			}
			//if we get here, delete the purchaseRequest
			PurchaseRequest removePurchaseRequest = db.PurchaseRequests.Find(purchaseRequest.UserID);
			if (removePurchaseRequest == null) {
				return Json(new Msg { Result = "Failure", Message = "PurchaseRequest ID not found" });
			}
			db.PurchaseRequests.Remove(removePurchaseRequest);
			//saves changes to database
			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Remove successful" });
		}



		#region MVC Methods

		// GET: PurchaseRequests
		public ActionResult Index()
        {
            var purchaseRequests = db.PurchaseRequests.Include(p => p.User);
            return View(purchaseRequests.ToList());
        }

        // GET: PurchaseRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            if (purchaseRequest == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequest);
        }

        // GET: PurchaseRequests/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: PurchaseRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseRequestID,Description,Justification,DateNeeded,DeliveryMode,Status,Total,SubmittedDate,UserID")] PurchaseRequest purchaseRequest)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRequests.Add(purchaseRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", purchaseRequest.UserID);
            return View(purchaseRequest);
        }

        // GET: PurchaseRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            if (purchaseRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", purchaseRequest.UserID);
            return View(purchaseRequest);
        }

        // POST: PurchaseRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseRequestID,Description,Justification,DateNeeded,DeliveryMode,Status,Total,SubmittedDate,UserID")] PurchaseRequest purchaseRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", purchaseRequest.UserID);
            return View(purchaseRequest);
        }

        // GET: PurchaseRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            if (purchaseRequest == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequest);
        }

        // POST: PurchaseRequests/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            db.PurchaseRequests.Remove(purchaseRequest);
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
