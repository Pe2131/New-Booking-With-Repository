using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model.Tables
{
  public class Tbl_DaysCapacity
    {
        [Key]
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public int Capacity { get; set; }
    }
}
