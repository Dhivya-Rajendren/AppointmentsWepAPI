using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsAppointmentAPI.Models
{
    public class Doctor
    {

        public int DoctorId { get; set; }


        public string DoctorName { get; set; }

        public string SpecializedIn { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
    }
}
