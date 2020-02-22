using System;

namespace Micro.Objects.CustomerRelation
{[Serializable]
    public class DCDeviceAllotment
    {
    public int DCDeviceAllotmentID
    {
        get;
        set;
    }
    public int DCDeviceID
    {
        get;
        set;
    }
    public int DCCollectorID
    {
        get;
        set;
    }
    public string EffectiveDateFrom
    {
        get;
        set;
    }
    public string EffectiveDateTo
    {
        get;
        set;
    }
    public int OfficeID
    {
        get;
        set;
    }
    public string DateAdded
    {
        get;
        set;
    }
    public int AddedBy
    {
        get;
        set;
    }
    public string DateModified
    {
        get;
        set;
    }
    public int ModifiedBy
    {
        get;
        set;
    }
    public string DCDeviceCode
    {
        get;
        set;
    }
    public string DCDeviceSerialNumber
    {
        get;
        set;
    }
  
    public string DCCollectorName
    {
        get;
        set;
    }
   

    }
}
