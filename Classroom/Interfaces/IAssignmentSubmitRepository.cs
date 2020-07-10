using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Interfaces
{
    public interface IAssignmentSubmitRepository
    {
        void Add(AssignmentSubmit assignmentSubmit);
    }
}
