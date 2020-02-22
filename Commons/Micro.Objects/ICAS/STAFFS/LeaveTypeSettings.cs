using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STAFFS
{
    [Serializable]

    public class LeaveTypeSettings
    {
        public int LeaveTypeSettingID
        {
            get;
            set;
        }

        public int LeaveTypeID
        {
            get;
            set;
        }

        public string LeaveTypeDescription
        {
            get;
            set;
        }

        public string LeaveTypeAlias
        {
            get;
            set;
        }


        public int NumberOfDaysAllowed
        {
            get;
            set;
        }

        public int NumberOfConsecutiveDaysAllowed
        {
            get;
            set;
        }

        public int CreditPeriodInMonths
        {
            get;
            set;
        }

        public String ForGender
        {
            get;
            set;
        }

        public int MaximumAccumulatedDays
        {
            get;
            set;
        }

        public int CalculationMode
        {
            get;
            set;
        }

        public bool IsTransferrable
        {
            get;
            set;
        }

        public bool IsEncashable
        {
            get;
            set;
        }

        public DateTime EffectiveDate
        {
            get;
            set;
        }

        public string CreditInterval
        {
            get;
            set;
        }

        public int Quarter1
        {
            get;
            set;
        }

        public int Quarter2
        {
            get;
            set;
        }

        public int Quarter3
        {
            get;
            set;
        }

        public int Quarter4
        {
            get;
            set;
        }

        public int OfficeID
        {
            get;
            set;
        }

        public string OfficeName
        {
            get;
            set;
        }

        public int TotalNumberOfLeavesElligibleToAvail
        {
            get;
            set;
        }

        public string AccountingYear
        {
            get;
            set;
        }

        public string Quarter
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

    }
}
