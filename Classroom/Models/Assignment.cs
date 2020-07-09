using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models
{
    public class Assignment
    {
        public int id { get; set; }
        public Class course { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int grade { get; set; }
        public DateTime deadline { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
