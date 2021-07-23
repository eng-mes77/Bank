using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Loan_level_Spec")]
    public partial class LoanLevelSpec
    {
        [Key]
        [Column("LLS_ID")]
        public long LlsId { get; set; }
        [Column("Bank_ID")]
        public long? BankId { get; set; }
        public int? Year { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        [StringLength(50)]
        public string Level { get; set; }
        [Column("Future_interest", TypeName = "decimal(18, 0)")]
        public decimal? FutureInterest { get; set; }
        [Column("Deferred_interest_And_fees", TypeName = "decimal(18, 0)")]
        public decimal? DeferredInterestAndFees { get; set; }
        [Column("Receivables_for_Mudaraba", TypeName = "decimal(18, 0)")]
        public decimal? ReceivablesForMudaraba { get; set; }
        [Column("Joint_acc_civil_participation", TypeName = "decimal(18, 0)")]
        public decimal? JointAccCivilParticipation { get; set; }
        [Column("Pub_DD_ID")]
        public long? PubDdId { get; set; }
        [Column("Ded_DD_ID")]
        public long? DedDdId { get; set; }

        [ForeignKey(nameof(BankId))]
        [InverseProperty("LoanLevelSpecs")]
        public virtual Bank Bank { get; set; }
        [ForeignKey(nameof(DedDdId))]
        [InverseProperty(nameof(DoubtfulReserveDetail.LoanLevelSpecDedDds))]
        public virtual DoubtfulReserveDetail DedDd { get; set; }
        [ForeignKey(nameof(PubDdId))]
        [InverseProperty(nameof(DoubtfulReserveDetail.LoanLevelSpecPubDds))]
        public virtual DoubtfulReserveDetail PubDd { get; set; }
    }
}
