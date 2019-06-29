using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Tables
{
    public class Tbl_ReservCount
    {
        public int Id { get; set; }
        public int RoutId_FG { get; set; }
        public DateTime ReservDate { get; set; }
        public int count { get; set; }
        #region Relation
        [ForeignKey(nameof(RoutId_FG))]
        public virtual Tbl_Routes Tbl_Routes { get; set; }
        #endregion
    }
}
