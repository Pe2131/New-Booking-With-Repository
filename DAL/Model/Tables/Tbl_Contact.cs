﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model.Tables
{
   public class Tbl_Contact
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public string Email { get; set; }
        [Display(Name = "Subject")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public string Subject { get; set; }
        [Display(Name = "text")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        [MinLength(10, ErrorMessage = "{0} must more than 5 character")]
        public string Text { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}
