using System.Collections.Generic;
using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
    public partial class MicroFormManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static MicroFormManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static MicroFormManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MicroFormManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        public string DefaultColumn = "FormName, ActualFormName, ActualFormClassName";
        public string DisplayMember = "FormName";
        public string ValueMember = "FormID";
        #endregion

        #region Methods & Implementation
        public List<MicroForm> GetMicroForms()
        {
            return MicroFormIntegration.GetMicroForms();
        }

        public List<MicroForm> GetMicroFormsByModuleMenuText(string moduleMenuText)
        {
            return MicroFormIntegration.GetMicroFormsByModuleMenuText(moduleMenuText);
        }

        public MicroForm GetMicroFormByName(string formName)
        {
            return MicroFormIntegration.GetMicroFormByName(formName);
        }

        public MicroForm GetMicroFormByActualName(string actualFormName)
        {
            return MicroFormIntegration.GetMicroFormByActualName(actualFormName);
        }

        public void UpdateRecords(List<MicroForm> microFormUpdateList)
        {
            MicroFormIntegration.UpdateRecords(microFormUpdateList);
        }
        #endregion
    }
}
