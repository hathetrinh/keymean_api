using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishCenterAPI.Models;

namespace EnglishCenterAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private englishcenterContext _context;
        private UserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public UnitOfWork(englishcenterContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
