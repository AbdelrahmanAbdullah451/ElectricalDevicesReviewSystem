using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewArena.Controllers
{
    public class LikesController : Controller
    {
        // GET: Likes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Likes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Likes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Likes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Likes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Likes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Likes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Likes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
