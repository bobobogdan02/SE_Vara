using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classroom.Interfaces;
using Classroom.Models;

namespace Classroom.Repositories
{
    public class StreamRepository : IStreamRepository
    {
        private readonly AppDbContext _appDbContext;

        public StreamRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddMessage(Stream stream)
        {
            _appDbContext.Add(stream);
            _appDbContext.SaveChanges();
        }

    }
}
