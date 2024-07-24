using GSTEducationERPLibrary.Account;
using GSTEducationERPLibrary.Accountant;
using GSTEducationERPLibrary.Trainer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;

namespace GSTEducationERP.Controllers
{
    public class AccountantController : Controller
    {
        private readonly BALAccountant objbal = new BALAccountant();

        public string newCode {  get; set; }
        public class BreadcrumbItem
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public class PaymentMethod
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }

        // GET: Accountant
        //-------------------------Mukesh Borkar---------------------------------------------------------####

        Accountant objAccountant = new Accountant();
      

        // GET: Accountant
        [HttpGet]
       
        public async Task<ActionResult> ExpenseDashboardAsyncMB()
        {         
            return View();
        }


        public async Task<ActionResult> ListOfRegularExpenseAsyncMB()
        {

            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
            else
            {
                DataSet ds = await objbal.ShowListOfRegularExpenseMB(objAccountant);
                List<Accountant> lstRegularExpense = new List<Accountant>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                   
                    Accountant objP = new Accountant();
                    objP.ExpID = (ds.Tables[0].Rows[i]["TransactionCode"].ToString());
                    objP.ExpenseType = ds.Tables[0].Rows[i]["ExpenseType"].ToString();
                    objP.VendorName = ds.Tables[0].Rows[i]["VendorName"].ToString();
                    objP.Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["TransactionDate"].ToString());
                    objP.PaymentMode = ds.Tables[0].Rows[i]["PaymentMode"].ToString();
                    objP.TranscationId = ds.Tables[0].Rows[i]["TransactionID_checqueNumber"].ToString();                
                    objP.TranscationChequedate = (ds.Tables[0].Rows[i]["ChequeClearenceDate"].ToString());
                    objP.Amount = int.Parse(ds.Tables[0].Rows[i]["TransactionAmount"].ToString());
                    objP.Balance = int.Parse(ds.Tables[0].Rows[i]["BalanceAmount"].ToString());
                    objP.Status = ds.Tables[0].Rows[i]["Status"].ToString(); 
                    lstRegularExpense.Add(objP);
                }
                objAccountant.lstRegularExpense = lstRegularExpense;
                
                return PartialView(objAccountant);
            }
               
        }

        public async Task<ActionResult> ListOfReferenceExpenseAsyncMB()
        {
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
            else
            {
                DataSet ds = await objbal.ShowListOfReferenceExpenseMB(objAccountant);
                List<Accountant> lstRegularExpense = new List<Accountant>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Accountant objP = new Accountant();
                    objP.ExpID = (ds.Tables[0].Rows[i]["TransactionCode"].ToString());
                    objP.ExpenseType = ds.Tables[0].Rows[i]["ExpenseType"].ToString();
                    objP.ReferenceByName = ds.Tables[0].Rows[i]["FullName"].ToString();
                    objP.ReferenceToName = ds.Tables[0].Rows[i]["ReferenceToCandidate"].ToString();
                    objP.Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["TransactionDate"]);
                    objP.PaymentMode = ds.Tables[0].Rows[i]["PaymentMode"].ToString();
                    objP.Amount = int.Parse(ds.Tables[0].Rows[i]["TransactionAmount"].ToString());
                    objP.Balance = int.Parse(ds.Tables[0].Rows[i]["BalanceAmount"].ToString());
                    objP.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                    lstRegularExpense.Add(objP);
                }
                objAccountant.lstRegularExpense = lstRegularExpense;
              
                return PartialView(objAccountant);

            }
           
        }


        public async Task<ActionResult> ListOfRefundExpenseAsyncMB()
        {
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
            else
            {
                DataSet ds = await objbal.ShowListOfRefundExpenseMB(objAccountant);
                List<Accountant> lstRegularExpense = new List<Accountant>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Accountant objP = new Accountant();
                    objP.ExpID = (ds.Tables[0].Rows[i]["TransactionCode"].ToString());
                    objP.ExpenseType = ds.Tables[0].Rows[i]["ExpenseType"].ToString();
                    objP.VendorName = ds.Tables[0].Rows[i]["FullName"].ToString();
                    objP.Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["TransactionDate"]);
                    objP.PaymentMode = ds.Tables[0].Rows[i]["PaymentMode"].ToString();
                    objP.Amount = int.Parse(ds.Tables[0].Rows[i]["TransactionAmount"].ToString());
                    objP.Balance = int.Parse(ds.Tables[0].Rows[i]["BalanceAmount"].ToString());
                    objP.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                    lstRegularExpense.Add(objP);
                }
                objAccountant.lstRegularExpense = lstRegularExpense;
               
                return PartialView(objAccountant);
            }

           
        }

        [HttpGet]
        public async Task<ActionResult> AddExpensesAsyncMB()
        {
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
            else
            {
                Accountant obj=new Accountant();
                obj.Date=DateTime.Now;
                await GetExpenceCategoryMB();
                await GetRefundCandidate();
                await GetReferenceByStudentsAsyncMB();
                await ListVoucherAsyncMB();
                var paymentmethod = new List<PaymentMethod>
                {
                    
                     new PaymentMethod { Value = "CASH", Text = "CASH" },
                     new PaymentMethod { Value = "BANK", Text = "BANK" },
                     new PaymentMethod { Value = "CHEQUE", Text = "CHEQUE" },
                    

                };
                ViewBag.PaymentMode = paymentmethod;
                return PartialView(obj);
            }
           
        }

        [HttpGet]

        public async Task GetRefundCandidate()
        {
            DataSet ds = await objbal.GetRefundCandidateMB();
            List<SelectListItem> lstRefundCandidate = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstRefundCandidate.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["CandidateCode"].ToString() });
            }
           
            await Task.Run(() => ViewBag.RefundCandidatelst = lstRefundCandidate);

        }

        [HttpGet]
        public async Task<JsonResult> GetRefundCandidatesPaidFee(string CandidateCode)
        {
            Accountant obj = new Accountant();
            obj.CandidateCode = CandidateCode;
            SqlDataReader dr = await objbal.GetRefundCandidatesPaidFee(obj);
            string CandidatePaidFee = string.Empty;

            while (dr.Read())
            {
                CandidatePaidFee = dr["TransactionAmount"].ToString();
            }

            return Json(new { success = true, CandidatePaidFee = CandidatePaidFee }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public async Task GetReferenceByStudentsAsyncMB()
        {
            DataSet ds = await objbal.GetReferenceByCandidatesAsyncMB();
            List<SelectListItem> lstReferenceByStudent= new List<SelectListItem>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                lstReferenceByStudent.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["RefBy"].ToString() });
            }
            await Task.Run(()=> ViewBag.ReferenceByStudentlst = lstReferenceByStudent);
        }

        [HttpGet]

        public async Task<JsonResult> GettheReferenceToCandidateAsyncMB(string CandidateCode)
        {
            Accountant obj = new Accountant();
            obj.CandidateCode = CandidateCode;
            DataSet ds= await objbal.GetReferenceToCandidatesAsyncMB(obj);
            List<SelectListItem> ReferenceToCandidate = new List<SelectListItem>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                ReferenceToCandidate.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["RefTo"].ToString() });
            }

            return Json(new { success = true, candidates = ReferenceToCandidate }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public async Task GetExpenceCategoryMB()
        {
            DataSet ds = await objbal.GetExpenceCategoryMB();
            List<SelectListItem> Courselist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Courselist.Add(new SelectListItem { Text = dr["ExpenseCategory"].ToString(), Value = dr["ExpenseCategoryId"].ToString() });
            }
            await Task.Run(() => ViewBag.CourseList = Courselist);

        }

        [HttpGet]
        public async Task< JsonResult> GetExpenceTypeAsynMB(int ExpCategoryId)
        {
            Accountant obj = new Accountant();
            obj.ExpID = Convert.ToInt32(ExpCategoryId).ToString();
            SqlDataReader dr = await objbal.GetTheExpenceTypeAsyncMB(obj);
            string expenseType = string.Empty;

            while (dr.Read())
            {
                expenseType = dr["ExpenseType"].ToString();
            }

            return Json(new { success = true, expenseType = expenseType }, JsonRequestBehavior.AllowGet);
        }

        

       

        [HttpPost]
        public async Task<JsonResult> AddExpensesAsyncMB(Accountant objA, String ReferenceToCandidateCode, string EmployeeCode)
        {
            if (Session["StaffCode"] == null)
            {
                return Json(new { success = false, redirect = Url.Action("Login", "Account") });
            }
            else
            {
                try
                {
                    string maxCode = null;
                    SqlDataReader dr = await objbal.GetMaxExpenseCodeForAutoIncrement();
                    if (dr.Read())
                    {
                        maxCode = dr["MaxCode"].ToString();
                    }

                    
                    if (string.IsNullOrEmpty(maxCode))
                    {
                        newCode = "EXP001";
                    }
                    else
                    {
                        int numericPart = int.Parse(maxCode.Substring(3)) + 1;
                        newCode = "EXP" + numericPart.ToString("D3");
                    }

                    objA.TransactionCode = newCode;
                    if (objA.ExpID == "3")
                    {
                        objA.ReferenceToName = ReferenceToCandidateCode;
                        objA.PaymentMode = "CASH";
                    }
                    if (objA.ExpID == "5")
                    {
                        objA.ReferenceToName = EmployeeCode;
                        objA.PaymentMode = "CASH";
                    }

                    objA.StaffCode = Session["StaffCode"].ToString();

                    
                    await objbal.SavetheExpenceMB(objA);

                    return Json(new { success = true, newCode = newCode });
                }
                catch (Exception ex)
                {
                    // Log the error
                    Console.WriteLine(ex.Message);
                    return Json(new { success = false, message = ex.Message });
                }
            }


        }

        [HttpGet]
        private async Task ListVoucherAsyncMB()
        {
            if (Session["StaffCode"] == null)
            {
                //return RedirectToAction("Login", "Account");
            }
            else
            {
                Accountant objac = new Accountant();
               
                //fetching the banks here for the add purchase 
                DataSet ds = await objbal.ListVouchersAsyncMB();
                List<SelectListItem> VoucherList = new List<SelectListItem>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    VoucherList.Add(new SelectListItem { Text = $"{dr["VoucherCode"].ToString() + "-" + dr["VendorName"].ToString() + "-" + dr["Balance"].ToString()}", Value = dr["VoucherCode"].ToString() });
                }
                ViewBag.VoucherCode = VoucherList;
                //return await Task.Run(() => Json(VoucherList, JsonRequestBehavior.AllowGet));
            }
        }


        [HttpGet]
        public async Task<ActionResult> MatchVoucherAsyncVM(string TCode,float Amount)
        {
            Accountant obj=new Accountant();
            obj.TransactionCode = TCode;
            obj.Amount = Amount;
           
           await ListVoucherAsyncMB();
            return PartialView("_MatchVoucherAsyncVM",obj);
        }

        [HttpGet]
        public async Task GetThePendingExpenseAsyncMB()
        {
            DataSet ds = await objbal.GetThePendingExpensesToMatchWithVoucherAsyncMB();
            List<SelectListItem> PendingExpencelst = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                PendingExpencelst.Add(new SelectListItem { Text = dr["PendingExpense"].ToString(), Value = dr["TransactionCode"].ToString() });
            }
            await Task.Run(() => ViewBag.PendingExpenses = PendingExpencelst);

        }

        [HttpGet]
        public async Task GetVouchersForMatchExpenceAsyncMB()
        {
            DataSet ds = await objbal.ListVouchersAsyncMB();
            List<SelectListItem> VouchersToMatchExpense = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                VouchersToMatchExpense.Add(new SelectListItem
                {
                    Text = dr["Vouchers"].ToString(),
                    Value = dr["VoucherCode"].ToString()
                });
            }

            ViewBag.VouchersToMatchExpenses = VouchersToMatchExpense;
           

        }

        [HttpGet]
        public async Task<JsonResult> GetTotalVoucherAmountAsyncMB(List<string> voucherCodes)
        {


            Accountant obj = new Accountant();
            List<string> amounts = new List<string>();

            foreach (var voucherCode in voucherCodes)
            {
                obj.VoucherCode = voucherCode;
                SqlDataReader dr = await objbal.GetVoucherAmountAsyncMB(obj);
                while (dr.Read())
                {
                    amounts.Add(dr["Balance"].ToString());
                }
            }

            // Calculate the total amount
            double totalAmount = amounts.Select(amount => double.Parse(amount)).Sum();

            return Json(new { success = true, totalAmount = totalAmount }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public async Task<ActionResult> UpdateTheVoucherAmountAsyncMB(float? paidAmount, List<string> voucherCodes, string TranscationCode)
        {
           
            Accountant obj = new Accountant();
            List<(string VoucherCode, double Balance)> voucherBalances = new List<(string, double)>();

            // Fetch balances for the selected vouchers
            foreach (var voucherCode in voucherCodes)
            {
                obj.VoucherCode = voucherCode;
                SqlDataReader dr = await objbal.GetVoucherAmountAsyncMB(obj);
                while (dr.Read())
                {
                    voucherBalances.Add((voucherCode, double.Parse(dr["Balance"].ToString())));
                }
            }

            double remainingPaidAmount = paidAmount.Value;

            foreach (var (VoucherCode, Balance) in voucherBalances)
            {
                if (remainingPaidAmount <= 0)
                {
                    break;
                }

                double amountToUse = Math.Min(remainingPaidAmount, Balance);
                remainingPaidAmount -= amountToUse;
                double newBalance = Balance - amountToUse;

                obj.VoucherCode = VoucherCode;
                obj.Amount = float.Parse(amountToUse.ToString());
                obj.TransactionCode = TranscationCode;

                await objbal.VoucherLinkWithTransaction(obj);
            }

            return Json(new { success = true, redirectUrl = Url.Action("ExpenseDashboardAsyncMB", "Accountant") }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DetailTranscationOfExpenseAsynMB(string ExpCode)
        {
            return PartialView();
        }







        //---------------------------Shreyas Coding Start-----------------------------------------------
        public ActionResult AccountantDashboardAsyncSGS()
        {
            return View();
        }
        private async Task<List<Accountant>> GetVouchersList()
        {
            Accountant objT = new Accountant();
            DataSet ds = await objbal.GetVoucher(objT);
            List<Accountant> studentsList = new List<Accountant>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                studentsList.Add(new Accountant
                {
                    VoucherId = Convert.ToInt32(dr["VoucherId"]),
                    VoucherCode = dr["VoucherCode"].ToString(),
                    VendorName = dr["VendorName"].ToString(),
                    Amount = float.Parse(dr["Amount"].ToString()),
                    AmountPaidTo = dr["AmountPaidTo"].ToString(),
                    Description = dr["Description"].ToString(),
                    PaymentMode = dr["PaymentMode"].ToString(),
                    BankId = Convert.ToInt32(dr["BankId"]),
                    ReceiverBankAccountNumber = Convert.ToInt64(dr["ReceiverBankAccountNumber"]),
                    ReceiverBankAccountHolderName = dr["ReceiverBankAccountHolderName"].ToString(),
                    ReceiverBankIFSCCode = dr["ReceiverBankIFSCCode"].ToString(),
                    ReceiverBankName = dr["ReceiverBankName"].ToString(),
                    Balance = float.Parse(dr["Balance"].ToString()),
                    Currency = dr["Currency"].ToString(),
                    TransactionId = dr["TransactionId"].ToString(),
                    VoucherType = dr["VoucherType"].ToString(),
                    VoucherDate = DateTime.Parse(dr["VoucherDate"].ToString()),
                    StaffCode = dr["StaffCode"].ToString(),
                    StatusId = Convert.ToInt32(dr["StatusId"])
                });
            }
            return studentsList;
        }
        [HttpGet]
        public async Task<ActionResult> ListAllPurchaceAsyncSGS()
        {

            //List<Accountant> vouchers = await GetVouchersList();
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            } else
            {
                return View();
            }
        }



        [HttpGet]
        public async Task<ActionResult> RegisterTestAsycTS()
        {
            //List<Accountant> vouchers = await GetVouchersList();
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            } else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<ActionResult> ListAllVouchersAsyncSGS()
        {
            //List<Accountant> vouchers = await GetVouchersList();
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            } else
            {

                return View();
            }
        }


        [HttpGet]
        public async Task<ActionResult> ListVoucherAsyncSGS()
        {
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login page if staff code is not found in session
            } else
            {
                string staffCode = Session["StaffCode"].ToString(); // Retrieve staff code from session
                                                                    //string branchCode = Session["BranchCode"].ToString(); // Retrieve branch code from session

                DataSet ds = new DataSet();

                // Pass staff code and branch code to the method for fetching tests
                ds = await objbal.ListVoucherAsyncSGS();

                Accountant objtr1 = new Accountant();
                List<Accountant> AddExpense1 = new List<Accountant>();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Accountant objtn = new Accountant
                    {
                        VoucherId = row.IsNull("VoucherId") ? 0 : Convert.ToInt32(row["VoucherId"]),
                        VoucherCode = row.IsNull("VoucherCode") ? string.Empty : row["VoucherCode"].ToString(),
                        VendorName = row.IsNull("VendorName") ? string.Empty : row["VendorName"].ToString(),
                        Amount = row.IsNull("Amount") ? 0.0f : float.Parse(row["Amount"].ToString()),
                        AmountPaidTo = row.IsNull("StaffName") ? string.Empty : row["StaffName"].ToString(),
                        Description = row.IsNull("Description") ? string.Empty : row["Description"].ToString(),
                        PaymentMode = row.IsNull("PaymentMode") ? string.Empty : row["PaymentMode"].ToString(),
                        BankId = row.IsNull("BankId") ? 0 : Convert.ToInt32(row["BankId"]),
                        ReceiverBankAccountNumber = row.IsNull("ReceiverBankAccountNumber") ? 0 : Convert.ToInt64(row["ReceiverBankAccountNumber"].ToString()),
                        ReceiverBankAccountHolderName = row.IsNull("ReceiverBankAccountHolderName") ? string.Empty : row["ReceiverBankAccountHolderName"].ToString(),
                        ReceiverBankIFSCCode = row.IsNull("ReceiverBankIFSCCode") ? string.Empty : row["ReceiverBankIFSCCode"].ToString(),
                        ReceiverBankName = row.IsNull("ReceiverBankName") ? string.Empty : row["ReceiverBankName"].ToString(),
                        Balance = row.IsNull("Balance") ? 0.0f : float.Parse(row["Balance"].ToString()),
                        Currency = row.IsNull("Currency") ? string.Empty : row["Currency"].ToString(),
                        TransactionId = row.IsNull("TransactionId") ? string.Empty : row["TransactionId"].ToString(),
                        VoucherType = row.IsNull("Status") ? string.Empty : row["Status"].ToString(),
                        VoucherDate = row.IsNull("VoucherDate") ? DateTime.MinValue : DateTime.Parse(row["VoucherDate"].ToString()),
                        StaffCode = row.IsNull("StaffCode") ? string.Empty : row["StaffCode"].ToString(),
                        StatusId = row.IsNull("StatusId") ? 0 : Convert.ToInt32(row["StatusId"])
                    };

                    AddExpense1.Add(objtn);
                }

                objtr1.lstVoucher = AddExpense1;

                List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
            {
                //new BreadcrumbItem { Name = "Home", Url = "/" },
                new BreadcrumbItem { Name = "TrainerDashboard", Url = "TrainerDashboardAsyncTS/Trainer" },
               new BreadcrumbItem { Name = "Test Managment", Url = "ListTestManagementAsynchTS/Trainer" }, // Adjust URL as needed
            };

                ViewBag.Breadcrumbs = breadcrumbs;
                return PartialView("ListVoucherAsyncSGS", objtr1);
            }
        }


        [HttpGet]
        public async Task<ActionResult> ListPendingVoucherAsyncSGS()
        {
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login page if staff code is not found in session
            } else
            {
                string staffCode = Session["StaffCode"].ToString(); // Retrieve staff code from session
                                                                    //string branchCode = Session["BranchCode"].ToString(); // Retrieve branch code from session

                DataSet ds = new DataSet();

                // Pass staff code and branch code to the method for fetching tests
                ds = await objbal.ListPendingVoucherAsyncSGS();

                Accountant objtr1 = new Accountant();
                List<Accountant> AddExpense1 = new List<Accountant>();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Accountant objtn = new Accountant
                    {
                        VoucherId = row.IsNull("VoucherId") ? 0 : Convert.ToInt32(row["VoucherId"]),
                        VoucherCode = row.IsNull("VoucherCode") ? string.Empty : row["VoucherCode"].ToString(),
                        VendorName = row.IsNull("VendorName") ? string.Empty : row["VendorName"].ToString(),
                        Amount = row.IsNull("Amount") ? 0.0f : float.Parse(row["Amount"].ToString()),
                        AmountPaidTo = row.IsNull("StaffName") ? string.Empty : row["StaffName"].ToString(),
                        Description = row.IsNull("Description") ? string.Empty : row["Description"].ToString(),
                        PaymentMode = row.IsNull("PaymentMode") ? string.Empty : row["PaymentMode"].ToString(),
                        BankId = row.IsNull("BankId") ? 0 : Convert.ToInt32(row["BankId"]),
                        ReceiverBankAccountNumber = row.IsNull("ReceiverBankAccountNumber") ? 0 : Convert.ToInt64(row["ReceiverBankAccountNumber"].ToString()),
                        ReceiverBankAccountHolderName = row.IsNull("ReceiverBankAccountHolderName") ? string.Empty : row["ReceiverBankAccountHolderName"].ToString(),
                        ReceiverBankIFSCCode = row.IsNull("ReceiverBankIFSCCode") ? string.Empty : row["ReceiverBankIFSCCode"].ToString(),
                        ReceiverBankName = row.IsNull("ReceiverBankName") ? string.Empty : row["ReceiverBankName"].ToString(),
                        Balance = row.IsNull("Balance") ? 0.0f : float.Parse(row["Balance"].ToString()),
                        Currency = row.IsNull("Currency") ? string.Empty : row["Currency"].ToString(),
                        TransactionId = row.IsNull("TransactionId") ? string.Empty : row["TransactionId"].ToString(),
                        VoucherType = row.IsNull("Status") ? string.Empty : row["Status"].ToString(),
                        VoucherDate = row.IsNull("VoucherDate") ? DateTime.MinValue : DateTime.Parse(row["VoucherDate"].ToString()),
                        StaffCode = row.IsNull("StaffCode") ? string.Empty : row["StaffCode"].ToString(),
                        StatusId = row.IsNull("StatusId") ? 0 : Convert.ToInt32(row["StatusId"])
                    };

                    AddExpense1.Add(objtn);
                }

                objtr1.lstVoucher = AddExpense1;

                List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
            {
                //new BreadcrumbItem { Name = "Home", Url = "/" },
                new BreadcrumbItem { Name = "TrainerDashboard", Url = "TrainerDashboardAsyncTS/Trainer" },
               new BreadcrumbItem { Name = "Test Managment", Url = "ListTestManagementAsynchTS/Trainer" }, // Adjust URL as needed
            };

                ViewBag.Breadcrumbs = breadcrumbs;
                return PartialView("ListPendingVoucherAsyncSGS", objtr1);
            }
        }
        [HttpGet]
        public async Task<ActionResult> ListCompletedVoucherAsyncSGS()
        {
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login page if staff code is not found in session
            } else
            {
                string staffCode = Session["StaffCode"].ToString(); // Retrieve staff code from session
                                                                    //string branchCode = Session["BranchCode"].ToString(); // Retrieve branch code from session

                DataSet ds = new DataSet();

                // Pass staff code and branch code to the method for fetching tests
                ds = await objbal.ListCompletedVoucherAsyncSGS();

                Accountant objtr1 = new Accountant();
                List<Accountant> AddExpense1 = new List<Accountant>();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Accountant objtn = new Accountant
                    {
                        VoucherId = row.IsNull("VoucherId") ? 0 : Convert.ToInt32(row["VoucherId"]),
                        VoucherCode = row.IsNull("VoucherCode") ? string.Empty : row["VoucherCode"].ToString(),
                        VendorName = row.IsNull("VendorName") ? string.Empty : row["VendorName"].ToString(),
                        Amount = row.IsNull("Amount") ? 0.0f : float.Parse(row["Amount"].ToString()),
                        AmountPaidTo = row.IsNull("StaffName") ? string.Empty : row["StaffName"].ToString(),
                        Description = row.IsNull("Description") ? string.Empty : row["Description"].ToString(),
                        PaymentMode = row.IsNull("PaymentMode") ? string.Empty : row["PaymentMode"].ToString(),
                        BankId = row.IsNull("BankId") ? 0 : Convert.ToInt32(row["BankId"]),
                        ReceiverBankAccountNumber = row.IsNull("ReceiverBankAccountNumber") ? 0 : Convert.ToInt64(row["ReceiverBankAccountNumber"].ToString()),
                        ReceiverBankAccountHolderName = row.IsNull("ReceiverBankAccountHolderName") ? string.Empty : row["ReceiverBankAccountHolderName"].ToString(),
                        ReceiverBankIFSCCode = row.IsNull("ReceiverBankIFSCCode") ? string.Empty : row["ReceiverBankIFSCCode"].ToString(),
                        ReceiverBankName = row.IsNull("ReceiverBankName") ? string.Empty : row["ReceiverBankName"].ToString(),
                        Balance = row.IsNull("Balance") ? 0.0f : float.Parse(row["Balance"].ToString()),
                        Currency = row.IsNull("Currency") ? string.Empty : row["Currency"].ToString(),
                        TransactionId = row.IsNull("TransactionId") ? string.Empty : row["TransactionId"].ToString(),
                        VoucherType = row.IsNull("Status") ? string.Empty : row["Status"].ToString(),
                        VoucherDate = row.IsNull("VoucherDate") ? DateTime.MinValue : DateTime.Parse(row["VoucherDate"].ToString()),
                        StaffCode = row.IsNull("StaffCode") ? string.Empty : row["StaffCode"].ToString(),
                        StatusId = row.IsNull("StatusId") ? 0 : Convert.ToInt32(row["StatusId"])
                    };

                    AddExpense1.Add(objtn);
                }

                objtr1.lstVoucher = AddExpense1;

                List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
            {
                //new BreadcrumbItem { Name = "Home", Url = "/" },
                new BreadcrumbItem { Name = "TrainerDashboard", Url = "TrainerDashboardAsyncTS/Trainer" },
               new BreadcrumbItem { Name = "Test Managment", Url = "ListTestManagementAsynchTS/Trainer" }, // Adjust URL as needed
            };

                ViewBag.Breadcrumbs = breadcrumbs;
               
            return PartialView("ListCompletedVoucherAsyncSGS", objtr1);
            }
        }

        [HttpGet]
        public async Task<ActionResult> AddVoucherAsyncSGS()
        {
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            } else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddVoucherAsyncSGSAsync(Accountant objA)
        {
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            } else {
                try
                {
                    //objA.StaffCode = Session["StaffCode"].ToString();
                    //objA.BranchCode = Session["BranchCode"].ToString();
                    await objbal.AddVoucherAsyncSGS(objA);
                    return Json(new { success = true, message = "Data saved successfully" });
                } catch (Exception ex)
                {
                    return Json(new { success = false, message = "An error occurred while saving data: " + ex.Message });
                }
            }
            
        }
    }
}