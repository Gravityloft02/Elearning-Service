using ERPSchoolManagement.Models.Custom;
using ERPSchoolManagement.Models.Request;
using ERPSchoolManagement.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Interface
{
    public interface IRegistration
    {
        Task<UserRegistrationResponse> RegisterUser(CustomUserRegistration registration);
        Task<UserRegistrationResponse> RegisterAdminUser(CustomUserModel registration);

        Task<LoginResponse> LoginUser(LoginRequest request);
        Task<IEnumerable<CustomUserRole>> GetUserRoles();
    }
}
