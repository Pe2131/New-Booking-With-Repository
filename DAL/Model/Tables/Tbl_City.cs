using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Tables
{
   public class Tbl_City
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "City Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public string name { get; set; }
        [Display(Name = "City Image")]
        public string Image { get; set; }
        public bool ShowInSlider { get; set; }
        public int Country_FG { get; set; }

        #region Relations
        [ForeignKey(nameof(Country_FG))]
        public virtual Tbl_Country Tbl_Country { get; set; }
        #endregion
    }
}
