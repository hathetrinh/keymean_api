using System;
using System.Collections.Generic;

namespace EnglishCenterAPI.Models
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int? IdRole { get; set; }
        public int? IdUser { get; set; }

        public User IdRoleNavigation { get; set; }
        public Role IdUserNavigation { get; set; }
    }
}
