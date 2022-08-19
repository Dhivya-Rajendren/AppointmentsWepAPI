using DoctorsAppointmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsAppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        IDoctorRepository repo;
        private readonly IConfiguration configuration;
        

        public DoctorsController(IDoctorRepository _repo,IConfiguration configuration)// Depenedency injection
        {
        //    repo = _repo;// The Controller class is takig over the control of creating objects.- Inversion of Control.
            this.configuration = configuration;
         repo= new DoctorRepository(  this.configuration.GetConnectionString("Appointments"));
        }
        public IActionResult Get()
        {
         //   repo = new DoctorRepository();
         List<Doctor> doctors=   repo.GetDoctors();
            return Ok(doctors);
        }


        [HttpGet("{doctorId}")]
        public IActionResult Get(int doctorId)
        {
            if (doctorId == 0)
            {
                return BadRequest("Doctor Id Cant be 0");
            }           
            else
            {
                var doctor = repo.GetDoctor(doctorId);
                if (doctor == null)
                {
                    return StatusCode(404, "Doctor Id Not found");
                }
                else
                {
                    return Ok(repo.GetDoctor(doctorId));
                }
            }
        }
   
        [HttpPost("AddDoctor")]
        public IActionResult AddDoctor([FromBody]Doctor doctor)
        {
          //  int countOld = repo.GetDoctors().Count;
            repo.AddDoctor(doctor);
         //   int countNew = repo.GetDoctors().Count;
          //  if (countNew>countOld)
          
                return Created("New Doctor Added",doctor);
          
        }

        [HttpPut("UpdateDoctor/{Id}")]
        public IActionResult UpdateDoctor(int Id,[FromBody]Doctor doctor)
        {
            Doctor _doctor = repo.GetDoctors().SingleOrDefault(t => t.DoctorId == Id);
            if (_doctor == null)
            {
                return NotFound("Doctor Id not found");
            }
            else
            {
                repo.GetDoctors().Remove(_doctor);
                _doctor.DoctorId = Id;
                _doctor.DoctorName = doctor.DoctorName;
                _doctor.Email = doctor.Email;
                _doctor.Mobile = doctor.Mobile;
                _doctor.SpecializedIn = doctor.SpecializedIn;
                _doctor.City = doctor.City;
                repo.GetDoctors().Add(_doctor);
                return Created("Updated ", repo.GetDoctors());
            }
        }
    
    
    }
}
