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
            try
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

                var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);


                FileStream stream = new FileStream(GetDirectory + "\\finance.xlsx", FileMode.Open, FileAccess.ReadWrite);
                IWorkbook book = application.Workbooks.Open(stream);
                stream.Close();
                long loanId;

                //check sheet Name on other other Excel

                var loanTypes = auditcontext.Set<LoanType>().Where(l => l.Ltype.Contains("غیر دولتی")).ToList();
                string year = "";
                foreach (var type in loanTypes)
                {
                    string coloumnKey = "میلیون ریال";
                    bool isDollar = false;
                    if (type.Ltitle.Contains("ارز"))
                        isDollar = true;

                    IWorksheet worksheet = book.Worksheets["13- تسهیلات اعطایی و مطالبات از"];

                    var abc2 = worksheet.FindFirst(coloumnKey, ExcelFindType.Text);

                    var abc = worksheet.FindFirst(type.Ltitle.Trim(), ExcelFindType.Text);
                    if (abc != null && abc2 != null)
                    {
                        var volume = worksheet.Range[abc.Row, abc2.Column].Text;
                        year = worksheet.Range[abc2.Row - 1, abc2.Column].Text;

                        Loan loan = new Loan()
                        {
                            Volumne = Convert.ToDecimal(volume),
                            TimeYear = int.Parse(year),
                            TypeId = type.LTId,
                            BankId = bankId,
                            IsDollar = (byte?)(isDollar ? 1 : 0)
                        };
                        auditcontext.Loans.Add(loan);
                        auditcontext.SaveChanges();
                        loanId = loan.LId;
                        Dictionary<string, string> lstLoan = new Dictionary<string, string>();
                        IWorksheet worksheet2 = book.Worksheets["13-3- طبقه بندی تسهیلات اعطایی "];

                        foreach (var suit in Enum.GetNames(typeof(Loan_details)))
                        {
                            MemberInfo info = typeof(Loan_details).GetMember(suit).FirstOrDefault();
                            var displayAttribute = info.GetCustomAttribute<DisplayAttribute>().Name;


                            var abc3 = worksheet2.FindFirst(displayAttribute, ExcelFindType.Text);
                            var abc4 = worksheet2.FindFirst(type.Ltitle.Trim(), ExcelFindType.Text);

                            var content = worksheet2.Range[abc4.Row, abc3.Column].Text;
                            lstLoan.Add(info.Name, content);

                        }

                        LoanDetailsLevel loanDetailsLevel = new LoanDetailsLevel()
                        {
                            LId = loanId,
                            Checking = decimal.Parse(lstLoan.Where(s => s.Key == "Checking").FirstOrDefault().Value),
                            PastMaturity = decimal.Parse(lstLoan.Where(s => s.Key == "Past_Maturity").FirstOrDefault().Value),
                            Delayed = decimal.Parse(lstLoan.Where(s => s.Key == "Delayed").FirstOrDefault().Value),
                            Doubtful = decimal.Parse(lstLoan.Where(s => s.Key == "Doubtful").FirstOrDefault().Value)
                        };
                        lstLDL.Add(loanDetailsLevel);
                    }
                }
                foreach (var element in lstLDL)
                {
                    auditcontext.LoanDetailsLevels.Add(element);
                    auditcontext.SaveChanges();
                }



                Dictionary<string, List<string>> lst = new Dictionary<string, List<string>>();

                foreach (var suit in Enum.GetNames(typeof(Loan_details)))
                {
                    MemberInfo info = typeof(Loan_details).GetMember(suit).FirstOrDefault();
                    var displayAttribute = info.GetCustomAttribute<DisplayAttribute>().Name;
                    //gheyre dolati bayad bashad
                    IWorksheet worksheet3 = book.Worksheets["13-3- طبقه بندی تسهیلات اعطایی "];

                    List<string> tmp = new List<string>();
                    string tst = "";
                    var abc3 = worksheet3.FindFirst(displayAttribute, ExcelFindType.Text);
                    foreach (var ls in Enum.GetNames(typeof(Loan_spec)))
                    {
                        MemberInfo infoS = typeof(Loan_spec).GetMember(ls).FirstOrDefault();
                        var displayAttributeS = infoS.GetCustomAttribute<DisplayAttribute>().Name;

                        var abc4 = worksheet3.FindFirst(displayAttributeS.Trim(), ExcelFindType.Text);
                        var content = worksheet3.Range[abc4.Row, abc3.Column].Text;
                        tst = ls;
                        tmp.Add(content);
                        //lst.Add(ls, content);
                    }
                    lst.Add(suit, tmp);


                }
                foreach (var element in lst)
                {
                    MemberInfo infoS = typeof(Loan_details).GetMember(element.Key).FirstOrDefault();
                    var displayAttributeS = infoS.GetCustomAttribute<DisplayAttribute>().Name;

                    LoanLevelSpec loanLevelSpec = new LoanLevelSpec
                    {
                        Year = int.Parse(year),
                        BankId = bankId,
                        Level = displayAttributeS,
                        Type = loanTypes.First().Ltype,
                        FutureInterest = decimal.Parse(element.Value[0].Replace("(", "").Replace(")", "")),
                        DeferredInterestAndFees = decimal.Parse(element.Value[1].Replace("(", "").Replace(")", "")),
                        ReceivablesForMudaraba = decimal.Parse(element.Value[2].Replace("(", "").Replace(")", "")),
                        JointAccCivilParticipation = decimal.Parse(element.Value[3].Replace("(", "").Replace(")", ""))
                    };
                    auditcontext.LoanLevelSpecs.Add(loanLevelSpec);
                    auditcontext.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


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
