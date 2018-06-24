using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishCenterAPI.Repository
{
    public class BaseUnitOfWork<K> : IBaseUnitOfWork<K>
        where K : DbContext
    {
        public UserRepository _userReposiory;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userReposiory == null)
                    _userReposiory = new UserRepository();
                return _userReposiory;
            }
        }
        public RoleRepository _roleReposiory;
        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleReposiory == null)
                    _roleReposiory = new RoleRepository();
                return _roleReposiory;
            }
        }
        public UserRoleRepository _userRoleReposiory;
        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userRoleReposiory == null)
                    _userRoleReposiory = new UserRoleRepository();
                return _userRoleReposiory;
            }
        }

        public BaseUnitOfWork(K dataContext)
        {
            this.DbContext = dataContext;
        }
        public K DbContext { get; private set; }

        public void Commit()
        {
            this.DbContext.ChangeTracker.DetectChanges();
            this.DbContext.SaveChanges();
        }
    }
}
