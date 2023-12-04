using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateSupply
{
    public Li_PlateSupply()
    {
    }

    public Li_PlateSupply
        (
       
        int sl, 
        string printOrder, 
        string pressID, 
        string plateTID, 
        string plateSID, 
        int givenT, 
        int plateQty, 
        int createdBy, 
        DateTime createdDate ,
        decimal plateRate
         
        )
    {
        
        this.Sl = sl;
        this.PrintOrder = printOrder;
        this.PressID = pressID;
        this.PlateTID = plateTID;
        this.PlateSID = plateSID;
        this.GivenT = givenT;
        this.PlateQty = plateQty;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;

       
    }

    public decimal PlateRate { get; set; }

    private int _sl;
    public int Sl
    {
        get { return _sl; }
        set { _sl = value; }
    }

    private string _printOrder;
    public string PrintOrder
    {
        get { return _printOrder; }
        set { _printOrder = value; }
    }

    private string _pressID;
    public string PressID
    {
        get { return _pressID; }
        set { _pressID = value; }
    }

    private string _plateTID;
    public string PlateTID
    {
        get { return _plateTID; }
        set { _plateTID = value; }
    }

    private string _plateSID;
    public string PlateSID
    {
        get { return _plateSID; }
        set { _plateSID = value; }
    }

    private int _givenT;
    public int GivenT
    {
        get { return _givenT; }
        set { _givenT = value; }
    }

    private int _plateQty;
    public int PlateQty
    {
        get { return _plateQty; }
        set { _plateQty = value; }
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

    
}
