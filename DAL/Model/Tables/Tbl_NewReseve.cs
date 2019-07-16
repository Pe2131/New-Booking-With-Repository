using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Tables
{
    public class Tbl_NewReseve
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please Enter {0}")]
        public string Fullname { get; set; }
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please Enter {0}")]
        public string Email { get; set; }
        [Display(Name = "Mobile")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please Enter {0}")]
        public string Mobile { get; set; }
        public string AgentId { get; set; }
        public int RouteId { get; set; }
        public DateTime ReservedDate { get; set; }
        [Display(Name = "Trip Date")]
        public DateTime TripdDate { get; set; }
        [Display(Name = "Adult Count")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please Enter {0}")]
        public int Adult { get; set; }
        [Display(Name = "Adult name")]
        public String AdultName { get; set; }
        [Display(Name = "Child Up to 2 yers")]
        public int ChildupTo2 { get; set; }
        [Display(Name = "Child Up to 2 yers names")]
        public string ChildupTo2Name { get; set; }
        [Display(Name = "Child 2years To 7 years")]
        public int Childup2To7 { get; set; }
        [Display(Name = "Child 2years To 7 years names")]
        public string Childup2To7Names { get; set; }
        [Display(Name = "Child 7years To 12 years")]
        public int Childup7To12 { get; set; }
        [Display(Name = "Child 7years To 12 years names")]
        public string Childup7To12Names { get; set; }
        [Display(Name = "student or retires")]
        public int StudentOrRetirs { get; set; }
        [Display(Name = "student or retires names")]
        public string studentOrRetirsName { get; set; }
        public decimal SumPrice { get; set; }
        public int SumCount { get; set; }
        public string Status { get; set; }
        #region reltion
        [ForeignKey(nameof(AgentId))]
        public virtual Tbl_Users Tbl_Users { get; set; }
        [ForeignKey(nameof(RouteId))]
        public virtual Tbl_Routes Tbl_Routes { get; set; }
        #endregion

    }
}
