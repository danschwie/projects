using Portfolio.DataAccess;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private const string CONN_STRING = @"Data Source=C:\Users\dschwie\Desktop\working\projects\Finance\db\Finance.db;Version=3;";

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var da = new PortfolioHistories();
            var histories = da.GetAll().ToList();

            //try
            //{
            //    var conn = new SQLiteConnection(CONN_STRING);
            //    conn.Open();

            //    var sql = new StringBuilder("INSERT INTO PortfolioHistory (market_date, employer_sponsored, rollover_ira, traditional_ira, roth_ira, sep_ira, hsa) ");
            //    sql.Append("VALUES ('2/9/2015', '130624.64', '123639.85', '6402.27', '9967.53', '3163', '2497')");

            //    var command = new SQLiteCommand(sql.ToString(), conn);
            //    command.ExecuteNonQuery();
            //}
            //catch(Exception ex)
            //{
            //    var message = ex.Message;
            //}

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
