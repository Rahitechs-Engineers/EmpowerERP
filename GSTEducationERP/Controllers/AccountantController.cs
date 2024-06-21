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
        //------------------------------------Vishal's Purchase Modules strts here------------------------------------------------------------
        [HttpGet]
        public ActionResult AccountantDashboardAsyncVP()
        {
            List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
             {
                new BreadcrumbItem { Name = "Dashboard", Url = "AccountantDashboardAsyncVP" },
                //new BreadcrumbItem { Name = "Purchase", Url = "DetailsPurchaseItemsAsyncVP" },
             };
            ViewBag.Breadcrumbs = breadcrumbs;
            return View("AccountantDashboardAsyncVP");
        }
        [HttpGet]
        public async Task<ActionResult> DetailsPurchaseItemsAsyncVP()
        {
            if (Session["StaffCode"] == null)
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
            else
            {
                try
                {
                    objac.BranchCode = Session["BranchCode"].ToString();
                    objac.StaffCode = Session["StaffCode"].ToString();
                    //ViewBag.Induastry = await objBalaccountant.GetInduastryPB();
                    ViewBag.Purchase = await objbal.ListPurchasesAsyncVP(objac);
                    List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
            {
            new BreadcrumbItem { Name = "Dashboard", Url = "AccountantDashboardAsyncVP" },
            new BreadcrumbItem { Name = "Purchase", Url = "DetailsPurchaseItemsAsyncVP" },
            };
                    ViewBag.Breadcrumbs = breadcrumbs;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                return await Task.Run(() => View("DetailsPurchaseItemsAsyncVP"));

            }
        }
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

            new BreadcrumbItem { Name = "Dashboard", Url =Url.Action("AccountantDashboardAsyncVP", "Accountant")  },
            new BreadcrumbItem { Name = "Purchase", Url = Url.Action("DetailsPurchaseItemsAsyncVP","Accountant") },
            new BreadcrumbItem { Name = "Add Purchase", Url = Url.Action("AddPurchaseAsyncVP", "Accountant") },
                };
                    ViewBag.Breadcrumbs = breadcrumbs;
                    //getting the last purchase code and making increment to it and inserting it to database
                    objac.TransactionCode = await GetPurchaseCoedAsyncVP(objac);
                    //fetching the banks here for the add purchase 
                    ViewBag.BankId = await ListBankAsyncVP(objac);
                    //fetching the status here i don't know why
                    ViewBag.StatusId = await ListStatusAsyncVP();
                    //setting the date by default todays
                    objac.TransactionDate = DateTime.Now;
                    return await Task.Run(() => PartialView("AddPurchaseAsyncVP", objac));
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error occurred while processing the request." + ex;
                    return View("Error");
                }
            }
        }
        /*
         * Param.Add("@TransactionCode", ObjA.TransactionCode);
            Param.Add("@VendorName", ObjA.VendorName);
            Param.Add("@TransactionDate", ObjA.TransactionDate.ToString("d"));
            Param.Add("@TransactionAmount", ObjA.TransactionDate.ToString());
            Param.Add("@BalanceAmount", ObjA.BalanceAmount.ToString());
            Param.Add("@PaymentMode", ObjA.PaymentMode);
            Param.Add("@TranId_CheqNo", ObjA.TranId_CheqNo);
            Param.Add("@BankId", ObjA.TransactionDate.ToString());//our bank from which the amount debited
            Param.Add("@LogInStaffCode", ObjA.StaffCode);
            Param.Add("@StatusId", ObjA.StatusId.ToString());//completed-66 or pending-6
            Param.Add("@Description", ObjA.Description);
         */
        [HttpPost]
        public async Task<ActionResult> AddPurchaseAsyncVP(Accountant objac)
        {
            //saving the details to database about the purchase
            try
            {
                objac.StaffCode = Session["StaffCode"].ToString();
                await objbal.SaveAddPurchaseAsyncVP(objac);
            }
            catch (Exception ex)
            {

            }

            return await Task.Run(() => RedirectToAction("DetailsPurchaseItemsAsyncVP"));
        }
        [HttpPost]
        public async Task<ActionResult> AddPurchaseItemAsyncVP(List<Accountant> PurchaseItemsAsyncVP)
        {
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
                await objbal.SaveAddPurchasedItemsAsyncVP(objpi);
            }
            return await Task.Run(() => RedirectToAction("DetailsPurchaseItemsAsyncVP"));
        }
        [HttpGet]
        public async Task<ActionResult> ViewPurchaseAsyncVP()
        {
            return await Task.Run(() => PartialView("ViewPurchaseAsyncVP"));
        }
        [HttpGet]
        public async Task<ActionResult> UpdatePurchaseAsyncVP(string TransactionCode)
        {
            return await Task.Run(() => PartialView("AddPurchaseAsyncVP", objac));
        }
        /// <summary>
        /// fetching the banks here any bropdown in purchase i need
        /// </summary>
        /// <param name="Bank"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<SelectListItem>> ListBankAsyncVP(Accountant obj)
        {
            obj.BranchCode = Session["BranchCode"].ToString();
            //fetching the banks here for the add purchase 
            DataSet ds = await objbal.ListBankAsyncVP(obj);
            List<SelectListItem> BankList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BankList.Add(new SelectListItem { Text = dr["BankName"].ToString(), Value = dr["BankId"].ToString() });
            }
            return BankList;
        }
        /// <summary>
        /// fetching the last purchase code and making the increment by 1 and sending it to add purchase form
        /// </summary>
        /// <param name="PurchaseCode"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> GetPurchaseCoedAsyncVP(Accountant obj)
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
        public async Task<List<SelectListItem>> ListStatusAsyncVP()
        {
            //obj.BranchCode = Session["BranchCode"].ToString();
            //fetching the banks here for the add purchase 
            DataSet ds = await objbal.ListStatusAsyncVP();
            List<SelectListItem> BankList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BankList.Add(new SelectListItem { Text = dr["Status"].ToString(), Value = dr["StatusId"].ToString() });
            }
            return BankList;
        }
        //------------------------------------Vishal's Purchase Modules ends here------------------------------------------------------------
    }
}