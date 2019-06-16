using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model.Tables
{
  public  class Tbl_Discount
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Discount Title")]
        [Required(AllowEmptyStrings =false,ErrorMessage = "please enter {0}")]
        public string  Title { get; set; }
        [Display(Name = "Discount Count")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public int  Count { get; set; }
        [Display(Name = "Date To Enable")]
        public DateTime StartTime { get; set; }
        [Display(Name = "Date To Disable")]
        public DateTime EndTime { get; set; }
        [Display(Name = "Discount Type ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public int Type { get; set; }
        [Display(Name = "Percent of Discount")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        [Range(0,100,ErrorMessage ="Out Of Range")]
        public int Percent { get; set; }
        [Display(Name = "Price of Discount")]
        public decimal Price { get; set; }
        [Display(Name = "Is Specific Discount")]
        public bool IsSpecific { get; set; }
        [Display(Name = "path ways that contain discount")]
        public string PathWays { get; set; }
    }
}
