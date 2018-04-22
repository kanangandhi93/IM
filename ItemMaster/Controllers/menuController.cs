using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItemMaster.Models;
namespace ItemMaster.Controllers
{
    public class menuController : Controller
    {
        private InventoryControlEntities db = new InventoryControlEntities();
        // GET: menu
        public ActionResult Index()
        {
            var Menus = db.Menus.Where(x => x.IsActive == true && x.ParentID == 0).ToList();
            ViewData["Menu"] = Menus;
            return View(Menus);
        }
    }
}