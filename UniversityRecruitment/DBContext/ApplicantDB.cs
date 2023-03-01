﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRecruitment.Models;

namespace UniversityRecruitment.DBContext
{
    public class ApplicantDB
    {
        DapperDbContext _dapper = new DapperDbContext();

        public List<SelectListItem> PostList()
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("Proc_GetAllPostList", dynamicParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        //public List<T> ListOfPostForApplying<T>(int PostId)
        //{
        //    try
        //    {
        //        DynamicParameters dynamicParameters = new DynamicParameters();
        //        dynamicParameters.Add("PostId", PostId, DbType.Int32);
        //        var res = _dapper.GetAll<T>("Proc_ListOfPostForApplying", dynamicParameters);
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public T saveAppliedForm<T>(saveAppliedForm model)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("FormNumber", model.FormNumber, DbType.Int32);
                dynamicParameters.Add("postCode", model.postCode, DbType.Int32);
                dynamicParameters.Add("PostId", model.postId, DbType.Int32);
                dynamicParameters.Add("subAndDeptId", model.subAndDeptId, DbType.Int32);
                dynamicParameters.Add("Category", model.Category, DbType.Int32);
                dynamicParameters.Add("SpecializationOfThePost", model.SpecializationOfThePost, DbType.Int32);
                var res = _dapper.ExecuteGet<T>("Proc_ListOfPostForApplying", dynamicParameters);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public dynamic ListOfPostForApplying(string PostTypeId,long UserId)
        {
            postListPara req = new postListPara();
            ApplicantModel model = new ApplicantModel();

            using (SqlConnection objConnection = new SqlConnection(DapperDbContext.connect()))
            {
                try
                {
                    req.Id = UserId;
                    req.PostTypeId = PostTypeId;

                    var reader = objConnection.QueryMultiple("GetPostListToApply", req, commandType: System.Data.CommandType.StoredProcedure);
                    var list = reader.Read<ApplicantModel>().ToList();
                    var list1 = reader.Read<AppliedForm>().ToList();

                    model.list = list;
                    model.list1 = list1;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return model;
            }

        }

    }
}