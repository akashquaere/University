using UniversityRecruitment.DBContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRecruitment.Models;

namespace UniversityRecruitment.DBContext
{
    public class AccountDb
    {
        DapperDbContext _dapper = new DapperDbContext();

        public List<SelectListItem> StateList()
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("ProcId", 1, DbType.Int32);
                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("Proc_BindDropDowns", dynamicParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public List<SelectListItem> CityList(int StateId)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("ProcId", 2, DbType.Int32);
                dynamicParameters.Add("CommonId", StateId, DbType.Int32);
                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("Proc_BindDropDowns", dynamicParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T RegistrationApplication<T>(Registration model)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("FirstName", model.FirstName, DbType.String);
                dynamicParameters.Add("MiddleName", model.MiddleName, DbType.String);
                dynamicParameters.Add("Surname", model.Surname, DbType.String);
                dynamicParameters.Add("FatherName", model.FatherName, DbType.String);
                dynamicParameters.Add("MotherName", model.MotherName, DbType.String);
                dynamicParameters.Add("DateOfBirth", model.DOB, DbType.String);
                dynamicParameters.Add("AddharNo", model.AddharNo, DbType.String);
                dynamicParameters.Add("Gender", model.Gender, DbType.String);
                dynamicParameters.Add("Category", model.Category, DbType.String);
                dynamicParameters.Add("Address1", model.PermanentAddress1, DbType.String);
                dynamicParameters.Add("Address2", model.PermanentAddress2, DbType.String);
                dynamicParameters.Add("StateId", model.PermanentStateId, DbType.String);
                dynamicParameters.Add("CityId", model.PermanentCityId, DbType.String);
                dynamicParameters.Add("PinCode", model.PinCode, DbType.String);
                dynamicParameters.Add("EmailId", model.EmailId, DbType.String);
                dynamicParameters.Add("Mobile", model.Mobile, DbType.String);
                dynamicParameters.Add("Password", model.Password, DbType.String);
                dynamicParameters.Add("Ip", model.Ip, DbType.String);
                var res = _dapper.ExecuteGet<T>("Proc_RegistrationApplication", dynamicParameters);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public T CheckAuthorization<T>(Login model)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("LoginId", model.LoginId, DbType.String);
                dynamicParameters.Add("Password", model.Password, DbType.String);
                var res = _dapper.ExecuteGet<T>("Proc_CheckAuthorization", dynamicParameters);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public T GetUserInformation<T>(int ApplicationId)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("ApplicationId", ApplicationId, DbType.Int32);
                var res = _dapper.Get<T>("Proc_GetUserInformation", dynamicParameters);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public T InsertOtp<T>(string Otp,string Purpose, string EmailOrPhone, string MessageBody,int ApplicationId)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Otp", Otp, DbType.String);
                dynamicParameters.Add("Purpose", Purpose, DbType.String);
                dynamicParameters.Add("EmailOrPhone", EmailOrPhone, DbType.String);
                dynamicParameters.Add("MessageBody", MessageBody, DbType.String);
                dynamicParameters.Add("ApplicationId", ApplicationId, DbType.String);
                var res = _dapper.Execute<T>("Proc_InsertOtp", dynamicParameters);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public T ValidateOtp<T>(string Otp,int ApplicationId)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Otp", Otp, DbType.String);
                dynamicParameters.Add("ApplicationId", ApplicationId, DbType.String);
                var res = _dapper.Execute<T>("Proc_ValidateOtp", dynamicParameters);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}