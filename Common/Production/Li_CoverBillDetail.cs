using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_CoverBillDetail
{
    public Li_CoverBillDetail()
    {
    }

    public Li_CoverBillDetail
        (
       
        string billNo, 
        decimal qty, 
        string receiveID
         
        )
    {
        
        this.BillNo = billNo;
        this.Qty = qty;
        this.ReceiveID = receiveID;
       
    }


  

    private string _billNo;
    public string BillNo
    {
        get { return _billNo; }
        set { _billNo = value; }
    }

    private decimal _qty;
    public decimal Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private string _receiveID;
    public string ReceiveID
    {
        get { return _receiveID; }
        set { _receiveID = value; }
    }


}
