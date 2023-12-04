using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonationDes
{
    public Li_DonationDes()
    {
    }

    public Li_DonationDes
        (
    
        int doDesId, 
        string doDescription, 
        bool isBdgIncluse
        )
    {
       
        this.DoDesId = doDesId;
        this.DoDescription = doDescription;
        this.IsBdgIncluse = isBdgIncluse;
    }

 
    private int _doDesId;
    public int DoDesId
    {
        get { return _doDesId; }
        set { _doDesId = value; }
    }

    private string _doDescription;
    public string DoDescription
    {
        get { return _doDescription; }
        set { _doDescription = value; }
    }

    private bool _isBdgIncluse;
    public bool IsBdgIncluse
    {
        get { return _isBdgIncluse; }
        set { _isBdgIncluse = value; }
    }
}
