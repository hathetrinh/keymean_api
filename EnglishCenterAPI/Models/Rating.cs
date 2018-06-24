using System;
using System.Collections.Generic;

namespace EnglishCenterAPI.Models
{
    public partial class Rating
    {
        public int IdRating { get; set; }
        public int? IdUser { get; set; }
        public int? IdCourse { get; set; }
        public string Content { get; set; }
        public string Point { get; set; }

        public Course IdCourseNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
