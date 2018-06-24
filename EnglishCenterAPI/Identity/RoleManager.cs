using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishCenterAPI.Models;

namespace EnglishCenterAPI.Identity
{
    public class RoleManager
    {
        private englishcenterContext _context;
        public RoleManager(englishcenterContext context)
        {
            _context = context;
        }
    }
}
