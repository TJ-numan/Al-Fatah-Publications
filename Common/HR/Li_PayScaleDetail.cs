using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PayScaleDetail
{
    public Li_PayScaleDetail()
    {
    }

    public Li_PayScaleDetail
        (
         
        int pSDetId, 
        int pScId, 
        int paHId, 
        decimal amount
        )
    {
         
        this.PSDetId = pSDetId;
        this.PScId = pScId;
        this.PaHId = paHId;
        this.Amount = amount;
    }


 

    private int _pSDetId;
    public int PSDetId
    {
        get { return _pSDetId; }
        set { _pSDetId = value; }
    }

    private int _pScId;
    public int PScId
    {
        get { return _pScId; }
        set { _pScId = value; }
    }

    private int _paHId;
    public int PaHId
    {
        get { return _paHId; }
        set { _paHId = value; }
    }

    private decimal _amount;
    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
}
