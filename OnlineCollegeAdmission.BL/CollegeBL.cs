using OnlineCollegeAdmission.DAL;
using OnlineCollegeAdmission.Entity;
using System.Collections.Generic;
using System.Data;

namespace OnlineCollegeAdmission.BL
{
    public interface ICollegeBL
    {
        void AddCollege(College college);
        void UpdateCollege(string CollegeCode, int fee, int seats);
        void DeleteCollege(string collegeCode);
        DataTable GetCollegeTable();
        DataTable GetDepartmentByCollege(string collegeCode);
        void AddDepartment(Department department);
        List<College> GetColleges();
        DataTable GetDept();
    }
    public class CollegeBL : ICollegeBL
    {
        ICollegeRepository collegeRepository;
        public CollegeBL()
        {
            collegeRepository = new CollegeRepository();
        }
        public void AddCollege(College college)
        {
            collegeRepository.AddCollege(college);
        }
        public void UpdateCollege(string collegeCode, int fee, int seats)
        {
            collegeRepository.UpdateCollege(collegeCode, fee, seats);
        }
        public void DeleteCollege(string collegeCode)
        {
            collegeRepository.DeleteCollege(collegeCode);
        }
        public DataTable GetCollegeTable()
        {
            return collegeRepository.GetCollegeTable();
        }
        public College GetCollegeByCode(string collegeCode)
        {
            return collegeRepository.GetCollegeByCode(collegeCode);
        }
        public DataTable GetDepartmentByCollege(string collegeCode)
        {
            return collegeRepository.GetDepartmentByCollege(collegeCode);
        }
        public void AddDepartment(Department department)
        {
            collegeRepository.AddDepartment(department);
        }
        public List<College> GetColleges()
        {
            return collegeRepository.GetColleges();
        }
        public DataTable GetDept()
        {
            return collegeRepository.GetDept();
        }
    }
}
