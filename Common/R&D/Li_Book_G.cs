using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Book_G
{
    public Li_Book_G()
    {
    }

    public Li_Book_G
        (
        
        int gID, 
        string gName, 
        string g_Detail 
         
        )
    {
        
        this.GID = gID;
        this.GName = gName;
        this.G_Detail = g_Detail;
        
    }

 

    private int _gID;
    public int GID
    {
        get { return _gID; }
        set { _gID = value; }
    }

    private string _gName;
    public string GName
    {
        get { return _gName; }
        set { _gName = value; }
    }

    private string _g_Detail;
    public string G_Detail
    {
        get { return _g_Detail; }
        set { _g_Detail = value; }
    }
 
}
