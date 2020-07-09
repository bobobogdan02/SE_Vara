using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.ViewModels
{
    public class ClassAssignmentViewModel
    {
        public IList<Assignment> Assignments { get; set; }

        public Class @class { get; set; }
    }
}
