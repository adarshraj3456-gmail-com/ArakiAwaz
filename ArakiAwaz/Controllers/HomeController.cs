using ArakiAwaz.dto;
using ArakiAwaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI;

namespace ArakiAwaz.Controllers
{
    public class HomeController : Controller
    {
        private ArakiAwazEntities db = new ArakiAwazEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Thanks()
        {
            return View();

            ViewBag.message = "";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(memberform objmemberform)
        {
            try
            {
                string message = "";
                if (objmemberform.membername == null || objmemberform.membername == string.Empty)
                {
                    message = "Please Provide Your Name";
                }
                else if (objmemberform.memberphone == null || objmemberform.memberphone == string.Empty)
                {
                    message = "Please Provide Your Phone Number";
                }
                else if (objmemberform.memberstate == null || objmemberform.memberstate == string.Empty)
                {
                    message = "Please Provide Your State";
                }
                else if (objmemberform.membervillage == null || objmemberform.membervillage == string.Empty)
                {
                    message = "Please Provide Your Viallage";
                }
                else
                {

                    objmemberform.status = true;
                    objmemberform.entrydate = System.DateTime.Now;
                    objmemberform.modifydate = System.DateTime.Now;

                    memberregistration objdata = new memberregistration
                    {
                        id=0,
                        membername = objmemberform.membername,
                        memberage = objmemberform.memberage,
                        memberblock = objmemberform.memberblock,
                        modifydate = System.DateTime.Now,
                        membercity = objmemberform.membercity,
                        memberemail = objmemberform.memberemail,
                        memberfathername = objmemberform.memberfathername,
                        membergender = objmemberform.membergender,
                        memberlocality = objmemberform.memberlocality,
                        memberpanchayat = objmemberform.memberpanchayat,
                        memberphone = objmemberform.memberphone,
                        memberstate = objmemberform.memberstate,
                        membervillage = objmemberform.membervillage,
                        memberwardno = objmemberform.memberwardno,
                        memberwhatsupno = objmemberform.memberwhatsupno,
                        entrydate = System.DateTime.Now,
                        status = true,
                        
                    };
                    db.memberregistrations.Add(objdata);
                    db.SaveChanges();
                    message = "Data Saved Success Fully";
                    ViewBag.message = message;

                }


                return RedirectToAction("Thanks");
            }
            catch (Exception)
            {

                return RedirectToAction("Thanks");
            }

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public JsonResult checkmobile(string mobile)
        {

            bool flag = false;

            var mobilenoexists = db.memberregistrations.Any(x => x.memberphone == mobile);

            if (mobilenoexists)
            {
                flag = true;
            }

            return Json(flag);
        
        }



        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult IsAlreadySigned([Bind(Prefix = "memberform.memberemail")]string memberemail)
        {

            return Json(IsUserEmailAvailable(memberemail));

        }


        [HttpPost]
        public JsonResult IsAlreadyPhone(string Phone)
        {

            return Json(checkmobile(Phone));

        }



        public bool IsUserEmailAvailable(string EmailId)
        {

            var RegEmailId = db.memberregistrations.Where(x => x.memberemail == EmailId);

            bool status;
            if (RegEmailId!=null)
            {
                //Already registered  
                status = true;
            }
            else
            {
                //Available to use  
                status = false;
            }


            return status;
        }

        //public bool IsUserPhoneAvailable(string Phone)
        //{

        //    var RegEmailId = db.memberregistrations.Where(x => x.memberphone == Phone).FirstOrDefault();

        //    bool status;
        //    if (RegEmailId != null)
        //    {
        //        //Already registered  
        //        status = false;
        //    }
        //    else
        //    {
        //        //Available to use  
        //        status = true;
        //    }


        //    return status;
        //}



        public ActionResult AdminLogin()
        {

            return View();
        
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin_table logindetails)
        {
            if (logindetails == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Admin_table details = db.Admin_table.Where(x => x.Login_name == logindetails.Login_name && x.pass == logindetails.pass && x.role.ToString().ToUpper() == "ADMIN").FirstOrDefault();
            if (details == null)
            {
                return HttpNotFound();
            }

            else 
            {

                FormsAuthentication.SignOut();
                FormsAuthentication.SetAuthCookie(logindetails.Login_name + "_" + logindetails.role, true);

            }


            return RedirectToAction("index","register");
        }

    }
}