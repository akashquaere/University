using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityRecruitment.Models
{
    public class ApplicantModel
    {
        public int PostId { get; set; }
        public int SubAndDeptId { get; set; }
        public string PostCode { get; set; }
        public string SubAndDeptName { get; set; }
        public int UR { get; set; }
        public int OBC { get; set; }
        public int SC { get; set; }
        public int ST { get; set; }
        public int EWS { get; set; }
        public int PWD { get; set; }
        public string LastDate { get; set; }
        public string PostName { get; set; }
        public string Category { get; set; }
        public string Specialization { get; set; }
        public IEnumerable<ApplicantModel> list { get; set; }
    }

    public class saveAppliedForm
    {
        public string postCode { get; set; }
        public string post { get; set; }
        public int postId { get; set; }
        public int subAndDeptId { get; set; }
        public string Category { get; set; }
        public string lastDate { get; set; }
        public string SpecializationOfThePost { get; set; }
        public string AppliedDate { get; set; }
        public string FeesPaid { get; set; }
        public string TransactionId { get; set; }
        public string TransactionDate { get; set; }
        public long UserId { get; set; }
        public string msg { get; set; }
        public string FormNumber { get; set; }
    }
}