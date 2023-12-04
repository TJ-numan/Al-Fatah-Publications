using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LeminationOrderPrint
{
    public Li_LeminationOrderPrint()
    {
    }

    public Li_LeminationOrderPrint
        (
        
        string orderNo, 
        DateTime orderDate, 
        DateTime createdDate, 
        int createdBy, 
        char status_D, 
        DateTime deleDate, 
        string causeOfDel, 
        int deleBy  
         
        )
    {
       
        this.OrderNo = orderNo;
        this.OrderDate = orderDate;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.Status_D = status_D;
        this.DeleDate = deleDate;
        this.CauseOfDel = causeOfDel;
        this.DeleBy = deleBy;
        
    }


    

    private string _orderNo;
    public string OrderNo
    {
        get { return _orderNo; }
        set { _orderNo = value; }
    }

    private DateTime _orderDate;
    public DateTime OrderDate
    {
        get { return _orderDate; }
        set { _orderDate = value; }
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

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private DateTime _deleDate;
    public DateTime DeleDate
    {
        get { return _deleDate; }
        set { _deleDate = value; }
    }

    private string _causeOfDel;
    public string CauseOfDel
    {
        get { return _causeOfDel; }
        set { _causeOfDel = value; }
    }

    private int _deleBy;
    public int DeleBy
    {
        get { return _deleBy; }
        set { _deleBy = value; }
    }

   
}
