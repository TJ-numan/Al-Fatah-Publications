using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PayGrade
{
    public Li_PayGrade()
    {
    }

    public Li_PayGrade
        (
        
        int payGrId, 
        string payGrName, 
        decimal startAmt, 
        decimal endAmt, 
        string payGrDes, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
    
        this.PayGrId = payGrId;
        this.PayGrName = payGrName;
        this.StartAmt = startAmt;
        this.EndAmt = endAmt;
        this.PayGrDes = payGrDes;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 
    private int _payGrId;
    public int PayGrId
    {
        get { return _payGrId; }
        set { _payGrId = value; }
    }

    private string _payGrName;
    public string PayGrName
    {
        get { return _payGrName; }
        set { _payGrName = value; }
    }

    private decimal _startAmt;
    public decimal StartAmt
    {
        get { return _startAmt; }
        set { _startAmt = value; }
    }

    private decimal _endAmt;
    public decimal EndAmt
    {
        get { return _endAmt; }
        set { _endAmt = value; }
    }

    private string _payGrDes;
    public string PayGrDes
    {
        get { return _payGrDes; }
        set { _payGrDes = value; }
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
