using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishCenterAPI.Models;

namespace EnglishCenterAPI.Repository
{
    public partial interface IUserRepository : IBaseRepository<User> { }
    public partial interface IRoleRepository : IBaseRepository<Role> { }
    public partial interface IUserRoleRepository : IBaseRepository<UserRole> { }
}
