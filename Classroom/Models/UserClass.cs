using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models
{
    public class UserClass
    {
        public int Id { get; set; }
        public Class Class { get; set; }
        public User User { get; set; }
    }
}
