using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Deposit")]
    public partial class Deposit
    {
        public Deposit()
        {
            DemandingAccs = new HashSet<DemandingAcc>();
            OtherDeposits = new HashSet<OtherDeposit>();
            SavingAccs = new HashSet<SavingAcc>();
        }

        [Key]
        [Column("D_ID")]
        public long DId { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [Column("BankID")]
        public long? BankId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Volumne { get; set; }
        [Column("Time_year")]
        public int? TimeYear { get; set; }
        [Column("is_Group")]
        public byte? IsGroup { get; set; }

        [ForeignKey(nameof(BankId))]
        [InverseProperty("Deposits")]
        public virtual Bank Bank { get; set; }
        [InverseProperty(nameof(DemandingAcc.DIdNavigation))]
        public virtual ICollection<DemandingAcc> DemandingAccs { get; set; }
        [InverseProperty(nameof(OtherDeposit.DIdNavigation))]
        public virtual ICollection<OtherDeposit> OtherDeposits { get; set; }
        [InverseProperty(nameof(SavingAcc.DIdNavigation))]
        public virtual ICollection<SavingAcc> SavingAccs { get; set; }
    }
}
