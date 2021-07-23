using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Loan_vasigheh")]
    public partial class LoanVasigheh
    {
        [Key]
        [Column("L_V_ID")]
        public long LVId { get; set; }
        [Column("Bank_ID")]
        public long? BankId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Amount { get; set; }
        [StringLength(10)]
        public string Title { get; set; }
        public int? Year { get; set; }

        [ForeignKey(nameof(BankId))]
        [InverseProperty("LoanVasighehs")]
        public virtual Bank Bank { get; set; }
    }
}
