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
        public int CheckReservCount(string date,int routesId)
        {
            try
            {
                if (date != null)
                {
                    DateTime mydate = utility.ConvertStaringToDate(date, "dd/MM/yyyy");
                    var ReservedCount = Db.ReservCountRepositori.Get(a => a.ReservDate == mydate & a.RoutId_FG == routesId).SingleOrDefault();
                    if (ReservedCount != null)
                    {
                        return ReservedCount.Id;
                    }
                    else
                    {
                        return 0;
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
                    //decimal totalDiscounts = (child * route.Price * ((decimal)(DiscountSetting.ForChild0 / 100))) + (child2 * route.Price * ((decimal)(DiscountSetting.ForChild2 / 100))) + (child7 * route.Price * ((decimal)(DiscountSetting.ForChild7 / 100))) + (student * route.Price * ((decimal)(DiscountSetting.forStudent / 100)));
                    decimal totalDiscounts = (child * route.Price * decimal.Divide((decimal)DiscountSetting.ForChild0 , 100m)) + (child2 * route.Price * decimal.Divide((decimal)DiscountSetting.ForChild2, 100m)) + (child7 * route.Price * decimal.Divide((decimal)DiscountSetting.ForChild7, 100m)) + (student * route.Price * decimal.Divide((decimal)DiscountSetting.forStudent, 100m));
                    return totalPrice - totalDiscounts;
                }
                else
                {
                    decimal totalPrice = count * route.twoWayPrice;
                    decimal totalDiscounts = (child * route.twoWayPrice * decimal.Divide((decimal)DiscountSetting.ForChild0, 100m)) + (child2 * route.twoWayPrice * decimal.Divide((decimal)DiscountSetting.ForChild2, 100m)) + (child7 * route.twoWayPrice * decimal.Divide((decimal)DiscountSetting.ForChild7, 100m)) + (student * route.twoWayPrice * decimal.Divide((decimal)DiscountSetting.forStudent, 100m));
                    return totalPrice - totalDiscounts;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public bool CnfirmReservDatTime(int routId,string reservDate)
        {
            try
            {
                var route = Db.RoutRepositori.GetById(routId);
                DateTime resrvdate = utility.ConvertStaringToDate(reservDate, "dd/MM/yyyy");
                DateTime routeTime = utility.ConvertStaringToTime(route.DepartureTime, "HH:mm");
                string thisTime = DateTime.Now.ToString("HH:mm");
                DateTime nowTime = utility.ConvertStaringToTime(thisTime, "HH:mm");
                string reservDateWithTime = reservDate + " " + thisTime;
                DateTime ReserveWithTime= utility.ConvertStaringToDate(reservDateWithTime, "dd/MM/yyyy HH:mm");
                if (utility.CompareDate(resrvdate, DateTime.Now.Date) == 2)
                {
                    return false;
                }
                if (utility.CompareDate(ReserveWithTime, DateTime.Now.Date) == 0)
                {
                    if (utility.CompareDate(routeTime, nowTime) == 2)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
