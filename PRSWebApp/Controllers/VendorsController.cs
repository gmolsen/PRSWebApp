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
    public class VendorsController : Controller
    {
        private PRSWebAppContext db = new PRSWebAppContext();

		//performs Json call to return list of Vendors
		//this will always return an array
		//it may have 0, 1, or more items within the array
		public ActionResult List() {
			return Json(db.Vendors.ToList(), JsonRequestBehavior.AllowGet);
		}

		// Vendors/VendorsID
		// will return a vendor or an error message
		public ActionResult Get(int? id) {
			//if nothing is passed in for ID
			if (id == null) {
				return Json(new Msg { Result = "Failure", Message = "ID is null" }, JsonRequestBehavior.AllowGet);
			}

			//returns a vendor or an error message
			Vendor vendor = db.Vendors.Find(id);
			//if id is not found when find is issued, you get this message as an array
			if (vendor == null) {
				return Json(new Msg { Result = "Failure", Message = "ID not found" }, JsonRequestBehavior.AllowGet);
			}
			//no errors, we have a vendor
			return Json(vendor, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Add([FromBody] Vendor vendor) {
			if (vendor == null || vendor.Code == null) {
				return Json(new Msg { Result = "Failure", Message = "Vendor parameter is missing or invalid" });
			}
			// if we get here, add vendor
			db.Vendors.Add(vendor);
			//saves changes to database
			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Add successful" });
		}

		public ActionResult Change([FromBody] Vendor vendor) {
			if (vendor == null || vendor.Code == null) {
				return Json(new Msg { Result = "Failure", Message = "Vendor parameter is missing or invalid" });
			}
			// if we get here, update vendor
			// were choosing this because its consistent with other functions??
			Vendor oldVendor = db.Vendors.Find(vendor.VendorID);
			oldVendor.Name = vendor.Name;
			oldVendor.Code = vendor.Code;
			oldVendor.Address = vendor.Address;
			oldVendor.City = vendor.City;
			oldVendor.State = vendor.State;
			oldVendor.Zip = vendor.Zip;
			oldVendor.Phone = vendor.Phone;
			oldVendor.Email = vendor.Email;
			oldVendor.IsPreapproved = vendor.IsPreapproved;
			//saves changes to database
			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Change successful" });
		}

		public ActionResult Remove([FromBody] Vendor vendor) {
			if (vendor == null || vendor.VendorID <= 0) {
				return Json(new Msg { Result = "Failure", Message = "Vendor parameter is missing or invalid" });
			}
			//if we get here, delete the vendor
			Vendor removeVendor = db.Vendors.Find(vendor.VendorID);
			if (removeVendor == null) {
				return Json(new Msg { Result = "Failure", Message = "Vendor ID not found" });
			}
			db.Vendors.Remove(removeVendor);
			//saves changes to database
			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Remove successful" });
		}

		#region MVC Methods

		// GET: Vendors
		public ActionResult Index()
        {
            return View(db.Vendors.ToList());
        }

        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorID,Code,Name,Address,City,State,Zip,Phone,Email,Preapproved")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorID,Code,Name,Address,City,State,Zip,Phone,Email,Preapproved")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
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
