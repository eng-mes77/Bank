using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Bank")]
    public partial class Bank
    {
        public Bank()
        {
            Deposits = new HashSet<Deposit>();
            IncomeCosts = new HashSet<IncomeCost>();
            LoanCustomers = new HashSet<LoanCustomer>();
            LoanLevelSpecs = new HashSet<LoanLevelSpec>();
            LoanVasighehs = new HashSet<LoanVasigheh>();
            Loans = new HashSet<Loan>();
        }

        [Key]
        [Column("BankID")]
        public long BankId { get; set; }
        [StringLength(10)]
        public string Title { get; set; }

        [InverseProperty(nameof(Deposit.Bank))]
        public virtual ICollection<Deposit> Deposits { get; set; }
        [InverseProperty(nameof(IncomeCost.Bank))]
        public virtual ICollection<IncomeCost> IncomeCosts { get; set; }
        [InverseProperty(nameof(LoanCustomer.Bank))]
        public virtual ICollection<LoanCustomer> LoanCustomers { get; set; }
        [InverseProperty(nameof(LoanLevelSpec.Bank))]
        public virtual ICollection<LoanLevelSpec> LoanLevelSpecs { get; set; }
        [InverseProperty(nameof(LoanVasigheh.Bank))]
        public virtual ICollection<LoanVasigheh> LoanVasighehs { get; set; }
        [InverseProperty(nameof(Loan.Bank))]
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
