using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcToDoList.Models;

namespace mvcToDoList.Controllers
{
    public class TodosController : Controller
    {
        private TodosDBContext db = new TodosDBContext();

        // GET: Todos
        public ActionResult Index()
        {
            return View(db.Todo.ToList());
        }

        // GET: Todos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todos todos = db.Todo.Find(id);
            if (todos == null)
            {
                return HttpNotFound();
            }
            return View(todos);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DueDate,Attributes,Priority")] Todos todos)
        {
            if (ModelState.IsValid)
            {
                db.Todo.Add(todos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todos);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todos todos = db.Todo.Find(id);
            if (todos == null)
            {
                return HttpNotFound();
            }
            return View(todos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DueDate,Attributes,Priority")] Todos todos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todos);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todos todos = db.Todo.Find(id);
            if (todos == null)
            {
                return HttpNotFound();
            }
            return View(todos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Todos todos = db.Todo.Find(id);
            db.Todo.Remove(todos);
            db.SaveChanges();
            return RedirectToAction("Index");
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
