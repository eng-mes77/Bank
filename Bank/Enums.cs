using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Enums
    {
        public enum Loan_details
        {
            [Display (Name = "جاری")]
            Checking,
            [Display(Name = "سررسید گذشته")]
            Past_Maturity,
            [Display(Name = "معوق")]
            Delayed,
            [Display(Name = "مشکوک الوصول")]
            Doubtful,
        }


        public enum Loan_spec
        {
            [Display(Name = "سود سال‌های آتی")]
            Future_interest,
            [Display(Name = "سود و کارمزد معوق")]
            Deferred_interest_And_fees,
            [Display(Name = "وجوه دریافتی بابت مضاربه")]
            Receivables_for_Mudaraba,
            [Display(Name = "حساب مشترک مدنی")]
            Joint_acc_civil_participation,
        }

    }
}
