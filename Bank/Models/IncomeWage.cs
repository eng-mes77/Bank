using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Income_Wage")]
    public partial class IncomeWage
    {
        public IncomeWage()
        {
            InverseICIdFkeyNavigation = new HashSet<IncomeWage>();
        }

        [Key]
        [Column("I_W_ID")]
        public long IWId { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("time_year")]
        public int? TimeYear { get; set; }
        [Column("I_C_ID")]
        public long? ICId { get; set; }
        [Column("I_C_ID_FKey")]
        public long? ICIdFkey { get; set; }

        [ForeignKey(nameof(ICId))]
        [InverseProperty(nameof(IncomeCost.IncomeWages))]
        public virtual IncomeCost IC { get; set; }
        [ForeignKey(nameof(ICIdFkey))]
        [InverseProperty(nameof(IncomeWage.InverseICIdFkeyNavigation))]
        public virtual IncomeWage ICIdFkeyNavigation { get; set; }
        [InverseProperty(nameof(IncomeWage.ICIdFkeyNavigation))]
        public virtual ICollection<IncomeWage> InverseICIdFkeyNavigation { get; set; }
    }
}
