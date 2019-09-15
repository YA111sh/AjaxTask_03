using AjaxTask3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxTask3.Controllers
{
    public class HomeController : Controller
    {
        DepartmentDataEntities db = new DepartmentDataEntities();
        public ActionResult Index()
        {
            List<CountryMaster> CountryList = db.CountryMasters.ToList();
            ViewBag.CountryList = new SelectList(CountryList, "CountryId", "CountryName");
            return View();
        }
        public JsonResult GetStateList(int CountryId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<StateMaster> StateList = db.StateMasters.Where(x => x.RefCountryId == CountryId).ToList();
            return Json(StateList, JsonRequestBehavior.AllowGet);
        }

        
    }
}