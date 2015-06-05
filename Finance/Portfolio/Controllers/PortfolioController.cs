using DataLayer.Entities;
using Portfolio.DataAccess;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        private PortfolioHistories _dataAccess = new PortfolioHistories();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create", new PortfolioHistory());
        }

        [HttpPost]
        public ActionResult Create(PortfolioHistory ph)
        {
            return RedirectToAction("Index");
        }

        public ActionResult GetGridData(string sidx, string sord)
        {
            var sortExpression = sidx + " " + sord;
            var totalRecords = 0;

            var items = _dataAccess.GetAll();
            totalRecords = items.Count();

            var itemList = items.ToList();

            var itemData = new
            {
                records = totalRecords,
                rows = (from o in itemList
                        select new
                        {
                            id = o.MarketDate.ToString(),
                            cell = new string[] {
                                o.MarketDate,
                                o.EmployerSponsored.ToString("C"),
                                o.RolloverIRA.ToString("C"),
                                o.TraditionalIRA.ToString("C"),
                                o.RothIRA.ToString("C"),
                                o.SepIRA.ToString("C"),
                                o.HSA.ToString("C")
                            }
                        }).ToArray()
            };

            return Json(itemData, JsonRequestBehavior.AllowGet);
        }
    }
}
