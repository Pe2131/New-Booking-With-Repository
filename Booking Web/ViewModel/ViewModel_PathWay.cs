using DAL.Model;
using DAL.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.ViewModel
{
    public class ViewModel_PathWay
    {
        UnitOfWork Db = new UnitOfWork();
        public int id { get; set; }
        public int Source_FG { get; set; }
        public int Destination_FG { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int Capacity { get; set; }
        public decimal PriceForAdultUro { get; set; }
        public decimal PriceForAdultDollar { get; set; }
        public decimal PriceForBabyUro { get; set; }
        public decimal PriceForBabyDollar { get; set; }
        public string Status { get; set; }
        public String GetSourceName {
            get
            {
                try
                {
                    return Db.CityRepository.GetById(Source_FG).name;
                }
                catch (Exception e)
                {

                    throw e.InnerException;
                }
            }
        }
        public String GetDestinationName
        {
            get
            {
                try
                {
                    return Db.CityRepository.GetById(Destination_FG).name;
                }
                catch (Exception e)
                {

                    throw e.InnerException;
                }
            }
        }
    }
}
