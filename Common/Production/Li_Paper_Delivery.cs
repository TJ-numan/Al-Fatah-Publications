using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Paper_Delivery
{
    public Li_Paper_Delivery()
    {
    }

    public Li_Paper_Delivery
        (
        
        string invNo, 
        string supplierID, 
        string billNo, 
        DateTime billDate, 
        decimal amount, 
        int createdBy, 
        DateTime createdDate, 
        char status_D, 
        int deletBy, 
        DateTime deleteDate, 
        string causeOFDel, 
        string remark  ,
        decimal lay_Cost,
        string purchase_OrderNo
         
        )
    {
         
        this.InvNo = invNo;
        this.SupplierID = supplierID;
        this.BillNo = billNo;
        this.BillDate = billDate;
        this.Amount = amount;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.Status_D = status_D;
        this.DeletBy = deletBy;
        this.DeleteDate = deleteDate;
        this.CauseOFDel = causeOFDel;
        this.Remark = remark;
        this.Lay_Cost = lay_Cost;
        this.Purchase_OrderNo = purchase_OrderNo;
         
    }

    public string Purchase_OrderNo { get; set; }

    public decimal Lay_Cost { get; set; }

    private string _invNo;
    public string InvNo
    {
        get { return _invNo; }
        set { _invNo = value; }
    }

    private string _supplierID;
    public string SupplierID
    {
        get { return _supplierID; }
        set { _supplierID = value; }
    }

    private string _billNo;
    public string BillNo
    {
        get { return _billNo; }
        set { _billNo = value; }
    }

    private DateTime _billDate;
    public DateTime BillDate
    {
        get { return _billDate; }
        set { _billDate = value; }
    }

    private decimal _amount;
    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
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

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private int  _deletBy;
    public  int DeletBy
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

    private string _remark;
    public string Remark
    {
        get { return _remark; }
        set { _remark = value; }
    }

   
}
