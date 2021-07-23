using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Income_Operational")]
    public partial class IncomeOperational
    {
        [Key]
        [Column("I_O_ID")]
        public long IOId { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("volumne", TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("time_Year")]
        public int? TimeYear { get; set; }
        [Column("I_C_ID")]
        public long? ICId { get; set; }

        [ForeignKey(nameof(ICId))]
        [InverseProperty(nameof(IncomeCost.IncomeOperationals))]
        public virtual IncomeCost IC { get; set; }
    }
}
