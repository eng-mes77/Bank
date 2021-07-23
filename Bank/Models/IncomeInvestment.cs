using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Income_Investment")]
    public partial class IncomeInvestment
    {
        public IncomeInvestment()
        {
            InverseIIIdFkeyNavigation = new HashSet<IncomeInvestment>();
        }

        [Key]
        [Column("I_I_ID")]
        public long IIId { get; set; }
        [Column("Common_vol_reial", TypeName = "decimal(18, 0)")]
        public decimal? CommonVolReial { get; set; }
        [Column("Common_vol_dollar", TypeName = "decimal(18, 0)")]
        public decimal? CommonVolDollar { get; set; }
        [Column("nonCommon_vol_reial", TypeName = "decimal(18, 0)")]
        public decimal? NonCommonVolReial { get; set; }
        [Column("nonCommon_vol_dollar", TypeName = "decimal(18, 0)")]
        public decimal? NonCommonVolDollar { get; set; }
        [Column("time_year")]
        public int? TimeYear { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("I_C_ID")]
        public long? ICId { get; set; }
        [Column("I_I_ID_FKey")]
        public long? IIIdFkey { get; set; }

        [ForeignKey(nameof(ICId))]
        [InverseProperty(nameof(IncomeCost.IncomeInvestments))]
        public virtual IncomeCost IC { get; set; }
        [ForeignKey(nameof(IIIdFkey))]
        [InverseProperty(nameof(IncomeInvestment.InverseIIIdFkeyNavigation))]
        public virtual IncomeInvestment IIIdFkeyNavigation { get; set; }
        [InverseProperty(nameof(IncomeInvestment.IIIdFkeyNavigation))]
        public virtual ICollection<IncomeInvestment> InverseIIIdFkeyNavigation { get; set; }
    }
}
