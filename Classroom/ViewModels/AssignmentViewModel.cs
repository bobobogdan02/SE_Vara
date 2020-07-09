using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.ViewModels
{
    public class AssignmentViewModel
    {
        public Assignment assignment { get; set; }

        public Class course { get; set; }
    }
}
