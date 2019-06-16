using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Tables
{
   public class Tbl_Destination
    {
        [Key]
        public int Id { get; set; }
        public int City_FG { get; set; }
        public int Source_FG { get; set; }
        public string ArriveDays { get; set; }
        public DateTime ArriveTime { get; set; }
        public decimal Price { get; set; }
        public string Stations { get; set; }
        public string ReturnDays { get; set; }
        public DateTime ReturnTime { get; set; }
        #region Relation
        [ForeignKey(nameof(City_FG))]
        public virtual Tbl_City Tbl_City { get; set; }
        [ForeignKey(nameof(Source_FG))]
        public virtual Tbl_Source tbl_Source { get; set; }
        #endregion
    }
}
