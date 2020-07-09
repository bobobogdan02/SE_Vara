using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models
{
    public class Class
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IList<Assignment> Assignments { get; set;}

        public IList<Stream> Messages { get; set; }

        public string SecurityCode { get; set; }
     
    }
}
