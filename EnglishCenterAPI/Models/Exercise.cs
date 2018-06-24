using System;
using System.Collections.Generic;

namespace EnglishCenterAPI.Models
{
    public partial class Exercise
    {
        public int IdExercise { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? IdCourse { get; set; }

        public Course IdCourseNavigation { get; set; }
    }
}
