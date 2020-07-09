using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models
{
    public class Stream
    {
        public int id { get; set; }
        public string message { get; set; }
        public Class Class { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime dateTime { get; set; }

        public int ClassId { get; set; }
    }
}
