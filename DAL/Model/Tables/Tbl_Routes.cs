using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model.Tables
{
    public class Tbl_Routes
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Source City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public int Source_FG { get; set; }
        [Display(Name = "Destination City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public int Destination_FG { get; set; }
        [Display(Name = "Departure Days")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public string DepartureDays { get; set; }
        [Display(Name = "Departure Time")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public string DepartureTime { get; set; }
        [Display(Name = "Arrive Days")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public string ArriveDays { get; set; }
        [Display(Name = "Arrive Time")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public string ArriveTime { get; set; }
        [Display(Name = "Source Station")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public string SourceStation { get; set; }
        [Display(Name = "Destination Station")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public string DestStation { get; set; }
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public decimal Price { get; set; }
        [Display(Name = "two way price")]
        [DataType(DataType.Currency)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public decimal twoWayPrice { get; set; }
        [Display(Name = "Price2")]
        [DataType(DataType.Currency)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public decimal Price2 { get; set; }
        [Display(Name = "two way price2")]
        [DataType(DataType.Currency)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public decimal twoWayPrice2 { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }

        #region Relation
        public ICollection<Tbl_ReservCount> tbl_ReservCounts { get; set; }
        #endregion
    }
}
