using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using CurrentBill.Models;

namespace CurrentBill.Controllers
{
    public class BillController : Controller
    {
        public IActionResult Index()
        {
          return View();
        }
        [HttpPost]
        public IActionResult Index(BillModel b1)
        {
            TempData["meterno"] = b1.MeterNo;
            TempData["name"] = b1.Name;
            TempData["pr"] = b1.prevReading;
            TempData["cr"] = b1.currReading;


            return RedirectToAction("ShowBill");
        }
        
        public IActionResult ShowBill(BillModel b)
        {
            if (TempData.ContainsKey("meterno"))
            {
              b.MeterNo   = (int)TempData["meterno"];
               
            }
            if (TempData.ContainsKey("name"))
            {
                b.Name = TempData["name"].ToString();

            }
            if (TempData.ContainsKey("pr"))
            {
                b.prevReading = (int)TempData["pr"];

            }
            if (TempData.ContainsKey("cr"))
            {
                b.currReading = (int)TempData["cr"];

            }



            b.billedUnits = b.currReading - b.prevReading;
            if (b.billedUnits > 0 && b.billedUnits < 100)
            {
                b.unitPrice = 2;
            }
            else
                b.unitPrice = 3;

            b.billAmount = b.billedUnits * b.unitPrice;
            b.surcharge = (0.02 * b.billAmount);
            b.netBill = b.billAmount + b.surcharge;
           // ViewBag.Bill = b.netBill;
            
            ViewBag.Bill = b.netBill;
            return View(b);
            // return View();
        }
    }
}
