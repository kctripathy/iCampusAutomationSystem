using System;

namespace Micro.Objects.HumanResource
{
    [Serializable]
    public class BioMetricDevice
    {
        public int DeviceType
        {
            get;
            set;
        }

        public string DeviceSerialNo
        {
            get;
            set;
        }

        public string IPAddress
        {
            get;
            set;
        }

        public string AccessFilePath
        {
            get;
            set;
        }

        public string ExcelFilePath
        {
            get;
            set;
        }

        public string DataImportType
        {
            get;
            set;
        }

        public int DataImportMode
        {
            get;
            set;
        }

        public int DataExportMode
        {
            get;
            set;
        }

        public int ImportTime
        {
            get;
            set;
        }

        public int ExportTime
        {
            get;
            set;
        }

        public string  Version
        {
            get;
            set;
        }

        public int DeviceModule
        {
            get;
            set;
        }

        public string MACAddress
        {
            get;
            set;
        }

        public int DeviceNumber
        {
            get;
            set;
        }

        public int DateFormat
        {
            get;
            set;
        }

        public string DeviceCode
        {
            get;
            set;
        }

        public string  SDKVersion
        {
            get;
            set;
        }

        public int DataClear
        {
            get;
            set;
        }
    }
}
