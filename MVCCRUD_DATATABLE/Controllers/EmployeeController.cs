using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUD_DATATABLE.Models;
using System.Data.Entity;

namespace MVCCRUD_DATATABLE.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (MVCMODEL db=new MVCMODEL())
            {
                List<Employee> empList = db.Employee.ToList<Employee>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddOrEdit(int id=0)
        {
            if (id==0)
            {
                return View(new Employee());
            }
            else
            {
                using (MVCMODEL db=new MVCMODEL())
                {
                    return View(db.Employee.Where(x => x.EmployeeId == id).FirstOrDefault<Employee>());
                }
            }
           
            
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            using (MVCMODEL db=new MVCMODEL())
            {
                if (emp.EmployeeId==0)
                {
                    db.Employee.Add(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);

                }

            }
         

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (MVCMODEL db=new MVCMODEL())
            {
                Employee emp = db.Employee.Where(x => x.EmployeeId == id).FirstOrDefault<Employee>();
                db.Employee.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}