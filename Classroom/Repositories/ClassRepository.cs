using Classroom.Interfaces;
using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Repositories
{
    public class ClassesRepository : IClassRepository
    {
        private readonly DatabaseContext _appDbContext;
        public ClassesRepository(DatabaseContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddClass(Class @class)
        {
            _appDbContext.Classes.Add(@class);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Class> Classes => _appDbContext.Classes;
    }
}
