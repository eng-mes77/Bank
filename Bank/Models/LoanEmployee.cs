using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Loan_employee")]
    public partial class LoanEmployee
    {
        [Key]
        [Column("L_E_ID")]
        public long LEId { get; set; }
        [Column("L_C_ID")]
        public long? LCId { get; set; }
        [Column("Type_ID")]
        public long? TypeId { get; set; }
        [Column("amount", TypeName = "decimal(18, 0)")]
        public decimal? Amount { get; set; }

        [ForeignKey(nameof(LCId))]
        [InverseProperty(nameof(LoanCustomer.LoanEmployees))]
        public virtual LoanCustomer LC { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(LoanType.LoanEmployees))]
        public virtual LoanType Type { get; set; }
    }
}
