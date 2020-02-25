using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCollegeAdmission.Entity
{
    public class Department
    {
        [DisplayName("College Code")]
        [Required(ErrorMessage ="CollegeCode is Required")]
        [Key]
        public string CollegeCode { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "please select Department")]
        public string DeptId { get; set; }

        [DisplayName("Fees")]
        [Required(ErrorMessage = "please enter college Fee")]
        public int Fees { get; set; }

        [DisplayName("Available Seats")]
        [Required(ErrorMessage = "please enter avilable seats")]
        public int Seats { get; set; }

        public Department()
        {

        }
    }
}
