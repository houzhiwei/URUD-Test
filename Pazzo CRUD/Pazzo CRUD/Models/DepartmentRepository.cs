using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pazzo_CRUD.Models
{
    public class DepartmentRepository : IDepartment
    {
        private PazzoDBEntities entities = new PazzoDBEntities();

        public DepartmentRepository(PazzoDBEntities entities)
        {
            this.entities = entities;
        }

        public void AddDepartment(Department department)
        {
            entities.Department.Add(department);
        }

        public void DeleteDepartment(Department department)
        {
            //Department department = entities.Department.Find(id);
            entities.Department.Remove(department);
            entities.SaveChanges();
        }

        public List<Department> GetAllDepartments()
        {
            return entities.Department.ToList();
        }

        public Department GetDepartmentById(int? id)
        {
            return entities.Department.SingleOrDefault(dept => dept.Id == id);
        }

        public void Save()
        {
            entities.SaveChanges();
        }

        public void UpdateDepartment(Department dept)
        {
            entities.Entry(dept).State = EntityState.Modified;
            entities.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                entities = null;
            }
        }
        ~DepartmentRepository()
        {
            Dispose(false);
        }
    }
}