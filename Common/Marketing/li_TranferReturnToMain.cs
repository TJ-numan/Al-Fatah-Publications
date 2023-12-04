using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_TranferReturnToMain
{
    public Li_TranferReturnToMain()
    {
    }

    public Li_TranferReturnToMain
        (
       
        string iD, 
        int memoNo, 
        decimal amountTotal, 
        int createdby, 
        DateTime transferDate, 
        DateTime createdDate, 
        char status_D, 
        string delete_Cause, 
        int? deleteBy, 
        DateTime? dateOfDelete  
         
        )
    {
       
        this.ID = iD;
        this.MemoNo = memoNo;
        this.AmountTotal = amountTotal;
        this.Createdby = createdby;
        this.TransferDate = transferDate;
        this.CreatedDate = createdDate;
        this.Status_D = status_D;
        this.Delete_Cause = delete_Cause;
        this.DeleteBy = deleteBy;
        this.DateOfDelete = dateOfDelete;
        
    }

     

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private int _memoNo;
    public int MemoNo
    {
        get { return _memoNo; }
        set { _memoNo = value; }
    }

    private decimal _amountTotal;
    public decimal AmountTotal
    {
        get { return _amountTotal; }
        set { _amountTotal = value; }
    }

    private int _createdby;
    public int Createdby
    {
        get { return _createdby; }
        set { _createdby = value; }
    }

    private DateTime _transferDate;
    public DateTime TransferDate
    {
        get { return _transferDate; }
        set { _transferDate = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private string _delete_Cause;
    public string Delete_Cause
    {
        get { return _delete_Cause; }
        set { _delete_Cause = value; }
    }

    private int? _deleteBy;
    public int? DeleteBy
    {
        get { return _deleteBy; }
        set { _deleteBy = value; }
    }

    private DateTime? _dateOfDelete;
    public DateTime? DateOfDelete
    {
        get { return _dateOfDelete; }
        set { _dateOfDelete = value; }
    }

    
}
