using System;
using System.Collections.Generic;

namespace EnglishCenterAPI.Models
{
    public partial class UserComment
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public int? IdComment { get; set; }

        public Comment IdCommentNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
