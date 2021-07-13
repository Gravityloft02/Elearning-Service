using ERPSchoolManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Interface
{
   public interface ILocation
    {
        Task<bool> AddState(CustomState state);
        Task<List<CustomState>> GetStates();

        Task<bool> AddCity(CustomCity city);
        Task<List<CustomCity>> GetCities(int stateId);

        Task<bool> AddLocality(CustomLocality locality);
        Task<List<CustomLocality>> GetLocalities(Int64 cityId);
    }
}
