using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishCenterAPI.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get;}
        void SaveChanges();
    }
}
