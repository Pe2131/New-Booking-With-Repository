﻿using DAL.Model.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class UnitOfWork : IDisposable
    {
        ApplicationDbContext db = new ApplicationDbContext();

        private GenericRepositori<Tbl_Users> _UserRepository;
        public GenericRepositori<Tbl_Users> UserRepository
        {
            get
            {
                if (_UserRepository == null)
                {
                    _UserRepository = new GenericRepositori<Tbl_Users>(db);
                }
                return _UserRepository;
            }
        }

        private GenericRepositori<Tbl_Setting> _SettingRepository;

        public GenericRepositori<Tbl_Setting> SettingRepository
        {
            get
            {
                if (_SettingRepository == null)
                {
                    _SettingRepository = new GenericRepositori<Tbl_Setting>(db);
                }

                return _SettingRepository;
            }
        }
        private GenericRepositori<Tbl_Country> _CountryRepository;

        public GenericRepositori<Tbl_Country> CountryRepository
        {
            get
            {
                if (_CountryRepository == null)
                {
                    _CountryRepository = new GenericRepositori<Tbl_Country>(db);
                }

                return _CountryRepository;
            }
        }
        private GenericRepositori<Tbl_City> _CityRepository;

        public GenericRepositori<Tbl_City> CityRepository
        {
            get
            {
                if (_CityRepository == null)
                {
                    _CityRepository = new GenericRepositori<Tbl_City>(db);
                }

                return _CityRepository;
            }
        }
        private GenericRepositori<Tbl_Discount> _DisCountRepository;

        public GenericRepositori<Tbl_Discount> DisCountRepository
        {
            get
            {
                if (_DisCountRepository == null)
                {
                    _DisCountRepository = new GenericRepositori<Tbl_Discount>(db);
                }

                return _DisCountRepository;
            }
        }
        private GenericRepositori<Tbl_PathWay> _PathWayRepository;

        public GenericRepositori<Tbl_PathWay> PathWayRepository
        {
            get
            {
                if (_PathWayRepository == null)
                {
                    _PathWayRepository = new GenericRepositori<Tbl_PathWay>(db);
                }

                return _PathWayRepository;
            }
        }
        private GenericRepositori<Tbl_Factore> _FactoreRepository;

        public GenericRepositori<Tbl_Factore> FactoreRepository
        {
            get
            {
                if (_FactoreRepository == null)
                {
                    _FactoreRepository = new GenericRepositori<Tbl_Factore>(db);
                }

                return _FactoreRepository ;
            }
        }
        private GenericRepositori<Tbl_Weblog> _WeblogRepositori;
        public GenericRepositori<Tbl_Weblog> WeblogRepositori
        {
            get
            {
                if (_WeblogRepositori == null)
                {
                    _WeblogRepositori = new GenericRepositori<Tbl_Weblog>(db);
                }

                return _WeblogRepositori;
            }
        }
        private GenericRepositori<Tbl_NewsLetter> _NewsLetterRepositori;
        public GenericRepositori<Tbl_NewsLetter> NewsLetterRepositori
        {
            get
            {
                if (_NewsLetterRepositori == null)
                {
                    _NewsLetterRepositori = new GenericRepositori<Tbl_NewsLetter>(db);
                }

                return _NewsLetterRepositori;
            }
        }
        private GenericRepositori<Tbl_Contact> _ContactRepositori;
        public GenericRepositori<Tbl_Contact> ContactRepositori
        {
            get
            {
                if (_ContactRepositori == null)
                {
                    _ContactRepositori = new GenericRepositori<Tbl_Contact>(db);
                }

                return _ContactRepositori;
            }
        }
        private GenericRepositori<Tbl_Routes> _RoutRepositori;
        public GenericRepositori<Tbl_Routes> RoutRepositori
        {
            get
            {
                if (_RoutRepositori == null)
                {
                    _RoutRepositori = new GenericRepositori<Tbl_Routes>(db);
                }

                return _RoutRepositori;
            }
        }
        private GenericRepositori<Tbl_NewReseve> _NewReservRepositori;
        public GenericRepositori<Tbl_NewReseve> NewReservRepositori
        {
            get
            {
                if (_NewReservRepositori == null)
                {
                    _NewReservRepositori = new GenericRepositori<Tbl_NewReseve>(db);
                }

                return _NewReservRepositori;
            }
        }
        private GenericRepositori<Tbl_DaysCapacity> _DaysCapacityRepositori;
        public GenericRepositori<Tbl_DaysCapacity> DaysCapacityRepositori
        {
            get
            {
                if (_DaysCapacityRepositori == null)
                {
                    _DaysCapacityRepositori = new GenericRepositori<Tbl_DaysCapacity>(db);
                }

                return _DaysCapacityRepositori;
            }
        }
        private GenericRepositori<Tbl_ReservCount> _ReservCountRepositori;
        public GenericRepositori<Tbl_ReservCount> ReservCountRepositori
        {
            get
            {
                if (_ReservCountRepositori == null)
                {
                    _ReservCountRepositori = new GenericRepositori<Tbl_ReservCount>(db);
                }

                return _ReservCountRepositori;
            }
        }
        private GenericRepositori<Tbl_DiscountSetting> _DiscountSettingRepositori;
        public GenericRepositori<Tbl_DiscountSetting> DiscountSettingRepositori
        {
            get
            {
                if (_DiscountSettingRepositori == null)
                {
                    _DiscountSettingRepositori = new GenericRepositori<Tbl_DiscountSetting>(db);
                }

                return _DiscountSettingRepositori;
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
