using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Loan_Flow")]
    public partial class LoanFlow
    {
        public LoanFlow()
        {
            Loans = new HashSet<Loan>();
        }

        [Key]
        [Column("L_F_ID")]
        public long LFId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [Column("Balance_prev_year", TypeName = "decimal(18, 0)")]
        public decimal? BalancePrevYear { get; set; }
        [Column("Inc_during_year", TypeName = "decimal(18, 0)")]
        public decimal? IncDuringYear { get; set; }
        [Column("Collected_during_year", TypeName = "decimal(18, 0)")]
        public decimal? CollectedDuringYear { get; set; }
        [Column("Foreign_exchange_effect", TypeName = "decimal(18, 0)")]
        public decimal? ForeignExchangeEffect { get; set; }

        [InverseProperty(nameof(Loan.LF))]
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
