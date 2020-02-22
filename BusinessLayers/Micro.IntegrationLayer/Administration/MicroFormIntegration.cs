using System;
using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.IntegrationLayer.Administration
{
	public partial class MicroFormIntegration
	{
		#region Methods & Implementation
		public static MicroForm DataRowToObject(DataRow dr)
		{
			MicroForm TheMicroForm = new MicroForm
			{
				FormID = int.Parse(dr["FormID"].ToString()),
				FormName = dr["FormName"].ToString(),
				ActualFormName = dr["ActualFormName"].ToString(),
				ActualFormClassName = dr["ActualFormClassName"].ToString(),
				ModuleID = int.Parse(dr["ModuleID"].ToString()),
				ModuleName=dr["ModuleName"].ToString(),
				IsActive = bool.Parse(dr["IsActive"].ToString()),
				IsDeleted = bool.Parse(dr["IsDeleted"].ToString())
			};

			return TheMicroForm;
		}

		public static List<MicroForm> GetMicroForms()
		{
			List<MicroForm> MicroFormList = new List<MicroForm>();
			DataTable MicroFormTable = MicroFormDataAccess.GetInstance.GetMicroForms();

			foreach(DataRow dr in MicroFormTable.Rows)
			{
				MicroForm TheMicroForm = DataRowToObject(dr);

				MicroFormList.Add(TheMicroForm);
			}

			return MicroFormList;
		}

		public static List<MicroForm> GetMicroFormsByModuleMenuText(string moduleMenuText)
		{
			List<MicroForm> MicroFormList = new List<MicroForm>();
			DataTable MicroFormTable = MicroFormDataAccess.GetInstance.GetMicroFormsByModuleMenuText(moduleMenuText);

			foreach(DataRow dr in MicroFormTable.Rows)
			{
				MicroForm TheMicroForm = DataRowToObject(dr);

				MicroFormList.Add(TheMicroForm);
			}

			return MicroFormList;
		}

		public static MicroForm GetMicroFormByName(string formName)
		{
			MicroForm TheMicroForm;
			DataRow MicroFormDataRow = MicroFormDataAccess.GetInstance.GetMicroFormByName(formName);

			if(MicroFormDataRow != null)
				TheMicroForm = DataRowToObject(MicroFormDataRow);
			else
				TheMicroForm = new MicroForm();

			return TheMicroForm;
		}

		public static MicroForm GetMicroFormByActualName(string actualFormName)
		{
			MicroForm TheMicroForm;
			DataRow MicroFormDataRow = MicroFormDataAccess.GetInstance.GetMicroFormByActualName(actualFormName);

			if(MicroFormDataRow != null)
				TheMicroForm = DataRowToObject(MicroFormDataRow);
			else
				TheMicroForm = new MicroForm();

			return TheMicroForm;
		}

		public static void UpdateRecords(List<MicroForm> microFormUpdateList)
		{
			MicroFormDataAccess.GetInstance.UpdateRecords(microFormUpdateList);
		}
		#endregion
	}
}
