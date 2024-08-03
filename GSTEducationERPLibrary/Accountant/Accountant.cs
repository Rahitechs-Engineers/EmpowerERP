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
        [DataType(DataType.Date)]
        [DisplayName("Cheque Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ChequeDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Cheque Clearence Date")]
        public DateTime ChequeClearenceDate { get; set; }
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
        #region
        /// <summary>
        /// vishals properties starts from here 
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// purchased Items for purchased items view
        /// </summary>
        [DisplayName("Bill Number")]
        public string BillNumber { get; set; }
        [DisplayName("Purchase Code")]
        public string PurchaseCode { get; set; }
        public int? ItemId { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }
        public double Discount { get; set; }
        [DisplayName("HSN Code")]
        public string HSNCode { get; set; }
        [DisplayName("Applied Tax")]
        public string AppliedTax { get; set; }
        public string Tax { get; set; }
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
        [DisplayName("Balance Amount")]
        public double BalanceAmount { get; set; }
        [DisplayName("Account Holder Name")]
        public string BankName { get; set; }
        [DisplayName("Bank Type")]
        public string BankType { get; set; }
        public string Status { get; set; }
        [DisplayName("TransactionId")]
        public string TranId_CheqNo { get; set; }

        public List<Accountant> lstPurchaseVP = new List<Accountant>();
        public List<Accountant> lstPurchaseItemVP = new List<Accountant>();
        public List<Accountant> lstTransactionVP = new List<Accountant>();
        #endregion
        //---------------------------vishals properties ends here-----------------------------------------------------------------------------------------------

        //-----------Siddhi's Properties for receipt------------------------------------------------------------//
        #region
        //------------------------Atharv Receipt Start------------------------------------------/
        public string CandidateCode { get; set; }
        public string StaffName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public long AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public double GrossSalary { get; set; }
        public List<Accountant> lstEmp { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }
        public double CourseFee { get; set; }
        public double TotalFees { get; set; }
        public double InstallmentAmount { get; set; }
        public List<Accountant> LstPendindFeeStud { get; set; }
        public List<Accountant> lstArrangeDemo { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public string ChequeNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Cheque Clearance Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? ChequeClearanceDate { get; set; } // Changed to nullable DateTime
        public string Branchcode { get; set; }
        public string ProvisionalReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string EnrollmentNumber { get; set; }
        public string Batch { get; set; }
        public double RemainingFee { get; set; }
        public double NextInstallmentAmount { get; set; }
        public string InstallmentNo { get; set; }
        public string DrawnOn { get; set; }
        public string AdmissionType { get; set; }
        public string Comment { get; set; }
        public string Course { get; set; }
        public int Id { get; set; }
        public int NumberOfPaidInstallments { get; set; }
        public string FeeType { get; set; }
        public string CreditTo { get; set; }
        public int AccountHolderId { get; set; }
        public string StudentName { get; set; }
        public int FeeTypeId { get; set; }
        public string PaymentModeId { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numeric values are allowed.")]
        public string TransactionID_checqueNumber { get; set; }
        public string LoggedStaffCode { get; set; }
        public string AccountHolderName { get; set; }
        public string ReciptCode { get; set; }
        public string ContactNumber { get; set; }
        public double RegistrationFees { get; set; }
        public double TotalPaid { get; set; }
        public double RemainingFees { get; set; }
        public DateTime LastInstallmentDate { get; set; }
        public double NextInstallment { get; set; }
        public DateTime InstallmentDate { get; set; }
        public DateTime NextInstallmentDate { get; set; }
        public double TotalCompletedAmount { get; set; }
        public string ChequeBankName { get; set; }
        #endregion

        #region //Siddhi Property Class ChequeDetails

        #endregion
    }
    public class AccountantProp
    {

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ChequeDateReceipt { get; set; }
        public string VendorName { get; set; }

        //public float Amount { get; set; }
        public string TransactionId { get; set; }
        public string StaffCode { get; set; }
        public int StatusId { get; set; }
        public List<AccountantProp> lstChequeExpense { get; set; }
        public List<AccountantProp> lstChequeReceipt { get; set; }
        public string TransactionCode { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TransactionDate { get; set; }
        public string ChequeNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Cheque Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ChequeDate { get; set; }
        public string Name { get; set; }

        public float Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Cheque Clearance Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Cheque Clearance Date is required.")]
        public DateTime? ChequeClearanceDate { get; set; }
        public string branchcode { get; set; }
        public string ProvisionalReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string Batch { get; set; }
        public string PaymentMode { get; set; }
        //public string TransactionId { get; set; }
        public string DrawnOn { get; set; }
        public string AdmissionType { get; set; }
        public string Course { get; set; }
        public string BankName { get; set; }
        public string Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Cheque Clearance Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NewClearanceDate { get; set; }
        public string Description { get; set; }
        public long AccountNumber { get; set; }
    }
}
