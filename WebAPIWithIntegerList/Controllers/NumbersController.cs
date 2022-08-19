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
    public class NumbersController : ControllerBase
    {

        public IActionResult Get()
        {
            Numbers obj = new Numbers();
            return Ok(obj.Get());
        }

        [HttpPost("{number}")]
        public IActionResult Post(int number)
        {
            Numbers obj = new Numbers();
            List<int> numbers = obj.Get();
            numbers.Add(number);
            return Created("",numbers);

        }
    }
}
