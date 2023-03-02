﻿using UniversityRecruitment.DBContext;
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
                dynamicParameters.Add("LastName", model.Surname, DbType.String);
                dynamicParameters.Add("FatherName", model.FatherName, DbType.String);
                dynamicParameters.Add("MotherName", model.MotherName, DbType.String);
                dynamicParameters.Add("Dob", model.DOB, DbType.String);
                dynamicParameters.Add("Aadhar", model.AddharNo, DbType.String);
                dynamicParameters.Add("Gender", model.Gender, DbType.String);
                dynamicParameters.Add("Category", model.Category, DbType.String);
                dynamicParameters.Add("PermanentAddress1", model.PermanentAddress1, DbType.String);
                dynamicParameters.Add("PermanentAddress2", model.PermanentAddress2, DbType.String);
                dynamicParameters.Add("PermanentStateId", model.PermanentStateId, DbType.String);
                dynamicParameters.Add("PermanentStateOther", model.PermanentStateOther, DbType.String);
                dynamicParameters.Add("PermanentCityId", model.PermanentCityId, DbType.String);
                dynamicParameters.Add("PermanentCityOther", model.PermanentCityOther, DbType.String);
                dynamicParameters.Add("PermanentPinCode", model.PinCode, DbType.String);
                dynamicParameters.Add("Email", model.Email, DbType.String);
                dynamicParameters.Add("Mobile", model.Mobile, DbType.String);
                dynamicParameters.Add("Password", model.Password, DbType.String);
                dynamicParameters.Add("IpAddress", model.Ip, DbType.String);
                var res = _dapper.ExecuteGet<T>("RegisterApplicant", dynamicParameters);
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
                dynamicParameters.Add("IpAddress", model.IpAddress, DbType.String);
                dynamicParameters.Add("DeviceType", "M", DbType.String);
                var res = _dapper.ExecuteGet<T>("ValidateApplicantLogin", dynamicParameters);
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

        public changePassword checkPaas(string loginId, string oldPassword)
        {
            changePassword obj = new changePassword();
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@loginId", loginId);
                dynamicParameters.Add("@Password", oldPassword);
                dynamicParameters.Add("@procId", 1);
              
               obj = _dapper.Execute<changePassword>("proc_checkPassword", dynamicParameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public changePassword changePaas(string loginId, string newPassword)
        {
            changePassword obj = new changePassword();
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@loginId", loginId);
                dynamicParameters.Add("@Password", newPassword);
                dynamicParameters.Add("@procId", 2);

                obj = _dapper.Execute<changePassword>("proc_checkPassword", dynamicParameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}