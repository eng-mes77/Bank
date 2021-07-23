using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Income_cost")]
    public partial class IncomeCost
    {
        public IncomeCost()
        {
            IncomeCostOthers = new HashSet<IncomeCostOther>();
            IncomeDollars = new HashSet<IncomeDollar>();
            IncomeInvestments = new HashSet<IncomeInvestment>();
            IncomeLoanDepositDebits = new HashSet<IncomeLoanDepositDebit>();
            IncomeOperationals = new HashSet<IncomeOperational>();
            IncomeSaleServices = new HashSet<IncomeSaleService>();
            IncomeWages = new HashSet<IncomeWage>();
        }

        [Key]
        [Column("I_C_ID")]
        public long ICId { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("Time_year")]
        public int? TimeYear { get; set; }
        [Column("BankID")]
        public long? BankId { get; set; }
        [Column("Is_income")]
        public byte? IsIncome { get; set; }

        [ForeignKey(nameof(BankId))]
        [InverseProperty("IncomeCosts")]
        public virtual Bank Bank { get; set; }
        [InverseProperty(nameof(IncomeCostOther.IC))]
        public virtual ICollection<IncomeCostOther> IncomeCostOthers { get; set; }
        [InverseProperty(nameof(IncomeDollar.IC))]
        public virtual ICollection<IncomeDollar> IncomeDollars { get; set; }
        [InverseProperty(nameof(IncomeInvestment.IC))]
        public virtual ICollection<IncomeInvestment> IncomeInvestments { get; set; }
        [InverseProperty(nameof(IncomeLoanDepositDebit.IC))]
        public virtual ICollection<IncomeLoanDepositDebit> IncomeLoanDepositDebits { get; set; }
        [InverseProperty(nameof(IncomeOperational.IC))]
        public virtual ICollection<IncomeOperational> IncomeOperationals { get; set; }
        [InverseProperty(nameof(IncomeSaleService.IC))]
        public virtual ICollection<IncomeSaleService> IncomeSaleServices { get; set; }
        [InverseProperty(nameof(IncomeWage.IC))]
        public virtual ICollection<IncomeWage> IncomeWages { get; set; }
    }
}
