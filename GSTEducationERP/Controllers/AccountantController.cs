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
       
        #endregion 
    }
}