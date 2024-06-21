using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Helper;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;

namespace GSTEducationERPLibrary.Accountant
{
	public class BALAccountant
	{
        MSSQL DBHelper = new MSSQL();
        Dictionary<string, string> Param = new Dictionary<string, string>();

        public async Task AddVoucherAsyncSGS(Accountant ObjT)
        {
            try
            {
                Param.Add("@flag", "AddVoucher");
                Param.Add("@VoucherCode", ObjT.VoucherCode.ToString());
                Param.Add("@VendorName", ObjT.VendorName.ToString());
                Param.Add("@Amount", ObjT.Amount.ToString());
                Param.Add("@AmountPaidTo", ObjT.AmountPaidTo.ToString());
                Param.Add("@Description", ObjT.Description.ToString());
                Param.Add("@PaymentMode", ObjT.PaymentMode.ToString());
                Param.Add("@StaffCode", ObjT.StaffCode.ToString());
                Param.Add("@BankId", ObjT.BankId.ToString());
                Param.Add("@ReceiverBankAccountNumber", ObjT.ReceiverBankAccountNumber.ToString());
                Param.Add("@ReceiverBankAccountHolderName", ObjT.ReceiverBankAccountHolderName.ToString());
                Param.Add("@ReceiverBankIFSCCode", ObjT.ReceiverBankIFSCCode.ToString());
                Param.Add("@ReceiverBankName", ObjT.ReceiverBankName.ToString());
                Param.Add("@Balance", ObjT.Balance.ToString());
                Param.Add("@Currency", ObjT.Currency.ToString());
                Param.Add("@TransactionId", ObjT.TransactionId.ToString());
                Param.Add("@VoucherType", ObjT.VoucherType.ToString());
                Param.Add("@VoucherDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                Param.Add("@StatusId", 6.ToString());
                await DBHelper.ExecuteStoreProcedure("GSTAccountant", Param);
            } catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the assigned project. Details: " + ex.Message);
            }
        }
        //public async Task<List<Accountant>> GetData(Accountant objU)
        //{
        //    List<Accountant> items = new List<Accountant>();
        //    Param.Clear();
        //    Param.Add("@flag", "ViewUser");

        //    DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
        //    foreach (DataRow sdr in ds.Tables[0].Rows)
        //    {
        //        items.Add(new Accountant
        //        {
        //            VoucherId = Convert.ToInt32(sdr["VoucherId"]),
        //            VoucherCode = sdr["VoucherCode"].ToString(),
        //            VendorName = sdr["VendorName"].ToString(),
        //            Amount = float.Parse(sdr["Amount"].ToString()),
        //            AmountPaidTo = sdr["AmountPaidTo"].ToString(),
        //            Description = sdr["Description"].ToString(),
        //            PaymentMode = sdr["PaymentMode"].ToString(),
        //            BankId = Convert.ToInt32(sdr["BankId"]),
        //            ReceiverBankAccountNumber = Convert.ToInt64(sdr["ReceiverBankAccountNumber"]),
        //            ReceiverBankAccountHolderName = sdr["ReceiverBankAccountHolderName"].ToString(),
        //            ReceiverBankIFSCCode = sdr["ReceiverBankIFSCCode"].ToString(),
        //            ReceiverBankName = sdr["ReceiverBankName"].ToString(),
        //            Balance = float.Parse(sdr["Balance"].ToString()),
        //            Currency = sdr["Currency"].ToString(),
        //            TransactionId = sdr["TransactionId"].ToString(),
        //            VoucherType = sdr["VoucherType"].ToString(),
        //            VoucherDate = DateTime.Parse(sdr["VoucherDate"].ToString()),
        //            StaffCode = sdr["StaffCode"].ToString(),
        //            StatusId = Convert.ToInt32(sdr["StatusId"])
        //        });
        //    }
        //    return items;
        //}
        public async Task<DataSet> GetVoucher(Accountant objT)
        {
            try
            {
                Dictionary<string, string> Param = new Dictionary<string, string>();
                Param.Add("@flag", "GetVoucher");
                DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
                return ds;
            } catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching course names. Details: " + ex.Message);
            }
        }
        public async Task<DataSet> ListVoucherAsyncSGS()
        {
            Dictionary<string, string> Param = new Dictionary<string, string>();
            Param.Add("@Flag", "ListVoucher");
            //Param.Add("@BranchCode", branchCode); // Pass branch code parameter
            //Param.Add("@StaffCode", staffCode); // Pass staff code parameter
            DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
            return ds;
        }
        public async Task<DataSet> ListPendingVoucherAsyncSGS()
        {
            Dictionary<string, string> Param = new Dictionary<string, string>();
            Param.Add("@Flag", "ListPendingVoucher");
            //Param.Add("@BranchCode", branchCode); // Pass branch code parameter
            //Param.Add("@StaffCode", staffCode); // Pass staff code parameter
            DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
            return ds;
        }
        public async Task<DataSet> ListCompletedVoucherAsyncSGS()
        {
            Dictionary<string, string> Param = new Dictionary<string, string>();
            Param.Add("@Flag", "ListCompletedVoucher");
            //Param.Add("@BranchCode", branchCode); // Pass branch code parameter
            //Param.Add("@StaffCode", staffCode); // Pass staff code parameter
            DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
            return ds;
        }
        /// <summary>
        /// making the methode for the incremental purchase codes
        /// </summary>
        /// <param name="PurchaseCode"></param>
        /// <returns>NewPurchaseCode</returns>
        public async Task<string> GetTaskPurchaseCode(Accountant obj)
        {
            Dictionary<String, String> Param = new Dictionary<String, String>();
            Param.Add("@Flag", "GetMaxPurCodeAsncVP");
            //Param.Add("@BranchCode", ObjA.BranchCode);
            SqlDataReader ds = await DBHelper.ExecuteStoreProcedureReturnDataReader("GSTAccountant", Param);
            string LastTransactionCode = "";
            while (ds.Read())
            {
                LastTransactionCode = ds["TransactionCode"].ToString();
            }
            string newPurchaseCode = IncrementPurchaseCode(LastTransactionCode);
            return newPurchaseCode;
        }
        public static string IncrementPurchaseCode(string lastPurchaseCode)
        {
            // Define a regular expression to extract the numeric part
            Regex regex = new Regex(@"(\D+)(\d+)");
            Match match = regex.Match(lastPurchaseCode);

            if (match.Success)
            {
                string prefix = match.Groups[1].Value; // The non-numeric prefix (e.g., "PUR")
                string numberPart = match.Groups[2].Value; // The numeric part (e.g., "017")

                // Parse the numeric part to an integer
                int number = int.Parse(numberPart);

                // Increment the number
                number++;

                // Determine the length of the original numeric part to maintain leading zeros
                int lengthOfNumberPart = numberPart.Length;

                // Format the new number with leading zeros
                string newNumberPart = number.ToString().PadLeft(lengthOfNumberPart, '0');

                // Reassemble the new purchase code
                string newPurchaseCode = prefix + newNumberPart;

                return newPurchaseCode;
            }
            else
            {
                throw new ArgumentException("Invalid purchase code format.");
            }
        }
        /// <summary>
        /// fetching the all the purchase details here for purchase dashboard
        /// </summary>
        /// <param name="ObjA"></param>
        /// <returns></returns>
        public async Task<DataSet> ListPurchasesAsyncVP(Accountant ObjA)
        {
            Dictionary<String, String> Param = new Dictionary<String, String>();
            Param.Add("@Flag", "ListPurchasesAsyncVP");
            Param.Add("@BranchCode", ObjA.BranchCode);
            DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
            return ds;
        }
        /// <summary>
        /// fetching the all items for purchase here for purchase dashboard
        /// </summary>
        /// <param name="ObjA"></param>
        /// <returns></returns>
        public async Task<DataSet> ListPurchasedItemsAsyncVP(Accountant ObjA)
        {
            Dictionary<String, String> Param = new Dictionary<String, String>();
            Param.Add("@Flag", "ListPurchasesAsyncVP");
            Param.Add("@BranchCode", ObjA.BranchCode);
            DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
            return ds;
        }
        /// <summary>
        /// fetching the banks for add purchase pages and purchase module
        /// </summary>
        /// <param name="ObjA"></param>
        /// <returns></returns>
        public async Task<DataSet> ListBankAsyncVP(Accountant ObjA)
        {
            Dictionary<String, String> Param = new Dictionary<String, String>();
            Param.Add("@Flag", "ListBanksAsyncVP");
            //Param.Add("@BranchCode", ObjA.BranchCode);
            DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
            return ds;
        }
        /// <summary>
        /// fetching the status (66-setteled,6-pending) for add purchase pages and purchase module
        /// </summary>
        /// <param name=""></param>
        /// <returns>status settled- 66 and pending-6</returns>
        public async Task<DataSet> ListStatusAsyncVP()
        {
            Dictionary<String, String> Param = new Dictionary<String, String>();
            Param.Add("@Flag", "ListStatusForPurchaseAsyncVP");
            //Param.Add("@BranchCode", ObjA.BranchCode);
            DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
            return ds;
        }
        /// <summary>
        /// Saving the add purchase details to database into the tbltransaction  
        /// </summary>
        /// <param name="ObjA"></param>
        /// <returns>@,@,@,
        /// @,@,@,@,@,
        /// @,@,@,@</returns>
        public async Task SaveAddPurchaseAsyncVP(Accountant ObjA)
        {
            Dictionary<String, String> Param = new Dictionary<String, String>();
            Param.Add("@Flag", "SavePurchaseAsyncVP");
            Param.Add("@TransactionCode", ObjA.TransactionCode);
            Param.Add("@VendorName", ObjA.VendorName);
            Param.Add("@TransactionDate", ObjA.TransactionDate.ToString("yyyy-MM-dd"));
            Param.Add("@TransactionAmount", ObjA.TransactionAmount.ToString());
            Param.Add("@BalanceAmount", ObjA.BalanceAmount.ToString());
            Param.Add("@PaymentMode", ObjA.PaymentMode);
            Param.Add("@TranId_CheqNo", ObjA.TranId_CheqNo);
            Param.Add("@BankId", ObjA.BankId.ToString());//our bank from which the amount debited
            Param.Add("@LogInStaffCode", ObjA.StaffCode);
            Param.Add("@StatusId", ObjA.StatusId.ToString());//completed-66 or pending-6
            Param.Add("@Description", ObjA.Description);
            Param.Add("@TransactionType", "68");//68 is the status for debit from account
            await DBHelper.ExecuteStoreProcedure("GSTAccountant", Param);

        }
        /// <summary>
        /// Saving the purchased items details to database into the tblPurchasedItem  
        /// </summary>
        /// <param name="ListPurchasedItem"></param>
        /// <returns>@,@,@,@,@,@,@</returns>
        public async Task SaveAddPurchasedItemsAsyncVP(Accountant ObjA)
        {
            Dictionary<String, String> Param = new Dictionary<String, String>();
            Param.Add("@Flag", "SaveItmsAsyncVP");
            Param.Add("@TransactionCode", ObjA.TransactionCode);
            Param.Add("@ItemName", ObjA.ItemName);
            Param.Add("@Quantity", ObjA.Quantity.ToString());
            Param.Add("@UnitPrice", ObjA.UnitPrice.ToString());
            Param.Add("@Discount", ObjA.Discount.ToString());
            Param.Add("@HSNCode", ObjA.HSNCode);
            Param.Add("@AppliedTax", ObjA.AppliedTax);
            await DBHelper.ExecuteStoreProcedure("GSTAccountant", Param);

        }

    }
}
