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
        public int RoutsCapacity(string date, int routesId)
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
                    var ReservedCount = Db.ReservCountRepositori.Get(a => a.ReservDate == mydate & a.RoutId_FG == routesId).SingleOrDefault();
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
        public decimal calculatPrice(int count, int adult, int child, int child2, int child7, int student, bool twoWay, int routId)
        {
            try
            {
                var route = Db.RoutRepositori.GetById(routId);
                var DiscountSetting = Db.DiscountSettingRepositori.Get().FirstOrDefault();
                if (twoWay == false)
                {
                    decimal totalPrice = count * route.Price;
                    decimal totalDiscounts = (child * route.Price * (DiscountSetting.ForChild0 / 100)) + (child2 * route.Price * (DiscountSetting.ForChild2 / 100)) + (child7 * route.Price * (DiscountSetting.ForChild7 / 100)) + (student * route.Price * (DiscountSetting.forStudent / 100));
                    return totalPrice - totalDiscounts;
                }
                else
                {
                    decimal totalPrice = count * route.twoWayPrice;
                    decimal totalDiscounts = (child * route.twoWayPrice * (DiscountSetting.ForChild0 / 100)) + (child2 * route.twoWayPrice * (DiscountSetting.ForChild2 / 100)) + (child7 * route.twoWayPrice * (DiscountSetting.ForChild7 / 100)) + (student * route.twoWayPrice * (DiscountSetting.forStudent / 100));
                    return totalPrice - totalDiscounts;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
