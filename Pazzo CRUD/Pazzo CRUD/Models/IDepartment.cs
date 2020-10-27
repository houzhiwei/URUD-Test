using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazzo_CRUD.Models
{
    public interface IDepartment
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int? id);
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(Department department);
        void Save();
    }
}
