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
    }
}
