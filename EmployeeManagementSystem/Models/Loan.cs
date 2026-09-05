using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    [Table("loans")]
    public class Loan
    {
        [Key]
        public int loan_id { get; set; }

        public int emp_id { get; set; }

        public decimal loan_amount { get; set; }

        public decimal monthly_installment { get; set; }

        public decimal remaining_balance { get; set; }

        public string status { get; set; } = "Active";

        public DateTime start_date { get; set; }
    }
}