using System;
using System.Collections.Generic;

namespace EnglishCenterAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int IdRole { get; set; }
        public string Name { get; set; }

        public ICollection<UserRole> UserRole { get; set; }
    }
}
