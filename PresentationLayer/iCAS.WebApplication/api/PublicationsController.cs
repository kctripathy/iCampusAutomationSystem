using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCon.iCAS.WebApplication.api
{
    public class PublicationsController : Controller
    {
        //
        // GET: /Publications/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Publications/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Publications/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Publications/Create
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

        //
        // GET: /Publications/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Publications/Edit/5
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

        //
        // GET: /Publications/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Publications/Delete/5
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
