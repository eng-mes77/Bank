using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Other_Deposit")]
    public partial class OtherDeposit
    {
        [Key]
        [Column("I_D_ID")]
        public long IDId { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("is_Dollar")]
        public byte? IsDollar { get; set; }
        [Column("D_ID")]
        public long? DId { get; set; }
        [Column("Time_year")]
        public int? TimeYear { get; set; }

        [ForeignKey(nameof(DId))]
        [InverseProperty(nameof(Deposit.OtherDeposits))]
        public virtual Deposit DIdNavigation { get; set; }
    }
}
