using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Income_Dollar")]
    public partial class IncomeDollar
    {
        [Key]
        [Column("I_D_ID")]
        public long IDId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("time_year")]
        public int? TimeYear { get; set; }
        [Column("I_C_ID")]
        public long? ICId { get; set; }

        [ForeignKey(nameof(ICId))]
        [InverseProperty(nameof(IncomeCost.IncomeDollars))]
        public virtual IncomeCost IC { get; set; }
    }
}
