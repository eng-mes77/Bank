using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Income_Cost_Other")]
    public partial class IncomeCostOther
    {
        public IncomeCostOther()
        {
            IncomeProperties = new HashSet<IncomeProperty>();
        }

        [Key]
        [Column("I_C_O_ID")]
        public long ICOId { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("volumne", TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("I_C_ID")]
        public long? ICId { get; set; }
        [Column("time_year")]
        public int? TimeYear { get; set; }

        [ForeignKey(nameof(ICId))]
        [InverseProperty(nameof(IncomeCost.IncomeCostOthers))]
        public virtual IncomeCost IC { get; set; }
        [InverseProperty(nameof(IncomeProperty.ICO))]
        public virtual ICollection<IncomeProperty> IncomeProperties { get; set; }
    }
}
