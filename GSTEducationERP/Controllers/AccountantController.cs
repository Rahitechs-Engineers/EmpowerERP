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
        private readonly Accountant objac = new Accountant();
        public class BreadcrumbItem
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
<<<<<<< HEAD



=======
       
>>>>>>> 66d0e4c38599ef06cb45f8fd86ad0bce370e359f
        // GET: Accountant
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
            }
            else
            {
                objac.StaffCode = Session["StaffCode"].ToString(); // Retrieve staff code from session
                objac.BranchCode = Session["BranchCode"].ToString(); // Retrieve branch code from session

                // Voucher Type List
                List<SelectListItem> VoucherTypeList = new List<SelectListItem>();
                DataSet ds = await objbal.VoucherTypeAsyncSGS(objac);
                List<SelectListItem> TypeList = new List<SelectListItem>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TypeList.Add(new SelectListItem
                    {
                        Text = dr["Status"].ToString(),
                        Value = dr["StatusId"].ToString()
                    });
                }
                VoucherTypeList.AddRange(TypeList);
                ViewBag.VoucherTypeList = VoucherTypeList;

                // Voucher Code
                objac.VoucherCode = await objbal.GetMaxVoucherCodeAsyncSGS(objac);
                ViewBag.VoucherNumber = objac.VoucherCode; // This line might be redundant now

                // Staff List
                List<SelectListItem> combinedReportingList = new List<SelectListItem>();
                DataSet ds1 = await objbal.StaffNameforVoucherAsyncSGS(objac);
                List<SelectListItem> StaffList = new List<SelectListItem>();
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    StaffList.Add(new SelectListItem
                    {
                        Text = dr["StaffName"].ToString(),
                        Value = dr["StaffCode"].ToString()
                    });
                }
                combinedReportingList.AddRange(StaffList);
                ViewBag.combinedReportingList = combinedReportingList;

                // Bank Account List
                List<SelectListItem> BankAccountList = new List<SelectListItem>();
                DataSet ds2 = await objbal.BankAccountforVoucherAsyncSGS(objac);
                List<SelectListItem> BankList = new List<SelectListItem>();
                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    string bankName = dr["BankName"].ToString();
                    string accountHolderName = dr["AccountHolderName"].ToString();
                    string accountNumber = dr["AccountNumber"].ToString();

                    BankList.Add(new SelectListItem
                    {
                        Text = $"{bankName} - {accountHolderName} - {accountNumber}",
                        Value = dr["BankId"].ToString()
                    });
                }
                BankAccountList.AddRange(BankList);
                ViewBag.BankAccountList = BankAccountList;

                // Breadcrumbs
                List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
        {
            new BreadcrumbItem { Name = "AccountantDashboard", Url = "AccountantDashboardAsyncSGS" },
            new BreadcrumbItem { Name = "Voucher Managment", Url = "ListAllVouchersAsyncSGS" },
            new BreadcrumbItem { Name = "Add Voucher", Url = "AddCashVoucherAsyncSGS" },
        };

                ViewBag.Breadcrumbs = breadcrumbs;
                return PartialView(objac);
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddVoucherAsyncSGS(Accountant objA)
        {
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
            else
            {
                try
                {
                    objA.StaffCode = Session["StaffCode"].ToString();
                    objA.BranchCode = Session["BranchCode"].ToString();
                    await objbal.AddVoucherAsyncSGS(objA);
                    return RedirectToAction("ListAllVouchersAsyncSGS");
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "An error occurred while saving data: " + ex.Message });
                }
            }

        }
        #region //Vishals purchase modules starts here
        //======================================================Vishal's Purchase Modules starts here===================================================================================
        #region//main view code for purchase by vishal pardeshi
        /// <summary>
        /// this action result methode for the purchase dashboard ...getting the all the purchases 
        /// </summary>
        /// <returns> this list of purchase</returns>
        [HttpGet]
        public async Task<ActionResult> DetailsPurchaseAsyncVP()
        {
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
            else
            {
                //try
                //{
                objac.BranchCode = Session["BranchCode"].ToString();
                objac.StaffCode = Session["StaffCode"].ToString();
                List<Accountant> model = await ListPurchasesAsyncVP();
                objac.lstPurchaseVP = model;
                List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
                        {
                            new BreadcrumbItem { Name = "Dashboard", Url = "AccountantDashboardAsyncSGS" },
                            new BreadcrumbItem { Name = "Purchase", Url = "DetailsPurchaseAsyncVP" },
                        };
                ViewBag.Breadcrumbs = breadcrumbs;
                ViewBag.Currency = "&#x20b9;";
                //}
                //catch (Exception ex)
                //{
                //    throw (ex);
                //}
                Session["ListforFilter"] = model;
                Session["Currency"] = "&#x20b9;";
                return await Task.Run(() => View("DetailsPurchaseAsyncVP", objac));

            }
        }
        /// <summary>
        /// this action result methode is written for thr purchase purpose
        /// </summary>
        /// <param name="status"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>filter llst</returns>
        [HttpGet]
        public async Task<ActionResult> FilterPurchases(string status, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                List<Accountant> purchases = Session["ListforFilter"] as List<Accountant>;
                if (!string.IsNullOrEmpty(status) && status != "selectall")
                {
                    purchases = purchases.Where(p => p.Status == status).ToList();
                }

                if (startDate.HasValue)
                {
                    purchases = purchases.Where(p => p.TransactionDate >= startDate.Value).ToList();
                }

                if (endDate.HasValue)
                {
                    purchases = purchases.Where(p => p.TransactionDate <= endDate.Value).ToList();
                }
                ViewBag.Currency = Session["Currency"].ToString();
                Accountant obj = new Accountant { lstPurchaseVP = purchases };
                return await Task.Run(() => PartialView("_PurchaseListAsyncVP", obj));
            }
            catch (Exception ex) 
            {
                ViewBag.ErrorMessage = ex.Message;
                return await Task.Run(()=> View("error"));
            }
        }

        /// <summary>
        /// this action methode is wrriten for the getting the view for the add purchase 
        /// </summary>
        /// <returns>the viewbags for the dropdowns in the add purchase</returns>
        [HttpGet]
        public async Task<ActionResult> AddPurchaseAsyncVP()
        {
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                try
                {
                    objac.BranchCode = Session["BranchCode"].ToString();
                    objac.StaffCode = Session["StaffCode"].ToString();
                    //breadcrumbs here
                    List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
                {

                        new BreadcrumbItem { Name = "Dashboard", Url =Url.Action("AccountantDashboardAsyncSGS", "Accountant")  },
                        new BreadcrumbItem { Name = "Purchase", Url = Url.Action("DetailsPurchaseAsyncVP","Accountant") },
                        new BreadcrumbItem { Name = "Add Purchase", Url = Url.Action("AddPurchaseAsyncVP", "Accountant") },
                };

                    ViewBag.Breadcrumbs = breadcrumbs;
                    //getting the last purchase code and making increment to it and inserting it to database
                    objac.TransactionCode = await GetPurchaseCoedAsyncVP(objac);
                    //fetching the banks here for the add purchase 
                    await ListStatusAsyncVP();//fetching the status here i don't know why
                    //setting the date by default todays
                    await ListHsnCodeAsyncVP();//getting thehsncode link for dropdown
                    await ListTaxAsyncVP();//getting the applied tax viewbag from methode
                    await PaymentmodesAsyncVP();//getting the payment modes to dropdown
                    ViewBag.Currency = "&#x20b9;";
                    ViewBag.IsitEdit = false;//sending the viewbag for checking the view is edit or not
                    return await Task.Run(() => PartialView("AddPurchaseAsyncVP", objac));
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error occurred while processing the request." + ex;
                    return View("Error");
                }
            }
        }
        /// <summary>
        /// post methode for saving the purchase details to database
        /// </summary>
        /// <param name="objac"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddPurchaseAsyncVP(Accountant objac)
        {
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                //saving the details to database about the purchase
                //try
                //{
                objac.StaffCode = Session["StaffCode"].ToString();
                objac.BranchCode = Session["BranchCode"].ToString();
                await objbal.SavePurchaseAsyncVP(objac);
                Accountant objpi = new Accountant();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                //}
                //catch (Exception ex)
                //{
                //    return Json(new { success = false, message = "Invalid purchase items data." + ex }, JsonRequestBehavior.AllowGet);
                //}
            }

        }
        /// <summary>
        /// this is the action result methode for the match voucher partial view
        /// </summary>
        /// <param name="TCode"></param>
        /// <param name="Amount"></param>
        /// <returns>partial view of match voucher</returns>
        [HttpGet]
        public async Task<ActionResult> MatchVoucherAsyncVM(string TCode, float Amount)
        {
            Accountant obj = new Accountant();
            obj.TransactionCode = TCode;
            obj.Amount = Amount;
            var parts = TCode.Split('-');
            obj.VendorName = parts[1];
            await ListVoucherAsyncVP(parts[1]);
            return PartialView("_MatchVoucherAsyncVM", obj);
        }
        /// <summary>
        /// this is the post methode for the inserting the data of transactions and voucher code into voucher link
        /// </summary>
        /// <param name="vouchers"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> MatchVoucherAsyncVM(string TranscationCode, float? TransactionAmount, List<Accountant> vouchers, string description)
        {
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (vouchers == null || !vouchers.Any())
            {
                return Json(new { success = false, message = "No vouchers provided." });
            }

            if (!TransactionAmount.HasValue || TransactionAmount.Value <= 0)
            {
                return Json(new { success = false, message = "Invalid transaction amount." });
            }

            double remainingPaidAmount = TransactionAmount.Value;

            foreach (var voucher in vouchers)
            {
                if (remainingPaidAmount <= 0)
                {
                    break;
                }

                double amountToUse = Math.Min(remainingPaidAmount, voucher.Amount);
                remainingPaidAmount -= amountToUse;
                double newBalance = voucher.Amount - amountToUse;

                // Update the voucher's details
                voucher.TransactionAmount = (float)amountToUse;
                voucher.TransactionCode = TranscationCode;
                voucher.Description = description;
                try
                {
                    await objbal.SaveVoucherPurchaseAsyncVP(voucher);
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"Error updating voucher {voucher.VoucherCode}: {ex.Message}" });
                }
            }

            return Json(new { success = true, redirectUrl = Url.Action("DetailsPurchaseAsyncVP", "Accountant") }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        /// <summary>
        /// this list methode is written for the fetching the Purchased item list 
        /// </summary>
        /// <param name="PurchaseCode"></param>
        /// <returns>this methode returns the list of purchased itms for update </returns>
        private async Task<(List<Accountant>, List<Accountant>)> ListPurchasItemsAsyncVP(string PurchaseCode)
        {
            //fetching the list of purchased itmes here
            List<Accountant> lstitems = new List<Accountant>();
            List<Accountant> lsttransaction = new List<Accountant>();
            objac.BranchCode = Session["BranchCode"].ToString();
            DataSet ds = await objbal.ListPurchasedItemsAsyncVP(objac);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Accountant objP = new Accountant
                    {
                        TransactionCode = PurchaseCode,
                        ItemName = ds.Tables[0].Rows[i]["ItemName"].ToString(),
                        HSNCode = ds.Tables[0].Rows[i]["HSNCode"].ToString(),
                        Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"].ToString()),
                        UnitPrice = decimal.Parse(ds.Tables[0].Rows[i]["UnitPrice"].ToString()),
                        Discount = Convert.ToDouble(ds.Tables[0].Rows[i]["Discount"].ToString()),
                        Tax = ds.Tables[0].Rows[i]["TaxRate"].ToString(),
                        Balance = float.Parse(ds.Tables[0].Rows[i]["DiscountAmount"].ToString()),
                        AppliedTax = ds.Tables[0].Rows[i]["TaxAmount"].ToString(),
                        TransactionAmount = Convert.ToDouble(ds.Tables[0].Rows[i]["TotalPrice"].ToString())
                    };
                    lstitems.Add(objP);
                }
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    Accountant objT = new Accountant();

                    string mode = ds.Tables[1].Rows[i]["PaymentMode"].ToString();
                    objT.TransactionDate = Convert.ToDateTime(ds.Tables[1].Rows[i]["Date"]);
                    objT.VoucherCode = ds.Tables[1].Rows[i]["VoucherCode"].ToString();
                    objT.PaymentMode = mode;
                    if (mode == "BANK")
                    {
                        objT.TranId_CheqNo = ds.Tables[1].Rows[i]["TransactionId_ChequeNo"].ToString();
                    }
                    else if (mode == "CHEQUE")
                    {
                        objT.TranId_CheqNo = ds.Tables[1].Rows[i]["TransactionId_ChequeNo"].ToString();
                        objT.ChequeDate = string.IsNullOrEmpty(ds.Tables[1].Rows[i]["ChequeDate"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[1].Rows[i]["ChequeDate"]);
                        objT.ChequeClearenceDate = string.IsNullOrEmpty(ds.Tables[1].Rows[i]["ChequeClearenceDate"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[1].Rows[i]["ChequeClearenceDate"]);
                    }
                    objT.TransactionAmount = Convert.ToDouble(ds.Tables[1].Rows[i]["Amount"]);
                    objT.BalanceAmount = Convert.ToDouble(ds.Tables[1].Rows[i]["BalanceAmount"]);


                    lsttransaction.Add(objT);
                }
            }
            return (lstitems, lsttransaction);
        }
        /// <summary>
        /// the action is to return the list for the pending purchase list
        /// </summary>
        /// <returns>Viewbag for Purchase and list for the all purchase</returns>
        private async Task<List<Accountant>> ListPurchasesAsyncVP()
        {
            objac.BranchCode = Session["BranchCode"].ToString();
            objac.StaffCode = Session["StaffCode"].ToString();
            DataSet ds = await objbal.ListPurchasesAsyncVP(objac);
            List<Accountant> lstpurchase = new List<Accountant>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Accountant objP = new Accountant
                    {
                        TransactionCode = row.IsNull("TransactionCode") ? string.Empty : row["TransactionCode"].ToString(),
                        VendorName = row.IsNull("VendorName") ? string.Empty : row["VendorName"].ToString(),
                        ItemName = row.IsNull("Items") ? string.Empty : row["Items"].ToString(),
                        Quantity = row.IsNull("ItemCount") ? 0 : Convert.ToInt32(row["ItemCount"]),
                        TransactionAmount = row.IsNull("TransactionAmount") ? 0.0 : Convert.ToDouble(row["TransactionAmount"]),
                        BalanceAmount = row.IsNull("BalanceAmount") ? 0.0 : Convert.ToDouble(row["BalanceAmount"]),
                        TransactionDate = row.IsNull("TransactionDate") ? DateTime.MinValue : Convert.ToDateTime(row["TransactionDate"]),
                        Description= row.IsNull("Description") ? string.Empty : row["Description"].ToString(),
                        PaymentMode = row.IsNull("PaymentMode") ? string.Empty : row["PaymentMode"].ToString(),
                        TranId_CheqNo = row.IsNull("TransactionID") ? string.Empty : row["TransactionID"].ToString(),
                        Status = row.IsNull("Status") ? string.Empty : row["Status"].ToString()
                    };

                    lstpurchase.Add(objP);
                }
            }
            return lstpurchase;
        }
        /// <summary>
        /// this mthode is written for the validating the purchase here 
        /// </summary>
        /// <param name="PurchaseCode"></param>
        /// <returns>true/false</returns>
        [HttpPost]
        public async Task<ActionResult> ValidatePurchaseAsyncVP(string PurchaseCode)
        {
            objac.PurchaseCode = PurchaseCode;
            SqlDataReader dr;
            objac.BranchCode = Session["BranchCode"].ToString();
            dr = await objbal.ValidatePurchaseAsyncVP(objac);
            if (dr.Read())
            {
                objac.VendorName = dr["VendorName"].ToString();
                //purchase code exists in the database
                return Json(new {success=false}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //purchase code doesn't exists
                return Json(new {success=true},JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// this action result methode is for the saving the purchased items details
        /// </summary>
        /// <param name="PurchaseItemsAsyncVP"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddPurchaseItemAsyncVP(List<Accountant> PurchaseItemsAsyncVP)
        {
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                //try
                //{

                //saving the details to database about the purchase
                Accountant objpi = new Accountant();
                foreach (var item in PurchaseItemsAsyncVP)
                {
                    objpi.TransactionCode = item.TransactionCode;
                    objpi.ItemName = item.ItemName;
                    objpi.Quantity = item.Quantity;
                    objpi.HSNCode = item.HSNCode;
                    objpi.UnitPrice = item.UnitPrice;
                    objpi.Discount = item.Discount;
                    objpi.AppliedTax = item.AppliedTax;
                    await objbal.SavePurchasedItemsAsyncVP(objpi);
                }
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

                //}
                //catch (Exception ex)
                //{
                //    return Json(new { success = false, message = "Invalid purchase items data." + ex });

                //}
            }
        }
        
        /// <summary>
        /// this action methode written for the viewing the purchase bill for the purchase dashboard
        /// </summary>
        /// <returns>the purchase bill for selected purchase</returns>
        [HttpGet]
        public async Task<ActionResult> ViewPurchaseAsyncVP(string PurchaseCode)
        {
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                //bread crumbs here
                List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
                {

                    new BreadcrumbItem { Name = "Dashboard", Url =Url.Action("AccountantDashboardAsyncSGS", "Accountant")  },
                    new BreadcrumbItem { Name = "Purchase", Url = Url.Action("DetailsPurchaseAsyncVP","Accountant") },
                    new BreadcrumbItem { Name = "View Purchase",Url = Url.Action("ViewPurchaseAsyncVP", "Accountant") + "?PurchaseCode=" + PurchaseCode },

                };

                ViewBag.Breadcrumbs = breadcrumbs;
                objac.PurchaseCode = PurchaseCode;
                objac.BranchCode = Session["BranchCode"].ToString();
                SqlDataReader dr;
                dr = await objbal.ListPurchasesDetailsAsyncVP(objac);
                if (dr.Read())
                {
                    DateTime transactionDate = Convert.ToDateTime(dr["TransactionDate"]);
                    ViewBag.TransactionDate = transactionDate.ToString("dd-MM-yyyy");
                    ViewBag.TransactionCode = PurchaseCode;
                    ViewBag.VendorName = dr["VendorName"].ToString();
                    ViewBag.TransactionAmount = dr["TransactionAmount"].ToString() == "0" ? 0 : long.Parse(dr["TransactionAmount"].ToString());
                    ViewBag.TransactionAmount = dr["BalanceAmount"].ToString() == "0" ? 0 : long.Parse(dr["BalanceAmount"].ToString());
                    ViewBag.PaymentMode = dr["PaymentMode"].ToString();
                    ViewBag.TranId_CheqNo = dr["TransactionID_checqueNumber"].ToString();
                    ViewBag.Description = dr["Description"].ToString();
                }
                //fetching the purchased item list here
                var (listitem, listtransaction) = await ListPurchasItemsAsyncVP(PurchaseCode);
                objac.lstPurchaseItemVP = listitem;
                objac.lstTransactionVP = listtransaction;
                ViewBag.transactionList=listtransaction;
                //giving the currency hard coded
                ViewBag.Currency = "&#x20b9;";
                return await Task.Run(() => View("ViewPurchaseAsyncVP", objac));
            }
        }
        /// <summary>
        /// this action result methode for getting the details for updating the purchase in purchase dashboard
        /// </summary>
        /// <param name="TransactionCode"></param>
        /// <returns>this returns the saved details for selected purchase</returns>
        [HttpGet]
        public async Task<ActionResult> UpdatePurchaseAsyncVP(string PurchaseCode)
        {
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Accountant accountant = new Accountant();
                //bread crumbs here
                List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
                {

                        new BreadcrumbItem { Name = "Dashboard", Url =Url.Action("AccountantDashboardAsyncSGS", "Accountant")  },
                        new BreadcrumbItem { Name = "Purchase", Url = Url.Action("DetailsPurchaseAsyncVP","Accountant") },
                        new BreadcrumbItem { Name = "Update Purchase",Url = Url.Action("UpdatePurchaseAsyncVP", "Accountant") + "?PurchaseCode=" + PurchaseCode },
                };

                ViewBag.Breadcrumbs = breadcrumbs;
                //getting the details from the database for this purchase code
                objac.TransactionCode = PurchaseCode;
                objac.PurchaseCode = PurchaseCode;
                objac.BranchCode = Session["BranchCode"].ToString();
                ViewBag.Currency = "&#x20b9;";
                ViewBag.IsitEdit = true;
                SqlDataReader dr = await objbal.ListPurchasesDetailsAsyncVP(objac);
                if (dr.Read())
                {
                    accountant.TransactionCode = PurchaseCode;
                    accountant.VendorName = dr["VendorName"].ToString();
                    accountant.TransactionDate = Convert.ToDateTime(dr["TransactionDate"].ToString());
                    accountant.BalanceAmount = long.Parse(dr["BalanceAmount"].ToString());
                    accountant.Description = dr["Description"].ToString();

                }
                await ListHsnCodeAsyncVP();//getting thehsncode link for dropdown
                await ListTaxAsyncVP();//getting the tax for purchased item list
                List<Accountant>lst1= new List<Accountant>();
                List<Accountant>lst2= new List<Accountant>();

                await ListPurchasedItemsAsyncVP(objac);//getting the list of purchased items
                await PaymentmodesAsyncVP();//getting the payment modes to dropdown
                return await Task.Run(() => View("AddPurchaseAsyncVP", accountant));
            }
        }
        /// <summary>
        /// this methode is wrriten to get the purchased items list for the purchase doen or pending
        /// </summary>
        /// <param name="objA"></param>
        /// <returns>ViewBag.ListofItems</returns>
        [HttpGet]
        private async Task ListPurchasedItemsAsyncVP(Accountant objA)
        {

            //fetching the list of purchased itmes here
            List<Accountant> lstitems = new List<Accountant>();
            DataSet ds = await objbal.ListPurchasedItemsAsyncVP(objA);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Accountant objP = new Accountant();
                    objP.ItemId = int.Parse(ds.Tables[0].Rows[i]["PurchaseItemId"].ToString());
                    objP.TransactionCode = objA.PurchaseCode;
                    objP.ItemName = ds.Tables[0].Rows[i]["ItemName"].ToString();
                    objP.HSNCode = ds.Tables[0].Rows[i]["HSNCode"].ToString();
                    objP.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"].ToString());
                    objP.UnitPrice = decimal.Parse(ds.Tables[0].Rows[i]["UnitPrice"].ToString());
                    objP.Discount = Convert.ToDouble(ds.Tables[0].Rows[i]["Discount"].ToString());
                    objP.AppliedTax = ds.Tables[0].Rows[i]["TaxRate"].ToString();
                    objP.Tax = ds.Tables[0].Rows[i]["foruddl"].ToString();
                    lstitems.Add(objP);
                }
            }
            ViewBag.ListofItems = lstitems;
        }
        /// <summary>
        /// updating the purchase details in transactions for purchase
        /// </summary>
        /// <param name="objA"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> UpdatePurchaseAsyncVP(Accountant objA)
        {
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                //try
                //{

                objA.StaffCode = Session["StaffCode"].ToString();
                await objbal.UpdatePurchaseAsyncVP(objA);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                //}
                //catch
                //{
                //    return await Task.Run(() => View("Error"));
                //}
            }
        }
        [HttpPost]
        public async Task<ActionResult> UpdatePurchaseItemAsyncVP(List<Accountant> PurchaseItemsAsyncVP)
        {
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                //try
                //{

                Accountant objpi = new Accountant();
                foreach (var item in PurchaseItemsAsyncVP)
                {
                    objpi.ItemId = item.ItemId;
                    objpi.TransactionCode = item.TransactionCode;
                    objpi.TransactionCode = item.TransactionCode;
                    objpi.ItemName = item.ItemName;
                    objpi.Quantity = item.Quantity;
                    objpi.HSNCode = item.HSNCode;
                    objpi.UnitPrice = item.UnitPrice;
                    objpi.Discount = item.Discount;
                    objpi.AppliedTax = item.AppliedTax;

                    if (objpi.ItemId == 0)
                    {

                        await objbal.SavePurchasedItemsAsyncVP(objpi);
                    }
                    else
                    {
                        await objbal.UpdatePurchasedItemsAsyncVP(objpi);
                        //update items in the purchased item table
                    }

                }
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                //}
                //catch
                //{

                //}
            }
        }
        /// <summary>
        /// fetching the last purchase code and making the increment by 1 and sending it to add purchase form
        /// </summary>
        /// <param name="PurchaseCode"></param>
        /// <returns></returns>
        [HttpGet]
        private async Task<string> GetPurchaseCoedAsyncVP(Accountant obj)
        {
            obj.BranchCode = Session["BranchCode"].ToString();
            obj.StaffCode = Session["StaffCode"].ToString();
            string newPurchaseCode = await objbal.GetTaskPurchaseCode(obj);
            return newPurchaseCode;
        }
        /// <summary>
        /// fetching the status here any bropdown in purchase i need
        /// </summary>
        /// <param name="Bank"></param>
        /// <returns></returns>
        [HttpGet]
        private async Task ListStatusAsyncVP()
        {
            //fetching the banks here for the add purchase 
            DataSet ds = await objbal.ListStatusAsyncVP();
            List<SelectListItem> StatusList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                StatusList.Add(new SelectListItem { Text = dr["Status"].ToString(), Value = dr["StatusId"].ToString() });
            }
            ViewBag.StatusId = StatusList;
        }
        /// <summary>
        /// this methode is wrriten for the all the payments modes for the purchase module ie. cahs and bank
        /// </summary>
        /// <returns>viewbag for the payment mode for add purchase</returns>
        private async Task PaymentmodesAsyncVP()
        {

            List<SelectListItem> lstp = new List<SelectListItem>
                    {
                        new SelectListItem { Value = "CASH", Text = "CASH" },
                        new SelectListItem { Value = "BANK", Text = "BANK" },
                        new SelectListItem { Value = "CHEQUE", Text = "CHEQUE" }
                    };
            await Task.Run(() => ViewBag.PaymentModes = lstp);
            //return await Task.Run(() => lstp);
        }
        /// <summary>
        /// this action methode is written for the applied tax list in the add and edit purchase
        /// </summary>
        /// <returns>viewbag for the Applied tax</returns>
        private async Task ListTaxAsyncVP()
        {
            //fetching the banks here for the add purchase ,
            DataSet ds = await objbal.ListtTaxAsyncVP();
            List<SelectListItem> taxList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                taxList.Add(new SelectListItem { Text = dr["TaxRate"].ToString(), Value = dr["TaxRateId"].ToString() });
            }

            await Task.Run(() => ViewBag.AppliedTax = taxList);
        }
        ///<summary>
        ///This action methode for the getting the list of the vouchers from the database
        /// </summary>
        /// <param name=""></param>
        /// <return>ListVoucherList</return>
        [HttpPost]
        public async Task<JsonResult> ListVoucherAsyncVP(string vendorName)
        {
            if (Session["StaffCode"] == null)
            {
                //return RedirectToAction("Login", "Account");
                return Json(new { success = false, message = "cannot find the user " }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //try
                //{

                //}
                //catch (Exception ex) { }
                if (!string.IsNullOrEmpty(vendorName))
                {
                    objac.BranchCode = Session["BranchCode"].ToString();
                    //fetching the banks here for the add purchase 
                    objac.VendorName = vendorName;
                    DataSet ds = await objbal.ListVouchersAsyncVP(objac);
                    List<SelectListItem> VoucherList = new List<SelectListItem>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        VoucherList.Add(new SelectListItem { Text = $"{dr["VoucherCode"].ToString() + "-" + dr["PaidTo"].ToString() + "-" + dr["Balance"].ToString()}", Value = dr["VoucherCode"].ToString() });
                    }
                    ViewBag.VoucherCode = VoucherList;
                    return await Task.Run(() => Json(new { success = true, data = VoucherList }, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    return await Task.Run(() => Json(new { success = true, message = "vendor code is null" }, JsonRequestBehavior.AllowGet));
                }
            }
        }
        /// <summary>
        /// this action result methode is wrriten for the Listing the HSN code and Category. for the dropdown for the add purchase
        /// </summary>
        /// <returns>the list of the HSNcode to view</returns>
        [HttpGet]
        private async Task ListHsnCodeAsyncVP()
        {
            DataSet ds = await objbal.ListHSNCategoryAsyncVP();
            List<SelectListItem> HsnList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                HsnList.Add(new SelectListItem { Text = dr["text"].ToString(), Value = dr["value"].ToString() });
            }
            ViewBag.HSNCode = HsnList;
        }
        /// <summary>
        /// this json result methode is wrritten for deleting purchased items from table so updated entires can be entred into table
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>Json</returns>
        [HttpPost]
        public async Task<ActionResult> DeletePurchaseItemAsyncVP(string itemId)
        {
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
            else
            {
                //try
                //{(
                if (string.IsNullOrEmpty(itemId)) 
                {
                    objac.ItemId = int.Parse(itemId);
                    await objbal.DeletePurchasedItemAsyncVP(objac);
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else 
                {
                    return Json(new { success = false,message="itemid is null" }, JsonRequestBehavior.AllowGet);

                }

                //}
                //catch
                //{
                //    return Json(new { success = false });
                //}
            }
        }
        //------------------------------------Vishal's Purchase Modules ends here------------------------------------------------------------
<<<<<<< HEAD
        #endregion

        #region//Mukesh Expense Modal Start Here

        public async Task<ActionResult> ExpenseDashboardAsyncMB()
        {
            List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
                 {
                     new BreadcrumbItem { Name = "Dashboard", Url = "AccountantDashboardAsyncSGS" },
                     new BreadcrumbItem { Name = "Expense List", Url = "ExpenseDashboardAsyncMB" },
                 };
            ViewBag.Breadcrumbs = breadcrumbs;
            return await Task.Run(() => View("ExpenseDashboardAsyncMB"));
        }

        //public string ExpId;
        /// <summary>
        /// List of Regular, Refund,Reference and Other Expenses
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> ExpenseView</returns>
        [HttpGet]
        public async Task<ActionResult> ListOfExpensesAsyncMB(string Id)
        {

            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
            else
            {
                List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
                 {
                     new BreadcrumbItem { Name = "Dashboard", Url = "AccountantDashboardAsyncSGS" },
                     new BreadcrumbItem { Name = "Expense List", Url = "ExpenseDashboardAsyncMB" },
                 };
                ViewBag.Breadcrumbs = breadcrumbs;
                ViewBag.Currency = "&#x20b9;";
                objac.ExpID = Id;
                Session["ID"] = Id;
                DataSet ds = await objbal.ListOfExpensesAsyncMB(objac);
                List<Accountant> lstRegularExpense = new List<Accountant>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    Accountant objP = new Accountant();
                    objP.TransactionCode = (ds.Tables[0].Rows[i]["TransactionCode"].ToString());
                    objP.ExpenseType = ds.Tables[0].Rows[i]["ExpenseType"].ToString();
                    objP.ReferenceByName = ds.Tables[0].Rows[i]["Name"].ToString();
                    objP.ReferenceToName = ds.Tables[0].Rows[i]["ReferenceToCandidate"].ToString();
                    objP.VendorName = ds.Tables[0].Rows[i]["Name"].ToString();
                    objP.Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["TransactionDate"].ToString());
                    objP.PaymentMode = ds.Tables[0].Rows[i]["PaymentMode"].ToString();
                    objP.TranscationId = ds.Tables[0].Rows[i]["TransactionID_checqueNumber"].ToString();
                    objP.TranscationChequedate = (ds.Tables[0].Rows[i]["ChequeClearenceDate"].ToString());
                    objP.Amount = int.Parse(ds.Tables[0].Rows[i]["TransactionAmount"].ToString());
                    objP.Balance = int.Parse(ds.Tables[0].Rows[i]["BalanceAmount"].ToString());
                    objP.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                    objP.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    objP.TotalAmount = objP.Amount + objP.Balance;
                    lstRegularExpense.Add(objP);
                }
                objac.lstRegularExpense = lstRegularExpense;
                Session["ListforFilter"] = lstRegularExpense;
                Session["Currency"] = "&#x20b9;";
                return PartialView("ListOfExpensesAsyncMB", objac);



            }

        }

        /// <summary>
        /// Filter use for list the filter of Expenses with status and date
        /// </summary>
        /// <param name="status"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>listofexpense</returns>
        [HttpGet]
        public async Task<ActionResult> Filterforlist(string status, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                List<Accountant> purchases = Session["ListforFilter"] as List<Accountant>;

                if (status == "SelectAll")
                {
                    purchases = purchases.ToList();
                }
                if (!string.IsNullOrEmpty(status) && status != "SelectAll")
                {
                    purchases = purchases.Where(p => p.Status == status).ToList();
                }

                if (startDate.HasValue)
                {
                    purchases = purchases.Where(p => p.Date >= startDate.Value).ToList();
                }

                if (endDate.HasValue)
                {
                    purchases = purchases.Where(p => p.Date <= endDate.Value).ToList();
                }
                ViewBag.Currency = Session["Currency"].ToString();
                Accountant obj = new Accountant { lstRegularExpense = purchases };
                obj.ExpID = Session["ID"].ToString();
                return await Task.Run(() => PartialView("ListOfExpensesAsyncMB", obj));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return await Task.Run(() => View("error"));
            }
        }

        /// <summary>
        /// here we can pass the data to Add Expense modal
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> AddExpensesAsyncMB()
        {
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
            else
            {

                Accountant obj = new Accountant();
                obj.Date = DateTime.Now;
                await GetExpenceCategoryMB();
                await GetRefundCandidate();
                await GetReferenceByStudentsAsyncMB();
                await ListVoucherAsyncMB();
                await GetStaffNameAsyncMB();
                return PartialView(obj);
            }

        }

        /// <summary>
        /// get the refund candidate 
        /// </summary>
        /// <returns>AddExpenseView</returns>
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

        /// <summary>
        /// get the refund candiadate paid fee 
        /// </summary>
        /// <param name="CandidateCode"></param>
        /// <returns> addexpenseview</returns>
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

        /// <summary>
        /// Get the Reference By Candiadate 
        /// </summary>
        /// <returns>AddExpenseView</returns>
        [HttpGet]
        public async Task GetReferenceByStudentsAsyncMB()
        {
            DataSet ds = await objbal.GetReferenceByCandidatesAsyncMB();
            List<SelectListItem> lstReferenceByStudent = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstReferenceByStudent.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["RefBy"].ToString() });
            }
            await Task.Run(() => ViewBag.ReferenceByStudentlst = lstReferenceByStudent);
        }

        /// <summary>
        /// Get the staffname for giving them Advance
        /// </summary>
        /// <returns>AddExpenseView </returns>
        [HttpGet]
        public async Task GetStaffNameAsyncMB()
        {
            DataSet ds = await objbal.GetStaffNameAsyncMB();
            List<SelectListItem> lstStaff = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstStaff.Add(new SelectListItem { Text = dr["StaffName"].ToString(), Value = dr["StaffCode"].ToString() });
            }
            await Task.Run(() => ViewBag.lstStaff = lstStaff);
        }

        /// <summary>
        /// Get Reference To Candidate 
        /// </summary>
        /// <param name="CandidateCode"></param>
        /// <returns>AddExpenseView</returns>
        [HttpGet]

        public async Task<JsonResult> GettheReferenceToCandidateAsyncMB(string CandidateCode)
        {
            Accountant obj = new Accountant();
            obj.CandidateCode = CandidateCode;
            DataSet ds = await objbal.GetReferenceToCandidatesAsyncMB(obj);
            List<SelectListItem> ReferenceToCandidate = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ReferenceToCandidate.Add(new SelectListItem { Text = dr["FullName"].ToString(), Value = dr["RefTo"].ToString() });
            }

            return Json(new { success = true, candidates = ReferenceToCandidate }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get Expense Category
        /// </summary>
        /// <returns>AddExpenseView</returns>
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

        /// <summary>
        /// Get Expense Type when we select expense Category
        /// </summary>
        /// <param name="ExpCategoryId"></param>
        /// <returns>AddExpenseView</returns>
        [HttpGet]
        public async Task<JsonResult> GetExpenceTypeAsynMB(int ExpCategoryId)
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




        /// <summary>
        /// Save All Expenses Here 
        /// </summary>
        /// <param name="objA"></param>
        /// <param name="ReferenceToCandidateCode"></param>
        /// <param name="EmployeeCode"></param>
        /// <returns>ExpenseDashboardView</returns>
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
                    string newCode;
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

                    }

                    if (objA.ExpID == "5")
                    {
                        objA.Comment = EmployeeCode;

                    }
                    if (objA.ExpID == "4")
                    {
                        objA.StaffCode_CandidateCode = EmployeeCode;

                    }

                    objA.LoginStaffCode = Session["StaffCode"].ToString();


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

        //pop up for the match voucher start here
        [HttpGet]
        public async Task<ActionResult> ExpenseMatchVoucherAsyncVM(string TCode, float Amount)
        {
            Accountant obj = new Accountant();
            obj.TransactionCode = TCode;
            obj.Amount = Amount;
            await ListVoucherAsyncMB();
            return PartialView("_MatchVoucherAsyncVMB", obj);
        }

        /// <summary>
        /// List the voucher to match with transcation 
        /// </summary>
        /// <returns>MatchVoucher</returns>
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

        /// <summary>
        /// MatchVoucher with Transcation
        /// </summary>
        /// <param name="TCode"></param>
        /// <param name="Amount"></param>
        /// <returns></returns>

        //[HttpGet]
        //public async Task<ActionResult> ExpenseMatchVoucherAsyncVM(string TCode, float Amount)
        //{
        //    Accountant obj = new Accountant();
        //    obj.TransactionCode = TCode;
        //    obj.Amount = Amount;

        //    await ListVoucherAsyncMB();
        //    return PartialView("_MatchVoucherAsyncVM", obj);
        //}


        /// <summary>
        /// Update the voucher which are selected
        /// </summary>
        /// <param name="paidAmount"></param>
        /// <param name="voucherCodes"></param>
        /// <param name="TranscationCode"></param>
        /// <returns></returns>
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


        /// <summary>
        /// here we can show the detail expense 
        /// </summary>
        /// <param name="TCode"></param>
        /// <param name="ExpId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ViewTransactionAsyncMB(string TCode, string ExpId)
        {
            Accountant objac = new Accountant();
            if (Session["StaffCode"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
                 {
                     new BreadcrumbItem { Name = "Dashboard", Url = "AccountantDashboardAsyncSGS" },
                     new BreadcrumbItem { Name = "Expense", Url = "ExpenseDashboardAsyncMB" },
                     new BreadcrumbItem { Name = "View Detail Transactions", Url = "ViewTransactionAsyncMB" },
                 };
                ViewBag.Breadcrumbs = breadcrumbs;
                objac.TransactionCode = TCode;
                SqlDataReader dr;
                dr = await objbal.ListExpenseDetailsAsyncMB(objac);
                if (dr.Read())
                {
                    DateTime transactionDate = Convert.ToDateTime(dr["TransactionDate"]);
                    ViewBag.TransactionDate = transactionDate.ToString("dd-MM-yyyy");
                    ViewBag.TransactionCode = TCode;
                    ViewBag.VendorName = dr["VendorName"].ToString();
                    ViewBag.TransactionAmount = dr["TransactionAmount"].ToString() == "0" ? 0 : long.Parse(dr["TransactionAmount"].ToString());
                    ViewBag.BalanceAmount = dr["BalanceAmount"].ToString() == "0" ? 0 : long.Parse(dr["BalanceAmount"].ToString());
                    ViewBag.ReferenceToCandidate = dr["RefToCandidate"].ToString();
                    ViewBag.RefundCandidate = dr["RefundCandidate"].ToString();
                    ViewBag.Description = dr["Description"].ToString();
                }
                Session["TCode"] = TCode;
                objac.ExpID = ExpId;

                // Fetch the list of purchased items
                var (listitem, listtransaction) = await ListExpenseDetailsAsyncMB();
                //List<Accountant> listitems = await ListExpenseDetailsAsyncMB();
                objac.ListGiveExpenseMB = listitem;
                objac.ListMatchVoucheToExpense = listtransaction;
                ViewBag.transactionList = listtransaction;

                // Giving the currency hard coded
                ViewBag.Currency = "&#x20b9;";


                return await Task.Run(() => View("ViewTransactionAsyncMB", objac));
            }
        }

        /// <summary>
        /// here we can deatils transaction details with match voucher
        /// </summary>
        /// <returns></returns>
        private async Task<(List<Accountant>, List<Accountant>)> ListExpenseDetailsAsyncMB()
        {
            Accountant objA = new Accountant();
            List<Accountant> lstitems = new List<Accountant>();
            List<Accountant> lsttransaction = new List<Accountant>();

            objA.TransactionCode = Session["TCode"].ToString();
            DataSet ds = await objbal.ListExpenseVoucherAsyncMB(objA);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Accountant objP = new Accountant();
                    objP.VendorName = (ds.Tables[0].Rows[i]["VendorName"].ToString());
                    objP.ReferenceToName = (ds.Tables[0].Rows[i]["RefToCandidate"].ToString());
                    objP.StudentName = (ds.Tables[0].Rows[i]["RefundCandidate"].ToString());
                    objP.TransactionCode = Session["TCode"].ToString();
                    objP.Amount = int.Parse(ds.Tables[0].Rows[i]["TransactionAmount"].ToString());
                    objP.Balance = int.Parse(ds.Tables[0].Rows[i]["BalanceAmount"].ToString());
                    objP.Description = (ds.Tables[0].Rows[i]["Description"].ToString());
                    objP.TransactionAmount = objP.Amount + objP.Balance;

                    lstitems.Add(objP);
                }
            }

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    Accountant objT = new Accountant();

                    string mode = ds.Tables[1].Rows[i]["PaymentMode"].ToString();
                    objT.Date = Convert.ToDateTime(ds.Tables[1].Rows[i]["Date"]);
                    objT.VoucherCode = ds.Tables[1].Rows[i]["VoucherCode"].ToString();
                    objT.PaymentMode = mode;
                    if (mode == "BANK")
                    {
                        objT.TransactionId = ds.Tables[1].Rows[i]["TransactionId_ChequeNo"].ToString();
                    }
                    else if (mode == "CHEQUE")
                    {
                        objT.TransactionId = ds.Tables[1].Rows[i]["TransactionId_ChequeNo"].ToString();
                        objT.ChequeDate = string.IsNullOrEmpty(ds.Tables[1].Rows[i]["ChequeDate"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[1].Rows[i]["ChequeDate"]);
                        objT.ChequeClearenceDate = string.IsNullOrEmpty(ds.Tables[1].Rows[i]["ChequeClearenceDate"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[1].Rows[i]["ChequeClearenceDate"]);
                    }
                    objT.TransactionAmount = int.Parse(ds.Tables[1].Rows[i]["Amount"].ToString());
                    objT.Balance = int.Parse(ds.Tables[1].Rows[i]["BalanceAmount"].ToString());


                    lsttransaction.Add(objT);
                }
            }
            return (lstitems, lsttransaction);
        }

        #endregion
=======
       
        #endregion 
>>>>>>> 66d0e4c38599ef06cb45f8fd86ad0bce370e359f
    }
}