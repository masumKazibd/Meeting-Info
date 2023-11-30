using Meeting_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var personType = Request.Form["PersonType"];

            //Customer Name
            //if (personType == "Individual")
            //{
            //    ViewBag.CustomerNames = db.Individual_Customer_Tbl.Select(c => c.Individual_Customer_Name).ToList();
            //}
            //else if (personType == "Corporate")
            //{
            //    ViewBag.CustomerNames = db.Corporate_Custoer_Tbl.Select(c => c.Corporate_Custoer_Name).ToList();
            //}
            ViewBag.CustomerNames = db.Corporate_Custoer_Tbl.Select(c => c.Corporate_Custoer_Name).ToList();
            //ViewBag.IndividualCustomerNames = db.Individual_Customer_Tbl.Select(c=>c.Individual_Customer_Name).ToList();

            //ViewBag.CorporateCustomerNames = db.Corporate_Custoer_Tbl.Select(c=>c.Corporate_Custoer_Name).ToList();

            //Service or Product

            return View();
        } 
        public ActionResult Details()
        {
            ViewBag.ProductNames = db.Products_Service_Tbl.Select(c => c.Products_Service_Name).ToList();
            return PartialView("_Details");
        }

        [HttpPost]
        public ActionResult save(string selectedProduct)
        {
            ViewBag.Unit = db.Products_Service_Tbl.Where(x => x.Products_Service_Name == selectedProduct).Select(c => c.Unit).FirstOrDefault();
            return (ViewBag.Unit); 
        }
        //[HttpPost]
        //public void onProductChange(string selectedProduct)
        //{
        //    // Your logic here
        //    Console.WriteLine("Product Changed: " + selectedProduct);
        //    ViewBag.Unit = db.Products_Service_Tbl.Where(x => x.Products_Service_Name == selectedProduct).Select(c => c.Unit).FirstOrDefault();
        //    //return (ViewBag.Unit);
        //}
        //[HttpPost]
        //public ActionResult onProductChange(string selectedProduct)
        //{
        //    ViewBag.Unit = db.Products_Service_Tbl.Where(x => x.Products_Service_Name == selectedProduct).Select(c => c.Unit).FirstOrDefault();
        //    return (ViewBag.Unit);
        //}

    }
}