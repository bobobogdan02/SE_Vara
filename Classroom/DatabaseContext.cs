using Classroom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Stream> StreamMessages { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserClass> UserClasses { get; set; }

        public DbSet<AssignmentSubmit> AssignmentSubmits { get; set; }

    }
}
