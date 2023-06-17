using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.ESTBLMT
{

    public class EstablishmentObject
    {
        public int EstbID
        {
            get;
            set;
        }
        public string EstbCode
        {
            get;
            set;
        }
        public string EstbTypeCode
        {
            get;

            set;

        }

        public string EstbTypeCodeDesc
        {
            get
            {
                return EstbTypeConstants.GetEstbTypeDescription(this.EstbTypeCode);
            }
        }

        public string EstbTitle
        {
            get;
            set;

        }

       

        public string EstbDescription
        {
            get;
            set;
        }

        public string EstbDescription1
        {
            get;
            set;
        }

        public string EstbDescription2
        {
            get;
            set;
        }


        public DateTime EstbDate
        {
            get;
            set;
        }
        public string EstbMessage
        {
            get;
            set;
        }
        public byte[] EstbUploadFile
        {
            set;
            get;
        }

        public string EstbUploadFileType
        {
            get;
            set;
        }
        public DateTime EstbViewStartDate
        {
            get;
            set;
        }

        public string FileNameWithPath
        {
            get;
            set;

        }
        public string AuthorOrContributorName
        {
            get;
            set;

        }
    }

    [Serializable]
    public class Establishment
    {
        public int EstbID
        {
            get;
            set;
        }
        public string EstbCode
        {
            get;
            set;
        }
        public string EstbTypeCode
        {
            get;
            set;
        }
        public string EstbTypeCodeDesc
        {
            get
            {
                return EstbTypeConstants.GetEstbTypeDescription(this.EstbTypeCode);
            }
        }
        public string EstbTitle
        {
            get;
            set;

        }
        public int EstbTitletZoneMaxLengh
        {
            get
            {
                //return 25;
                return int.Parse(ConfigurationManager.AppSettings["EstbTitletZoneMaxLengh"].ToString());
            }
        }
        public string EstbTitleZone
        {
            get
            {
                if (EstbTitle.Length > EstbTitletZoneMaxLengh)
                {
                    return string.Concat(EstbTitle.ToString().Substring(0, EstbTitletZoneMaxLengh), "...more");
                }
                else
                {
                    return EstbTitle;
                }
            }

        }
        public string EstbDescription
        {
            get;
            set;
        }
        public string EstbDescription1
        {
            get;
            set;
        }
        public string EstbDescription2
        {
            get;
            set;
        }
        public DateTime EstbDate
        {
            get;
            set;
        }
        public string EstbMessage
        {
            get;
            set;
        }
        public byte[] EstbUploadFile
        {
            set;
            get;
        }

        public string EstbUploadFileType
        {
            get;
            set;
        }
        public DateTime EstbViewStartDate
        {
            get;
            set;
        }

        public DateTime EstbViewEndDate
        {
            get;
            set;
        }
        public string EstbStatusFlag
        {
            get;
            set;
        }

        public string EstbStatusFlagDesc
        {
            get
            {
                string _desc = string.Empty;
                if (this.EstbStatusFlag.Equals("A"))
                {
                    _desc = "Approved";
                }
                else if (this.EstbStatusFlag.Equals("P"))
                {
                    _desc = "Pending";
                }
                return _desc;
            }
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;

        }

        public int ModifiedBy
        {
            get;
            set;
        }

        public string DateAdded
        {
            get;
            set;
        }

        public string DateModified
        {
            get;
            set;

        }
        public int OfficeID
        {
            get;
            set;

        }
        public int CompanyID
        {
            get;
            set;
        }
        public string FileNameWithPath
        {
            get;
            set;

        }
        public string AuthorOrContributorName
        {
            get;
            set;

        }

        public string PublicationAuthorName
        {
            get;
            set;

        }
    }

    [Serializable]
    public class EstablishmentType
    {
        public int EstbTypeID
        {
            get;
            set;
        }
        public string EstbTypeCode
        {
            get;
            set;
        }
        public string EstbTypeCodeDescription
        {
            get;

            set;

        }

        public int TotalRecords
        {
            get
            {
              return 0; // SELECT COUNT(*) FROM 
            }
        }
    }


    public static class EstbTypeConstants
    {
        public static string AQAR = "A";
        public static string CIRCULAR = "C";
        public static string DOWNLOAD = "D";
        public static string IQAC = "I";
        public static string MoM = "M";
        public static string NOTICE = "N";
        public static string PHOTO = "P";
        public static string RECENT_ACTIVITY = "R";
        public static string SYLLABUS = "S";
        public static string TENDER = "T";
        public static string VIDEO = "V";
        public static string WORLDBANK = "W";
        public static string NAAC = "Z";

        public static string ARTCLE = "1";
        public static string PROJECT_PAPER = "2";
        public static string BOOK = "3";
        public static string AWARD = "4";
        public static string SEMINAR_PAPER = "5";
        public static string STUDY_MATERIAL = "6";
        public static string LITERATURE = "7";
        public static string STAFF_PROFILE = "8";
    

    public static string GetEstbTypeDescription(string typeCode)
    {
        string _typeCodeDesc = string.Empty;
        if (typeCode.Equals(EstbTypeConstants.AQAR))
        {
            _typeCodeDesc = "AQAR";
        }
        else if (typeCode.Equals(EstbTypeConstants.CIRCULAR))
        {
            _typeCodeDesc = "Circular";
        }
        else if (typeCode.Equals(EstbTypeConstants.DOWNLOAD))
        {
            _typeCodeDesc = "Downloadable";
        }
        else if (typeCode.Equals(EstbTypeConstants.IQAC))
        {
            _typeCodeDesc = "IQAC";
        }
        else if (typeCode.Equals(EstbTypeConstants.MoM))
        {
            _typeCodeDesc = "Minutes of Meeting";
        }
        else if (typeCode.Equals(EstbTypeConstants.NOTICE))
        {
            _typeCodeDesc = "Notice";
        }
        else if (typeCode.Equals(EstbTypeConstants.PHOTO))
        {
            _typeCodeDesc = "Photo";
        }
        else if (typeCode.Equals(EstbTypeConstants.RECENT_ACTIVITY))
        {
            _typeCodeDesc = "Recent Activity";
        }
        else if (typeCode.Equals(EstbTypeConstants.SYLLABUS))
        {
            _typeCodeDesc = "Syllabus";
        }
        else if (typeCode.Equals(EstbTypeConstants.TENDER))
        {
            _typeCodeDesc = "Tender";
        }
        else if (typeCode.Equals(EstbTypeConstants.VIDEO))
        {
            _typeCodeDesc = "Video";
        }
        else if (typeCode.Equals(EstbTypeConstants.WORLDBANK))
        {
            _typeCodeDesc = "World Bank";
        }
        else if (typeCode.Equals(EstbTypeConstants.NAAC))
        {
            _typeCodeDesc = "NAAC";
        }
        else if (typeCode.Equals(EstbTypeConstants.ARTCLE))
        {
            _typeCodeDesc = "Article";
        }
        else if (typeCode.Equals(EstbTypeConstants.PROJECT_PAPER))
        {
            _typeCodeDesc = "Project Paper";
        }
        else if (typeCode.Equals(EstbTypeConstants.BOOK))
        {
            _typeCodeDesc = "Book";
        }
        else if (typeCode.Equals(EstbTypeConstants.AWARD))
        {
            _typeCodeDesc = "Award";
        }
        else if (typeCode.Equals(EstbTypeConstants.SEMINAR_PAPER))
        {
            _typeCodeDesc = "Seminar Paper";
        }
        else if (typeCode.Equals(EstbTypeConstants.STUDY_MATERIAL))
        {
            _typeCodeDesc = "Study Material";
        }
        else if (typeCode.Equals(EstbTypeConstants.LITERATURE))
        {
            _typeCodeDesc = "Literature";
        }
        else if (typeCode.Equals(EstbTypeConstants.STAFF_PROFILE))
        {
            _typeCodeDesc = "Staff Profile";
        }
        return _typeCodeDesc;
    }
    }
}
