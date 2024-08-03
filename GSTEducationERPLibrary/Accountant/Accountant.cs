using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GSTEducationERPLibrary.Accountant
{
	public class Accountant
	{
        //------------------SHREYAYAS Voucher Start --------------------------------------------------------------//
        public int VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public string VendorName { get; set; }
        public float Amount { get; set; }
        public string AmountPaidTo { get; set; }
        public string Description { get; set; }
        public string PaymentMode { get; set; }
        public int BankId { get; set; }
        public long ReceiverBankAccountNumber { get; set; }
        public string ReceiverBankAccountHolderName { get; set; }
        public string ReceiverBankIFSCCode { get; set; }
        public string ReceiverBankName { get; set; }
        public float Balance { get; set; }
        public string Currency { get; set; }
        public string TransactionId { get; set; }
        public string VoucherType { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Voucher Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime VoucherDate { get; set; }
        public string StaffCode { get; set; }
        public int StatusId { get; set; }
        public List<Accountant> lstVoucher { get; set; }
        public List<Accountant> lstPendingVoucher { get; set; }
        //------------------SHREYAYAS Voucher End --------------------------------------------------------------//

        //---------------------Mukesh Expence Properties---------------------------------------//
        public string ExpID { get; set; }
        public string ExpenseType { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }    
        public string TranscationId { get; set; }
        public string BankName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ChequeDate { get; set; }
        public string Comment { get; set; }
        public string StudentName { get; set; }
        public string PaidFee { get; set; }
        public string ReferenceByName { get; set; }
        public string ReferenceToName { get; set; }
        public string CandidateCode { get; set; }
        public string TranscationChequedate { get; set; }
        public string TransactionCode { get; set; }
        public float TransactionAmount { get; set; }
        public float TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime ChequeClearenceDate { get; set; }
        

        public List<Accountant> lstRegularExpense {  get; set; }
        public List<Accountant> lstExpenseMB {  get; set; }
        public List<Accountant> lstExpenseMB1 {  get; set; }


    }
}
