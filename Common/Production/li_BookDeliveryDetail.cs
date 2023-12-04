using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookDeliveryDetail
{
    public Li_BookDeliveryDetail()
    {
    }

    public Li_BookDeliveryDetail
        (
      
        bool isForma, 
        string binderId, 
        decimal qty, 
        char status_D, 
        int deID ,
        string startingNo,
        string endingNo
         
        )
    {
         
        this.IsForma = isForma;
        this.BinderId = binderId;
        this.Qty = qty;
        this.Status_D = status_D;
        this.DeID = deID;
        this.StartingNo = startingNo;
        this.EndingNo = endingNo;
        
    }

    public string StartingNo { get; set; }

    public string EndingNo { get; set; }

    private bool _isForma;
    public bool IsForma
    {
        get { return _isForma; }
        set { _isForma = value; }
    }

    private string _binderId;
    public string BinderId
    {
        get { return _binderId; }
        set { _binderId = value; }
    }

    private decimal _qty;
    public decimal Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private int _deID;
    public int DeID
    {
        get { return _deID; }
        set { _deID = value; }
    }
 
}
