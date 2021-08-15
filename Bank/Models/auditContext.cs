using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Bank.Models
{
    public partial class auditContext : DbContext
    {
        string connectionString = "";
        public auditContext()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            connectionString = config["ConnectionStrings:sqlConnection"];
        }

        public auditContext(DbContextOptions<auditContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<DemandingAcc> DemandingAccs { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<DoubtfulReserveDetail> DoubtfulReserveDetails { get; set; }
        public virtual DbSet<IncomeCost> IncomeCosts { get; set; }
        public virtual DbSet<IncomeCostOther> IncomeCostOthers { get; set; }
        public virtual DbSet<IncomeDepositDebit> IncomeDepositDebits { get; set; }
        public virtual DbSet<IncomeDollar> IncomeDollars { get; set; }
        public virtual DbSet<IncomeInvestment> IncomeInvestments { get; set; }
        public virtual DbSet<IncomeLoan> IncomeLoans { get; set; }
        public virtual DbSet<IncomeLoanDepositDebit> IncomeLoanDepositDebits { get; set; }
        public virtual DbSet<IncomeOperational> IncomeOperationals { get; set; }
        public virtual DbSet<IncomeProperty> IncomeProperties { get; set; }
        public virtual DbSet<IncomeSaleService> IncomeSaleServices { get; set; }
        public virtual DbSet<IncomeWage> IncomeWages { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanCustomer> LoanCustomers { get; set; }
        public virtual DbSet<LoanDetailsLevel> LoanDetailsLevels { get; set; }
        public virtual DbSet<LoanDetailsSpec> LoanDetailsSpecs { get; set; }
        public virtual DbSet<LoanEmployee> LoanEmployees { get; set; }
        public virtual DbSet<LoanFlow> LoanFlows { get; set; }
        public virtual DbSet<LoanInternal> LoanInternals { get; set; }
        public virtual DbSet<LoanLevelSpec> LoanLevelSpecs { get; set; }
        public virtual DbSet<LoanSourceCurrency> LoanSourceCurrencies { get; set; }
        public virtual DbSet<LoanTimeBenefit> LoanTimeBenefits { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }
        public virtual DbSet<LoanVasigheh> LoanVasighehs { get; set; }
        public virtual DbSet<OtherDeposit> OtherDeposits { get; set; }
        public virtual DbSet<SavingAcc> SavingAccs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasComment("بانک");

                entity.Property(e => e.Title).IsFixedLength(true);
            });

            modelBuilder.Entity<DemandingAcc>(entity =>
            {
                entity.Property(e => e.DAId).ValueGeneratedNever();

                entity.HasOne(d => d.DIdNavigation)
                    .WithMany(p => p.DemandingAccs)
                    .HasForeignKey(d => d.DId)
                    .HasConstraintName("FK_Demanding_Acc_Saving_Account");
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.HasKey(e => e.DId)
                    .HasName("PK_Saving_Account");

                entity.Property(e => e.DId).ValueGeneratedNever();

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_Saving_Account_Bank");
            });

            modelBuilder.Entity<DoubtfulReserveDetail>(entity =>
            {
                entity.HasComment("انواع ذخیره مطالبات مشکوک الوصول مطابق بند 13-4 (عمومی/خصوصی)");

                entity.Property(e => e.DdId)
                    .ValueGeneratedNever()
                    .HasComment("شناسه جزئیات ذخیره مطالبات مشکوک الوصول");

                entity.Property(e => e.BadDebts).HasComment("سوخت شده");

                entity.Property(e => e.BeginningBalance).HasComment("مانده در ابتدای دوره");

                entity.Property(e => e.IncOrDecDuringYear).HasComment("افزایش یا کاهش طی سال");

                entity.Property(e => e.Recovered).HasComment("بازیافت شده");
            });

            modelBuilder.Entity<IncomeCost>(entity =>
            {
                entity.Property(e => e.ICId).ValueGeneratedNever();

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.IncomeCosts)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_Income_cost_Bank");
            });

            modelBuilder.Entity<IncomeCostOther>(entity =>
            {
                entity.Property(e => e.ICOId).ValueGeneratedNever();

                entity.HasOne(d => d.IC)
                    .WithMany(p => p.IncomeCostOthers)
                    .HasForeignKey(d => d.ICId)
                    .HasConstraintName("FK_Income_Cost_Other_Income_cost");
            });

            modelBuilder.Entity<IncomeDepositDebit>(entity =>
            {
                entity.Property(e => e.IDDId).ValueGeneratedNever();

                entity.HasOne(d => d.ILDD)
                    .WithMany(p => p.IncomeDepositDebits)
                    .HasForeignKey(d => d.ILDDId)
                    .HasConstraintName("FK_Income_Deposit_Debit_Income_Loan_Deposit_debit");
            });

            modelBuilder.Entity<IncomeDollar>(entity =>
            {
                entity.Property(e => e.IDId).ValueGeneratedNever();

                entity.HasOne(d => d.IC)
                    .WithMany(p => p.IncomeDollars)
                    .HasForeignKey(d => d.ICId)
                    .HasConstraintName("FK_Income_Dollar_Income_cost");
            });

            modelBuilder.Entity<IncomeInvestment>(entity =>
            {
                entity.Property(e => e.IIId).ValueGeneratedNever();

                entity.HasOne(d => d.IC)
                    .WithMany(p => p.IncomeInvestments)
                    .HasForeignKey(d => d.ICId)
                    .HasConstraintName("FK_Income_Investment_Income_cost");

                entity.HasOne(d => d.IIIdFkeyNavigation)
                    .WithMany(p => p.InverseIIIdFkeyNavigation)
                    .HasForeignKey(d => d.IIIdFkey)
                    .HasConstraintName("FK_Income_Investment_Income_Investment");
            });

            modelBuilder.Entity<IncomeLoan>(entity =>
            {
                entity.Property(e => e.ILId).ValueGeneratedNever();

                entity.HasOne(d => d.ILDD)
                    .WithMany(p => p.IncomeLoans)
                    .HasForeignKey(d => d.ILDDId)
                    .HasConstraintName("FK_Income_Loan_Income_Loan_Deposit_debit");
            });

            modelBuilder.Entity<IncomeLoanDepositDebit>(entity =>
            {
                entity.HasKey(e => e.ILDDId)
                    .HasName("PK_Loan_income");

                entity.Property(e => e.ILDDId).ValueGeneratedNever();

                entity.HasOne(d => d.IC)
                    .WithMany(p => p.IncomeLoanDepositDebits)
                    .HasForeignKey(d => d.ICId)
                    .HasConstraintName("FK_Loan_income_Income_cost");
            });

            modelBuilder.Entity<IncomeOperational>(entity =>
            {
                entity.Property(e => e.IOId).ValueGeneratedNever();

                entity.HasOne(d => d.IC)
                    .WithMany(p => p.IncomeOperationals)
                    .HasForeignKey(d => d.ICId)
                    .HasConstraintName("FK_Income_Operational_Income_cost");
            });

            modelBuilder.Entity<IncomeProperty>(entity =>
            {
                entity.Property(e => e.IPId).ValueGeneratedNever();

                entity.HasOne(d => d.ICO)
                    .WithMany(p => p.IncomeProperties)
                    .HasForeignKey(d => d.ICOId)
                    .HasConstraintName("FK_Income_Property_Income_Cost_Other");
            });

            modelBuilder.Entity<IncomeSaleService>(entity =>
            {
                entity.Property(e => e.ISSId).ValueGeneratedNever();

                entity.HasOne(d => d.IC)
                    .WithMany(p => p.IncomeSaleServices)
                    .HasForeignKey(d => d.ICId)
                    .HasConstraintName("FK_Income_Sale_Service_Income_cost");
            });

            modelBuilder.Entity<IncomeWage>(entity =>
            {
                entity.Property(e => e.IWId).ValueGeneratedNever();

                entity.HasOne(d => d.IC)
                    .WithMany(p => p.IncomeWages)
                    .HasForeignKey(d => d.ICId)
                    .HasConstraintName("FK_Income_Wage_Income_cost");

                entity.HasOne(d => d.ICIdFkeyNavigation)
                    .WithMany(p => p.InverseICIdFkeyNavigation)
                    .HasForeignKey(d => d.ICIdFkey)
                    .HasConstraintName("FK_Income_Wage_Income_Wage");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasComment("تسهیلات");

                entity.Property(e => e.LId).HasComment("شناسه اطلاعات هر نوع تسهیلات");

                entity.Property(e => e.BankId).HasComment("شناسه بانک (کلید خارجی از جدول بانک)");

                entity.Property(e => e.IsDollar).HasComment("ارزی/غیرارزی");

                entity.Property(e => e.IsGroup).HasComment("اطلاعات تلفیقی/بانک");

                entity.Property(e => e.LFId).HasComment("شناسه اطلاعات گردش مالی مربوط به هر تسهیلات (کلید خارجی جدول Loan_Flow)");

                entity.Property(e => e.TimeYear).HasComment("سال مالی");

                entity.Property(e => e.TypeId).HasComment("نوع تسهیلات");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_loan_Bank");

                entity.HasOne(d => d.LF)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.LFId)
                    .HasConstraintName("FK_loan_Loan_Flow");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_loan_LoanType");
            });

            modelBuilder.Entity<LoanCustomer>(entity =>
            {
                entity.HasComment("انواع مشتری مطابق بند 13-5 و 13-5-1");

                entity.Property(e => e.LCId).ValueGeneratedNever();

                entity.Property(e => e.BankId).HasComment("کلید خارجی از جدول بانک");

                entity.Property(e => e.CustomerType).HasComment("نوع مشتری (حقیقی/حقوقی)");

                entity.Property(e => e.DoubtfulDebtsReserves).HasComment("ذخیره مطالبات مشکوک الوصول");

                entity.Property(e => e.GrossAmount).HasComment("مبلغ ناخالص");

                entity.Property(e => e.NetAmount).HasComment("مبلغ خالص");

                entity.Property(e => e.Year).HasComment("سال مالی");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.LoanCustomers)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_Loan_Customer_Bank");
            });

            modelBuilder.Entity<LoanDetailsLevel>(entity =>
            {
                entity.Property(e => e.LdlId);

                entity.Property(e => e.Checking).HasComment("جاری");

                entity.Property(e => e.Delayed).HasComment("معوق");

                entity.Property(e => e.Doubtful).HasComment("مشکوک الوصول");

                entity.Property(e => e.PastMaturity).HasComment("سررسید گذشته");

                entity.HasOne(d => d.LIdNavigation)
                    .WithMany(p => p.LoanDetailsLevels)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_Loan_details_level_loan");
            });

            modelBuilder.Entity<LoanDetailsSpec>(entity =>
            {
                entity.HasComment("جزئیات انواع تسهیلات مطابق با بند 12 و بند 13-2");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BalanceAndCommInterestFuture).HasComment("مانده و سود التزام سالهای آتی");

                entity.Property(e => e.BalanceAndInterestReceivableFee).HasComment("مانده و سود کارمزد دریافتنی");

                entity.Property(e => e.DeferredPenaltyClauseInterestFee).HasComment("سود و کارمزد وجه التزام معوق");

                entity.Property(e => e.DoubtfulDebtsReserves).HasComment("ذخیره مطالبات مشکوک الوصول (کسر)");

                entity.Property(e => e.FutureInterest).HasComment("سود سالهای آتی (کسر)");

                entity.Property(e => e.MudarabaAndJointCivilReceivables).HasComment("وجه دریافتنی مضاربه و حساب مشترک مدنی");

                entity.Property(e => e.RecPenaltyClause).HasComment("مانده وجه التزام دریافتنی");

                entity.HasOne(d => d.LIdNavigation)
                    .WithMany(p => p.LoanDetailsSpecs)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_Loan_details_Spec_loan");
            });

            modelBuilder.Entity<LoanEmployee>(entity =>
            {
                entity.Property(e => e.LEId).ValueGeneratedNever();

                entity.HasOne(d => d.LC)
                    .WithMany(p => p.LoanEmployees)
                    .HasForeignKey(d => d.LCId)
                    .HasConstraintName("FK_Loan_employee_Loan_Customer");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.LoanEmployees)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Loan_employee_LoanType");
            });

            modelBuilder.Entity<LoanFlow>(entity =>
            {
                entity.HasComment("گردش تسهیلات اعطایی مطابق بندهای 13-10 و 13-10-1");

                entity.Property(e => e.LFId).ValueGeneratedNever();

                entity.Property(e => e.BalancePrevYear).HasComment("مانده سال قبل");

                entity.Property(e => e.CollectedDuringYear).HasComment("وصولی طی سال");

                entity.Property(e => e.ForeignExchangeEffect).HasComment("تاثیر تسعیر ارز");

                entity.Property(e => e.IncDuringYear).HasComment("افزایش طی سال");

                entity.Property(e => e.Title).HasComment("نوع گردش تسهیلات (اصل/فرع سوددریافتنی/فرع وجه التزام دریافتنی/مشکوک الوصول)");
            });

            modelBuilder.Entity<LoanInternal>(entity =>
            {
                entity.HasComment("تسهیلات ارائه شده به شرکتهای فرعی و وابسته مطابق بند 13-6");

                entity.Property(e => e.LIId).ValueGeneratedNever();

                entity.Property(e => e.Current).HasComment("جاری");

                entity.Property(e => e.DoubtfulDebtsReserves).HasComment("ذخیره مطالبات مشکوک الوصول");

                entity.Property(e => e.NonPerforming).HasComment("غیر جاری");

                entity.Property(e => e.Title).HasComment("نام شرکت عضو گروه");

                entity.Property(e => e.WeightedAverageInterestRate).HasComment("متوسط موزون نرخ سود");

                entity.HasOne(d => d.LIdNavigation)
                    .WithMany(p => p.LoanInternals)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_Loan_internal_loan1");
            });

            modelBuilder.Entity<LoanLevelSpec>(entity =>
            {
                entity.HasKey(e => e.LlsId)
                    .HasName("PK_Load_level_Spec");

                entity.HasComment("جزئیات کسری ها از تسهیلات مطابق بند 12 و 13-3");

                entity.Property(e => e.LlsId)
                    .HasComment("شناسه کسریها");

                entity.Property(e => e.BankId).HasComment("شناسه بانک (کلید خارجی از جدول بانک)");

                entity.Property(e => e.DeferredInterestAndFees).HasComment("سود و کارمزد معوق");

                entity.Property(e => e.FutureInterest).HasComment("سود سالهای آتی");

                entity.Property(e => e.JointAccCivilParticipation).HasComment("حساب مشترک مشارکت مدنی");

                entity.Property(e => e.Level).HasComment("چهار سطح جاری/سررسید/معوق/مشکوک الوصول");

                entity.Property(e => e.ReceivablesForMudaraba).HasComment("وجه دریافتنی بابت مضاربه");

                entity.Property(e => e.Type).HasComment("نوع دولتی/غیردولتی");

                entity.Property(e => e.Year).HasComment("سال مالی");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.LoanLevelSpecs)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_Loan_level_Spec_Bank");

                entity.HasOne(d => d.DedDd)
                    .WithMany(p => p.LoanLevelSpecDedDds)
                    .HasForeignKey(d => d.DedDdId)
                    .HasConstraintName("FK_Loan_level_Spec_Doubtful_Reserve_Details1");

                entity.HasOne(d => d.PubDd)
                    .WithMany(p => p.LoanLevelSpecPubDds)
                    .HasForeignKey(d => d.PubDdId)
                    .HasConstraintName("FK_Loan_level_Spec_Doubtful_Reserve_Details");
            });

            modelBuilder.Entity<LoanSourceCurrency>(entity =>
            {
                entity.HasComment("تسهیلات اعطایی به ارز مطابق بند 13-7");

                entity.Property(e => e.ScD)
                    .ValueGeneratedNever()
                    .HasComment("کلید اصلی منابع ارزی");

                entity.Property(e => e.ItemName).HasComment("نوع تسهیلات ارزی (منابع داخلی/حساب ذخیره ارزی/ صندوق توسعه ملی)");

                entity.Property(e => e.LId).HasComment("شناسه وام (کلید خارجی به جدول loan)");

                entity.Property(e => e.LdlId).HasComment("شناسه نوع جزئیات (کلید خارجی به جدول Loan_Details_Level مبنی بر جاری/ سررسید...)");

                entity.HasOne(d => d.LIdNavigation)
                    .WithMany(p => p.LoanSourceCurrencies)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_Loan_Source_Currency_loan");

                entity.HasOne(d => d.Ldl)
                    .WithMany(p => p.LoanSourceCurrencies)
                    .HasForeignKey(d => d.LdlId)
                    .HasConstraintName("FK_Loan_Source_Currency_Loan_details_level");
            });

            modelBuilder.Entity<LoanTimeBenefit>(entity =>
            {
                entity.HasComment("تسهیلات برحسب سود و زمان سررسید مطابق بند 13-8");

                entity.Property(e => e.LTBId)
                    .ValueGeneratedNever()
                    .HasComment("شناسه وام (کلید خارجی به جدول تسهیلات)");

                entity.Property(e => e.LId).HasComment("کمتر از 12 ");

                entity.Property(e => e.LessThan12).HasComment("شناسه وام از نظر زمان سررسید");

                entity.Property(e => e.Title)
                    .IsFixedLength(true)
                    .HasComment("بیشتر از 24");

                entity.Property(e => e._1215).HasComment("کمتر از 12");

                entity.HasOne(d => d.LIdNavigation)
                    .WithMany(p => p.LoanTimeBenefits)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_Loan_Time_benefit_loan");
            });

            modelBuilder.Entity<LoanType>(entity =>
            {
                entity.HasKey(e => e.LTId)
                    .HasName("PK_LoanType");

                entity.HasComment("انواع تسهیلات دولتی و غیردولتی مطابق بند 13 و بند 12");

                entity.Property(e => e.LTId).HasComment("شناسه هر نوع تسهیلات (اعم از دولتی و غیردولتی)");

                entity.Property(e => e.Ltitle).HasComment("عنوان هر زیردسته از تسهیلات دولتی یا غیردولتی");

                entity.Property(e => e.Ltype).HasComment("نوع تسهیلات (دولتی/غیردولتی)");
            });

            modelBuilder.Entity<LoanVasigheh>(entity =>
            {
                entity.HasComment("دسته بندی بر حسب نوع وثیقه مطابق بند 13-9");

                entity.Property(e => e.LVId)
                    .ValueGeneratedNever()
                    .HasComment("کلید اصلی وثیقه");

                entity.Property(e => e.Amount).HasComment("مبلغ وثیقه");

                entity.Property(e => e.BankId).HasComment("شناسه بانک (کلید خارجی به جدول Bank)");

                entity.Property(e => e.Title)
                    .IsFixedLength(true)
                    .HasComment("نوع وثیقه (سپرده/اوراق مشارکت/ضمانت نامه بانکی ...)");

                entity.Property(e => e.Year).HasComment("سال مالی");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.LoanVasighehs)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_Loan_vasigheh_Bank");
            });

            modelBuilder.Entity<OtherDeposit>(entity =>
            {
                entity.Property(e => e.IDId).ValueGeneratedNever();

                entity.HasOne(d => d.DIdNavigation)
                    .WithMany(p => p.OtherDeposits)
                    .HasForeignKey(d => d.DId)
                    .HasConstraintName("FK_Other_Deposit_Deposit");
            });

            modelBuilder.Entity<SavingAcc>(entity =>
            {
                entity.Property(e => e.SAId).ValueGeneratedNever();

                entity.HasOne(d => d.DIdNavigation)
                    .WithMany(p => p.SavingAccs)
                    .HasForeignKey(d => d.DId)
                    .HasConstraintName("FK_Saving_ACC_Deposit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
