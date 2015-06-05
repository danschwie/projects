using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JSONPClient.Results;

namespace JSONPServer.Controllers
{
    public class JSONPController : Controller
    {
        public JsonpResult GetJSON()
        {
            //JsonpResult result = new JsonpResult("HELLO WORLD from JSONPServer!", JsonRequestBehavior.AllowGet);
            JsonpResult result = new JsonpResult("HELLO WORLD from JSONPServer!");
            return result;
        }
    }
}
