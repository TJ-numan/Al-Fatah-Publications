using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

public class Li_PaperReturn
{
    public Li_PaperReturn()
    {
    }

    public Li_PaperReturn
        (

        int retNo,
        DateTime retDate, 
        string prssFrom,
        string supplTo, 
        decimal totalBill, 
        decimal labourBill, 
        string remark, 
        DateTime createdDate, 
        int createdBy,
        DateTime modifiedDate,
        int modifiedBy,
        char status_D, 
        int deletBy, 
        DateTime deleteDate, 
        string causeOFDel
         
        )
    {
        this.RetNo = retNo;
        this.RetDate = retDate;
        this.PrssFrom = prssFrom;
        this.SupplTo = supplTo;
        this.TotalBill = totalBill;
        this.LabourBill = labourBill;
        this.Remark = remark;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.ModifiedDate = modifiedDate;
        this.ModifiedBy = modifiedBy;
        this.Status_D = status_D;
        this.DeletBy = deletBy;
        this.DeleteDate = deleteDate;
        this.CauseOFDel = causeOFDel;
       
    }

 

    private int _retNo;
    public int RetNo
    {
        get { return _retNo; }
        set { _retNo = value; }
    }

    private DateTime _retDate;
    public DateTime RetDate
    {
        get { return _retDate; }
        set { _retDate = value; }
    }

    private string _prssFrom;
    public string PrssFrom
    {
        get { return _prssFrom; }
        set { _prssFrom = value; }
    }

    private string _supplTo;
    public string SupplTo
    {
        get { return _supplTo; }
        set { _supplTo = value; }
    }

    private decimal _totalBill;
    public decimal TotalBill
    {
        get { return _totalBill; }
        set { _totalBill = value; }
    }

    private decimal _labourBill;
    public decimal LabourBill
    {
        get { return _labourBill; }
        set { _labourBill = value; }
    }

    private string _remark;
    public string Remark
    {
        get { return _remark; }
        set { _remark = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }
    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }
    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private int _deletBy;
    public int DeletBy
    {
        get { return _deletBy; }
        set { _deletBy = value; }
    }

    private DateTime _deleteDate;
    public DateTime DeleteDate
    {
        get { return _deleteDate; }
        set { _deleteDate = value; }
    }

    private string _causeOFDel;
    public string CauseOFDel
    {
        get { return _causeOFDel; }
        set { _causeOFDel = value; }
    }
 
}
