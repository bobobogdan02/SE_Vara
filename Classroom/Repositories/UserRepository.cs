using Classroom.Interfaces;
using Classroom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext _appDbContext)
        {
            this._appDbContext = _appDbContext;
        }
        public void Add(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

        public bool UserBelongsToClassroom(int courseId, string userId)
        {
            var userClass = _appDbContext.UserClasses.Include(a => a.User).Include(a => a.Class).Where(a => a.User.UserId == userId && a.Class.Id == courseId).SingleOrDefault();
            if (userClass == null)
                return false;
            return true;
        }
        public User GetByUserId(string userId)
        {
            return _appDbContext.Users.Where(a => a.UserId == userId).SingleOrDefault();
        }

        public void AddUserToClass(UserClass userClass)
        {
            _appDbContext.UserClasses.Add(userClass);
            _appDbContext.SaveChanges();
        }
    }
}
