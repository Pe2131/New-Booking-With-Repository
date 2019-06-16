using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Tables
{
   public class Tbl_Factore
    {
        [Key]
        public int Id { get; set; }
        public string UserId_FG { get; set; }
        public int PathwayId_FG  { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int AdultCount { get; set; }
        public int BabyCount { get; set; }
        public decimal SumPrice { get; set; }
        public bool isPayed { get; set; }
        public string UseDisCount { get; set; }

        #region Relations
        [ForeignKey(nameof(UserId_FG))]
        public virtual Tbl_Users Tbl_User { get; set; }
        [ForeignKey(nameof(PathwayId_FG))]
        public virtual Tbl_PathWay Tbl_PathWay { get; set; }
        #endregion

    }
}
