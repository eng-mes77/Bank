using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Loan_details_Spec")]
    public partial class LoanDetailsSpec
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("Balance_and_comm_interest_future", TypeName = "decimal(18, 0)")]
        public decimal? BalanceAndCommInterestFuture { get; set; }
        [Column("Balance_and_interest_receivable_fee", TypeName = "decimal(18, 0)")]
        public decimal? BalanceAndInterestReceivableFee { get; set; }
        [Column("Rec_penalty_clause", TypeName = "decimal(18, 0)")]
        public decimal? RecPenaltyClause { get; set; }
        [Column("-Mudaraba_and_joint_civil_receivables", TypeName = "decimal(18, 0)")]
        public decimal? MudarabaAndJointCivilReceivables { get; set; }
        [Column("-Future_interest", TypeName = "decimal(18, 0)")]
        public decimal? FutureInterest { get; set; }
        [Column("-Deferred_penalty_clause_interest_fee", TypeName = "decimal(18, 0)")]
        public decimal? DeferredPenaltyClauseInterestFee { get; set; }
        [Column("-Doubtful_debts_reserves", TypeName = "decimal(18, 0)")]
        public decimal? DoubtfulDebtsReserves { get; set; }
        [Column("L_ID")]
        public long? LId { get; set; }

        [ForeignKey(nameof(LId))]
        [InverseProperty(nameof(Loan.LoanDetailsSpecs))]
        public virtual Loan LIdNavigation { get; set; }
    }
}
