using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Income_Property")]
    public partial class IncomeProperty
    {
        [Key]
        [Column("I_P_ID")]
        public long IPId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [Column("Sale_vol", TypeName = "decimal(18, 0)")]
        public decimal? SaleVol { get; set; }
        [Column("Arzesh_daftari_Vol", TypeName = "decimal(18, 0)")]
        public decimal? ArzeshDaftariVol { get; set; }
        [Column("Tamam_Vol", TypeName = "decimal(18, 0)")]
        public decimal? TamamVol { get; set; }
        [Column("time_year")]
        public int? TimeYear { get; set; }
        [Column("I_C_O_ID")]
        public long? ICOId { get; set; }

        [ForeignKey(nameof(ICOId))]
        [InverseProperty(nameof(IncomeCostOther.IncomeProperties))]
        public virtual IncomeCostOther ICO { get; set; }
    }
}
