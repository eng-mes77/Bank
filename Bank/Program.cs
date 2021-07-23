using Newtonsoft.Json.Linq;
using Syncfusion.XlsIO;
using System;
using System.IO;
using System.Text;
using Bank.Models;
using System.Linq;
using System.Reflection;
using static Bank.Enums;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            auditContext auditcontext = new auditContext();
            var banks = auditcontext.Set<Bank.Models.Bank>().ToList();
            Console.WriteLine("Enter Bank Id");

            foreach (var bank in banks)
                Console.WriteLine($"id:{bank.BankId}  Name:{bank.Title}");

            long bankId = long.Parse(Console.ReadLine());

            ExcelEngine excelEngine = new ExcelEngine();

            List<LoanDetailsLevel> lstLDL = new List<LoanDetailsLevel>();

            //Instantiate the Excel application object.
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;

            //Load the input Excel file.
            FileStream stream = new FileStream(@"C:\Users\Mohammad\Desktop\Sahand\یادداشت های صورت مالی.xlsx", FileMode.Open, FileAccess.ReadWrite);
            IWorkbook book = application.Workbooks.Open(stream);
            stream.Close();
            long loanId;
            var loanTypes = auditcontext.Set<LoanType>().ToList();
            foreach (var type in loanTypes)
            {
                string coloumnKey = "میلیون ریال";
                IWorksheet worksheet = book.Worksheets["13- تسهیلات اعطایی و مطالبات از"];

                var abc2 = worksheet.FindFirst(coloumnKey, ExcelFindType.Text);

                var abc = worksheet.FindFirst(type.Ltitle.Trim(), ExcelFindType.Text);
                if (abc != null && abc2 != null)
                {
                    var volume = worksheet.Range[abc.Row, abc2.Column].Text;
                    var year = worksheet.Range[abc2.Row - 1, abc2.Column].Text;

                    Loan loan = new Loan()
                    {
                        Volumne = Convert.ToDecimal(volume),
                        TimeYear = int.Parse(year),
                        TypeId = type.LTId,
                        BankId = bankId
                    };
                    auditcontext.Loans.Add(loan);
                    auditcontext.SaveChanges();
                    loanId = loan.LId;
                    Dictionary<string, string> lst = new Dictionary<string, string>();

                    foreach (var suit in Enum.GetNames(typeof(Loan_details)))
                    {
                        MemberInfo info = typeof(Loan_details).GetMember(suit).FirstOrDefault();
                        var displayAttribute = info.GetCustomAttribute<DisplayAttribute>().Name;

                        IWorksheet worksheet2 = book.Worksheets["13-3- طبقه بندی تسهیلات اعطایی "];

                        var abc3 = worksheet2.FindFirst(displayAttribute, ExcelFindType.Text);
                        var abc4 = worksheet2.FindFirst(type.Ltitle.Trim(), ExcelFindType.Text);

                        var content = worksheet.Range[abc4.Row, abc2.Column].Text;
                        lst.Add(info.Name, content);

                    }

                    LoanDetailsLevel loanDetailsLevel = new LoanDetailsLevel()
                    {
                        LId = loanId,
                        Checking = decimal.Parse(lst.Where(s => s.Key == "Checking").FirstOrDefault().Value),
                        PastMaturity = decimal.Parse(lst.Where(s => s.Key == "Past_Maturity").FirstOrDefault().Value),
                        Delayed = decimal.Parse(lst.Where(s => s.Key == "Delayed").FirstOrDefault().Value),
                        Doubtful = decimal.Parse(lst.Where(s => s.Key == "Doubtful").FirstOrDefault().Value)
                    };
                    lstLDL.Add(loanDetailsLevel);
                }
            }
            foreach (var element in lstLDL)
                auditcontext.LoanDetailsLevels.Add(element);


            auditcontext.SaveChanges();


            //Instantiate the spreadsheet creation engine.

            //IApplication application = excelEngine.Excel;
            //application.DefaultVersion = ExcelVersion.Xlsx;

            ////Load the input Excel file.
            //FileStream stream = new FileStream(@"C:\Users\Mohammad\Desktop\dep.xlsx", FileMode.Open, FileAccess.ReadWrite);
            //IWorkbook book = application.Workbooks.Open(stream);
            //stream.Close();

            ////Access first worksheet.
            //IWorksheet worksheet = book.Worksheets[0];

            //Access a range.
            //IRange range = worksheet.Range["A1:L8"];

            //MemoryStream jsonStream = new MemoryStream();

            ////if (ConvertOptions == "Workbook")
            //book.SaveAsJson(jsonStream); //Save the entire workbook as a JSON stream.
            //                             //else if (ConvertOptions == "Worksheet")
            //book.SaveAsJson(jsonStream, worksheet); //Save the first worksheet as a JSON stream.
            //                                        //else if (ConvertOptions == "Range")

            //excelEngine.Dispose();

            //byte[] json = new byte[jsonStream.Length];

            ////Read the JSON stream and convert to a JSON object.
            //jsonStream.Position = 0;
            //string jsonString = Encoding.UTF8.GetString(json);

            //Bind the converted JSON object to the DataGrid.
            //if (ConvertOptions == "Workbook")
            //{
            //    //The first worksheet in the input document is converted to a JSON stream and bound to the DataGrid in the first tab.
            //    ViewBag.Tab1 = ((JArray)(jsonObject["Sheet1"])).ToObject<List<CustomDynamicObject>>();

            //    //The second worksheet in the input document is converted to a JSON stream and bound to the DataGrid in the second tab.
            //    ViewBag.Tab2 = ((JArray)(jsonObject["Sheet2"])).ToObject<List<CustomDynamicObject>>();

            //    return View();
            //}
            //else if (ConvertOptions == "Worksheet" || ConvertOptions == "Range")
            //{
            //    ViewBag.Tab1 = ((JArray)(jsonObject["Sheet1"])).ToObject<List<CustomDynamicObject>>();
            //    ViewBag.Tab2.Visible = false;
            //}

            //jsonStream.Position = 0;

            //return View();

        }
    }
}
