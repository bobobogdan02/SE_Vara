using Classroom.Interfaces;
using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Repositories
{
    public class AssignmentSubmitRepository : IAssignmentSubmitRepository
    {
        private readonly AppDbContext appDbContext;
        public AssignmentSubmitRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void Add(AssignmentSubmit assignmentSubmit)
        {
            appDbContext.AssignmentSubmits.Add(assignmentSubmit);
            appDbContext.SaveChanges();
        }
    }
}
