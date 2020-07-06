using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models
{
    public class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public List<Class> Classes { get; set; }
    }
}
