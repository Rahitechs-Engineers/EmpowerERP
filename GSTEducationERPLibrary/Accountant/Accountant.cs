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







        //------------------SOMNATH HAMBIRE FEES LIST Start --------------------------------------------------------------//



        public string StudetCode { get; set; }
        public string StudentName { get; set; }
        public long Contact { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public string Batch { get; set; }
        public double CourseFee { get; set; }
        public int Discount { get; set; }

        public double RegistrationFee { get; set; }
        public double TotalFees { get; set; }
        public double PaidFees { get; set; }
        public double RemainingFees { get; set; }
        public double InstallmentAmount { get; set; }
        public string LastInstallmentDate { get; set; }
        public string NextInstallmentDate { get; set; }
        public string Status { get; set; }
        public double OneMonthCTC { get; set; }
        public double PayableAmmount { get; set; }

        public List<Accountant> StudentFees { get; set; }





    }
}
