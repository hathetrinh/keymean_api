using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnglishCenterAPI.Models
{
    public partial class User
    {
        public User()
        {
            Rating = new HashSet<Rating>();
            UserClass = new HashSet<UserClass>();
            UserComment = new HashSet<UserComment>();
            UserOrder = new HashSet<UserOrder>();
            UserRole = new HashSet<UserRole>();
        }

        public int IdUser { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        public string Code { get; set; }
        public string Pol { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Rating> Rating { get; set; }
        public ICollection<UserClass> UserClass { get; set; }
        public ICollection<UserComment> UserComment { get; set; }
        public ICollection<UserOrder> UserOrder { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
