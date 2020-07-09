using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        bool UserBelongsToClassroom(int courseId, string userId);

        public User GetByUserId(string userId);
        public void AddUserToClass(UserClass userClass);
    }
}
