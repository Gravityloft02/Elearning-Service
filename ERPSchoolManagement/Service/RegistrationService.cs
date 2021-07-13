using ERPSchoolManagement.Interface;
using ERPSchoolManagement.Models;
using ERPSchoolManagement.Models.Custom;
using ERPSchoolManagement.Models.Request;
using ERPSchoolManagement.Models.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Service
{
    public class RegistrationService :IRegistration
    {
         readonly SchoolManagementERPDBContext _context;
         

        public RegistrationService(SchoolManagementERPDBContext context)
        {
            _context = context;
        }

        #region Registration
        public async Task<UserRegistrationResponse> RegisterUser(CustomUserRegistration Request)
        {
            UserRegistrationResponse response = new UserRegistrationResponse();
            City currentCity = null;
            Locality currentLocality = null;

            if (string.IsNullOrEmpty(Request.MobileNo))
            {
                response.IsRegistered = false;
                response.Message = "Mobile Number is required";                
                return response;
            }

            if (string.IsNullOrEmpty(Request.Email))
            {
                response.IsRegistered = false;
                response.Message = "Email is required";                
                return response;
            }

            var isEmailExists = await _context.UserRegistration.AnyAsync(x => x.Email.ToLower() == Request.Email.ToLower());
            if (isEmailExists)
            {
                response.IsRegistered = false;
                response.Message = "Email already exists";
                return response;
            }
            var isMobileNoExists = await _context.UserRegistration.AnyAsync(x => x.MobileNo == Request.MobileNo);
            if (isMobileNoExists)
            {
                response.IsRegistered = false;
                response.Message = "Mobile No already exists";
                return response;
            }

            if (Request.IsCity)
            {
                currentCity = _context.City.Where(x => x.CityName.ToLower() == Request.CityName.ToLower()).FirstOrDefault();
                if (currentCity == null)
                {
                    currentCity = new City() { CityName = Request.CityName, StateId = Request.StateId };
                    _context.City.Add(currentCity);
                    _context.SaveChanges();
                }
            }
            else if (Request.CityId > 0)
            {
                currentCity = _context.City.Where(x => x.Id == Request.CityId).FirstOrDefault();
            }


            if (currentCity == null)
            {
                response.IsRegistered = false;
                response.ErrorMessage = "City is Not Selected";
                return response;
            }

            Request.CityId = currentCity.Id;

            if (Request.IsLocality)
            {
                currentLocality = _context.Locality.Where(x => x.LocalityName.ToLower() == Request.LocalityName.ToLower()).FirstOrDefault();
                if (currentLocality == null)
                {
                    currentLocality = new Locality() { LocalityName = Request.LocalityName, CityId = currentCity.Id, StateId = Request.StateId, Pincode = Convert.ToInt64(Request.Pincode) };
                    _context.Locality.Add(currentLocality);
                    _context.SaveChanges();
                }
            }
            else if (Request.LocalityId > 0)
            {
                currentLocality = _context.Locality.Where(x => x.Id == Request.LocalityId).FirstOrDefault();
            }

            if (currentLocality == null)
            {
                response.IsRegistered = false;
                response.ErrorMessage = "Locality is Not Selected";
                return response;
            }
            Request.LocalityId = currentLocality.Id;
            var register = GetRegistration(Request);

            _context.UserRegistration.Add(register);
            _context.SaveChanges();

            
            if (register.Id > 0)
            {
                response.IsRegistered = true;
                response.Message = "User Registered Successfully";
                //response.LoginLink = await GenerateLoginLink(register.Id);
                return response;
            }

            response.IsRegistered = false;
            response.Message = "Please try again";
            return response;
        }



        UserRegistration GetRegistration(CustomUserRegistration Request)
        {
            UserRegistration user = new UserRegistration()
            {
                UserName = Request.UserName,
                Address = Request.Address,
                CityId = Request.CityId,
                LocalityId = Request.LocalityId,
                StateId = Request.StateId,
                Email = Request.Email,
                MobileNo = Request.MobileNo,
                Password = Request.Password,
                Pincode = Request.Pincode,
                RoleId = Request.RoleId
            };
            return user;
        }
        #endregion


        #region Login
        public async Task<LoginResponse> LoginUser(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            if (request.RoleId == 1)
            {
                var user = await _context.TblUser.FirstOrDefaultAsync(x => x.Userid.ToLower() == request.LoginId.ToLower());

                if (user == null)
                {
                    response.IsLoginSuccess = false;
                    response.ErrorMessage = "User is not available,Please Register again";
                    return response;
                }

                if (user.Password == request.Password || user.MobileNo == request.Password)
                {
                    response.IsLoginSuccess = true;
                    response.ErrorMessage = "";

                    var User = new CustomUserModel()
                    {
                        Sno = user.Sno,
                        Email = user.Email,
                        MobileNo = user.MobileNo,
                        //RoleId = user.RoleId,
                        Password = user.Password,
                        WebAppLoginTime = DateTime.Now,
                        WindowsAppLoginTime = DateTime.Now,
                        BrachId = user.BrachId,
                        City = user.City,
                        DeletePermission = user.DeletePermission,
                        FinancialYear = user.FinancialYear,
                        Fullname = user.Fullname,
                        ModifyPermisson = user.ModifyPermisson,
                        PrintPermission = user.PrintPermission,
                        ReportPermission = user.ReportPermission,
                        Status = user.Status,
                        Userid = user.Userid,
                        Username = user.Username,
                        Usertype = user.Usertype,
                        
                    };
                    response.Profile = JsonConvert.SerializeObject(User);


                }
                else
                {
                    response.IsLoginSuccess = false;
                    response.ErrorMessage = "Invalid credentials";
                }
            }
            else if(request.RoleId == 3)
            {
                var user = await _context.TblStudent.FirstOrDefaultAsync(x => x.StudentRegNo.ToLower() == request.LoginId.ToLower());

                if (user == null)
                {
                    response.IsLoginSuccess = false;
                    response.ErrorMessage = "User is not available,Please Register again";
                    return response;
                }

                if( user.EmgMobno == request.Password)
                {
                    response.IsLoginSuccess = true;
                    response.ErrorMessage = "";

                    var User = new CustomStudentModel()
                    {
                        Sno = user.Sno,
                        City = user.City,
                        Adharno = user.Adharno,
                        AdmNo = user.AdmNo,
                        AllergyMedDesc = user.AllergyMedDesc,
                        EmgAddress = user.EmgAddress,
                        FathersAnnualincome = user.FathersAnnualincome,
                        Incaseofemgname = user.Incaseofemgname,
                        FathersOffaddress = user.FathersOffaddress,
                        Weight = user.Weight,
                        BloodGroup = user.BloodGroup,
                        Caste = user.Caste,
                        Class = user.Class,
                        Dateofadmission = user.Dateofadmission,
                        EmgMobno = user.EmgMobno,
                        EmgPhoneno = user.EmgPhoneno ,
                        FathersEmail = user.FathersEmail,
                        MothersEmail = user.MothersEmail,
                        MedicalAddress = user.MedicalAddress,
                        MothersAnnualincome = user.MothersAnnualincome,
                        MothersDesignation = user.MothersDesignation,
                        MothersDob =user.MothersDob,
                        MothersMobno = user.MothersMobno,
                        MothersName = user.MothersName,
                        MothersOffaddress = user.MothersOffaddress,
                        MothersProfession = user.MothersProfession,
                        MothersResaddress = user.MothersResaddress,
                        FathersMobno = user.FathersMobno,
                        FamilyDoc = user.FamilyDoc,
                        FathersDesignation = user.FathersDesignation,
                        FathersDob = user.FathersDob,
                        FathersName = user.FathersName,
                        FathersProfession = user.FathersProfession,
                        FathersResaddress = user.FathersResaddress,
                        Gender = user.Gender, 
                        Height = user.Height,
                        Nationality = user.Nationality,
                        Relation = user.Relation,
                        Religion = user.Religion,
                        StudentRegNo = user.StudentRegNo,
                        SamgraId = user.SamgraId,
                        Section = user.Section,
                        SmsDetailaltmobno = user.SmsDetailaltmobno,
                        SmsDetailemail = user.SmsDetailemail,
                        SmsDetailmobno = user.SmsDetailmobno ,
                        SmsSendername = user.SmsSendername,
                        State = user.State,
                        StudentAddress = user.StudentAddress,
                         StudentCategory = user.StudentCategory,
                         StudentDob = user.StudentDob,
                         StudentImage = user.StudentImage,
                         StudentName = user.StudentName ,
                         StudentType = user.StudentType,
                         Timeofsync = user.Timeofsync
                        
                    };
                    response.Profile = JsonConvert.SerializeObject(User);


                }
                else
                {
                    response.IsLoginSuccess = false;
                    response.ErrorMessage = "Invalid credentials";
                }

            }
                return response;
            
        }
        #endregion

        #region User Roles
        public async Task<IEnumerable<CustomUserRole>> GetUserRoles()
        {
            var roles =  _context.UserRoles.AsEnumerable();
            List<CustomUserRole> customRole = new List<CustomUserRole>();
            foreach (var role in roles)
            {
                customRole.Add(GetUserRole(role));
            }
            return customRole.AsEnumerable();
        }
        CustomUserRole GetUserRole(UserRoles user)
        {
            CustomUserRole custom = new CustomUserRole()
            {
               Id = (int)user.Id,
               RoleName = user.RoleName
            };
            return custom;
        }
        #endregion

        #region Admin Registration
        public async Task<UserRegistrationResponse> RegisterAdminUser(CustomUserModel Request)
        {
            UserRegistrationResponse response = new UserRegistrationResponse();
            //City currentCity = null;
            //Locality currentLocality = null;

            if (string.IsNullOrEmpty(Request.MobileNo))
            {
                response.IsRegistered = false;
                response.Message = "Mobile Number is required";
                return response;
            }

            if (string.IsNullOrEmpty(Request.Email))
            {
                response.IsRegistered = false;
                response.Message = "Email is required";
                return response;
            }

            var isEmailExists = await _context.TblUser.AnyAsync(x => x.Email.ToLower() == Request.Email.ToLower());
            if (isEmailExists)
            {
                response.IsRegistered = false;
                response.Message = "Email already exists";
                return response;
            }
            var isMobileNoExists = await _context.TblUser.AnyAsync(x => x.MobileNo == Request.MobileNo);
            if (isMobileNoExists)
            {
                response.IsRegistered = false;
                response.Message = "Mobile No already exists";
                return response;
            }

          
            var admin_register = GetAdminRegistration(Request);

            _context.TblUser.Add(admin_register);
            _context.SaveChanges();


            if (admin_register.Sno > 0)
            {
                response.IsRegistered = true;
                response.Message = "Admin Registered Successfully";
                //response.LoginLink = await GenerateLoginLink(register.Id);
                return response;
            }

            response.IsRegistered = false;
            response.Message = "Please try again";
            return response;
        }

        TblUser GetAdminRegistration(CustomUserModel Request)
        {
            TblUser user = new TblUser()
            {

                Email = Request.Email,
                MobileNo = Request.MobileNo,
                Password = Request.Password,
                WebAppLoginTime = DateTime.Now,
                WindowsAppLoginTime = DateTime.Now,
                BrachId = Request.BrachId,
                City = Request.City,
                DeletePermission = Request.DeletePermission,
                FinancialYear = Request.FinancialYear,
                Fullname = Request.Fullname,
                ModifyPermisson = Request.ModifyPermisson,
                PrintPermission= Request.PrintPermission,
                ReportPermission = Request.ReportPermission,
                WebPermission = Request.WebPermission,
                Status = 1,
                Userid = Request.Userid,
                Username = Request.Username,
                Usertype = Request.Usertype,
                WindowsPermission = Request.WindowsPermission
            };
            return user;
        }
        #endregion

    }
}
