using DAL.Model;
using DAL.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.ViewModel
{
    public class ViewModel_Routes
    {
        UnitOfWork Db = new UnitOfWork();
        public int id { get; set; }
        public int Source_FG { get; set; }
        public int Destination_FG { get; set; }
        public string DepartureDays { get; set; }
        public string DepartureTime { get; set; }
        public string ArriveDays { get; set; }
        public string ArriveTime { get; set; }
        public string SourceStation { get; set; }
        public string DestStation { get; set; }
        public decimal Price { get; set; }
        public decimal twoWayPrice { get; set; }
        public decimal Price2 { get; set; }
        public decimal twoWayPrice2 { get; set; }
        public string Status { get; set; }
        public int Capacity { get; set; }  // just for show in view and this isnt exist in table
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
