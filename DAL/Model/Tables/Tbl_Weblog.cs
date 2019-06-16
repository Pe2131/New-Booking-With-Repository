using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Tables
{
    public class Tbl_Weblog
    {
        [Key]
        public int id { get; set; }
        public string UserId_Fk { get; set; }

        [Display(Name = "Title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        [MaxLength(300, ErrorMessage = "{0} cant bigger than {1}")]
        [MinLength(5, ErrorMessage = "{0} cant smaller than {1}")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        [MinLength(5, ErrorMessage = "{0} cant smaller than {1}")]
        public string Description { get; set; }
        [Display(Name = "writer")]
        public string Authore { get; set; }
        [Display(Name = "publish Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public DateTime Date { get; set; }
        [Display(Name = "image")]
        public string image { get; set; }
        [Display(Name = "KeyWords")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter {0}")]
        public string KeyWords { get; set; }
        [Display(Name = "Is News")]
        public bool isnews { get; set; }

        //************************************************************************************************

        #region relationship

        [ForeignKey(nameof(UserId_Fk))]
        public virtual Tbl_Users Tbl_Users { get; set; }
        #endregion
    }
}
