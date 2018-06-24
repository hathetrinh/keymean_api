using System;
using System.Collections.Generic;

namespace EnglishCenterAPI.Models
{
    public partial class Comment
    {
        public Comment()
        {
            UserComment = new HashSet<UserComment>();
        }

        public int IdComment { get; set; }
        public string Content { get; set; }

        public ICollection<UserComment> UserComment { get; set; }
    }
}
