using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Loan_internal")]
    public partial class LoanInternal
    {
        [Key]
        [Column("L_I_ID")]
        public long LIId { get; set; }
        [Column("L_ID")]
        public long? LId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Current { get; set; }
        [Column("Non-performing", TypeName = "decimal(18, 0)")]
        public decimal? NonPerforming { get; set; }
        [Column("Weighted_average_interest_rate", TypeName = "decimal(18, 0)")]
        public decimal? WeightedAverageInterestRate { get; set; }
        [Column("Doubtful_debts_reserves", TypeName = "decimal(18, 0)")]
        public decimal? DoubtfulDebtsReserves { get; set; }

        [ForeignKey(nameof(LId))]
        [InverseProperty(nameof(Loan.LoanInternals))]
        public virtual Loan LIdNavigation { get; set; }
    }
}
