using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Loan_Source_Currency")]
    public partial class LoanSourceCurrency
    {
        [Key]
        [Column("SC_D")]
        public long ScD { get; set; }
        [Column("L_ID")]
        public long? LId { get; set; }
        [Column("LDL_ID")]
        public long? LdlId { get; set; }
        [Column("Item_name")]
        [StringLength(50)]
        public string ItemName { get; set; }

        [ForeignKey(nameof(LId))]
        [InverseProperty(nameof(Loan.LoanSourceCurrencies))]
        public virtual Loan LIdNavigation { get; set; }
        [ForeignKey(nameof(LdlId))]
        [InverseProperty(nameof(LoanDetailsLevel.LoanSourceCurrencies))]
        public virtual LoanDetailsLevel Ldl { get; set; }
    }
}
