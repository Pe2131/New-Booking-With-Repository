using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Tables
{
    public class Tbl_Reserve
    {
        [Key]
        public int Id { get; set; }
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
        #region reltion
        [ForeignKey(nameof(AgentId))]
        public virtual Tbl_Users Tbl_Users { get; set; }
        [ForeignKey(nameof(PathId))]
        public virtual Tbl_PathWay Tbl_PathWay { get; set; }
        #endregion

    }
}
