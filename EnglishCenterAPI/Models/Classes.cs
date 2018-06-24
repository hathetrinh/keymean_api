using System;
using System.Collections.Generic;

namespace EnglishCenterAPI.Models
{
    public partial class Classes
    {
        public Classes()
        {
            UserClass = new HashSet<UserClass>();
        }

        public int IdClass { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Location { get; set; }
        public int? IdCourse { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public Course IdCourseNavigation { get; set; }
        public ICollection<UserClass> UserClass { get; set; }
    }
}
