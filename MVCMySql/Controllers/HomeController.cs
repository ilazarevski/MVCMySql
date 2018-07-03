using log4net;
using MVCMySql.Helpers.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCMySql.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

         
        public async Task<ActionResult> Index()
        {
            //Log.Info("Start logging");
            log.Error("This could be an error");
            //MySqlConnection myConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);
            //myConnection.Open();

            //string query = "SELECT * FROM studenti WHERE elektronska_posta = 'zdravko.1611001@msu.edu.mk'";

            ////Create Command
            //MySqlCommand cmd = new MySqlCommand(query, myConnection);
            ////Create a data reader and Execute the command
            //MySqlDataReader dataReader = cmd.ExecuteReader();

            //List<string> cityList = new List<string>();

            ////Read the data and store them in the list
            //while (dataReader.Read())
            //{
            //    cityList.Add(dataReader["ime"].ToString());
            //    //list[0].Add(dataReader["id"] + "");
            //    //list[1].Add(dataReader["name"] + "");
            //    //list[2].Add(dataReader["age"] + "");
            //}

            ////close Data Reader
            //dataReader.Close();

            ////ViewBag.Info = "ServerVersion: " + myConnection.ServerVersion + "\nState: " + myConnection.State.ToString();

            //ViewBag.Info = "City: " + cityList[0].ToString();

            ////close Connection
            //myConnection.Close();

            MSU.Base.Services.AccountService accountService = new MSU.Base.Services.AccountService();

            var student = await accountService.AuthenticateAsync("zdravko.1611001@msu.edu.mk", "");

            ViewBag.Info = "Student: " + student;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}