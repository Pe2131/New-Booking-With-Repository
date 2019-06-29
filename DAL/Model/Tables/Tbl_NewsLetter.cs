using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model.Tables
{
    public class Tbl_NewsLetter
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "this type isnt match")]
        public string Email { get; set; }
    }
}
