using DAL.Model;
using DAL.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Web.Utility
{
    public class RoutesTools
    {
        UnitOfWork Db = new UnitOfWork();
        NormalUtility utility = new NormalUtility();
        public List<Tbl_Routes> searchRoutes(int source, int dest, string date)
        {
            try
            {
                var Routes = Db.RoutRepositori.Get(a => a.Status != "Deactive" & a.Source_FG == source & a.Destination_FG == dest, orderby: a => a.OrderByDescending(b => b.id));
                if (date != null)
                {
                    DateTime mydate = utility.ConvertStaringToDate(date, "dd/MM/yyyy");
                    int daynumber = (int)mydate.DayOfWeek;
                    string dayofweek = daynumber.ToString();
                    List<Tbl_Routes> routes = new List<Tbl_Routes>();
                    foreach (var item in Routes)
                    {
                        var days = utility.StringToarrayString(item.DepartureDays);
                        if (days.Contains(dayofweek))
                        {
                            routes.Add(item);
                        }

                    }
                    return routes;
                }
                return Routes.ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public int RoutsCapacity(string date , int routesId)
        {
            try
            {
                if (date != null)
                {
                    DateTime mydate = utility.ConvertStaringToDate(date, "dd/MM/yyyy");
                    int daynumber = (int)mydate.DayOfWeek;
                    string dayofweek = daynumber.ToString();
                    List<Tbl_Routes> routes = new List<Tbl_Routes>();
                    int DayCapacity = Db.DaysCapacityRepositori.Get(a => a.DayOfWeek == daynumber).SingleOrDefault().Capacity;
                    var ReservedCount = Db.ReservCountRepositori.Get(a => a.ReservDate == mydate & a.RoutId_FG==routesId).SingleOrDefault();
                    if (ReservedCount != null)
                    {
                        return (DayCapacity - ReservedCount.count);
                    }
                    else
                    {
                        return DayCapacity;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
