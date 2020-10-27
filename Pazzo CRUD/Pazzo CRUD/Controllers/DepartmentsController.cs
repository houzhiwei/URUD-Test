using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pazzo_CRUD.Models;

namespace Pazzo_CRUD.Controllers
{
    public class DepartmentsController : Controller
    {
        //private PazzoDBEntities db = new PazzoDBEntities();
        private UnitOfWork unitOfWork = null;                       //使用UnitOfWork 進行資料庫存取
        public DepartmentsController(): this(new UnitOfWork())
        {

        }
        public DepartmentsController(UnitOfWork uow)
        {
            this.unitOfWork = uow;
        }
        // GET: Departments
        public ActionResult Index()
        {
            List<Department> depts = unitOfWork.DepartmentRepository.GetAllDepartments();
            return View(depts);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = unitOfWork.DepartmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,createDate")] Department department)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DepartmentRepository.AddDepartment(department);
                unitOfWork.DepartmentRepository.Save();
                //db.Department.Add(department);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = unitOfWork.DepartmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,createDate")] Department department)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DepartmentRepository.UpdateDepartment(department);
                unitOfWork.DepartmentRepository.Save();
               
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = unitOfWork.DepartmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department dept = unitOfWork.DepartmentRepository.GetDepartmentById(id);
            unitOfWork.DepartmentRepository.DeleteDepartment(dept);

            //Department department = db.Department.Find(id);
            //db.Department.Remove(department);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
