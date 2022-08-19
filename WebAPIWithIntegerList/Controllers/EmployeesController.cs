using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithIntegerList.Models;

namespace WebAPIWithIntegerList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        public IActionResult Get()
        {
            Employee employee = new Employee();
            return Ok(employee.GetEmployees());
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            Employee emp = new Employee();
            emp.GetEmployees().Add(employee);
            return Created("", emp.GetEmployees());
        }



    }
}
