using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineCollegeAdmission.Entity
{
    public class College
    {
        [DisplayName("College Code")]
        [Required(ErrorMessage = "College code is required")]
        [Key]
        public string CollegeCode { get; set; }

        [DisplayName("College Name")]
        [Required(ErrorMessage = "College Name is required")]
        public string CollegeName { get; set; }

        [DisplayName("College Website")]
        [Required(ErrorMessage = "College Website is required")]
        public string CollegeWebsite { get; set; }

        [DisplayName("Fees")]
        [Required(ErrorMessage = "Fees is required")]
        public int AdmissionFee { get; set; }

        [DisplayName("Avilable Seats")]
        [Required(ErrorMessage = "Total seat count is required")]
        public int TotalSeats { get; set; }

        public College()
        {

        }
        public College(string collegeCode, string collegeName, string collegeWebsite, int admissionfee, int totalSeats)
        {
            this.CollegeCode = collegeCode;
            this.CollegeName = collegeName;
            this.CollegeWebsite = collegeWebsite;
            this.AdmissionFee = admissionfee;
            this.TotalSeats = totalSeats;
        }
    }
}
