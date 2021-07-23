using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Demanding_Acc")]
    public partial class DemandingAcc
    {
        [Key]
        [Column("D_A_ID")]
        public long DAId { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("is_Dollar")]
        public byte? IsDollar { get; set; }
        [Column("Time_year")]
        public int? TimeYear { get; set; }
        [Column("D_ID")]
        public long? DId { get; set; }

        [ForeignKey(nameof(DId))]
        [InverseProperty(nameof(Deposit.DemandingAccs))]
        public virtual Deposit DIdNavigation { get; set; }
    }
}
