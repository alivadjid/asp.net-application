using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreditCalculator.Models;
using CreditCalculator.Service;

namespace CreditCalculator.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home/Index 
        public ActionResult Index()
        {
            return View();
        }

        //POST: Home/Index
        [HttpPost]
        public ActionResult Index(CreditModel creditData)
        {
            if (ModelState.IsValid)
            {
                Calc calculator = new Calc();
                double annuity = calculator.Annuitet(creditData.Amount, creditData.Time, creditData.Term);
                TempData["annuitet"] = annuity;
                TempData["items"] = calculator.GetItemsByMonth(creditData.Amount, creditData.Time, annuity, creditData.Term);

                TempData["overpayments"] = calculator.OverPayments(creditData.Amount, creditData.Time, annuity);
                TempData["total"] = calculator.Total(creditData.Amount, creditData.Time, annuity);

                return RedirectToAction("Table");
            }

            return View(creditData);
        }

        // GET: Home/Table
        public ActionResult Table()
        {
            var items = TempData["items"] as List<PaymentModel>;
            ViewBag.Total = TempData["total"];
            ViewBag.Overs = TempData["overpayments"];
            ViewBag.Annuitet = TempData["annuitet"];
            if (items != null && ViewBag.Overs != null && ViewBag.Total != null)
            {
                return View(items);
            }

            return HttpNotFound();
        }
    }
}