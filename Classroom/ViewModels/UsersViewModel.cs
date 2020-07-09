using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<IdentityUser> Users { get; set; }

    }
}
