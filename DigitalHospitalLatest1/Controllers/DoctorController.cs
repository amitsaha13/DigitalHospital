using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalHospitalLatest1.Models;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DigitalHospitalLatest1.Controllers
{
    public class DoctorController:Controller
    {
        [HttpGet]
        public List<DoctorModel> GetAllDoctors()
        {

            String myConnectionString = ConfigurationManager.ConnectionStrings["projectDatabase"].ConnectionString;
            SqlConnection connection = new SqlConnection(myConnectionString);
            DoctorModel adoctor = new DoctorModel();
            List<DoctorModel> doctors = new List<DoctorModel>();
            connection.Open();
            
            SqlCommand cmd = new SqlCommand("select * from Doctor", connection);
            
            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            
            DataSet ds = new DataSet();
            da.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                //RR_ID.Add(int.Parse(row.ItemArray.GetValue(0).ToString()));
                adoctor.Doctor_name = row["Doctor_name"].ToString();
                adoctor.Doctor_email = row["Doctor_email"].ToString();
                adoctor.Doctor_phone = row["Doctor_phone"].ToString();
                adoctor.Doctor_gender = row["Doctor_gender"].ToString();
                adoctor.Doctor_field = row["Doctor_field"].ToString();

                doctors.Add(adoctor);
            }           

            connection.Close();
            return doctors;

        }
    }
}