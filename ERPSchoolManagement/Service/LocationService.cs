using ERPSchoolManagement.Interface;
using ERPSchoolManagement.Models;
using ERPSchoolManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Service
{
    public class LocationService : ILocation
    {
        SchoolManagementERPDBContext _context;
        public LocationService(SchoolManagementERPDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCity(CustomCity city)
        {
            var _city = GetCity(city);
            _context.City.Add(_city);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddLocality(CustomLocality locality)
        {
            var _locality = GetLocality(locality);
            _context.Locality.Add(_locality);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddState(CustomState state)
        {
            var _state = GetState(state);
            _context.State.Add(_state);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<CustomCity>> GetCities(int stateId)
        {
            var _cities = _context.City.Where(x => x.StateId == stateId);
            List<CustomCity> _customCities = new List<CustomCity>();
            foreach (City city in _cities)
            {
                var c = GetCity(city);
                _customCities.Add(c);
            }
            return _customCities;
        }

        public async Task<List<CustomState>> GetStates()
        {
            var _states = _context.State.ToList();
            List<CustomState> _customStates = new List<CustomState>();
            foreach (State state in _states)
            {
                var s = GetState(state);
                _customStates.Add(s);
            }
            return _customStates;
        }

        public async Task<List<CustomLocality>> GetLocalities(long cityId)
        {
            var _localities = _context.Locality.Where(x => x.CityId == cityId).ToList();
            List<CustomLocality> _customLocalities = new List<CustomLocality>();
            foreach (Locality locality in _localities)
            {
                var l = GetLocality(locality);
                _customLocalities.Add(l);
            }
            return _customLocalities;
        }

        #region City

        City GetCity(CustomCity customCity)
        {
            City city = new City()
            {
                CityName = customCity.CityName,
                Id = customCity.Id,
                StateId = customCity.StateId
            };
            return city;
        }

        CustomCity GetCity(City city)
        {
            CustomCity customCity = new CustomCity()
            {
                Id = city.Id,
                CityName = city.CityName,
                StateId = (int)city.StateId
            };
            return customCity;
        }

        #endregion

        #region State

        State GetState(CustomState customState)
        {
            State state = new State()
            {
                StateName = customState.StateName,
                Id = customState.Id
            };
            return state;
        }

        CustomState GetState(State state)
        {
            CustomState customState = new CustomState()
            {
                Id = state.Id,
                StateName = state.StateName
            };
            return customState;
        }

        #endregion

        #region LocationArea

        Locality GetLocality(CustomLocality customLocality)
        {
            Locality locality = new Locality()
            {
                LocalityName = customLocality.LocalityName,
                Id = customLocality.Id,
                Pincode = customLocality.Pincode,
                CityId = customLocality.CityId,
                StateId = customLocality.StateId
            };
            return locality;
        }

        CustomLocality GetLocality(Locality locality)
        {
            CustomLocality customLocality = new CustomLocality()
            {
                LocalityName = locality.LocalityName,
                Id = locality.Id,
                Pincode = locality.Pincode,
                CityId = locality.CityId,
                StateId = locality.StateId
            };
            return customLocality;
        }


        #endregion

    }
}
