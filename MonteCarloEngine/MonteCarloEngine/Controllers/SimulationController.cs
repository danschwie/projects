using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonteCarloEngine.Controllers
{
    public class SimulationController : Controller
    {
        //
        // GET: /Simulation/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Run()
        {
            return View();
        }
    }
}
