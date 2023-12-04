using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_BinderReturn
{
    public Li_BinderReturn()
    {
    }

    public Li_BinderReturn
        (
     
        string receiveID, 
        string binderID, 
        DateTime receiveDate, 
        decimal totalQty, 
        DateTime createdDate, 
        int createdBy, 
        char statud_D  
         
        )
    {
     
        this.ReceiveID = receiveID;
        this.BinderID = binderID;
        this.ReceiveDate = receiveDate;
        this.TotalQty = totalQty;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.Statud_D = statud_D;
       
    }


 

    private string _receiveID;
    public string ReceiveID
    {
        get { return _receiveID; }
        set { _receiveID = value; }
    }

    private string _binderID;
    public string BinderID
    {
        get { return _binderID; }
        set { _binderID = value; }
    }

    private DateTime _receiveDate;
    public DateTime ReceiveDate
    {
        get { return _receiveDate; }
        set { _receiveDate = value; }
    }

    private decimal _totalQty;
    public decimal TotalQty
    {
        get { return _totalQty; }
        set { _totalQty = value; }
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

    private char _statud_D;
    public char Statud_D
    {
        get { return _statud_D; }
        set { _statud_D = value; }
    }

}
