using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int emp_id { get; set; }

        public string emp_name { get; set; }

        public string emp_email { get; set; }

        public string phone { get; set; }

        public int Dep_id { get; set; }

        public string designation { get; set; }

        public DateTime joiningDate { get; set; }

        public decimal salary { get; set; }

        public string password { get; set; }

        public string status { get; set; } = "Active";
        public int? reporting_manager_id { get; set; }
    }
}