using Booking_Web.Controllers;
using DAL.Model;
using DAL.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.ViewModel
{
    public class ViewModel_Reserve
    {
        public int Id { get; set; }
        public string SourceName { get; set; }
        public string DestName { get; set; }
        public string PathDate { get; set; }
        public decimal PriceForAdult { get; set; }
        public decimal PriceForBaby { get; set; }
        [Display(Name = "Full Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please Enter {0}")]
        public string Fullname { get; set; }
        public string AgentId { get; set; }
        public int PathId { get; set; }
        public DateTime ReservedDate { get; set; }
        [Display(Name = "Adult Count")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please Enter {0}")]
        public int Adult { get; set; }
        [Display(Name = "Baby Count")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please Enter {0}")]
        public int Baby { get; set; }
        public decimal SumPrice { get; set; }
        public int SumCount { get; set; }
        public string Status { get; set; }
        public Tbl_Users Tbl_Users { get; set; }
    }
}
