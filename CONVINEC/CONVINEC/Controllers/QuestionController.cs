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
    public class QuestionController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Question
        public ActionResult Index()
        {
            var question = db.Question.Include(q => q.Topic);
            return View(question.ToList());
        }

        // GET: Question/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            ViewBag.description = question.description;
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            ViewBag.fkTopic = new SelectList(db.Topic, "pkTopic", "description");
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pkQuestion,fkTopic,fullName,date,tittle,description,isActive")] Question question)
        {
            if (ModelState.IsValid)
            {
                question.isActive = true;
                db.Question.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkTopic = new SelectList(db.Topic, "pkTopic", "description", question.fkTopic);
            return View(question);
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
