using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Income_Loan_Deposit_debit")]
    public partial class IncomeLoanDepositDebit
    {
        public IncomeLoanDepositDebit()
        {
            IncomeDepositDebits = new HashSet<IncomeDepositDebit>();
            IncomeLoans = new HashSet<IncomeLoan>();
        }

        [Key]
        [Column("I_L_D_D_ID")]
        public long ILDDId { get; set; }
        [Column("Is_common")]
        public byte? IsCommon { get; set; }
        [Column("is_dollar")]
        public byte? IsDollar { get; set; }
        [Column("I_C_ID")]
        public long? ICId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("time_year")]
        public int? TimeYear { get; set; }

        [ForeignKey(nameof(ICId))]
        [InverseProperty(nameof(IncomeCost.IncomeLoanDepositDebits))]
        public virtual IncomeCost IC { get; set; }
        [InverseProperty(nameof(IncomeDepositDebit.ILDD))]
        public virtual ICollection<IncomeDepositDebit> IncomeDepositDebits { get; set; }
        [InverseProperty(nameof(IncomeLoan.ILDD))]
        public virtual ICollection<IncomeLoan> IncomeLoans { get; set; }
    }
}
