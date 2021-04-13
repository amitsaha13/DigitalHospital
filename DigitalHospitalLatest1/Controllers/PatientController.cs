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
    public class PatientController: Controller
    {

       
        // GET: /<controller>/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult User_Profile()
        {
            return View();
        }
        public ActionResult PatientSignupView()
        {
            return View();
        }
        public ActionResult PatientPrivatePage()
        {
            return View();
        }

        [HttpPost] 
       public ActionResult savePatient(PatientModel Patient_info)
        {
            String myConnectionString = ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString;
            SqlConnection connection = new SqlConnection(myConnectionString);
            PatientModel Patient = new PatientModel();
            connection.Open();
            SqlCommand com = new SqlCommand("insert into patient values('"+ Patient_info.PatientName+"','"+ Patient_info.PatientEmail + "','"+ Patient_info.Phone+ "','"+ Patient_info.Passward+ "','"+ Patient_info.PatientGender+ "')", connection);
            var count = (string)com.ExecuteScalar();
            connection.Close();
            
           return null;
        }
        public ActionResult EditData(PatientModel Edit_info)
        {
            String myConnectionString = ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString;
            SqlConnection connection = new SqlConnection(myConnectionString);
            connection.Open();
            SqlCommand com = new SqlCommand("UPDATE patient SET PatientName='"+Edit_info.PatientName+"',PatientEmail='"+Edit_info.PatientEmail+"',Phone='"+Edit_info.Phone+"',Passward='"+Edit_info.Passward+"',PatientGender='"+Edit_info.PatientGender+ "'WHERE Phone='01700000000'", connection);
          com.ExecuteScalar();

            connection.Close();
            return null;
        }

    }
}