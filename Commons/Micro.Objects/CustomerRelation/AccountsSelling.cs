using System;

namespace Micro.Objects.CustomerRelation
{   [Serializable]
    public class AccountsSelling
    {
    public int ShareSellingID
    {
        get;
        set;
    }
    public int CustomerID_Selling
    {
        get;
        set;
    }
    public int CustomerID_Buying
    {
        get;
        set;
    }
    public int AccountID
    {
        get;
        set;
    }
    public string SellingDate
    {
        get;
        set;
    }
    public int FieldForceID_Selling
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
    }
} 
