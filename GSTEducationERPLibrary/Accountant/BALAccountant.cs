using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace GSTEducationERPLibrary.Accountant
{
	public class BALAccountant
	{

        MSSQL DBHelper = new MSSQL();
        Dictionary<string, string> Param = new Dictionary<string, string>();

        public async Task< DataSet> ShowListOfRegularExpenseMB(Accountant obj)
		{
            Dictionary<string, string> Param = new Dictionary<string, string>();

            Param.Add("@Flag", "ShowListOfRegularExpenseMB");
			DataSet ds=await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
			return ds;
			
		}

        public async Task<DataSet> ShowListOfReferenceExpenseMB(Accountant obj)
        {
            Dictionary<string, string> Param = new Dictionary<string, string>();
            Param.Add("@Flag", "ShowListOfReferenceExpenseMB");
            DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
            return ds;

        }

        public async Task<DataSet> ShowListOfRefundExpenseMB(Accountant obj)
        {
            Dictionary<string, string> Param = new Dictionary<string, string>();
            Param.Add("@Flag", "ShowListOfRefundExpenseMB");
            DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
            return ds;

        }

        public async Task<DataSet> GetExpenceCategoryMB()
		{
            Dictionary<string, string> Param = new Dictionary<string, string>();

            Param.Add("@Flag", "GetExpenceCategoryMB");
			DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
			return ds;
		}

        public async Task<DataSet> GetRefundCandidateMB()
        {
            Dictionary<string, string> Param = new Dictionary<string, string>();
            Param.Add("@Flag", "GetRefundCandidateMB");
            DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
            return ds;
        }

        public async Task SavetheExpenceMB(Accountant obj)
        {
            int id=Convert.ToInt32(1);
            int TYd=Convert.ToInt32(68);
            Dictionary<string,string> Param = new Dictionary<string, string>();
            Param.Add("@Flag", "SavetheExpenceMB");
            Param.Add("@TranscationCode", obj.TranscationCode);
            Param.Add("@VendorName", obj.VendorName);
            Param.Add("@TransactionDate", obj.Date.ToString());
            Param.Add("@TransactionAmount", obj.Amount.ToString());
            Param.Add("@ExpenseCategoryId", obj.ExpID);
            Param.Add("@StaffCode", obj.StaffCode);
            Param.Add("@PaymentMode", obj.PaymentMode);
            Param.Add("@TransactionId", obj.TranscationId);
            Param.Add("@ChequeDate", obj.ChequeDate.ToShortDateString());
            Param.Add("@LoggedStaffCode", obj.StaffCode);
            Param.Add("@StatusId","6");
            Param.Add("@Description", obj.Comment);
            Param.Add("@TransactionType","68");
            await DBHelper.ExecuteStoreProcedure("GSTAccountant", Param);

           
        }

        public async Task<SqlDataReader> GetMaxExpenseCodeForAutoIncrement()
        {
            Dictionary<string, string> Param = new Dictionary<string, string>();
            Param.Add("@Flag", "GetMaxExpenseCodeForAutoIncrement");
            SqlDataReader dr;
            dr= await DBHelper.ExecuteStoreProcedureReturnDataReader("GSTAccountant", Param);
            return dr;
        }

        public async Task<SqlDataReader> GetTheExpenceTypeAsyncMB(Accountant obj)
        {
            Dictionary<string,string> Param= new Dictionary<string, string>();
            Param.Add("@Flag", "GetExpenceTypeMB");
            Param.Add("@ExpenseCategoryId",obj.ExpID );
            SqlDataReader dr;
            dr = await DBHelper.ExecuteStoreProcedureReturnDataReader("GSTAccountant", Param);
            return dr;
        }

        public async Task<DataSet> GetReferenceByCandidatesAsyncMB()
        {
            Dictionary<string,string> Param= new Dictionary<string, string>();
            Param.Add("@Flag", "GetReferenceByCandidates");
            DataSet ds =await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);
            
            return ds;
        }

        public async Task<DataSet> GetReferenceToCandidatesAsyncMB(Accountant obj)
        {
            Dictionary<string, string> Param = new Dictionary<string, string>();
            Param.Add("@Flag", "GetReferenceToCandidates");
            Param.Add("@CandidateCode", obj.CandidateCode);
            DataSet ds = await DBHelper.ExecuteStoreProcedureReturnDS("GSTAccountant", Param);

            return ds;
        }







        /// <summary>
        /// Shreyas Function code 
        /// </summary>
        /// <param name="ObjT"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

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
            }
            catch (Exception ex)
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
            }
            catch (Exception ex)
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






    }
}
