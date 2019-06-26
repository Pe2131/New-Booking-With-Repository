using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model.Tables
{
   public class Tbl_DiscountSetting
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Discount for age or student")]
        public string DisCountFor { get; set; }
        public int percent { get; set; }
    }
}
