using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishCenterAPI.Repository
{
    public interface IBaseUnitOfWork<K> where K : DbContext
    {
        K DbContext { get; }
        void Commit();
    }
}
