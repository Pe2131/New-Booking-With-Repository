using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model.Tables
{
  public  class Tbl_Country
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Country Name")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="please enter {0}")]  
        public string Name { get; set; }
        [Display(Name = "Country Code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter {0}")]
        public string Code { get; set; }

        [Display(Name = "Country Image")]
        public string Image { get; set; }
        #region Relations
        public ICollection<Tbl_City> tbl_Cities { get; set; }
        #endregion
    }
}
