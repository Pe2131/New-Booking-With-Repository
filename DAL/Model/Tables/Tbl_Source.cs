using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Tables
{
    public class Tbl_Source
    {
        [Key]
        public int Id { get; set; }
        public int City_FG { get; set; }
        public string DepartureDays { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Stations { get; set; }
        public int Capacity { get; set; }
        #region Relation
        [ForeignKey(nameof(City_FG))]
        public virtual Tbl_City Tbl_City { get; set; }
        public ICollection<Tbl_Source> tbl_Sources { get; set; }
        #endregion
    }
}
