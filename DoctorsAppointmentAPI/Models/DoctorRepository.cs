using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsAppointmentAPI.Models
{
    public class DoctorRepository:IDoctorRepository
    {
        static private List<Doctor> doctors = new List<Doctor>();
        SqlConnection con;
        SqlCommand com;
        SqlDataReader reader;
  //      public static string conString;
      

        public DoctorRepository(string conString)
        {
            con = new SqlConnection(conString);
            con.Open();
        }

        public List<Doctor> GetDoctors()
        {
            return doctors;
        }

        public Doctor GetDoctor(int doctorId)
        {
            var doctor = doctors.FirstOrDefault(t => t.DoctorId == doctorId);
            return doctor;
        }


        public int AddDoctor(Doctor doctor)
        {
            com = new SqlCommand("insert into Doctors(DoctorNAme,Email,Mobile,City,SpecializedIn) values('" + doctor.DoctorName + "','" + doctor.Email + "'," + doctor.Mobile + ",'" + doctor.City + "','" + doctor.SpecializedIn + "')", con);
            return com.ExecuteNonQuery();
        }

    }
}
