using System;
using System.Collections.Generic;

namespace EnglishCenterAPI.Models
{
    public partial class UserClass
    {
        public int IdUserClass { get; set; }
        public int? IdUser { get; set; }
        public int? IdClass { get; set; }

        public Classes IdClassNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
