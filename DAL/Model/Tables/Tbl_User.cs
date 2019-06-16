using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model.Tables
{
    public class Tbl_Users : IdentityUser
    {
        public string FullName { get; set; }
        public string Country { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Sex")]
        public bool Sex { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }
        #region Relations
        public ICollection<Tbl_Factore> Tbl_Factores { get; set; }
        public ICollection<Tbl_Reserve> tbl_Reserves { get; set; }
        #endregion
    }
}
