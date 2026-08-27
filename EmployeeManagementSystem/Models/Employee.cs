using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int emp_id { get; set; }

        public string? employee_code { get; set; }

        public string emp_name { get; set; }

        public string emp_email { get; set; }

        public string phone { get; set; }

        public string? gender { get; set; }

        public DateTime? date_of_birth { get; set; }

        public string? cnic { get; set; }

        public string? address { get; set; }

        public string? emergency_contact { get; set; }

        public int Dep_id { get; set; }

        public string designation { get; set; }

        public string employment_type { get; set; } = "Full-time";

        public DateTime joiningDate { get; set; }

        public decimal salary { get; set; }

        public string password { get; set; }

        public string status { get; set; } = "Active";

        public int? reporting_manager_id { get; set; }
    }
}