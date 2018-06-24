using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishCenterAPI.Models;

namespace EnglishCenterAPI.Repository
{
    //public class Repository
    //{
    //    public IBaseUnitOfWork<englishcenterContext> UnitOfWork { get; private set; }
    //    public IServiceProvider ServiceProvider { get; private set; }
    //    public Repository(IBaseUnitOfWork<englishcenterContext> unitOfWork, IServiceProvider serviceProvider)
    //    {
    //        UnitOfWork = UnitOfWork;
    //        ServiceProvider = serviceProvider;
    //    }

    //    private IRoleRepository _RoleRepository;
    //    public IRoleRepository RoleRepository
    //    {
    //        get
    //        {
    //            return _RoleRepository ??
    //            (_RoleRepository = ServiceProvider.GetService<IRoleRepository>());
    //        }
    //    }

    //    private IUserRepository _UserRepository;
    //    public IUserRepository UserRepository
    //    {
    //        get
    //        {
    //            return _UserRepository ??
    //            (_UserRepository = ServiceProvider.GetService<IUserRepository>());
    //        }
    //    }

    //    private IUserRoleRepository _UserRoleRepository;
    //    public IUserRoleRepository UserRoleRepository
    //    {
    //        get
    //        {
    //            return _UserRoleRepository ??
    //            (_UserRoleRepository = ServiceProvider.GetService<IUserRoleRepository>());
    //        }
    //    }
    //}
    public partial class UserRepository : BaseRepository<User, englishcenterContext>, IUserRepository
    {
        protected override int GetKeyId(User model)
        {
            return model.IdUser;
        }
    }

    public partial class RoleRepository : BaseRepository<Role, englishcenterContext>, IRoleRepository
    {
        protected override int GetKeyId(Role model)
        {
            return model.IdRole;
        }
    }

    public partial class UserRoleRepository : BaseRepository<UserRole, englishcenterContext>, IUserRoleRepository
    {
        protected override int GetKeyId(UserRole model)
        {
            return model.Id;
        }
    }
}
