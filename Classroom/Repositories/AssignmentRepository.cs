using Classroom.Interfaces;
using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Repositories
{
    public class AssignmentRepository:IAssignmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public AssignmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddAssignment(Assignment assignment)
        {
            _appDbContext.Assignments.Add(assignment);
            _appDbContext.SaveChanges();
        }

    }
}
