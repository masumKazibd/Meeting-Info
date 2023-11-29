using Meeting_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting_Management.Controllers
{
    public class TaskController : Controller
    {
        MeetingInfoDbContext db = new MeetingInfoDbContext();
        public ActionResult Index()
        {
            ViewBag.Names = db.Corporate_Custoer_Tbl.ToList();
            return View();
        }
    }
}