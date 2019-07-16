using DAL.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.ViewModel
{
    public class ViewModel_Reserv
    {

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string AgentId { get; set; }
        public int RouteId { get; set; }
        public DateTime ReservedDate { get; set; }
        public DateTime TripdDate { get; set; }
        public int Adult { get; set; }
        public String AdultName { get; set; }
        public int ChildupTo2 { get; set; }
        public string ChildupTo2Name { get; set; }
        public int Childup2To7 { get; set; }
        public string Childup2To7Names { get; set; }
        public int Childup7To12 { get; set; }
        public string Childup7To12Names { get; set; }
        public int StudentOrRetirs { get; set; }
        public string studentOrRetirsName { get; set; }
        public decimal SumPrice { get; set; }
        public int SumCount { get; set; }
        public string Status { get; set; }
        public string SourceName { get; set; }
        public string DestName { get; set; }
        public virtual Tbl_Users Tbl_Users { get; set; }
        public virtual Tbl_Routes Tbl_Routes { get; set; }
    }
}
