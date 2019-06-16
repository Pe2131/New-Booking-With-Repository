using DAL.Model.Tables;
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
        private GenericRepositori<Tbl_Reserve> _ReservRepositori;
        public GenericRepositori<Tbl_Reserve> ReservRepositori
        {
            get
            {
                if (_ReservRepositori == null)
                {
                    _ReservRepositori = new GenericRepositori<Tbl_Reserve>(db);
                }

                return _ReservRepositori;
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
        private GenericRepositori<Tbl_Source> _SourceRepositori;
        public GenericRepositori<Tbl_Source> SourceRepositori
        {
            get
            {
                if (_SourceRepositori == null)
                {
                    _SourceRepositori = new GenericRepositori<Tbl_Source>(db);
                }

                return _SourceRepositori;
            }
        }
        private GenericRepositori<Tbl_Destination> _DestinationRepositori;
        public GenericRepositori<Tbl_Destination> DestinationRepositori
        {
            get
            {
                if (_DestinationRepositori == null)
                {
                    _DestinationRepositori = new GenericRepositori<Tbl_Destination>(db);
                }

                return _DestinationRepositori;
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
