using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ItemMaster.Models;

namespace ItemMaster.Controllers
{
    public class ItemGroupsController : Controller
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: ItemGroups
        public ActionResult Index()
        {
            var itemGroups = db.ItemGroups.Include(i => i.Company).Include(i => i.ItemGroup2);
            return View(itemGroups.ToList());
        }

        // GET: ItemGroups/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemGroup itemGroup = db.ItemGroups.Find(id);
            if (itemGroup == null)
            {
                return HttpNotFound();
            }
            return View(itemGroup);
        }

        // GET: ItemGroups/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Code");
            ViewBag.ParentGroupID = new SelectList(db.ItemGroups, "ID", "Code");
            return View();
        }

        // POST: ItemGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,Code,Name,ParentGroupID")] ItemGroup itemGroup)
        {
            if (ModelState.IsValid && itemGroup.ParentGroupID > 0)
            {
                db.ItemGroups.Add(itemGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Code", itemGroup.CompanyID);
            ViewBag.ParentGroupID = new SelectList(db.ItemGroups, "ID", "Code", itemGroup.ParentGroupID);
            return View(itemGroup);
        }

        // GET: ItemGroups/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemGroup itemGroup = db.ItemGroups.Find(id);
            if (itemGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Code", itemGroup.CompanyID);
            ViewBag.ParentGroupID = new SelectList(db.ItemGroups, "ID", "Code", itemGroup.ParentGroupID);
            return View(itemGroup);
        }

        // POST: ItemGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,Code,Name,ParentGroupID")] ItemGroup itemGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Code", itemGroup.CompanyID);
            ViewBag.ParentGroupID = new SelectList(db.ItemGroups, "ID", "Code", itemGroup.ParentGroupID);
            return View(itemGroup);
        }

        // GET: ItemGroups/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemGroup itemGroup = db.ItemGroups.Find(id);
            if (itemGroup == null)
            {
                return HttpNotFound();
            }
            return View(itemGroup);
        }

        // POST: ItemGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ItemGroup itemGroup = db.ItemGroups.Find(id);
            db.ItemGroups.Remove(itemGroup);
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
