using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Loan_details_level")]
    public partial class LoanDetailsLevel
    {
        public LoanDetailsLevel()
        {
            LoanSourceCurrencies = new HashSet<LoanSourceCurrency>();
        }

        [Key]
        [Column("LDL_ID")]
        public long LdlId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Checking { get; set; }
        [Column("Past_Maturity", TypeName = "decimal(18, 0)")]
        public decimal? PastMaturity { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Delayed { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Doubtful { get; set; }
        [Column("L_ID")]
        public long? LId { get; set; }

        [ForeignKey(nameof(LId))]
        [InverseProperty(nameof(Loan.LoanDetailsLevels))]
        public virtual Loan LIdNavigation { get; set; }
        [InverseProperty(nameof(LoanSourceCurrency.Ldl))]
        public virtual ICollection<LoanSourceCurrency> LoanSourceCurrencies { get; set; }
    }
}
