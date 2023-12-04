using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

public class Li_PlateDamageDetail
{
    public Li_PlateDamageDetail()
    {
    }
    public Li_PlateDamageDetail    
        (
        
        int sl,
        string pdm_ID,  
        string plateTypeID, 
        string plateSizeID, 
        int    qty, 
        decimal billRate,
        string refno
         
        )
    {
         
        this.Sl = sl;
        this.PDM_ID = pdm_ID;
        this.PlateTypeID = plateTypeID;
        this.PlateSizeID = plateSizeID;
        this.Qty = qty;
        this.BillRate = billRate;
        this.Refno = refno;
    }
    public string Refno { get; set; }
 
    private int _sl;
    public int Sl
    {
        get { return _sl; }
        set { _sl = value; }
    }

    private string _pdm_ID;
    public string PDM_ID
    {
        get { return _pdm_ID; }
        set { _pdm_ID = value; }
    }
    private string _plateTypeID;
    public string PlateTypeID
    {
        get { return _plateTypeID; }
        set { _plateTypeID = value; }
    }

    private string _plateSizeID;
    public string PlateSizeID
    {
        get { return _plateSizeID; }
        set { _plateSizeID = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private decimal _billRate;
    public decimal BillRate
    {
        get { return _billRate; }
        set { _billRate = value; }
    }

     
}

