using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlateBill
{
    public Li_PlateBill()
    {
    }

    public Li_PlateBill
        (
     
        int billSerial, 
        string billNo, 
        string supplierID, 
        decimal amount, 
        DateTime createdDate, 
        int createdBy, 
        char status_D 
         
        )
    {
      
        this.BillSerial = billSerial;
        this.BillNo = billNo;
        this.SupplierID = supplierID;
        this.Amount = amount;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.Status_D = status_D;
        
    }


 

    private int _billSerial;
    public int BillSerial
    {
        get { return _billSerial; }
        set { _billSerial = value; }
    }

    private string _billNo;
    public string BillNo
    {
        get { return _billNo; }
        set { _billNo = value; }
    }

    private string _supplierID;
    public string SupplierID
    {
        get { return _supplierID; }
        set { _supplierID = value; }
    }

    private decimal _amount;
    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
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
 
}
