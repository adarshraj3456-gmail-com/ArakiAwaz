using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArakiAwaz.Models;
using System.Web.Security;

namespace ArakiAwaz.Controllers
{

    [Authorize]
    public class RegisterController : Controller
    {
        private ArakiAwazEntities db = new ArakiAwazEntities();

        // GET: Register
        public async Task<ActionResult> Index()
        {
            return View(await db.memberregistrations.ToListAsync());
        }

        // GET: Register/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memberregistration memberregistration = await db.memberregistrations.FindAsync(id);
            if (memberregistration == null)
            {
                return HttpNotFound();
            }
            return View(memberregistration);
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,membername,memberemail,memberphone,membergender,memberage,memberstate,membercity,memberfathername,memberwardno,memberlocality,membervillage,memberpanchayat,memberblock,memberwhatsupno,entrydate,modifydate,status")] memberregistration memberregistration)
        {
            if (ModelState.IsValid)
            {
                db.memberregistrations.Add(memberregistration);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(memberregistration);
        }

        // GET: Register/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memberregistration memberregistration = await db.memberregistrations.FindAsync(id);
            if (memberregistration == null)
            {
                return HttpNotFound();
            }
            return View(memberregistration);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,membername,memberemail,memberphone,membergender,memberage,memberstate,membercity,memberfathername,memberwardno,memberlocality,membervillage,memberpanchayat,memberblock,memberwhatsupno,entrydate,modifydate,status")] memberregistration memberregistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberregistration).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(memberregistration);
        }

        // GET: Register/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memberregistration memberregistration = await db.memberregistrations.FindAsync(id);
            if (memberregistration == null)
            {
                return HttpNotFound();
            }
            return View(memberregistration);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            memberregistration memberregistration = await db.memberregistrations.FindAsync(id);
            db.memberregistrations.Remove(memberregistration);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("AdminLogin","Home");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
