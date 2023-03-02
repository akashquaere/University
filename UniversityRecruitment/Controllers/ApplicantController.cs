using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRecruitment.DBContext;
using UniversityRecruitment.Models;
using UniversityRecruitment.Utilities;

namespace UniversityRecruitment.Controllers
{
    public class ApplicantController : Controller
    {
        // GET: Applicant

        ApplicantDB apdb = new ApplicantDB();
        SessionManager sm = new SessionManager();

        public ActionResult Index(string  PostTypeId)
        {
            ApplicantModel model = new ApplicantModel();
            ViewBag.PostList = apdb.PostList();
            if (!String.IsNullOrEmpty(PostTypeId))
            {
                model = apdb.ListOfPostForApplying(PostTypeId, sm.userId);
            }
            else
            {
                model = apdb.ListOfPostForApplying("PROF", sm.userId);
            }
            return View(model);
        }

        public PartialViewResult BindPostList(string PostTypeId)
        {
            var res = new ApplicantModel();
            if (!String.IsNullOrEmpty(PostTypeId))
            {
                res = apdb.ListOfPostForApplying(PostTypeId, sm.userId);
            }
            else
            {
                res = apdb.ListOfPostForApplying("PROF",sm.userId);
            }
            return PartialView("_PostList", res);
        }

        [HttpPost]
        public JsonResult saveAppliedForm(saveAppliedForm model)
        {
            if (model != null)
            {
                model.UserId = sm.userId;
                var result = apdb.saveAppliedForm<saveAppliedForm>(model);
                model.msg = result.msg;
            }           
            return Json(model, JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult PersonalDetails()
        {
            return View();
        }

        public ActionResult UploadPhoto()
        {
            return View();
        }
        public ActionResult AcademicDetails()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AcademicDetails(academicsDetails model)
        {
            AccountDb repo = new AccountDb();
            academicsDetails obj = new academicsDetails();
            model.ip = Common.GetIPAddress();
            model.UserId = sm.userId;
            if (model.lst!=null && model.lst.Count() > 0)
            {
               
                obj = repo.saveQualification(model);
            }
            if(model.lst1!=null && model.lst1.Count() > 0)
            {
                obj = repo.saveugcDetails(model);
            }


            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Experience()
        {
            return View();
        }

        public ActionResult Awards()
        {
            return View();
        }

        public ActionResult Lectures()
        {
            return View();
        }

        public ActionResult FeePayment()
        {
            return View();
        }

        public ActionResult FeeRecipt()
        {
            return View();
        }

        

        public ActionResult ResearchDegree()
        {
            return View();
        }

        public ActionResult Activities()
        {
            return View();
        }



    }
}