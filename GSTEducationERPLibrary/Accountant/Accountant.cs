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

        //-------------------------------
	{
        //------------------SHREYAYAS Voucher Start --------------------------------------------------------------//
        public int VoucherId { get; set; }
        public string VoucherCode { get; set; }
        [DisplayName("Vendor Name")]
        public string VendorName { get; set; }
        public float Amount { get; set; }
        public string AmountPaidTo { get; set; }
        public string Description { get; set; }
        [DisplayName("Payment Mode")]
        public string PaymentMode { get; set; }
        [DisplayName("Bank Name")]
        public int? BankId { get; set; }
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
        //----------------------------------------vishla's properties here-----------------------------------------------------------------------------------
        /// <summary>
        /// vishals properties starts from here 
        /// </summary>
       
        public string BranchCode { get; set; }
       
        /// <summary>
        /// purchased Items for purchased items view
        /// </summary>

        public string PurchaseCode { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }
        public double Discount { get; set; }
        public string HSNCode { get; set; }
        [DisplayName("Appiled Tax")]
        public string AppliedTax { get; set; }
        /// <summary>
        /// properties for the purchase  table here
        /// </summary>

        public string TransactionCode { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TransactionDate { get; set; }
        [DisplayName("Paid amount")]
        public double TransactionAmount { get; set; }
        public double BalanceAmount { get; set; }
        [DisplayName("Bank Name")]
        public string BankName { get; set; }
        public string Status { get; set; }
        [DisplayName("TransactionId")]
        public string TranId_CheqNo { get; set; }
        
        public List<Accountant> lstPurchaseVP = new List<Accountant>();
        public List<Accountant> lstPurchaseItemVP = new List<Accountant>();
        //---------------------------vishals properties ends here-----------------------------------------------------------------------------------------------
    }
}
