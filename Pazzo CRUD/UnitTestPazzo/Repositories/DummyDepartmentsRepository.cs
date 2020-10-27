using Pazzo_CRUD.Models;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestPazzo.Repositories
{
    class DummyDepartmentsRepository: IDepartment
    {
        List<Department> m_depts = null;

        public DummyDepartmentsRepository(List<Department> depts)
        {
            this.m_depts = depts;
        }

        public void AddDepartment(Department dept)
        {
            m_depts.Add(dept);
        }

        public void DeleteDepartment(Department dept)
        {
            m_depts.Remove(dept);
        }

        public List<Department> GetAllDepartments()
        {
            return m_depts;
        }

        public Department GetDepartmentById(int? id)
        {
            return m_depts.SingleOrDefault(dept => dept.Id == id);
        }

        public void Save()
        {
            // Nothing to do here
        }

        public void UpdateDepartment(Department dept)
        {
            int id = dept.Id;
            Department deptToUpdate = m_depts.SingleOrDefault(b => b.Id == id);
            DeleteDepartment(deptToUpdate);
            m_depts.Add(dept);
        }

    }
}
