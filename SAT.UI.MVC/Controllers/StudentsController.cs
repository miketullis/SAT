using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAT.DATA.EF;
using SAT.UI.MVC.Utilities;

namespace SAT.UI.MVC.Controllers
{
    
    public class StudentsController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Students
        [Authorize(Roles = "Admin,Scheduler")]
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.StudentStatus);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        [Authorize(Roles = "Admin,Scheduler")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,Major,Address,City,State,ZipCode,Phone,Email,PhotoUrl,SSID")] Student student, HttpPostedFileBase studentPhoto)
        {
            if (ModelState.IsValid)
            {
                #region File Upload

                string imageName = "noImage.jpg";

                if ( studentPhoto != null)
                {
                    imageName = studentPhoto.FileName;

                    string ext = imageName.Substring(imageName.LastIndexOf("."));

                    string[] goodExts = new string[] { ".jpeg", ".jpg", ".png", ".gif" };

                    if (goodExts.Contains(ext.ToLower()) && studentPhoto.ContentLength <= 4194304)
                    {
                        imageName = Guid.NewGuid() + ext;

                        #region Resize Image Functionality
                        string savePath = Server.MapPath("~/Content/assets/images/students/");

                        Image convertedImage = Image.FromStream(studentPhoto.InputStream);

                        int maxImageSize = 300;

                        int maxThumbSize = 65;

                        ImageUtility.ResizeImage(savePath, imageName, convertedImage, maxImageSize, maxThumbSize);

                        #endregion

                    }                  
                }

                student.PhotoUrl = imageName;

                #endregion

                db.Students.Add(student);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Details", new { id = student.StudentId });
            }

            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // GET: Students/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FirstName,LastName,Major,Address,City,State,ZipCode,Phone,Email,PhotoUrl,SSID")] Student student, HttpPostedFileBase studentPhoto)
        {
            if (ModelState.IsValid)
            {
                #region File Upload

                string imageName = "noImage.jpg";

                if (studentPhoto != null)
                {
                    imageName = studentPhoto.FileName;

                    string ext = imageName.Substring(imageName.LastIndexOf("."));

                    string[] goodExts = new string[] { ".jpeg", ".jpg", ".png", ".gif" };

                    if (goodExts.Contains(ext.ToLower()) && studentPhoto.ContentLength <= 4194304)
                    {
                        imageName = Guid.NewGuid() + ext;

                        #region Resize Image Functionality
                        string savePath = Server.MapPath("~/Content/assets/images/students/");

                        Image convertedImage = Image.FromStream(studentPhoto.InputStream);

                        int maxImageSize = 300;

                        int maxThumbSize = 65;

                        ImageUtility.ResizeImage(savePath, imageName, convertedImage, maxImageSize, maxThumbSize);

                        #endregion

                        student.PhotoUrl = imageName;
                    }

                }

                #endregion

                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Details", new { id = student.StudentId });
            }
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // GET: Students/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            if (student.SSID == 2)
            {
                ViewBag.ButtonText = "Withdraw Student";
                ViewBag.Display = "Are you sure you want to withdraw " + student.FullName + "?";
            }
            else if (student.SSID == 3)
            { 
                ViewBag.ButtonText = "Reactivate Student";
                ViewBag.Display = "Reactivating " + student.FullName;
            }
            else
            {
                ViewBag.ButtonText = "Edit";
                ViewBag.Display = "For more complex statuses, please go to Edit";
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            if(student.SSID == 2)
            {
                student.SSID = 3;
            }
            else if (student.SSID == 3)
            {
                student.SSID = 2;
            }
            else
            {
                return RedirectToAction("Edit");
            }

            //db.Students.Remove(student);
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
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
