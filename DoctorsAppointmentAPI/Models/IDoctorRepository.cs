using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsAppointmentAPI.Models
{
   public interface IDoctorRepository
    {
     // static  string conString;
        List<Doctor> GetDoctors();
        Doctor GetDoctor(int doctorId);
        int AddDoctor(Doctor doctor);
    }
}
