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
        //------------------SHREYAYAS Voucher Start --------------------------------------------------------------//


        public string ExpID { get; set; }
        public string ExpenseType { get; set; }
       // public string VendorName { get; set; }
        public string Date { get; set; }
       // public string PaymentMode { get; set; }
        public string TranscationId { get; set; }
        public string BankName { get; set; }
        public string ChqueDate { get; set; }
       // public string Amount { get; set; }
        //public string Action { get; set; }

        public List<Accountant> lstRegularExpense {  get; set; }

    }
}
