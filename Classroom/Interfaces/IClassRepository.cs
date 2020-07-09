using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Interfaces
{
    public interface IClassRepository
    {
        public void AddClass(Class @class);
        IEnumerable<Class> Classes { get; }
        public Class GetById(int classId);
    }
}
