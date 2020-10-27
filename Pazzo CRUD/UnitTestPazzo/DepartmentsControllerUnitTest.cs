using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pazzo_CRUD.Controllers;
using Pazzo_CRUD.Models;
using UnitTestPazzo.Repositories;

namespace UnitTestPazzo
{
    [TestClass]
    public class DepartmentsControllerUnitTest
    {
        Department dept1;
        List<Department> depts = null;
        DummyDepartmentsRepository deptsRepo = null;
        UnitOfWork uow = null;
        DepartmentsController controller = null;

        public DepartmentsControllerUnitTest()
        {
            dept1 = new Department { Id=1, name = "業務一部", createDate = DateTime.Now };
            depts = new List<Department>
            {
                dept1,
                new Department {Id=2, name = "業務部", createDate = DateTime.Now},
                new Department {Id=3, name = "行政部", createDate = DateTime.Now},
                new Department {Id=4, name = "生產部", createDate = DateTime.Now},
                new Department {Id=5, name = "工程部", createDate = DateTime.Now},

            };

            // 建立假的Repository
            deptsRepo = new DummyDepartmentsRepository(depts);

            // 建立測試用的UnitOfWork
            uow = new UnitOfWork(deptsRepo);

            // 建立Department 控制項 用來測試與傳送uow 參數
            controller = new DepartmentsController(uow);
        }


        [TestMethod]
        public void Create()
        {
            // 建立假資料
            Department newDept = new Department { Id = 6, name = "總經理室", createDate = DateTime.Now };

            // 執行
            controller.Create(newDept);

            // 取得所有資料
            List<Department> depts = deptsRepo.GetAllDepartments();

            CollectionAssert.Contains(depts, newDept);
        }

        [TestMethod]
        public void Edit()
        {
            // 建立筆要驗證修改的資料
            Department eDept = new Department { Id = 2, name = "業務部"};

            // 執行修改
            controller.Edit(eDept);

            // 回傳所有資料
            List<Department> depts = deptsRepo.GetAllDepartments();

            CollectionAssert.Contains(depts, eDept);
        }

        [TestMethod]
        public void Delete()
        {
            // 呼叫確認刪除的方法
            controller.DeleteConfirmed(1);

            // 取得目前所有的資料
            List<Department> depts = deptsRepo.GetAllDepartments();

            CollectionAssert.DoesNotContain(depts, dept1);
        }
    }
}
