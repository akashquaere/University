﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityRecruitment.Models
{
    public class ApplicantModel
    {
        public string Code { get; set; }
        public string TypeId { get; set; }
        public string PostType { get; set; }
        public string PostRank { get; set; }
        public string PostName { get; set; }
        public string PostNameHindi { get; set; }
        public int TotalSeat { get; set; }
        public int UR { get; set; }
        public int OBC { get; set; }
        public int SC { get; set; }
        public int ST { get; set; }
        public int PWD { get; set; }
        public int EWS { get; set; }
        public string URFee { get; set; }
        public string OBCFee { get; set; }
        public string SCFee { get; set; }
        public string PWDFee { get; set; }
        public string EWSFee { get; set; }
        public string FormLastDate { get; set; }
        public string ApplyLastDate { get; set; }
        public string PaymentLastDate { get; set; }
        public string Instruction { get; set; }
        public string PostColor { get; set; }
        public string Category { get; set; }
        public string Specialization { get; set; }
        public string PostTypeId { get; set; }
        public IEnumerable<ApplicantModel> list { get; set; }
        public IEnumerable<AppliedForm> list1 { get; set; }
    }

    public class AppliedForm
    {
        public string Id { get; set; }
        public string FormNo { get; set; }
        public string PostCode { get; set; }
        public string PostType { get; set; }
        public string ApplyingCategory { get; set; }
        public string PostName { get; set; }
        public string SystemDate { get; set; }
        public int FeePaid { get; set; }
        public string TransactionId { get; set; }
        public string TransactionDate { get; set; }
        public string Specialization { get; set; }
        public string ApplyingSubCategory { get; set; }
    }

    public class saveAppliedForm
    {
        public string postCode { get; set; }
        public string post { get; set; }
        public int postId { get; set; }
        public int subAndDeptId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string lastDate { get; set; }
        public string SpecializationOfThePost { get; set; }
        public string AppliedDate { get; set; }
        public string FeesPaid { get; set; }
        public string TransactionId { get; set; }
        public string TransactionDate { get; set; }
        public long UserId { get; set; }
        public string msg { get; set; }
        public string FormNumber { get; set; }
        public string IpAddress { get; set; }
    }

    public class postListPara
    {
        public string PostTypeId { get; set; }
        public long Id { get; set; }
    }

}