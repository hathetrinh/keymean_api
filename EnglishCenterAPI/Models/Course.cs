using System;
using System.Collections.Generic;

namespace EnglishCenterAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            Classes = new HashSet<Classes>();
            Exercise = new HashSet<Exercise>();
            Rating = new HashSet<Rating>();
        }

        public int IdCourse { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? NumberOfStudent { get; set; }

        public ICollection<Classes> Classes { get; set; }
        public ICollection<Exercise> Exercise { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}
