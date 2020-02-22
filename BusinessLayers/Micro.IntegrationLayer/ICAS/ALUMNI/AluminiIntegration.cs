using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.Objects.ICAS.ALUMNI;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.ICAS.ALUMNI;

namespace Micro.IntegrationLayer.ICAS.ALUMNI
{
    public partial class AluminiIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static Alumini DataRowToObject(DataRow dr)
        {
            Alumini TheAlumini = new Alumini();

            TheAlumini.AluminiID = int.Parse(dr["AluminiID"].ToString());
            TheAlumini.AluminiCode = dr["AluminiCode"].ToString();
            TheAlumini.Salutation = dr["Salutation"].ToString();
            TheAlumini.AluminiName = dr["AluminiName"].ToString();
            TheAlumini.FatherName = dr["FatherName"].ToString();
            TheAlumini.MotherName = dr["MotherName"].ToString();
            TheAlumini.Gender = dr["Gender"].ToString();
            TheAlumini.Caste = dr["Caste"].ToString();
            TheAlumini.Status = dr["Status"].ToString();
            TheAlumini.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString()).ToString(MicroConstants.DateFormat);
            TheAlumini.DateOfAdmission = DateTime.Parse(dr["DateOfAdmission"].ToString()).ToString(MicroConstants.DateFormat);
            TheAlumini.DateOfLeaving = DateTime.Parse(dr["DateOfLeaving"].ToString()).ToString(MicroConstants.DateFormat);
            TheAlumini.Age = int.Parse(dr["Age"].ToString());
            TheAlumini.Address_Present_TownOrCity = dr["Address_Present_TownOrCity"].ToString();
            TheAlumini.Address_Present_Landmark = dr["Address_Present_Landmark"].ToString();
            TheAlumini.Address_Present_PinCode = dr["Address_Present_PinCode"].ToString();
            TheAlumini.Address_Present_DistrictID = int.Parse(dr["Address_Present_DistrictID"].ToString());
            if (dr["Address_Present_DistrictID"].ToString() != "")
            {
                TheAlumini.Address_Present_DistrictID = int.Parse(dr["Address_Present_DistrictID"].ToString());
                TheAlumini.Address_Present_DistrictName = dr["Address_Present_DistrictName"].ToString();
            }
            TheAlumini.Address_Present_StateName = dr["Address_Present_StateName"].ToString();
            TheAlumini.Address_Present_CountryName = dr["Address_Present_CountryName"].ToString();




            TheAlumini.Address_Permanent_TownOrCity = dr["Address_Permanent_TownOrCity"].ToString();
            TheAlumini.Address_Permanent_Landmark = dr["Address_Permanent_Landmark"].ToString();
            TheAlumini.Address_Permanent_PinCode = dr["Address_Permanent_PinCode"].ToString();
            TheAlumini.Address_Permanent_DistrictID = int.Parse(dr["Address_Permanent_DistrictID"].ToString());
            if (dr["Address_Permanent_DistrictID"].ToString() != "")
            {
                TheAlumini.Address_Permanent_DistrictID = int.Parse(dr["Address_Permanent_DistrictID"].ToString());
                TheAlumini.Address_Permanent_DistrictName = dr["Address_Permanent_DistrictName"].ToString();
            }
            TheAlumini.Address_Permanent_StateName = dr["Address_Permanent_StateName"].ToString();
            TheAlumini.Address_Permanent_CountryName = dr["Address_Permanent_CountryName"].ToString();

            TheAlumini.PhoneNumber = dr["PhoneNumber"].ToString();
            TheAlumini.Mobile = dr["Mobile"].ToString();
            TheAlumini.EMailID = dr["EmailID"].ToString();
            TheAlumini.OfficeID = int.Parse(dr["OfficeID"].ToString());

            return TheAlumini;
        }

        public static List<Alumini> GetAluminiList()
        {
            List<Alumini> AluminiList = new List<Alumini>();
            DataTable AluminiTable = AluminiDataAccess.GetInstance.GetAluminiList();
            foreach (DataRow dr in AluminiTable.Rows)
            {
                Alumini TheAlumini = DataRowToObject(dr);
                AluminiList.Add(TheAlumini);
            }
            return AluminiList;
        }
        public static int InsertAlumini(Alumini theAlumini)
        {
            return AluminiDataAccess.GetInstance.InsertAlumini(theAlumini);
        }
        public static int UpdateAlumini(Alumini theAlumini)
        {
            return AluminiDataAccess.GetInstance.UpdateAlumini(theAlumini);
        }
        public static int DeleteAlumini(Alumini theAlumini)
        {
            return AluminiDataAccess.GetInstance.DeleteAlumini(theAlumini);
        }
        #endregion
    }
}
