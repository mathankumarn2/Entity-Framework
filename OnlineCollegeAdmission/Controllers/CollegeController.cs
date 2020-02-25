using OnlineCollegeAdmission.BL;
using OnlineCollegeAdmission.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCollegeAdmission.Controllers
{
    public class CollegeController : Controller
    {
        // GET: College
        CollegeBL collegeBL;
        public ActionResult Index()
        {
            return View();
        }
        public CollegeController()
        {
            collegeBL = new CollegeBL();
        }
        public ActionResult DisplayCollegeByUser()
        {
            List<College> collegeList = collegeBL.GetColleges();
            return View(collegeList);
        }
        public ActionResult DisplayCollegeByAdmin()
        {
            DataTable dataTable = collegeBL.GetCollegeTable();
            return View(dataTable);
        }
        public ActionResult CreateCollege()
        {
            return View();
        }
        [HttpPost]
        [ActionName("CreateCollege")]
        public ActionResult CreateCollege_post()
        {
            College college = new College();
            TryUpdateModel(college);
            if (ModelState.IsValid)
            {
                collegeBL.AddCollege(college);
                TempData["CollegeCode"] = college.CollegeCode;
                return RedirectToAction("AddDepartment");
            }
            return View(); 
        }
        public ActionResult EditCollege(string collegeCode)
        {
            College college = collegeBL.GetCollegeByCode(collegeCode);
            return View(college);
        }
        public ActionResult UpdateCollege([Bind(Include = "CollegeCode, AdmissionFee, TotalSeats")] College college)
        {
            collegeBL.UpdateCollege(college.CollegeCode, college.AdmissionFee, college.TotalSeats);
            TempData["Message"] = "Update Sucessfully";
            return RedirectToAction("DisplayCollegeByAdmin");
        }
        public ActionResult DeleteCollege(College college)
        {
            collegeBL.DeleteCollege(college.CollegeCode);
            return RedirectToAction("DisplayCollegeByAdmin");
        }
        public ActionResult AddDepartment()
        {
            Department department = new Department();
            department.CollegeCode = TempData["CollegeCode"].ToString();
            DataTable dataTable = collegeBL.GetDept();
            List<SelectListItem> deptList = new List<SelectListItem>();
            foreach (DataRow row in dataTable.Rows)
            {
                deptList.Add(new SelectListItem { Text = @row[1].ToString(), Value = @row[0].ToString() });
            }
            ViewBag.dept = deptList;
            return View(department);
        }
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                collegeBL.AddDepartment(department);
                TempData["CollegeCode"] = department.CollegeCode;
                return RedirectToAction("DisplayDepartment");
            }
            return View();            
        }
        public ActionResult DisplayDepartment()
        {
            DataTable dataTable = collegeBL.GetDepartmentByCollege(TempData["CollegeCode"].ToString());
            ViewData["CollegeCode"] = TempData["CollegeCode"].ToString();
            return View(dataTable);
        }
    }
}