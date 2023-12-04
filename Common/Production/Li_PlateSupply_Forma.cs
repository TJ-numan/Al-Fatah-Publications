using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateSupply_Forma
{
    public Li_PlateSupply_Forma()
    {
    }

    public Li_PlateSupply_Forma
        (
         
        string plate_SID, 
       
        string print_OID, 
        string bookCode, 
        decimal plateQty, 
        decimal plateBill, 
        decimal processBill, 
        decimal totalAmount, 
        DateTime createdDate, 
        int createdBy ,
        bool isExtra,
        string plateFor
         
        )
    {
       
        this.Plate_SID = plate_SID;
       
        this.Print_OID = print_OID;
        this.BookCode = bookCode;
        this.PlateQty = plateQty;
        this.PlateBill = plateBill;
        this.ProcessBill = processBill;
        this.TotalAmount = totalAmount;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.IsExtra = isExtra;
        this.PlateFor = plateFor;
    }

    public string PlateFor { get; set; }
    public  bool IsExtra { get; set; }

    private string _plate_SID;
    public string Plate_SID
    {
        get { return _plate_SID; }
        set { _plate_SID = value; }
    }

  

    private string _print_OID;
    public string Print_OID
    {
        get { return _print_OID; }
        set { _print_OID = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private decimal _plateQty;
    public decimal PlateQty
    {
        get { return _plateQty; }
        set { _plateQty = value; }
    }

    private decimal _plateBill;
    public decimal PlateBill
    {
        get { return _plateBill; }
        set { _plateBill = value; }
    }

    private decimal _processBill;
    public decimal ProcessBill
    {
        get { return _processBill; }
        set { _processBill = value; }
    }

    private decimal _totalAmount;
    public decimal TotalAmount
    {
        get { return _totalAmount; }
        set { _totalAmount = value; }
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

   
}
