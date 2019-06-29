using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model.Tables
{
   public class Tbl_PathWay
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="Source City")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="please enter {0}")]
        public int Source_FG { get; set; }
        [Display(Name = "Destination City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public int Destination_FG { get; set; }
        [Display(Name = "Date To start")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Date to arrive")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public DateTime ArrivalDate { get; set; }
        [Display(Name = "Capacity")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public int Capacity { get; set; }
        [Display(Name = "Price for adult in Uro format")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public decimal PriceForAdultUro { get; set; }
        [Display(Name = "Price for adult in Dollar format")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public decimal PriceForAdultDollar { get; set; }
        [Display(Name = "Price for baby in Uro format")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public decimal PriceForBabyUro { get; set; }
        [Display(Name = "Price for baby in Dollar format")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public decimal PriceForBabyDollar { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        #region Relations
        public ICollection<Tbl_Factore> tbl_Factores { get; set; }
        public ICollection<Tbl_Reserve> tbl_Reserves { get; set; }
        #endregion
    }
}
