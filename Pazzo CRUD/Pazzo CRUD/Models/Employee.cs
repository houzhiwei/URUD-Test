using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pazzo_CRUD.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int DeptID { get; set; }

    }
}