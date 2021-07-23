using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bank.Models
{
    [Table("Loan_Time_benefit")]
    public partial class LoanTimeBenefit
    {
        [Key]
        [Column("L_T_B_ID")]
        public long LTBId { get; set; }
        [Column("L_ID")]
        public long? LId { get; set; }
        [Column("Less_than_12", TypeName = "decimal(18, 0)")]
        public decimal? LessThan12 { get; set; }
        [Column("12-15", TypeName = "decimal(18, 0)")]
        public decimal? _1215 { get; set; }
        [Column("15-18", TypeName = "decimal(18, 0)")]
        public decimal? _1518 { get; set; }
        [Column("18-21", TypeName = "decimal(18, 0)")]
        public decimal? _1821 { get; set; }
        [Column("21-24", TypeName = "decimal(18, 0)")]
        public decimal? _2124 { get; set; }
        [Column("More_than_24", TypeName = "decimal(18, 0)")]
        public decimal? MoreThan24 { get; set; }
        [Column("title")]
        [StringLength(10)]
        public string Title { get; set; }

        [ForeignKey(nameof(LId))]
        [InverseProperty(nameof(Loan.LoanTimeBenefits))]
        public virtual Loan LIdNavigation { get; set; }
    }
}
