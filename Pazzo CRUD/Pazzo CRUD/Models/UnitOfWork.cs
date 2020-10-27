using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pazzo_CRUD.Models
{
    public class UnitOfWork: IDisposable
    {
        private PazzoDBEntities entities = null;

        // Controller 的預設建構子呼叫時使用
        public UnitOfWork()
        {
            entities = new PazzoDBEntities();
            DepartmentRepository = new DepartmentRepository(entities);
        }

        // This will be created from test project and passed on to the
        // controllers parameterized constructors
        public UnitOfWork(IDepartment deptRepo)
        {
            DepartmentRepository = deptRepo;
        }

        public IDepartment DepartmentRepository
        {
            get;
            private set;
        }
        #region IDisposable Members

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

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}