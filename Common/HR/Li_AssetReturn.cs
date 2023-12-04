using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AssetReturn
{
    public Li_AssetReturn()
    {
    }

    public Li_AssetReturn
        (
      
        int assRelId, 
        int empSl, 
        string refNo, 
        int assetId, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.AssRelId = assRelId;
        this.EmpSl = empSl;
        this.RefNo = refNo;
        this.AssetId = assetId;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _assRelId;
    public int AssRelId
    {
        get { return _assRelId; }
        set { _assRelId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _refNo;
    public string RefNo
    {
        get { return _refNo; }
        set { _refNo = value; }
    }

    private int _assetId;
    public int AssetId
    {
        get { return _assetId; }
        set { _assetId = value; }
    }

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _infStId;
    public int InfStId
    {
        get { return _infStId; }
        set { _infStId = value; }
    }
}
