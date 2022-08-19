using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_ADO.Net.Models;

namespace WebAPI_ADO.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        SqlConnection con;

        public EmployeesController()
        {
            string connectionString = "Server=Dhivya-pc\\SQLEXPRESS;Database=EmployeeDB;integrated security=true";

            // user id=sa;password=password-1
             con = new SqlConnection(connectionString);
            con.Open();
        }
       
        public IActionResult Get()
        {
            Department dept;
            List<Department> departments = new List<Department>();
       
            SqlCommand com = new SqlCommand("Select * from Department", con);
            SqlDataReader dataReader = com.ExecuteReader();
           while( dataReader.Read())
            {
                dept = new Department();
                dept.Id = dataReader.GetInt32(0);
                dept.Name = dataReader.GetString(1);
                dept.LocationId = (string)(dataReader["location_id"]);
                departments.Add(dept);
            }
            dataReader.Close();
            return Ok(departments);
        }

        [HttpPost("{department}")]
        public IActionResult AddDepartment([FromBody]Department department)
        {
            string insertText = "insert into Department values(" + department.Id + ",'" + department.Name + "','" + department.LocationId + "')";
            SqlCommand com = new SqlCommand(insertText, con);
       int rowsAffected    = com.ExecuteNonQuery();//Executes all the DML statements(insert,update,delete)
            if (rowsAffected>0)
            {
                return Created("", department);
            }
            else
            {
                return BadRequest("Error While Adding new Department");
            }

        }
    }
}




























