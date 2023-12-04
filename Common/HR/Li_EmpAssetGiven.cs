using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpAssetGiven
{
    public Li_EmpAssetGiven()
    {
    }

    public Li_EmpAssetGiven
        (
        
        int uiTiId, 
        int empSl, 
        DateTime givenDate, 
        int reqNo, 
        int itemId, 
        decimal qty, 
        string moU, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.UiTiId = uiTiId;
        this.EmpSl = empSl;
        this.GivenDate = givenDate;
        this.ReqNo = reqNo;
        this.ItemId = itemId;
        this.Qty = qty;
        this.MoU = moU;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


  

    private int _uiTiId;
    public int UiTiId
    {
        get { return _uiTiId; }
        set { _uiTiId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private DateTime _givenDate;
    public DateTime GivenDate
    {
        get { return _givenDate; }
        set { _givenDate = value; }
    }

    private int _reqNo;
    public int ReqNo
    {
        get { return _reqNo; }
        set { _reqNo = value; }
    }

    private int _itemId;
    public int ItemId
    {
        get { return _itemId; }
        set { _itemId = value; }
    }

    private decimal _qty;
    public decimal Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private string _moU;
    public string MoU
    {
        get { return _moU; }
        set { _moU = value; }
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
