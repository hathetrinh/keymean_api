using System;
using System.Collections.Generic;

namespace EnglishCenterAPI.Models
{
    public partial class UserOrder
    {
        public int IdOrder { get; set; }
        public string Price { get; set; }
        public string PromotionCode { get; set; }
        public string Status { get; set; }
        public string DateCreate { get; set; }
        public string UserOrder1 { get; set; }
        public string Type { get; set; }
        public string DateUpdate { get; set; }
        public int? IdUser { get; set; }

        public User IdUserNavigation { get; set; }
    }
}
