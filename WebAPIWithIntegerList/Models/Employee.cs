using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWithIntegerList.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        private static List<Employee> employees = new List<Employee>() { new Employee() { Id = 1, FirstName = "Dhivya" }, new Employee() { Id = 2, FirstName = "Aabha" } };

        public List<Employee> GetEmployees()
        {
            return employees;
        }
            
    }
}
