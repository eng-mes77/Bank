using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("loan")]
    public partial class Loan
    {
        public Loan()
        {
            LoanDetailsLevels = new HashSet<LoanDetailsLevel>();
            LoanDetailsSpecs = new HashSet<LoanDetailsSpec>();
            LoanInternals = new HashSet<LoanInternal>();
            LoanSourceCurrencies = new HashSet<LoanSourceCurrency>();
            LoanTimeBenefits = new HashSet<LoanTimeBenefit>();
        }

        [Key]
        [Column("L_ID")]
        public long LId { get; set; }
        [Column("TypeID")]
        public long? TypeId { get; set; }
        [Column("Time_Year")]
        public int? TimeYear { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("Is_Group")]
        public byte? IsGroup { get; set; }
        [Column("Is_Dollar")]
        public byte? IsDollar { get; set; }
        [Column("BankID")]
        public long? BankId { get; set; }
        [Column("L_F_ID")]
        public long? LFId { get; set; }

        [ForeignKey(nameof(BankId))]
        [InverseProperty("Loans")]
        public virtual Bank Bank { get; set; }
        [ForeignKey(nameof(LFId))]
        [InverseProperty(nameof(LoanFlow.Loans))]
        public virtual LoanFlow LF { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(LoanType.Loans))]
        public virtual LoanType Type { get; set; }
        [InverseProperty(nameof(LoanDetailsLevel.LIdNavigation))]
        public virtual ICollection<LoanDetailsLevel> LoanDetailsLevels { get; set; }
        [InverseProperty(nameof(LoanDetailsSpec.LIdNavigation))]
        public virtual ICollection<LoanDetailsSpec> LoanDetailsSpecs { get; set; }
        [InverseProperty(nameof(LoanInternal.LIdNavigation))]
        public virtual ICollection<LoanInternal> LoanInternals { get; set; }
        [InverseProperty(nameof(LoanSourceCurrency.LIdNavigation))]
        public virtual ICollection<LoanSourceCurrency> LoanSourceCurrencies { get; set; }
        [InverseProperty(nameof(LoanTimeBenefit.LIdNavigation))]
        public virtual ICollection<LoanTimeBenefit> LoanTimeBenefits { get; set; }
    }
}
