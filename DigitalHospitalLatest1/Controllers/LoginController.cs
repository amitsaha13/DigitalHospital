using DigitalHospitalLatest1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalHospitalLatest1.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult PatientLoginView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login_user(LoginModel Login_info)
        {
            string passward = null;
            String myConnectionString = ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString;
            SqlConnection connection = new SqlConnection(myConnectionString);
            connection.Open();
            SqlCommand com = new SqlCommand("select Passward from patient where Phone ='" + Login_info.Phone+"'", connection);
            SqlDataReader data = com.ExecuteReader();
            while (data.Read())
            {
                passward = data[0].ToString();
            }
            data.Close();
            connection.Close();

            if (Login_info.Passward == passward)
            {
                return RedirectToLocal("/Home/About");
            }
            else
            {
               return null;
            }

        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("PatientSignupView", "Patient");
            }
        }
    }
}