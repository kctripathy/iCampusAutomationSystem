using System.Drawing;

namespace Micro.Commons
{
    public class MicroConstants
    {
        /// <summary>
        /// DateFormat = "dd-MMM-yyyy"
        /// </summary>
        public const string DateFormat = "dd-MMM-yyyy";
        /// <summary>
        /// DateTimeFormat = "dd-MMM-yyyy HH:mm:ss"
        /// </summary>
        public const string DateTimeFormat = "dd-MMM-yyyy HH:mm:ss";
        /// <summary>
        /// DateTimeStampFormat = "dd-MMM-yyyy HH:mm:ss.ms"
        /// </summary>
        public const string DateTimeStampFormat = "dd-MMM-yyyy HH:mm:ss.ms";
        /// <summary>
        /// DateShortMonth ="MMM-yyyy"
        /// </summary>
        public const string DateShortMonth = "MMM-yyyy";
        /// <summary>
        /// DateLongMonth = "MMMM-yyyy"
        /// </summary>
        public const string DateLongMonth = "MMMM-yyyy";
        /// <summary>
        /// DateSqlFormat= "yyyy/MM/dd"
        /// </summary>
        public const string DateSqlFormat = "yyyy/MM/dd";
        /// <summary>
        /// DateSystemFormat= "dd/MM/yyyy"
        /// </summary>
        public const string DateSystemFormat = "dd/MM/yyyy";
        /// <summary>
        /// DateTimeSqlFormat = "yyyy/MM/dd hh:mm"
        /// </summary>
        public const string DateTimeSqlFormat = "yyyy/MM/dd hh:mm";
        /// <summary>
        /// DateTimeSystemFormat= "dd/MM/yyyy hh:mm"
        /// </summary>
        public const string DateTimeSystemFormat = "dd/MM/yyyy hh:mm";
        /// <summary>
        /// TimeFormat= "HH:mm tt"
        /// </summary>
        public const string TimeFormat = "HH:mm tt";

        /// <summary>
        /// @"HKEY_CURRENT_USER\\SOFTWARE\\MicroGroup\\ERP-Appln"
        /// </summary>
        public static string REGISTRY_KEYNAME = @"HKEY_CURRENT_USER\\SOFTWARE\\MicroGroup\\ERP-Appln";
        /// <summary>
        /// LastDatabaseConnectionIndex
        /// </summary>
        public static string REGISTRY_KEYVALUE_LASTDATABASECONNECTIONINDEX = "LastDatabaseConnectionIndex";
        /// <summary>
        /// "LastDatabaseConnectionName
        /// </summary>
        public static string REGISTRY_KEYVALUE_LASTDATABASECONNECTIONNAME = "LastDatabaseConnectionName";
        /// <summary>
        /// LastOfficeLoggedOnUser
        /// </summary>
        public static string REGISTRY_KEYVALUE_LASTOFFICELOGGEDONUSER = "LastOfficeLoggedOnUser";
        /// <summary>
        /// LastCompanyIndex
        /// </summary>
        public static string REGISTRY_KEYVALUE_LASTCOMPANYINDEX = "LastCompanyIndex";
        /// <summary>
        /// LastCompanyName
        /// </summary>
        public static string REGISTRY_KEYVALUE_LASTCOMPANYNAME = "LastCompanyName";
        /// <summary>
        /// ANDCondition
        /// </summary>
        public static string CONDITION_AND = " AND ";
        /// <summary>
        /// LikeOperatorName
        /// </summary>
        public static string OPERATOR_LIKE = " Like";
        /// <summary>
        /// EqualToOperator
        /// </summary>
        public static string OPERATOR_EQUALSTO = " =";
        /// <summary>
        /// Default Minimum Age = 1
        /// </summary>
        public static string DEFAULT_MIN_AGE = "1";

        /// <summary>
        /// Regular Expression for Date. It validates not only the Date Format but also checks is it a Calender Date or not.
        /// </summary>
        public const string REGEX_DATE = "^(?:((31-(Jan|Mar|May|Jul|Aug|Oct|Dec))|((([0-2]\\d)|30)-(Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))|(([01]\\d|2[0-8])-Feb))|(29-Feb(?=-((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))-((1[6-9]|[2-9]\\d)\\d{2})$";
        /// <summary>
        /// Regular Expression for Month and year. It validates only the month and year, it may be like 01-1900 or Jan-1900.
        /// </summary>
        public const string REGEX_MONTH_YEAR = "^((Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)|((0[1-9])|(1[0-2])))\\-([1-2][0-9][0-9][0-9])$";
        /// <summary>
        /// Regular Expression for EMail ID.
        /// </summary>
        public const string REGEX_EMAILID = "^([\\w-]+(?:\\.[\\w-]+)*)@((?:[\\w-]+\\.)*\\w[\\w-]{0,66})\\.([a-z]{2,6}(?:\\.[a-z]{2})?)$";
        /// <summary>
        /// Regular Expression for Only Numeric with out space
        /// </summary>
        public const string REGEX_NUMBER_ONLY = "^\\d+$";
        /// <summary>
        /// Regular Expression for Only Numeric with  space
        /// </summary>                
        public const string REGEX_NUMBER_WITH_SPACE = "^[0-9\\s]+$";
        public const string REGEX_MOBILE_LENGTH = "^[0-9]{10}";
         /// <summary>
        /// Regular Expression for Only Numeric 10 digit only
        /// </summary>
        /// 
        /// <summary>
        /// Regular Expression for Only Numeric with  space and dot
        /// </summary>
        public const string REGEX_NUMBER_WITH_SPACE_DOT = "^[0-9\\s\\.]+$";
		/// <summary>
        /// Regular Expression for Only Numeric with  space and dot
        /// </summary>
		public const string REGEX_DECIMAL_GREATERTHANZERO = "(^\\d*\\.?\\d*[1-9]+\\d*$)|(^[1-9]+\\d*\\.\\d*$)";
        /// <summary>
        /// "^(([0-9]*[1-9][0-9]*([.][0-9]+)?)|([0]+[.][0-9]*[1-9][0-9]*))$"
        /// </summary>
        public const string REGEX_NUMBER_GREATERTHANZERO = "^[1-9]+[0-9]*$";
        /// <summary>
        /// "^(([0-9]*[1-9][0-9]*([.][0-9]+)?)|([0]+[.][0-9]*[1-9][0-9]*))$"
        /// </summary>
        public const string REGEX_CURRENCY_GREATERTHANZERO = "^(([0-9]*[1-9][0-9]*([.][0-9]+)?)|([0]+[.][0-9]*[1-9][0-9]*))$";
        /// <summary>
        /// Retular Expression for Only alfabates
        /// </summary>
        public const string REGEX_ALPHABETS_ONLY = "[a-zA-Z][a-zA-Z\\s]+";
        /// <summary>
        /// Accepts only A-Z, a-z, 0-9
        /// </summary>
        public const string REGEX_ALPHANUMERIC = "^[0-9a-zA-Z]+$";
        /// <summary>
        /// Accepts only A-Z, a-z, 0-9 and "-"
        /// </summary>
        public const string REGEX_ALPHANUMERIC_MINUS = "^[0-9a-zA-Z\\-]+$";
        /// <summary>
        /// Accepts only A-Z, a-z, 0-9, (space) and (dot)
        /// </summary>
        public const string REGEX_ALPHANUMERIC_SPACE_DOT = "^[0-9a-zA-Z\\s\\.]+$";
        /// <summary>
        /// Regular Expression for Common Name (Accepts A-Z, Space & dot)
        /// </summary>
        public const string REGEX_NAME = "[a-zA-Z\\s\\.]+";
        /// Regular Expression for Image File Type (.bmp,.jpg,.jpeg,.gif,.png)
        /// </summary>
        public const string REGEX_IMAGE_FILE_TYPE = "^.+(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|PNG)$";
        /// <summary>
        /// Regular Expression for Time Format(HH:mm tt) like 00:00 AM/PM
        /// </summary>
       
        public const string REGEX_ALPHABETS_SPECIFIED_ONLY = "[ynYN]+";
        /// <summary>
        /// Regular Expression for Common Name (Accepts Y , y , N & n)
        /// </summary>
        public const string REGEX_TIME = "(1[012]|0?\\d):[0-5]?\\d?\\s+[AaPp][Mm]?";
    
        /// <summary>
        /// 
        /// </summary>
        public const string VALID_CHAR_DATE = "0123456789ADFJMNOSabcdefgjlmnoprstuvy-";
        /// <summary>
        /// 
        /// </summary>
        public const string VALID_CHAR_NAME = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz. ";


        /// <summary>
        /// Server Path to store the image. "~\\Themes\\Default\\Profiles\\FieldForceProfiles\\"
        /// </summary>
        public const string PROFILE_IMAGE_URL = "~\\Themes\\Profiles\\";
        public const string PROFILE_IMAGE_TEMP = "~\\TEMP";

        /// <summary>
        /// Default Text of DropDownList "--SELECT--"
        /// </summary>
        public const string DROPDOWNLIST_DEFAULT_ADMISSION = "1,"+"4,"+"8,"+"11";
		public const string DROPDOWNLIST_DEFAULT_ITEMTEXT = "--SELECT--";
		public const string DROPDOWNLIST_DEFAULT_ITEMTEXT_STAFF = "--SELECT A STAFF--";
		public const string DROPDOWNLIST_DEFAULT_ITEMTEXT_STUDENT = "--SELECT A STUDENT--";
		public const string DROPDOWNLIST_DEFAULT_ITEMTEXT_BOOK = "--SELECT A BOOK--";
        public const string COMMAND_GO = "GO";
        public const string COMMAND_INSERT = "Insert";
		public const string DROPDOWNLIST_ALL_ITEMTEXT = "--ALL--";
		public const string DROPDOWNLIST_DEFAULT_ITEMTEXT_DASH = "--";
        public const int NUMERIC_VALUE_ZERO = 0;
        public const int NUMERIC_ONE = 1;
        public const int NUMERIC_TWO = 2;
        public const int NUMERIC_THREE = 3;
        public const int NUMERIC_FOUR = 4;
        /// <summary>
        /// Default Text of Labels "Not Available"
        /// </summary>
        public const string LABEL_DEFAULT_TEXT = "N/A";

        public const string MICRO_VALUE_YES = "Y";
        public const string MICRO_VALUE_NO = "N";

        public static Color MICRO_MENU_FORECOLOR = Color.Navy;

        public static Color GRID_DEFAULT_ROW_FORECOLOR = Color.DarkBlue;
        public static Color GRID_DEFAULT_ROW_BACKCOLOR = Color.WhiteSmoke;
        public static Color GRID_ALTERNATE_ROW_FORECOLOR = Color.Black;
        public static Color GRID_ALTERNATE_ROW_BACKCOLOR = Color.MintCream;
        public static Color GRID_SELELCTED_ROW_FORECOLOR = Color.Indigo;
        public static Color GRID_SELELCTED_ROW_BACKCOLOR = Color.MistyRose;
        public static int GRIDVIEW_COL_WIDTH_MENU_PERMISSION = 202;
        public static int GRIDVIEW_COL_HEIGH_MENU_PERMISSION = 387;

        public static string INFO_SELECT_RECORD_AND_CLICK_DELETE = "Please select a record and then click delete button";
        public static string INFO_EVENT_NOT_ATTACHED_YET = "Button event not attached to Form event yet";
        public static string QUESTION_WANT_TO_DELETE_THE_RECORD = "Do you want to delete this record?";

        public static string MICRO_KEY_WILL_SHOW_INSERT_SUCCESS_MESSAGE = "WILL_SHOW_INSERT_SUCCESS_MESSAGES";
        public static string MICRO_KEY_WILL_SHOW_UPDATE_SUCCESS_MESSAGE = "WILL_SHOW_UPDATE_SUCCESS_MESSAGES";
        public static string MICRO_KEY_WILL_CONFIRM_BEFORE_DELETE = "WILL_CONFIRM_BEFORE_DELETE";

        public static string REPORT_FORM_NAME = "MicroERP.Forms.frmReportViewer";
    }
}
