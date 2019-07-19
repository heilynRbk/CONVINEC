using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CONVINEC.Models;

namespace CONVINEC.Controllers
{
    public class UserController : Controller
    {
        private DbModel db = new DbModel();

        // GET: User/Create
        [ActionName("Suscripcion")]
        public ActionResult Create()
        {
            ViewBag.fkOccupation = new SelectList(db.Occupation, "pkOccupation", "description");
            return View("Create");
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pkUser,email,DNI,fullName,birthdate,address,fkOccupation,isActive")] User user)
        {
            if (ModelState.IsValid)
            {
                user.isActive = true;
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Suscripcion");
            }

            ViewBag.fkOccupation = new SelectList(db.Occupation, "pkOccupation", "description", user.fkOccupation);
            return View(user);
        }

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
