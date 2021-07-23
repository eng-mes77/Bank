using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Income_Sale_Service")]
    public partial class IncomeSaleService
    {
        [Key]
        [Column("I_S_S_ID")]
        public long ISSId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("Time_year")]
        public int? TimeYear { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("I_C_ID")]
        public long? ICId { get; set; }

        [ForeignKey(nameof(ICId))]
        [InverseProperty(nameof(IncomeCost.IncomeSaleServices))]
        public virtual IncomeCost IC { get; set; }
    }
}
