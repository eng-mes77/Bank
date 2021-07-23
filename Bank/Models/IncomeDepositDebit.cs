using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Income_Deposit_Debit")]
    public partial class IncomeDepositDebit
    {
        [Key]
        [Column("I_D_D_ID")]
        public long IDDId { get; set; }
        [Column("Common_vol_reial", TypeName = "decimal(18, 0)")]
        public decimal? CommonVolReial { get; set; }
        [Column("noncommon_vol_reial", TypeName = "decimal(18, 0)")]
        public decimal? NoncommonVolReial { get; set; }
        [Column("common_dollar", TypeName = "decimal(18, 0)")]
        public decimal? CommonDollar { get; set; }
        [Column("I_L_D_D_ID")]
        public long? ILDDId { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("time_year")]
        public int? TimeYear { get; set; }

        [ForeignKey(nameof(ILDDId))]
        [InverseProperty(nameof(IncomeLoanDepositDebit.IncomeDepositDebits))]
        public virtual IncomeLoanDepositDebit ILDD { get; set; }
    }
}
