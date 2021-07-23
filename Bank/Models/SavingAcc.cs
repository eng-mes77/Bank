using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Saving_ACC")]
    public partial class SavingAcc
    {
        [Key]
        [Column("S_A_ID")]
        public long SAId { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("is_dollar")]
        public byte? IsDollar { get; set; }
        [Column("D_ID")]
        public long? DId { get; set; }
        [Column("Time_year")]
        public int? TimeYear { get; set; }

        [ForeignKey(nameof(DId))]
        [InverseProperty(nameof(Deposit.SavingAccs))]
        public virtual Deposit DIdNavigation { get; set; }
    }
}
