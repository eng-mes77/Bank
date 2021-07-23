using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Doubtful_Reserve_Details")]
    public partial class DoubtfulReserveDetail
    {
        public DoubtfulReserveDetail()
        {
            LoanLevelSpecDedDds = new HashSet<LoanLevelSpec>();
            LoanLevelSpecPubDds = new HashSet<LoanLevelSpec>();
        }

        [Key]
        [Column("DD_ID")]
        public long DdId { get; set; }
        [Column("Beginning_balance", TypeName = "decimal(18, 0)")]
        public decimal? BeginningBalance { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Recovered { get; set; }
        [Column("Bad_debts", TypeName = "decimal(18, 0)")]
        public decimal? BadDebts { get; set; }
        [Column("Inc_or_dec_during_year", TypeName = "decimal(18, 0)")]
        public decimal? IncOrDecDuringYear { get; set; }

        [InverseProperty(nameof(LoanLevelSpec.DedDd))]
        public virtual ICollection<LoanLevelSpec> LoanLevelSpecDedDds { get; set; }
        [InverseProperty(nameof(LoanLevelSpec.PubDd))]
        public virtual ICollection<LoanLevelSpec> LoanLevelSpecPubDds { get; set; }
    }
}
