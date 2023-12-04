using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_GodownReceiveSutli
{
    public Li_GodownReceiveSutli()
    {
    }

    public Li_GodownReceiveSutli
        (
       
        int receiveID, 
        int partyID, 
        DateTime receiveDate, 
        int receiveBy, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int qty  
         
        )
    {
         this.ReceiveID = receiveID;
        this.PartyID = partyID;
        this.ReceiveDate = receiveDate;
        this.ReceiveBy = receiveBy;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Qty = qty;
         
    }

 

    private int _receiveID;
    public int ReceiveID
    {
        get { return _receiveID; }
        set { _receiveID = value; }
    }

    private int _partyID;
    public int PartyID
    {
        get { return _partyID; }
        set { _partyID = value; }
    }

    private DateTime _receiveDate;
    public DateTime ReceiveDate
    {
        get { return _receiveDate; }
        set { _receiveDate = value; }
    }

    private int _receiveBy;
    public int ReceiveBy
    {
        get { return _receiveBy; }
        set { _receiveBy = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    
}
