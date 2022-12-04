using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;

namespace tp4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\souma\Downloads\database.db;");
            con.Open();
            String query = "SELECT * FROM personal_info ";
            using (con)
            {
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        String first_name = (string)reader["first_name"];
                        String last_name = (string)reader["last_name"];
                        String email = (string)reader["email"];
                        //DateOnly dateofbirth = (DateOnly)reader["date_birth"];
                        String image = (string)reader["image"];
                        String country = (string)reader["country"];
                        Debug.WriteLine("Id : "+id + " First name : "+first_name+ " Last name : "+ last_name+ " Email : "+email+ " Country : "+country+ " image : "+image+  "  Date of birth : ");
                    }
                }
            }
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