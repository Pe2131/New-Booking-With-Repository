using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model.Tables
{
   public class Tbl_Setting
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "site title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public string Title { get; set; }
        [Display(Name = "slogan")]
        public string Slogan { get; set; }

        [Display(Name = "Describtion Of site")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public string Description { get; set; }

        [Display(Name = "Smtp Mail")]
        public string Smpt { get; set; } //smtp.gmail.com

        [Display(Name = "Email ")]
        [RegularExpression(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$")]
        public string Email { get; set; } 

        [Display(Name = "Email Pass")]
        public string EmailPwd { get; set; } //pwd

        [Display(Name = "Element Per Page")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public string PageNumber { get; set; }

        [Display(Name = "Sms Number")]
        public string SmsNumber { get; set; }

        [Display(Name = "Sms Service")]
        public string SmsApiService { get; set; }

        [Display(Name = "Sms Secret Key")]
        public string SmsSecretKey { get; set; }

        [Display(Name = "Contact Us")]
        public string ContactUs { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        public string CopyRight { get; set; }
        public string  instagrm { get; set; }
        public string facebook  { get; set; }
        public string linkedin  { get; set; }
        public string twitter { get; set; }
        public string  Logo { get; set; }
        public string PanelLogo { get; set; }
        public string AboutImag1 { get; set; }
        public string AboutImag2 { get; set; }


    }
}
