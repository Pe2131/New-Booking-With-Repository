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
        public int ForChild0 { get; set; }
        public int ForChild2 { get; set; }
        public int ForChild7 { get; set; }
        public int forStudent { get; set; }
        public int ForTwoWay { get; set; }

    }
}
