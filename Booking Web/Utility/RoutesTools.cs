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
                    DateTime mydate = utility.ConvertStaringToDate(date, "MM/dd/yyyy");
                    String dayofweek = mydate.DayOfWeek.ToString();
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

    }
}
