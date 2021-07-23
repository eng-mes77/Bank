using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Income_Loan")]
    public partial class IncomeLoan
    {
        [Key]
        [Column("I_L_ID")]
        public long ILId { get; set; }
        [Column("Common_Vol_reial", TypeName = "decimal(18, 0)")]
        public decimal? CommonVolReial { get; set; }
        [Column("noncommon_Vol_reial", TypeName = "decimal(18, 0)")]
        public decimal? NoncommonVolReial { get; set; }
        [Column("Common_vol_dollar", TypeName = "decimal(18, 0)")]
        public decimal? CommonVolDollar { get; set; }
        [Column("noncommon_vol_dollar", TypeName = "decimal(18, 0)")]
        public decimal? NoncommonVolDollar { get; set; }
        [Column("I_L_D_D_ID")]
        public long? ILDDId { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("time_year")]
        public int? TimeYear { get; set; }

        [ForeignKey(nameof(ILDDId))]
        [InverseProperty(nameof(IncomeLoanDepositDebit.IncomeLoans))]
        public virtual IncomeLoanDepositDebit ILDD { get; set; }
    }
}
