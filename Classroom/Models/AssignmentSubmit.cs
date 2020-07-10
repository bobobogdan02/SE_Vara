using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models
{
    public class AssignmentSubmit
    {
        public int Id { get; set; }
        public Assignment assignment { get; set; }

        public User user { get; set; }

        public string content { get; set; }
    }
}
