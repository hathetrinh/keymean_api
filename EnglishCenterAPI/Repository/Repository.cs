using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishCenterAPI.Models;

namespace EnglishCenterAPI.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(englishcenterContext context) : base (context) { }
    }
}
