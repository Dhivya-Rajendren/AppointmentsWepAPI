using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWithIntegerList.Models
{
    public class Numbers
    {

        public int Number { get; set; }

        private static List<int> lstNumbers = new List<int>() { 1, 2, 3, 4 };

        public List<int> Get()
        {
            return lstNumbers;
        }
    }
}
