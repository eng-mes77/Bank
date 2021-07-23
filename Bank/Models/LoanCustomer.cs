using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Loan_Customer")]
    public partial class LoanCustomer
    {
        public LoanCustomer()
        {
            LoanEmployees = new HashSet<LoanEmployee>();
        }

        [Key]
        [Column("L_C_ID")]
        public long LCId { get; set; }
        [Column("Customer_type")]
        [StringLength(50)]
        public string CustomerType { get; set; }
        [Column("Gross_Amount", TypeName = "decimal(18, 0)")]
        public decimal? GrossAmount { get; set; }
        [Column("Doubtful_debts_reserves", TypeName = "decimal(18, 0)")]
        public decimal? DoubtfulDebtsReserves { get; set; }
        [Column("Net_Amount", TypeName = "decimal(18, 0)")]
        public decimal? NetAmount { get; set; }
        public int? Year { get; set; }
        [Column("Bank_ID")]
        public long? BankId { get; set; }

        [ForeignKey(nameof(BankId))]
        [InverseProperty("LoanCustomers")]
        public virtual Bank Bank { get; set; }
        [InverseProperty(nameof(LoanEmployee.LC))]
        public virtual ICollection<LoanEmployee> LoanEmployees { get; set; }
    }
}
