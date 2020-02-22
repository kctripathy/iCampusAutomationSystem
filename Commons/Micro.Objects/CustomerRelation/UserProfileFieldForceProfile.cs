using System;
using System.Drawing;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
   public class UserProfileFieldForceProfile
    {
        public int FieldForceID
        {
            get;
            set;
        }
        public Image SettingKeyValue
        {
            get;
            set;
        }
        public string SettingKeyDescription
        {
            get;
            set;
        }
        public DateTime DateModified
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
    }
}
