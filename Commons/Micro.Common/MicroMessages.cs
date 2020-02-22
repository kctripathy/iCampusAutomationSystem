using System;
using System.Text;
using System.Windows.Forms;

namespace Micro.Commons
{
    public class MicroMessages 
    {
        public const string MSG_TITLE_EXCEPTION="Exception!";
        public const string MSG_TITLE_INFORMATION="Information!";
        public const string MSG_TITLE_INVALID_INPUT="Invalid Input!";
        public const string MSG_TITLE_DATA_ENTRY_ERROR="Data Entry Error!";

        public const string MSG_ERR_FIELD_LEFT_BLANK = " left blank.";
        public const string MSG_ERR_SELECT_DATABASE = "Please select a database to connect.";
        
        public const string MSG_INFO_GRIDVIEW_EDIT="If you want to edit the column or cell content click on Row Header.";
        public const string MSG_QUESTION_DELETE="Do you want to delete the selected record.";
        public const string MSG_QUESTION_RESTORE="Do you want to restore the selected record.";

        public const string MSG_CONTACT_SUPPORT_TEAM= "Please contact the support team. ";
        public const string MSG_EMAIL_ISSUE_TO_HO_MDC= "Please escalate this issue to Micro Development Center located at Head Office by sending an email to ";

        public const string MSG_LOGIN_VALIDATION_PLEASE_WAIT= "Validating the user name and password. Please wait a moment.";
        public const string MSG_LOGIN_EMPTY_USERNAME = "Login Failed! The user name doesn't exists.";
        public const string MSG_LOGIN_EMPTY_PASSWORD = "Login Failed! Incorrect password.";
        public const string MSG_LOGIN_EMPTY_COMPANY = "Fatal Error! \nThis user doesn't belongs to any company.";
        public const string MSG_LOGIN_EMPTY_COMPANY_CODE = "Fatal Error! \nThis user doesn't have a company code.";
        public const string MSG_LOGIN_USER_NOT_OF_COMPANY = "This user doesn't belongs to the selected company";
        public const string MSG_UPDATE_PROFILE_EMPLOYEE = "Update Profile Successfully";
        public const string MSG_SAVED_LEAVE_APPLICATION = "Leave Application saved Successfully";
        public const string MSG_UPDATE_LEAVE_APPLICATION = "Leave Application updated Successfully";
        public const string MSG_FAILED_LEAVE_APPLICATION = "Leave Application Failed";
        public const string MSG_INSUFFICIENT_LEAVE_BALANCE = "Insufficent Leave Balance";
        public const string MSG_SELECT_DATE_PROPER = "To Select Date Properly";

        public const string MSG_SELECT_SHIFT_GEN_MENTION_WEEKLY_OFF_FOR_SHIFT_GEN = "To Select Gen and Mention weekly off for Shift-Gen";
        public const string MSG_SELECT_WEEKLY_OFF_FOR_SHIFT_GEN = "To Select Weekly off for shift-Gen";
        public const string MSG_SHIFTTIMIMG_SAVED = "Shift Time Settings Saved Successfully";
        public const string MSG_SELECT_MONTH_YEAR_PROPERLY = "Select Month and Year Properly";
        public const string MSG_SELECT_EMPLOYEE = "Select An Employee";
        public const string MSG_ATTENDANCE_NOT_FOUND_FOR_EDIT = "Attendance Not Found For Edit";
        public const string MSG_SELECT_AN_EMPLOYEE = "Select an Employee";
        public const string MSG_SELECT_SOMETHING_TO_EDIT = "Select Something To Edit";
        public const string MSG_NOTHING_TO_EDIT = "Nothing To Edit";
        public const string MSG_SELECT_POSTING_OFFICE = "Select Posting Office Name";
        public const string MSG_SELECT_DESIGNATION_OF_EMPLOYEE = "Select Designation Of Employee";
        public const string MSG_SELECT_DEPARTMENT_OF_EMPLOYEE = "Select Department Of Employee";
        public const string MSG_SELECT_SERVICE_TYPE_OF_EMPLOYEE = "Select Service Type";
        public const string MSG_SELECT_SERVICE_STATUS_OF_EMPLOYEE = "Select Service Status";
        public const string MSG_SPECIFY_REFERENCE_LETTER_NUMBER = "Specify Reference Letter Number";
        public const string MSG_SELECT_TO_DELETE = "Nothing is selected to delete";
        public const string MSG_SHIFTTIMIMG_UPDATE="SHIFT TIMINGS UPDATE SUCCESSFULLY";
        public const string MSG_SHIFTTIMIMG_INSERT = "SHIFT TIMINGS SAVED SUCCESSFULLY";

		public const string MSG_SELECT_GRIDVIEW_ROW = "SELECT AN EMPLOYEE NAME FROM THE EMPLOYEE LIST";
        public const string MSG_VALIDATION_NUMBER_ALLOWED_ONLY = "ONLY NUMBER ALLOWED";
        public const string MSG_VALIDATION_NO_NUMBER_ALLOWED = "NUMBER NOT ALLOWED";
        public const string MSG_VALIDATION_NEGATIVE_NUMBER_NOT_ALLOWED = "NEGATIVE NUMBER NOT ALLOWED";

        public const string DATA_DELETED_SUCCESSFULLY = "DATA DELETED SUCCESSFULLY";
        public const string DATA_DELETED_FAILED = "FAILED TO DELETE DATA";

        public const string DUPLICATE_RECORD_FOUND = "Duplicate record found";
        public const string DATA_SAVED_SUCCESSFULLY = "DATA SAVED SUCCESSFULLY";
        public const string DATA_SAVED_FAILED = "FAILED TO SAVE DATA";
        public const string DATA_UPDATED_SUCCESSFULLY = "DATA UPDATED SUCCESSFULLY";
        public const string RECORD_NOT_FOUND_FOR_UPDATE = "Record Not Found For Update";
        public const string RECORD_NOT_FOUND_FOR_DELETE = "Record Not Found For Delete";
        public const string DELETE_ABORDTED = "RECORD DELETE ABORTED";
        
        public const string MSG_UNKNOWN_ERROR = "An Unknown Error Found"; 

        public static string MSG_APPLICATION_TITLE="Micro-ERP: ";

		public static StringBuilder ErrorMessages; 

		public static string ApplicationErrorMessage = "";

		public static void ShowDataExceptionErrorMessage(Exception theException)
		{
			StringBuilder MessageString = new StringBuilder(theException.Message);

			if(!(theException.InnerException == null))
			{
				MessageString.Append("\n\nSource \t\t:- " + theException.InnerException.Source);
				MessageString.Append("\nInner Message\t:- " + theException.InnerException.Message);
			}

			//throw (new Exception(MessageString.ToString()));
            //if (!(string.IsNullOrEmpty(MessageString.ToString())))
            //{
            //    throw (new Exception(MessageString.ToString()));
            //}
			//TODO: Log the error messages into a table
			//MessageBox.Show(MessageString.ToString(), MicroMessages.MSG_APPLICATION_TITLE + MicroMessages.MSG_TITLE_EXCEPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void ShowLeftBlankMessage()
		{
			MicroMessages.ErrorMessages.AppendLine();
			MicroMessages.ErrorMessages.AppendLine("The above field(s) left blank.");
			MessageBox.Show(MicroMessages.ErrorMessages.ToString());
		}

        public static void ShowDataValidationTextBoxMessage()
        {
            MicroMessages.ErrorMessages.AppendLine();
            MicroMessages.ErrorMessages.AppendLine("Sorry, Please enter valid data.");
            MessageBox.Show(MicroMessages.ErrorMessages.ToString());
        }
    }
}
