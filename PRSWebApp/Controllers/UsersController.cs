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
    public class UsersController : Controller
    {
        private PRSWebAppContext db = new PRSWebAppContext();

		public ActionResult Login(string UserName, string Password) {
			User user = db.Users.SingleOrDefault(u => u.UserName == UserName && u.Password == Password);
			return Json(user, JsonRequestBehavior.AllowGet);
		}

		//performs Json call to return list of Users
		//this will always return an array
		//it may have 0, 1, or more items within the array
		public ActionResult List() {
			return Json(db.Users.ToList(), JsonRequestBehavior.AllowGet);
		}

		// Users/UserID
		// will return a user or an error message
		public ActionResult Get(int? id) {
			//if nothing is passed in for ID
			if (id == null) {
				return Json(new Msg { Result = "Failure", Message = "ID is null" }, JsonRequestBehavior.AllowGet);
			}

			//returns a user or an error message
			User user = db.Users.Find(id);
			//if id is not found when find is issued, you get this message as an array
			if (user == null) {
				return Json(new Msg { Result = "Failure", Message = "ID not found" }, JsonRequestBehavior.AllowGet);
			}
			//no errors, we have a user
			return Json(user, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Add([FromBody] User user) {
			if (user == null || user.UserName == null) {
				return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" });
			}
			if (user.UserName.Length < 8 || user.UserName.Length > 16) {
				return Json(new Msg { Result = "Failure", Message = "Username must be between 8 and 16 characters" });
			}

			if (user.Password.Length < 8 || user.Password.Length > 32) {
				return Json(new Msg { Result = "Failure", Message = "Password must be between 8 and 32 characters" });
			}

			if (user.Password.Length > 30) {
				return Json(new Msg { Result = "Failure", Message = "Password must be between 8 and 32 characters" });
			}
			// if we get here, add user
			db.Users.Add(user);
			//saves changes to database - add try and catch

			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Add successful" });
		}

		public ActionResult Change([FromBody] User user) {
			if (user == null || user.UserName == null) {
				return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" });
			}
			// if we get here, update user
			// were choosing this because its consistent with other functions??
			User oldUser = db.Users.Find(user.UserID);
			oldUser.UserName = user.UserName;
			oldUser.Password = user.Password;
			oldUser.FirstName = user.FirstName;
			oldUser.LastName = user.LastName;
			oldUser.Phone = user.Phone;
			oldUser.Email = user.Email;
			oldUser.IsReviewer= user.IsReviewer;
			oldUser.IsAdmin = user.IsAdmin;
			//saves changes to database
			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Change successful" });
		}

		public ActionResult Remove([FromBody] User user) {
			if (user == null || user.UserID <= 0) {
				return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" });
			}
			//if we get here, delete the user
			User removeUser = db.Users.Find(user.UserID);
			if (removeUser == null) {
				return Json(new Msg { Result = "Failure", Message = "User ID not found" });
			}
			db.Users.Remove(removeUser);
			//saves changes to database
			db.SaveChanges();
			return Json(new Msg { Result = "Success", Message = "Remove successful" });
		}

		//region tag allows you group code and hide to make code display cleaner
		#region MVC Methods

		// GET: Users
		public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Username,Password,FirstName,LastName,Phone,Email,IsReviewer,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Username,Password,FirstName,LastName,Phone,Email,IsReviewer,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
