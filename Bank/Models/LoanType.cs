using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Loan_Type")]
    public partial class LoanType
    {
        public LoanType()
        {
            LoanEmployees = new HashSet<LoanEmployee>();
            Loans = new HashSet<Loan>();
        }

        [Key]
        [Column("L_T_ID")]
        public long LTId { get; set; }
        [Column("LType")]
        [StringLength(50)]
        public string Ltype { get; set; }
        [Column("LTitle")]
        [StringLength(50)]
        public string Ltitle { get; set; }

        [InverseProperty(nameof(LoanEmployee.Type))]
        public virtual ICollection<LoanEmployee> LoanEmployees { get; set; }
        [InverseProperty(nameof(Loan.Type))]
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
