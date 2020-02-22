using System;
using System.Reflection;

namespace Micro.Commons
{
    public static class MicroEnums
    {


        #region Methods & Implementation
        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
        #endregion

        #region CommonKeyNames

        public enum AnalasisFlag
        {
            [StringValue("ACADEMIC")]
            A,

            [StringValue("FINANCIAL")]
            F,

            [StringValue("CALENDAR")]
            C

        }
        public enum EstablishmentType
        {

            [StringValue("A")]
            All = 0,
            [StringValue("N")]
            Notice=1,
            [StringValue("T")]
            Tender = 2,
            [StringValue("C")]
            Circular = 3,     
             [StringValue("R")]
            RecentActivities = 4,
            [StringValue("P")]
            Publication = 5,
            [StringValue("S")]
            Syllabus = 6,
            [StringValue("Y")]
            PhotoGallery= 7,
           
        }

        public enum CommonKeyNames
        {
            [StringValue("Employee Type1")]
            EmployeeType1,

            [StringValue("Employee Type2")]
            EmployeeType2,

            [StringValue("Employee Type3")]
            EmployeeType3,

            [StringValue("Employee Type4")]
            EmployeeType4,

            [StringValue("Salutation")]
            Salutation,

            [StringValue("AnalasisFlag")]
            AnalasisFlag,

            [StringValue("Payment Mode")]
            PaymentMode,

            [StringValue("Policy Mode (Regular)")]
            PolicyModeRegular,

            [StringValue("Policy Mode (Fixed)")]
            PolicyModeFixed,

            [StringValue("Gender")]
            Gender,

            [StringValue("Marital Status")]
            MaritalStatus,

            [StringValue("Relationship")]
            Relationship,

            [StringValue("Occupation")]
            Occupation,

            [StringValue("Policy Type")]
            PolicyType,

            [StringValue("Policy Sub Type")]
            PolicySubType,

            [StringValue("Policy From Organisation")]
            PolicyFromOrganisation,

            [StringValue("Customer Profile Policy")]
            CustomerProfilePolicy,

            [StringValue("Customer Profile Loan")]
            CustomerProfileLoan,

            [StringValue("Customer KYC")]
            CustomerKYC,

            [StringValue("Nationality")]
            Nationality,

            [StringValue("Religion")]
            Religion,

            [StringValue("Caste")]
            Caste,

            [StringValue("Qualification")]
            Qualification,

            [StringValue("Installment Type (Loan)")]
            InstallmentTypeLoan,

            [StringValue("Employee Profile")]
            EmployeeProfile,

            [StringValue("Business Type")]
            BusinessType,

            [StringValue("Attendance Type")]
            AttendanceType,

            [StringValue("Brokerage Fee Type")]
            BrokerageFeeType,

            [StringValue("Guarantor Loan Applicant Type")]
            GuarantorLoanApplicantType,

            [StringValue("Approval Status")]
            ApprovalStatus,

            [StringValue("Field Force Profile")]
            FieldForceProfile,

            [StringValue("Field Force Status")]
            FieldForceStatus,

            [StringValue("Setting Data Type")]
            SettingDataType,

            [StringValue("MIS Payment Mode")]
            MISPaymentMode,

            [StringValue("Scroll Status")]
            ScrollStatus,

            [StringValue("Passbook Print Page")]
            PassbookPrintPage,

            [StringValue("Payment Status")]
            PaymentStatus,

            [StringValue("User Type")]
            UserType,

            [StringValue("Passbook Type")]
            PassbookType,

            [StringValue("Voucher Type")]
            VoucherType,

            [StringValue("Voucher Entry Type")]
            VoucherEntryType,

            [StringValue("Field Force Promotion Status")]
            FieldForcePromotionStatus,

            [StringValue("Password Type")]
            PasswordType,

            [StringValue("Customer Profile Prematurity")]
            CustomerProfilePrematurity,

            [StringValue("Account Access Type")]
            AccountAccessType,

            [StringValue("Account Analysis Flag")]
            AccountAnalysisFlag,

            [StringValue("Account Head Type")]
            AccountHeadType,

            [StringValue("Blood Group")]
            BloodGroup,

            [StringValue("Service Type")]
            ServiceType,

            [StringValue("Service Status")]
            ServiceStatus,

            [StringValue("Item Type")]
            ItemType,

            [StringValue("Unit Of Measurement")]
            UnitOfMeasurement,

            [StringValue("Booking Status")]
            BookingStatus,
        }

        public enum EmployeeType1
        {
            [StringValue("GIA")]
            GIA,

            [StringValue("BlockGrant")]
            BlockGrant,

            [StringValue("Management")]
            Management
        }

        public enum EmployeeType2
        {
            [StringValue("Regular")]
            Regular,

            [StringValue("Adhoc")]
            Adhoc,

            [StringValue("PartTime")]
            PartTime
        }

        public enum EmployeeType3
        {
            [StringValue("UGC")]
            UGC,

            [StringValue("State")]
            State


        }

        public enum EmployeeType4
        {
            [StringValue("NonPlan")]
            NonPlan,

            [StringValue("Plan")]
            Plan,

            [StringValue("PlanConverted")]
            PlanConverted,

            [StringValue("Other")]
            Other

        }
        

        public enum BloodGroup
        {
            [StringValue("A+")]
            APositive,
            [StringValue("A-")]
            ANegative,
            [StringValue("AB+")]
            ABPositive,
            [StringValue("AB-")]
            ABNegative,
            [StringValue("B+")]
            BPositive,
            [StringValue("B-")]
            BNegative,
            [StringValue("O+")]
            OPositive,
            [StringValue("O-")]
            ONegative,
        }

		public enum ServiceType
		{
			[StringValue("PERMANENT")]
			PERMANENT,

			[StringValue("CONTRACTUAL")]
			CONTRACTUAL
		}

		public enum ServiceStatus
		{
			[StringValue("Active")]
			Active,

			[StringValue("Deactive")]
			Deactive
		}

        public enum AccountAccessType
        {
            [StringValue("Auto")]
            Auto,

            [StringValue("Manual")]
            Manual
        }

        public enum AnalysisFlagPayment
        {
            [StringValue("Expenses")]
            Expenses,

            [StringValue("Payment")]
            Payment
        }

        public enum AnalysisFlagReceipt
        {
            [StringValue("Income")]
            Income,

            [StringValue("Receipt")]
            Receipt
        }

        public enum AccountAnalysisFlag
        {
            [StringValue("Expenses")]
            Expenses,

            [StringValue("Income")]
            Income,

            [StringValue("Payment")]
            Payment,

            [StringValue("Receipt")]
            Receipt
        }

        public enum AccountHeadType
        {
            [StringValue("Receipt")]
            Receipt,

            [StringValue("Payment")]
            Payment
        }

        public enum CustomerProfilePrematurity
        {

            [StringValue("Death Certificate")]
            DeathCertificate
        }

        public enum FieldForcePromotionStatus
        {
            [StringValue("Provisional")]
            Provisional,

            [StringValue("Promoted")]
            Promoted,

            [StringValue("Rejected")]
            Rejected,
        }

        public enum PaymentStatus
        {
            [StringValue("Due")]
            Due,

            [StringValue("Paid")]
            Paid
        }

        public enum PassbookPrintPage
        {
            [StringValue("Cover Page")]
            CoverPage,

            [StringValue("First Page")]
            FirstPage,

            [StringValue("Installment Page")]
            InstallmentPage
        }

        public enum ScrollStatus
        {
            [StringValue("Due")]
            Due,

            [StringValue("Owe")]
            Owe,

            [StringValue("Paid")]
            Paid
        }

        public enum MISPaymentMode
        {
            [StringValue("Account")]
            Account,

            [StringValue("Cash")]
            Cash,
        }

        public enum PolicyType
        {
            [StringValue("MIS")]
            MIS,

            [StringValue("One Time")]
            OneTime,

            [StringValue("Recurring Deposit")]
            RecurringDeposit
        }

        public enum SettingDataType
        {
            [StringValue("Decimal")]
            Decimal,

            [StringValue("Percentage")]
            Percentage
        }

        public enum FieldForceProfile
        {
            [StringValue("PAN")]
            PAN,

            [StringValue("Photo")]
            Photo,

            [StringValue("Signature")]
            Signature,

            [StringValue("Thumb Impression")]
            ThumbImpression
        }

        public enum GuarantorLoanApplicantType
        {
            [StringValue("Employee")]
            Employee,

            [StringValue("Field Staff")]
            FieldStaff
        }

        public enum ApprovalStatus
        {
            [StringValue("Approved")]
            Approved,

            [StringValue("Pending")]
            Pending,

            [StringValue("Rejected")]
            Rejected
        }

        public enum Salutations
        {
            [StringValue("Mr.")]
            Mr,

            [StringValue("Mrs.")]
            Mrs,

            [StringValue("Miss")]
            Miss,

            [StringValue("Dr.")]
            Dr
        }

        public enum Qualifications
        {
            [StringValue("UnderMatric")]
            UnderMatric,

            [StringValue("Matriculate")]
            Matriculate,

            [StringValue("Intermediate")]
            Intermediate,

            [StringValue("Graduate")]
            Graduate,

            [StringValue("PostGraduate")]
            PostGraduate,

            [StringValue("Others")]
            Others
        }

        public enum Gender
        {
            [StringValue("Male")]
            Male,

            [StringValue("Female")]
            Female
        }

        public enum PaymentMode
        {
            [StringValue("Cash")]
            Cash,

            [StringValue("Cheque")]
            Cheque,

            [StringValue("Demand Draft")]
            DemandDraft,
        }

        public enum MaritalStatus
        {
            [StringValue("Married")]
            Married,

            [StringValue("Unmarried")]
            Unmarried
        }

        /// <summary>
        /// CSR stands as C-CustomerAccountID, S-ScrollID, R-ReceiptID. This is used for pRPT_Receipts_SelectByCSRID
        /// </summary>
        public enum CSRIDType
        {
            [StringValue("CustomerAccountID")]
            CustomerAccountID,

            [StringValue("ScrollID")]
            ScrollID,

            [StringValue("ReceiptID")]
            ReceiptID
        }

        public enum CustomerProfileType
        {
            [StringValue("Customer Profile Policy")]
            CustomerProfilePolicy,

            [StringValue("Customer KYC")]
            CustomerKYC,
        }

        public enum CustomerProfilePolicy
        {
            [StringValue("Photo")]
            Photo,

            [StringValue("Signature")]
            Signature,

            [StringValue("Thumb Impression")]
            ThumbImpression
        }

        public enum PolicyMode
        {
            [StringValue("Mly")]
            Mly,
            [StringValue("Qly")]
            Qly,
            [StringValue("Hly")]
            Hly,
            [StringValue("Yly")]
            Yly,
            [StringValue("One Time")]
            OneTime
        }

        public enum AttendanceType
        {
            [StringValue("In")]
            In = 1,

            [StringValue("Out")]
            Out = 2,
        }

        public enum PolicyModeConversionType
        {
            /// <summary>
            /// If Policy Mode is "QLY" then it returns 4 installments
            /// </summary>
            [StringValue("How Many Installments In a Year")]
            Installments,

            /// <summary>
            /// If Policy Mode is "QLY" then it returns 3 intervals
            /// </summary>
            [StringValue("Interval between Two Installments in months")]
            Intervals,
        }

        public enum UserType
        {
            [StringValue("Employee")]
            Employee,

            [StringValue("FieldForce")]
            FieldForce,

            [StringValue("Guest")]
            Guest
        }

        public enum PassbookType
        {
            [StringValue("Customer Loan")]
            CustomerLoan,

            [StringValue("MIS Payment")]
            MISPayment,

            [StringValue("Recurring Deposit")]
            RecurringDeposit
        }

        public enum VoucherType
        {
            [StringValue("Contra Voucher")]
            ContraVoucher,

            [StringValue("Credit Voucher")]
            CreditVoucher,

            [StringValue("Debit Voucher")]
            DebitVoucher,

            [StringValue("Journal Voucher")]
            JournalVoucher
        }

        public enum VoucherEntryType
        {
            [StringValue("Credit")]
            CreditSide,

            [StringValue("Debit")]
            DebitSide
        }
        #endregion

        #region SettingKeys
		public enum UserSettingKey
		{
			
			[StringValue("USER_DEFAULT_MODE")]
			USER_DEFAULT_MODE,

			[StringValue("USER_DEFAULT_PAGE")]
			USER_DEFAULT_PAGE,

			[StringValue("USER_MENU_STYLE")]
			USER_MENU_STYLE
		}
		
		public enum SettingKeys
        {
            [StringValue("Administration Fees")]
            AdministrationFees,

            [StringValue("Late Fee")]
            LateFee,

            [StringValue("Rate Of Interest (Demand Loan)")]
            RateofInterestDemandLoan,

            [StringValue("Rate Of Interest (Demand Loan - Short Term)")]
            RateofInterestDemandLoanShortTerm,

            [StringValue("Rate Of Interest (Guarantor Loan)")]
            RateofInterestGuarantorLoan,

            [StringValue("Rate Of Interest (Gold Loan)")]
            RateofInterestGoldLoan,

            [StringValue("Application Fees (Demand Loan)")]
            ApplicationFeesDemandLoan,

            [StringValue("Application Fees (Guarantor Loan)")]
            ApplicationFeesGuarantorLoan,

            [StringValue("Duplicate Passbook Fee")]
            DuplicatePassbookFee,

            [StringValue("Field Force ID Card Fee (New)")]
            FieldForceIDCardFeeNew,

            [StringValue("Field Force ID Card Fee (Duplicate)")]
            FieldForceIDCardFeeDuplicate,

            [StringValue("Grace Period (Late Fee)")]
            GracePeriodLateFee,

            [StringValue("Grace Period (Last Payment)")]
            GracePeriodLastPayment
        }
        #endregion

        #region Reports
        public enum CRMReports
        {
            [StringValue("CollectionStatement")]
            CollectionStatement,

            [StringValue("CollectionStatement-Summary")]
            CollectionStatementSummary,

            [StringValue("CustomerAccountMaturityForm")]
            CustomerAccountMaturityForm,

            [StringValue("CustomerAccount_Passbook-Print")]
            CustomerAccountPassbook,

            [StringValue("CustomerAccount_Receipt")]
            CustomerAccountReceipt,

            [StringValue("Customers_Account-List")]
            Customers_AccountList,

            [StringValue("CustomerAccount_Account-Ledger")]
            CustomerAccountAccountLedger,

            [StringValue("CustomerAccount_MIS-Payment-Statement")]
            CustomerAccountMISPaymentStatement,

            [StringValue("CustomerAccount_ReVival")]
            CustomerAccountRevival,

            [StringValue("CustomerAccount_Selling")]
            CustomerAccountSelling,

            [StringValue("CustomerLoan_Application-Form")]
            CustomerLoanApplicationForm,

            [StringValue("CustomerLoan_AccountLedger")]
            CustomerLoanAccountLedger,

            [StringValue("CustomerLoan_Payment-Statement")]
            CustomerLoanPaymentStatement,

            [StringValue("Customers_Profile")]
            CustomersProfile,

            [StringValue("Customers_List-All")]
            Customers_ListAll,

            [StringValue("Customers_List-Single")]
            CustomersListSingle,

            [StringValue("Customers_Details")]
            CustomersDetails,

            [StringValue("CustomerLoan_Recovery-Statement")]
            CustomerLoanRecoveryStatement,

            [StringValue("FieldForces_List-All")]
            FieldForcesListAll,

            [StringValue("FieldForces_Business-Report-New")]
            FieldForcesBusinessReportNew,

            [StringValue("FieldForces_Business-Report-New-TermWise")]
            FieldForcesBusinessReportNew_TermWise,

            [StringValue("FieldForces-Commission-Payable-Statement")]
            FieldForcesCommissionPayableStatement,

            [StringValue("FieldForces-Commission-Payable-Statement_Account-Wise")]
            FieldForcesCommissionPayableStatement_AccountWise,

            [StringValue("FieldForces-Commission-UnPaid-Statement")]
            FieldForcesCommissionUnPaidStatement,

            [StringValue("GuarantorLoan_Account-Ledger")]
            GuarantorLoanAccountLedger,

            [StringValue("GuarantorLoan_Applications")]
            GuarantorLoanApplications,

            [StringValue("GuarantorLoan_EMI-Chart")]
            GuarantorLoanEMIChart,

            [StringValue("GuarantorLoan_Applications-Approval-Statuswise")]
            GuarantorLoanApplicationsApprovalStatuswise,

            [StringValue("GuarantorLoan_Applications-Approval-Authoritywise")]
            GuarantorLoanApplicationsApprovalAuthoritywise,

            [StringValue("GuarantorLoan_Applications-Approved")]
            GuarantorLoanApplicationsApproved,

            [StringValue("GuarantorLoan_Applications-Pending")]
            GuarantorLoanApplicationsPending,

            [StringValue("GuarantorLoan_Applications-Rejected")]
            GuarantorLoanApplicationsRejected,

            [StringValue("GuarantorLoan_Applications-Rejection-Authoritywise")]
            GuarantorLoanApplicationsRejectionAuthoritywise,

            [StringValue("GuarantorLoan_Applications-Statuswise")]
            GuarantorLoanApplicationsStatuswise,

            [StringValue("GuarantorLoan_Recovery-Statement")]
            GuarantorLoanRecoveryStatement,

            [StringValue("GuarantorLoan_Payment-Statement")]
            GuarantorLoanPaymentStatement,

            [StringValue("GuarantorLoan_Receipt")]
            GuarantorLoanReceipt,

            [StringValue("CustomerAccount_Maturity-Payment-Statement")]
            CustomerAccountMaturityPaymentStatement,

            [StringValue("CustomerAccount_MIS-Payment-Voucher")]
            CustomerAccountMISPaymentVoucher,

            [StringValue("CustomerAccount_Pre-Maturity-Payment-Statement")]
            CustomerAccountPreMaturityPaymentStatement,

            [StringValue("CustomerAccount_Projected-Maturity-Statement")]
            CustomerAccountProjectedMaturityStatement,

            [StringValue("CustomerAccount_Projected-Maturity-Statement-FieldForceWise")]
            CustomerAccountProjectedMaturityStatementFieldForceWise,

            [StringValue("CustomerAccount_CRMScroll-Statuswise")]
            CustomerAccountCRMScrollStatuswise,

            [StringValue("CustomerAccount_Maturity-Payment-Form")]
            CustomerAccountMaturityPaymentForm,

            [StringValue("FieldForces-Promotions-Statuswise")]
            FieldForcesPromotionsStatuswise,

            [StringValue("FieldForces-Promotions-Authoritywise")]
            FieldForcesPromotionsAuthoritywise,

            [StringValue("Cashbook")]
            CashBook,

			[StringValue("CashStatement-Summary-Monthly")]
			CashReportSummaryMonthly,

			[StringValue("CashStatement-Summary-BetweenDates")]
			CashReportSummaryBetweenDates,

			[StringValue("CashStatement-Details-BetweenDates")]
			CashReportDetailsBetweenDates,

			[StringValue("StatementOfReceivedItems")]
			StatementOfReceivedItems,

			[StringValue("StatementOfIssueItems")]
            StatementOfIssueItems,

			[StringValue("ItemLedger")]
			ItemLedger,
        }

        public enum CRMReportsParameterFieldTitle
        {
            [StringValue("Customer List")]
            CustomerList,

            [StringValue("Customer Account List")]
            CustomerAccountList,

            [StringValue("Customer Profile List")]
            CustomerProfile,

            [StringValue("Customer Details List")]
            CustomerDetails,

            [StringValue("Collection Statement New")]
            CollectionStatementNew,

            [StringValue("Collection Statement Renew")]
            CollectionStatementRenew,

            [StringValue("Collection Statement OneTime")]
            CollectionStatementOneTime,

            [StringValue("Pre-Maturity Payment Statement")]
            Pre_MaturityPaymentStatement,

            [StringValue("Maturity Payment Form")]
            MaturityPaymentForm,

            [StringValue("Projected Maturity (Account-Wise)")]
            ProjectedMaturity_AccountWise,

            [StringValue("Projected Maturity (FieldForce-Wise)")]
            ProjectedMaturity_FieldForceWise,

            [StringValue("Customer Account Revival Statement")]
            CustomerAccountRevivalStatement,

            [StringValue("Customer Account Selling Statement")]
            CustomerAccountSellingStatement,

            [StringValue("Customer Loan Payment")]
            CustomerLoanPayment,

            [StringValue("Customer Loan Recovery")]
            CustomerLoanRecovery,

            [StringValue("Field Force List")]
            FieldForceList,

            [StringValue("Field Force Collection Statement")]
            FieldForceCollectionStatement,

            [StringValue("Field Force Collection Statement (TermWise)")]
            FieldForceCollectionStatement_TermWise,

            [StringValue("By-Name Commission Payable (Summary)")]
            FieldForceByName_CommissionPayable,

            [StringValue("Account-Wise Commission Payable (Summary)")]
            FieldForceAccountWise_CommissionPayable,

            [StringValue("Guarantor Loan Applications")]
            GuarantorLoanApplications,

            [StringValue("Guarantor Loan Payment")]
            GuarantorLoanPayment,

            [StringValue("Guarantor Loan Recovery")]
            GuarantorLoanRecovery,

            [StringValue("Guarantor Loan Receipts")]
            GuarantorLoanReceipts,

            [StringValue("Guarantor Loan Ledger")]
            GuarantorLoanLedger,

            [StringValue("Guarantor Loan EMI Chart")]
            GuarantorLoanEMIChart,

            [StringValue("FieldForces_Business-Report-New")]
            FieldForcesBusinessReportNew,

            [StringValue("FieldForces-Commission-Payable-Statement")]
            FieldForcesCommissionPayableStatement,

            [StringValue("FieldForces-Commission-UnPaid-Statement")]
            FieldForcesCommissionUnPaidStatement,

            [StringValue("Field Force Promotion Statement")]
            FieldForcePromotionStatement,

            [StringValue("Field Force Promotion-Authority Wise")]
            FieldForcePromotion_AuthorityWise,

            [StringValue("GuarantorLoan_Account-Ledger")]
            GuarantorLoanAccountLedger,

            [StringValue("GuarantorLoan")]
            GuarantorLoan,

            [StringValue("GuarantorLoan_Applications-Approval-Statuswise")]
            GuarantorLoanApplicationsApprovalStatuswise,

            [StringValue("GuarantorLoan_Applications-Approval-Authoritywise")]
            GuarantorLoanApplicationsApprovalAuthoritywise,

            [StringValue("GuarantorLoan_Applications-Approved")]
            GuarantorLoanApplicationsApproved,

            [StringValue("GuarantorLoan_Applications-Pending")]
            GuarantorLoanApplicationsPending,

            [StringValue("GuarantorLoan_Applications-Rejected")]
            GuarantorLoanApplicationsRejected,

            [StringValue("GuarantorLoan_Applications-Rejection-Authoritywise")]
            GuarantorLoanApplicationsRejectionAuthoritywise,

            [StringValue("GuarantorLoan_Applications-Statuswise")]
            GuarantorLoanApplicationsStatuswise,

            [StringValue("GuarantorLoan_Recovery-Statement")]
            GuarantorLoanRecoveryStatement,

            [StringValue("GuarantorLoan_Payment-Statement")]
            GuarantorLoanPaymentStatement,

            [StringValue("CustomerAccount_Maturity-Payment-Statement")]
            CustomerAccountMaturityPaymentStatement,

            [StringValue("CustomerAccount_MIS-Payment-Voucher")]
            CustomerAccountMISPaymentVoucher,

            [StringValue("CustomerAccount_Pre-Maturity-Payment-Statement")]
            CustomerAccountPreMaturityPaymentStatement,

            [StringValue("CustomerAccount Projected Maturity Statement")]
            CustomerAccountProjectedMaturityStatement,

            [StringValue("CustomerAccount_CRMScroll-Statuswise")]
            CustomerAccountCRMScrollStatuswise,

            [StringValue("CustomerAccount_Maturity-Payment-Form")]
            CustomerAccountMaturityPaymentForm,

            [StringValue("FieldForces-Promotions-Statuswise")]
            FieldForcesPromotionsStatuswise,

            [StringValue("FieldForces-Promotions-Authoritywise")]
            FieldForcesPromotionsAuthoritywise,
            [StringValue("Cashbook")]
            CashBook,
        }

        public enum MultiView_ViewIndex
        {
            Customers = 0,
            CollectionStatement = 1,
            CustomerAccountProjectedMaturityStatement = 2,
            CustomerAccountMaturityPayment = 3,
            CustomerAccountRevivalAndSelling = 4,
            CustomerLoan = 5,
            FieldForce = 6,
            FieldForceCommission = 7,
            FieldForcePromotion = 8,
            GuarantorLoan = 9,
            GuarantorLoanLedger = 10,
			Transaction=11,
			Item=12,
            IssueItem = 13,
        }

		public enum CRMReportsName
		{
			[StringValue("CustomerList")]
			CustomerList,

			[StringValue("CustomerAccountList")]
			CustomerAccountList,

			[StringValue("CustomerProfileList")]
			CustomerProfile,

			[StringValue("CustomerDetailsList")]
			CustomerDetails,

			[StringValue("MaturityPaymentForm")]
			MaturityPaymentForm,

			[StringValue("ProjectedMaturity-AccountWise")]
			ProjectedMaturity_AccountWise,

			[StringValue("ProjectedMaturity-FieldForceWise")]
			ProjectedMaturity_FieldForceWise,

			[StringValue("AccountRevivalStatement")]
			CustomerAccountRevivalStatement,

			[StringValue("AccountSellingStatement")]
			CustomerAccountSellingStatement,

			[StringValue("FieldForceList")]
			FieldForceList,

			[StringValue("FieldForceCollectionList")]
			FieldForceCollectionStatement,

			[StringValue("FieldForceCollection-TermWise")]
			FieldForceCollectionStatement_TermWise,

			[StringValue("ByNameCommissionPayable")]
			FieldForceByName_CommissionPayable,

			[StringValue("Account-WiseCommission")]
			FieldForceAccountWise_CommissionPayable,

			[StringValue("FieldForces_Business-Report-New")]
			FieldForcesBusinessReportNew,

			[StringValue("FieldForces-Commission-Payable-Statement")]
			FieldForcesCommissionPayableStatement,

			[StringValue("FieldForces-Commission-UnPaid-Statement")]
			FieldForcesCommissionUnPaidStatement,

			[StringValue("FieldForcePromotionList")]
			FieldForcePromotionStatement,

			[StringValue("FieldForcePromotionAuthoritywise")]
			FieldForcePromotion_AuthorityWise,

			[StringValue("GuarantorLoan_Account-Ledger")]
			GuarantorLoanAccountLedger,

			[StringValue("GurantorLoanApplictionsList")]
			GuarantorLoanApplication,

			[StringValue("GuarantorLoan_Applications-Approval-Statuswise")]
			GuarantorLoanApplicationsApprovalStatuswise,

			[StringValue("GuarantorLoan_Applications-Approval-Authoritywise")]
			GuarantorLoanApplicationsApprovalAuthoritywise,

			[StringValue("GuarantorLoan_Applications-Approved")]
			GuarantorLoanApplicationsApproved,

			[StringValue("GuarantorLoan_Applications-Pending")]
			GuarantorLoanApplicationsPending,

			[StringValue("GuarantorLoan_Applications-Rejected")]
			GuarantorLoanApplicationsRejected,

			[StringValue("GuarantorLoan_Applications-Rejection-Authoritywise")]
			GuarantorLoanApplicationsRejectionAuthoritywise,

			[StringValue("GuarantorLoan_Applications-Statuswise")]
			GuarantorLoanApplicationsStatuswise,

			[StringValue("GurantorLoanRecoveryList")]
			GuarantorLoanRecoveryStatement,

			[StringValue("GurantorLoanPaymentList")]
			GuarantorLoanPaymentStatement,

			[StringValue("GurantorLoanReceipt")]
			GuarantorLoanReceipts,

			[StringValue("GurantorLoanLedger")]
			GuarantorLoanLedger,

			[StringValue("GurantorLoanEMIChart")]
			GuarantorLoanEMIChart,

			[StringValue("CustomerAccount_Maturity-Payment-Statement")]
			CustomerAccountMaturityPaymentStatement,

			[StringValue("CustomerAccount_MIS-Payment-Voucher")]
			CustomerAccountMISPaymentVoucher,

			[StringValue("CustomerAccount_Pre-Maturity-Payment-Statement")]
			CustomerAccountPreMaturityPaymentStatement,

			[StringValue("CustomerAccount Projected Maturity Statement")]
			CustomerAccountProjectedMaturityStatement,

			[StringValue("CustomerAccount_CRMScroll-Statuswise")]
			CustomerAccountCRMScrollStatuswise,

			[StringValue("CustomerAccount_Maturity-Payment-Form")]
			CustomerAccountMaturityPaymentForm,

			[StringValue("FieldForces-Promotions-Statuswise")]
			FieldForcesPromotionsStatuswise,

			[StringValue("FieldForces-Promotions-Authoritywise")]
			FieldForcesPromotionsAuthoritywise,

			[StringValue("Cashbook")]
			CashBook,

			[StringValue("CollectionStatement-One-Tme")]
			CollectionStatementOneTime,

			[StringValue("NewCollectionStatement")]
			CollectionStatementNew,

			[StringValue("RenewalCollectionStatement")]
			CollectionStatementRenew,

			[StringValue("CustomerLoanPaymentList")]
			CustomerLoanPayment,

			[StringValue("CustomerLoanRecoveryList")]
			CustomerLoanRecovery,

			[StringValue("PreMaturityPaymentStatement")]
			Pre_MaturityPaymentStatement,

			[StringValue("CashStatement-Summary-Monthly")]
			CashReportSummaryMonthly,

			[StringValue("CashStatement-Summary-BetweenDates")]
			CashReportSummaryBetweenDates,

			[StringValue("CashStatement-Details-BetweenDates")]
			CashReportDetailsBetweenDates,

			[StringValue("StatementOfReceivedItems")]
			StatementOfReceivedItems,

            [StringValue("StatementOfIssueItems")]
            StatementOfIssueItems,

			[StringValue("Item_Ledger")]
			ItemLedger,
		}
        #endregion

        #region Usual
        public enum ERPObjects
        {
            [StringValue("MicroERP")]
            ERPName = 0,

            [StringValue("Forms")]
            ERPFormsRootName = 1,

            [StringValue("frm")]
            ERPFormsPrefix = 2
        }

        public enum Modules
        {
            [StringValue("Common")]
            Common,

            [StringValue("Administration")]
            Administration,

            [StringValue("Customer Relation")]
            CustomerRelation,

            [StringValue("Human Resource")]
            HumanResource,

            [StringValue("Financial Accounts")]
            FinancialAccounts,

            [StringValue("Asset Management")]
            InventoryControl
        }

        public enum MenuItem
        {
            Separator
        }

        public enum SatusBar
        {
            [StringValue("User")]
            User = 0,

            [StringValue("Branch")]
            Branch = 1,

            [StringValue("Website")]
            WebSite = 2,

            [StringValue("DateTime")]
            DateTime = 3,

            [StringValue("Database")]
            Database = 4,

            [StringValue("Language")]
            Language = 5
        }

        public enum PathType
        {
            [StringValue("Absolute")]
            Absolute,

            [StringValue("Relative")]
            Relative
        }
        #endregion

        #region Data Operation
        public enum CommandButton
        {
            [StringValue("&Add")]
            AddNew = 0,

            [StringValue("&Edit")]
            Edit = 1,

            [StringValue("&Delete")]
            Delete = 2,

            [StringValue("&Save")]
            Save,

            [StringValue("&Update")]
            Update,

            [StringValue("&Cancel")]
            Cancel,

            [StringValue("E&xit")]
            Exit,

            [StringValue("Sea&rch")]
            Search
        }

        public enum DataOperation
        {
            [StringValue("None")]
            None = 0,

            [StringValue("AddNew")]
            AddNew = 1,

            [StringValue("Edit")]
            Edit = 2,

            [StringValue("Delete")]
            Delete = 3,

            [StringValue("View")]
            View = 4,

            [StringValue("Save")]
            Save = 5,

            [StringValue("Update")]
            Update = 6,

            [StringValue("Cancel")]
            Cancel = 7,

            [StringValue("Search")]
            Search = 8,

            [StringValue("Select")]
            Select = 9,

            [StringValue("Page")]
            Page = 10
        }

        public enum DataOperationResult
        {
            [StringValue("Record {0} successfully")]
            Success = 0,

            [StringValue("Duplicate record found")]
            Duplicate = -1,

            [StringValue("Failed to {0} the record")]
            Failure = -2,

            [StringValue("Record not found")]
            RecordNotFound = -3,

            [StringValue("Operation not Possible")]
            OperationNotPossible = -4,
            Failures
        }
        #endregion

        #region Unused References
        public enum Forms
        {
            [StringValue("MicroERP.Forms.Administration.Language")]
            Language = 0,

            [StringValue("MicroERP.Forms.Administration.Role")]
            Role = 1,

            [StringValue("MicroERP.Forms.Administration.Country")]
            Country = 10,

            [StringValue("MicroERP.Forms.Administration.State")]
            State = 11,

            [StringValue("MicroERP.Forms.Administration.District")]
            District = 12,

            [StringValue("MicroERP.Forms.Administration.Location")]
            Location = 12,

            [StringValue("MicroERP.Forms.Administration.Departments")]
            Departments = 40,

            [StringValue("MicroERP.Forms.Administration.Designations")]
            Designations = 41
        }

        public enum Office
        {
            [StringValue("HO")]
            HeadOffice = 1,

            [StringValue("CO")]
            CentralOffice = 2,

            [StringValue("U")]
            Unit = 3,

            [StringValue("A")]
            Area = 4,

            [StringValue("B")]
            Branch = 5,

            [StringValue("C")]
            CollectionCenter = 3,
        }

        public enum UserRole
        {
            Everyone = 7,
            SuperAdmin = 10,
            Administrator = 1,
            Operator = 2,
            Visitor = 3,
            Editor = 4,
            Deletor = 5
        }

        public enum UserCompany
        {
            TSDC=8,
            KSUB=9
        }
        public enum MicroRole
        {
            [StringValue("Administrator")]
            Admin = 1,

            [StringValue("Customer")]
            Customer = 2,

            [StringValue("Employee")]
            Employee = 3,

            [StringValue("User")]
            User = 4
        }

        public enum BackColor
        {
            [StringValue("#FFFFFF")]
            White,

            [StringValue("#F5F5F5")]
            WhiteSmoke,

            [StringValue("#F8F8FF")]
            GhostWhite,

            [StringValue("#FFFFE0")]
            LightYellow,

            [StringValue("#F5FFFA")]
            MintCream
        }

        public enum ForeColor
        {
            [StringValue("#000000")]
            Black,

            [StringValue("#0000FF")]
            Blue,

            [StringValue("#00008B")]
            DarkBlue,

            [StringValue("#8B0000")]
            DarkRed,

            [StringValue("#4B0082")]
            Indigo
        }
        #endregion

        #region app.Config <appSettings>
        public enum appSettings
        {
            [StringValue("ApplicationName")]
            ApplicationName,

            [StringValue("DefaultCompanyIndex")]
            DefaultCompanyIndex,

            [StringValue("DefaultDatabaseIndex")]
            DefaultDatabaseIndex,

            [StringValue("DefaultDatabaseEnviroment")]
            DefaultDatabaseEnviroment,

            [StringValue("MailSendingFromUser")]
            MailSendingFromUser,

            [StringValue("MailSendingFromPawd")]
            MailSendingFromPawd,

            [StringValue("MailServerName")]
            MailServerName,

            [StringValue("MailAddressesTo")]
            MailAddressesTo,

            [StringValue("MailAddressesCC")]
            MailAddressesCC,

            [StringValue("MailAddressBCC")]
            MailAddressBCC,

            [StringValue("MailSubjectPrefix")]
            MailSubjectPrefix,

            [StringValue("DeviceType")]
            DeviceType,

            [StringValue("DeviceSerialNo")]
            DeviceSerialNo,

            [StringValue("DeviceNumber")]
            DeviceNumber,

            [StringValue("DeviceDataClear")]
            DeviceDataClear,

            [StringValue("DeviceIP")]
            DeviceIP,

            [StringValue("DataImportType")]
            DataImportType,

            [StringValue("DataImportMode")]
            DataImportMode,

            [StringValue("DataExportMode")]
            DataExportMode,

            [StringValue("DataImportTime")]
            DataImportTime,

            [StringValue("DataExportTime")]
            DataExportTime,

            [StringValue("EmpCodeInitializer")]
            EmpCodeInitializer,

            [StringValue("ClientSettingsProvider.ServiceUri")]
            ClientSettingsProviderServiceUri,

            [StringValue("AllowRescheduleOfPastShiftSchedules")]
            AllowRescheduleOfPastShiftSchedules,

            [StringValue("ReportPathType")]
            ReportPathType,

            [StringValue("ReportFilePath")]
            ReportFilePath,

            [StringValue("ReportLogoPathType")]
            ReportLogoPathType,

            [StringValue("ReportLogoFilePath")]
            ReportLogoFilePath,

            [StringValue("XMLPathType")]
            XMLPathType,

            [StringValue("XMLFilePath_Message")]
            XMLFilePath_Message,

            [StringValue("EnableLogErrors")]
            EnableLogErrors,

            [StringValue("ErrorLogFileName")]
            ErrorLogFileName,

            [StringValue("AccessFilePath")]
            AccessFilePath,

            [StringValue("ExcelFilePath")]
            ExcelFilePath,

            [StringValue("Micro Messages")]
            MicroMessages
        }
        #endregion

        #region Message
        public enum Message
        {
            [StringValue("Success")]
            Success,

            [StringValue("Failure")]
            Failure,

            [StringValue("Other")]
            Other,
        }
        #endregion

        #region Search
        public enum SearchOperator
        {
            [StringValue("Contains")]
            Contains,

            [StringValue("StartsWith")]
            StartsWith,

            [StringValue("EqualsTo")]
            EqualsTo
        }

      
        public enum SearchForm
        {
            [StringValue("Book")]
            Book,

            [StringValue("Student")]
            Student,

            [StringValue("Customer")]
            Customer,

            [StringValue("FieldForce")]
            FieldForce,

            [StringValue("CustomerAccountReceipt")]
            CustomerAccountReceipt,

            [StringValue("Accounts")]
            Accounts,

            [StringValue("PrematurityApplication")]
            PrematurityApplication,

            [StringValue("PrematurityPayment")]
            PrematurityPayment,

            [StringValue("DCAccount")]
            DCAccount,

            [StringValue("DCDevice")]
            DCDevice,

            [StringValue("DCAccountReceipt")]
            DCAccountReceipt,

            [StringValue("GuarantorLoanApplication")]
            GuarantorLoanApplication,

            [StringValue("SearchGuarantorLoanPayment")]
            GuarantorLoanPayment,

            [StringValue("DCCollector")]
            DCCollector,

            [StringValue("CRMScrolls")]
            CRMScrolls,

            [StringValue("DCDeviceAllotments")]
            DCDeviceAllotments,

            [StringValue("MediclaimApplication")]
            MediclaimApplication,

            [StringValue("MediclaimApproval")]
            MediclaimApproval,

            [StringValue("AccountHead")]
            AccountHead,

            [StringValue("AccountName")]
            AccountName,

            [StringValue("AccountTransaction")]
            AccountTransaction,

            [StringValue("Employee")]
            Employee,

            [StringValue("Department")]
            Department,

            [StringValue("Designation")]
            Designation,

            [StringValue("Holiday")]
            Holiday,

            [StringValue("AttendanceAmendment")]
            AttendanceAmendment,

            [StringValue("AttendanceApplication")]
            AttendanceApplication,

            [StringValue("Shift")]
            Shift,

            [StringValue("Office")]
            Office,

            [StringValue("ErrorLog")]
            UserLog,

			[StringValue("Item")]
			Item,

			[StringValue("Item Group")]
			ItemGroup,

			[StringValue("ItemIngredient")]
			ItemIngredient,

           [StringValue("Guests")]
            Guests,

           [StringValue("BillDetails")]
           BillDetails,

           [StringValue("Booking")]
           Booking,

		   [StringValue("Room")]
		   Room,

		   [StringValue("RoomType")]
		   RoomType,

           [StringValue("ItemIssue")]
           ItemIssue,

           [StringValue("ItemReceive")]
           ItemReceive,
        }

        public enum SearchCustomerAccountReceipt
        {
            [StringValue("CustomerAccountCode")]
            CustomerAccountCode,

            [StringValue("CustomerName")]
            CustomerName,

            [StringValue("Status")]
            Status
        }

        public enum SearchCRMScrolls
        {
            [StringValue("ScrollNumber")]
            ScrollNumber,

            [StringValue("DepositorName")]
            DepositorName,

            [StringValue("Status")]
            Status
        }

        public enum SearchCustomer
        {
            [StringValue("CustomerName")]
            CustomerName,

            [StringValue("CustomerCode")]
            CustomerCode,

            [StringValue("MobilePhone")]
            MobilePhone,

            [StringValue("OfficeName")]
            OfficeName

        }

        public enum SearchStudent
        {
            [StringValue("StudentName")]
            StudentName,

            [StringValue("MobilePhone")]
            MobilePhone
            
            //[StringValue("StudentCode")]
            //StudentCode,

            //[StringValue("ClassName")]
            //ClassName,

            //[StringValue("StreamName")]
            //StreamName,



        }

        public enum SearchFieldForce
        {
            [StringValue("FieldForceName")]
            FieldForceName,

            [StringValue("FieldForceCode")]
            FieldForceCode,

            [StringValue("FieldForceLocation")]
            FieldForceLocation,

            [StringValue("FieldForceRank")]
            FieldForceRank,

            [StringValue("MobilePhone")]
            MobilePhone,

            [StringValue("OfficeName")]
            OfficeName,

        }

        public enum SearchAccount
        {
            [StringValue("AccountName")]
            AccountName,

            [StringValue("AccountGroupName")]
            AccountGroupName
        }

        public enum SearchPrematurityApplication
        {
            [StringValue("CustomerName")]
            CustomerName,

            [StringValue("ApprovalStatus")]
            ApprovalStatus
        }

        public enum SearchPrematurityPayment
        {
            [StringValue("PreMaturityFormNumber")]
            FormNumber,

            [StringValue("PreMaturityPaymentDate")]
            PaymentDate
        }

        public enum SearchDCAccount
        {
            [StringValue("CustomerName")]
            CustomerName,

            [StringValue("DCAccountCode")]
            DCAccountCode,

            [StringValue("OfficeName")]
            OfficeName
        }

        public enum SearchDCDevice
        {
            [StringValue("DCDeviceSerialNumber")]
            DCDeviceSerialNumber,

            [StringValue("OfficeName")]
            OfficeName
        }

        public enum SearchDCDeviceAllotment
        {
            [StringValue("DCCollectorName")]
            DCCollectorName,

            [StringValue("DCDeviceSerialNumber")]
            DCDeviceSerialNumber
        }

        public enum SearchDCAccountReceipt
        {
            [StringValue("DCReceiptDate")]
            DCReceiptDate,

            [StringValue("DCReceiptNumber")]
            DCReceiptNumber
        }

        public enum SearchDCCollector
        {
            [StringValue("DCCollectorName")]
            DCCollectorName,

            [StringValue("DCCollectorCode")]
            DCCollectorCode,

            [StringValue("OfficeName")]
            OfficeName
        }
        public enum SearchBook
        {
            //[StringValue("BookType")]
            //BookType,


            //[StringValue("Segment")]
            //Segment,


            //[StringValue("Category")]
            //Category,

            [StringValue("Title")]
            Title,

            [StringValue("AccessionNo")]
            AccessionNo,

            [StringValue("AuthorName")]
            AuthorName,

            [StringValue("Publisher")]
            Publisher,
        }

        public enum SearchEmployee
        {
            [StringValue("EmployeeName")]
            EmployeeName,

            [StringValue("EmployeeCode")]
            EmployeeCode,


        }

        public enum SearchDepartment
        {
            [StringValue("DepartmentName")]
            DepartmentName
        }

        public enum SearchAttendanceAmmendment
        {
            [StringValue("DateOfAttendance")]
            DateOfAttendance
        }

        public enum SearchAttendanceApplication
        {
            [StringValue("DateOfAttendance")]
            DateOfAttendance
        }

        public enum SearchShift
        {
            [StringValue("Description")]
            Description,

            [StringValue("Alias")]
            Alias,

        }



        public enum SearchHoliday
        {
            [StringValue("Occasion")]
            Occasion
        }

        public enum SearchOffice
        {
            [StringValue("OfficeName")]
            OfficeName
        }

        public enum SearchGuest
        { 
        [StringValue("GuestName")]
        GuestName,
        [StringValue("GuestMobile")]
        GuestMobile,
        }

        public enum SearchBillDetail
        { 
        [StringValue("BillDate")]
         BillDate
        }
        public enum SearchErrorLog
        {
            [StringValue("Ticket")]
            Ticket,
            [StringValue("UserDomain")]
            UserDomain,
            [StringValue("Date")]
            Date
        }
        public enum SearchDesignation
        {
            [StringValue("DesignationDescription")]
            DesignationDescription
        }

        public enum SearchGuarantorLoanApplication
        {
            [StringValue("LoanApplicantName")]
            ApplicantName,

            [StringValue("ApprovalStatus")]
            ApprovalStatus
        }

        public enum SearchGuarantorLoanPayment
        {
            [StringValue("LoanApplicantName")]
            ApplicantName,

            [StringValue("IssueDate")]
            IssueDate
        }

        public enum SearchMediclaimApplication
        {
            [StringValue("LoanApplicantName")]
            LoanApplicantName,

            [StringValue("ApprovalStatus")]
            ApprovalStatus,

            [StringValue("OfficeName")]
            OfficeName,

        }

        public enum SearchMediclaimApproval
        {
            [StringValue("LoanApplicantName")]
            LoanApplicantName,

            [StringValue("ApprovalDate")]
            ApprovalDate
        }

        public enum SearchAccountHead
        {
            [StringValue("AccountHeadDescription")]
            Name,

            [StringValue("AccountHeadType")]
            Type,

            [StringValue("IsPrimary")]
            IsPrimary
        }

        public enum SearchAccountName
        {
            [StringValue("AccountDescription")]
            Name,

            [StringValue("AccountHeadDescription")]
            AccountHead,

            [StringValue("AccessType")]
            AccessType,

            [StringValue("AnalysisFlag")]
            AnalysisFlag
        }

        public enum SearchAccountTransaction
        {
            [StringValue("AccountDescription")]
            AccountName,

            [StringValue("HeadType")]
            HeadType,

            [StringValue("ThirdPartyDescription")]
            ThirdParty,
        }

		public enum SearchItemGroup
		{
			[StringValue("Item Group Name")]
			ItemGroupName,

			[StringValue("Item Group Parent Name")]
			ItemGroupParentName,
		}

        public enum SearchItem
        {
            [StringValue("Item Name")]
            ItemName,

            [StringValue("Item Group Name")]
            ItemGroupName,
        }

        public enum SearchBooking
        {
            [StringValue("Customer Name")]
            CustomerName,

            [StringValue("Room Type")]
            RoomType,
        }

        public enum SearchItemIssue
        {
            [StringValue("Item Name")]
            ItemName,

            [StringValue("Transaction Date")]
            TransactionDate,
        }

        public enum SearchItemReceive
        {
            [StringValue("Item Name")]
            ItemName,

            [StringValue("Transaction Date")]
            TransactionDate,
        }

		public enum SearchIngredient
		{
			[StringValue("Item Name")]
			ItemName,

			[StringValue("Ingredient Name")]
			IngredientName,
		}

		public enum SearchRoom
		{
			[StringValue("Room Number")]
			RoomNumber,

			[StringValue("Room Type")]
			RoomType,
		}

		public enum SearchRoomType
		{
			

			[StringValue("Room Type")]
			RoomType,
		}
		
        #endregion

        public enum CustomerAccountFilter
        {
            [StringValue("ALL")]
            ALL,

            [StringValue("MIS")]
            MIS,

            [StringValue("OneTime")]
            OneTime,

            [StringValue("Recurring")]
            Recurring,

            [StringValue("Imature")]
            Imature,

            [StringValue("Mature")]
            Mature
        }

        public enum RoleDescription
        {
            [StringValue("Administrator")]
            Administrator,

            [StringValue("TOP_MANAGEMENT")]
            TopManagement,

            [StringValue("UNIT_MANAGER")]
            UnitManager,

            [StringValue("AREA_MANAGER")]
            AreaManager,

            [StringValue("BRANCH_MANAGER")]
            BranchManager,

            [StringValue("COMPUTER_OPERATOR")]
            ComputerOperator,

            [StringValue("GUEST")]
            Guest,

            [StringValue("USER")]
            User
        }

		public enum PermissionDescription
		{
			[StringValue("Add")]
			Add,

			[StringValue("Edit")]
			Edit,

			[StringValue("Delete")]
			Delete,

			[StringValue("View")]
			View
		}

        public enum RemittanceType
        {
            [StringValue("Remittance (Payment)")]
            Payment,

            [StringValue("Remittance (Receipt)")]
            Receipt
        }

        public enum RemittanceMode
        {
            [StringValue("Remittance by Cash")]
            Cash,

            [StringValue("Remittance by Bank Deposit")]
            BankDeposit
        }

		public enum UserTheme
		{
			[StringValue("Default")]
			Micro_Default,

			[StringValue("Dark Green")]
			Micro_DarkGreen
		}

		public enum ItemTypeName
		{
			[StringValue("ALL")]
			ALL,

			[StringValue("Recipe")]
			Recipe,

			[StringValue("MFEL Product")]
			MFELProduct,

			[StringValue("MLFL Product")]
			MLFLProduct
		}

        public enum WeekNameAlias
        {
            MON = 1,
            TUE = 2,
            WED = 3,
            THU = 4,
            FRI = 5,
            SAT = 6,
            SUN = 7,
        }
    }
}