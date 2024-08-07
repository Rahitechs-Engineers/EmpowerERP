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
        #region//Jay
        //----------------Jayash-  Accountant -----------------------------------start //
        public List<Accountant> LstAttendence { get; set; }

<<<<<<< HEAD
        #region//Mukesh Expense Modal Start Here
        //---------------------Mukesh Expence Properties---------------------------------------//
        public string ExpID { get; set; }
        public string ExpenseType { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string TranscationId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Comment { get; set; }
        public string StudentName { get; set; }
        public string PaidFee { get; set; }
        public string ReferenceByName { get; set; }
        public string ReferenceToName { get; set; }
        public string CandidateCode { get; set; }
        public string TranscationChequedate { get; set; }
        public float TotalAmount { get; set; }
        public string LoginStaffCode { get; set; }
        public string StaffCode_CandidateCode { get; set; }


        public List<Accountant> lstRegularExpense { get; set; }
        public List<Accountant> lstExpenseMB { get; set; }
        public List<Accountant> ListGiveExpenseMB { get; set; }
        public List<Accountant> ListMatchVoucheToExpense { get; set; }

        public List<Accountant> lstExpenseMB1 { get; set; }

=======
        public string ProvisionalReceiptNo { get; set; }
        public string addressPart1 { get; set; }
        public string addressPart2 { get; set; }
        public string addressPart3 { get; set; }
        public string ClientLogo { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        //public long Amount { get; set; }
        //public DateTime ChequeDate { get; set; }
        public DateTime ProvisionalReceiptDate { get; set; }
        public string EnrollmentNumber { get; set; }
        public string Batch { get; set; }
        //public string PaymentMode { get; set; }
        //public string TransactionId { get; set; }
        //public decimal Discount { get; set; }
        public decimal RemainingFee { get; set; }
        public DateTime NextInstallmentDate { get; set; }
        public decimal NextInstallmentAmount { get; set; }
        public string InstallmentNo { get; set; }
        public string DrawnOn { get; set; }
        public string AdmissionType { get; set; }
        public string Comment { get; set; }
        public int Id { get; set; }
        public string Logo { get; set; }
        public string InwordsAmmount { get; set; }
        public long Chequenumber { get; set; }
        public DateTime ChequeClearanceDate { get; set; }
        public decimal TotalFee { get; set; }
        public string Address { get; set; }
        public string Signature { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public String Remark { get; set; }
        public string Hrs { get; set; }
    
        public DateTime Date { get; set; }

        public String Workeddays { get; set; }
        public String HalfDays { get; set; }
        public String PresentDays { get; set; }
        public String PayableDays { get; set; }
        public string StaffName { get; set; }
        public int CurrentInstallment { get; set; }

        //----------------Jayash-  Accountant -----------------------------------End //
>>>>>>> 0cf263b568412b961a747309b73861cf33eba645
        #endregion
    }
}
