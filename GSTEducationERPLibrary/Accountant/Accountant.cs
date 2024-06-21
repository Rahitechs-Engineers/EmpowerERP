using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        //--------------------------Siddhi Cheque Details Start--------------------------------------------------------//
        public List<Accountant> lstChequeExpense { get; set; }
        public List<Accountant> lstChequeReceipt { get; set; }
        public string TransactionCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ChequeNumber { get; set; }
        public DateTime ChequeDate { get; set; }
        public string Name { get; set; }
        //public long Amount { get; set; }
        public DateTime ChequeClearanceDate { get; set; }
        public string branchcode { get; set; }
        public string ProvisionalReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string EnrollmentNumber { get; set; }
        public string Batch { get; set; }
        //public string PaymentMode { get; set; }
        //public string TransactionId { get; set; }
        public decimal Discount { get; set; }
        public decimal RemainingFee { get; set; }
        public DateTime NextInstallmentDate { get; set; }
        public decimal NextInstallmentAmount { get; set; }
        public string InstallmentNo { get; set; }
        public string DrawnOn { get; set; }
        public string AdmissionType { get; set; }
        public string Comment { get; set; }
        public string Course { get; set; }
        public string BankName { get; set; }
        public int Id { get; set; }

        //--------------------------Siddhi Cheque Details End--------------------------------------------------------//

    }
}
