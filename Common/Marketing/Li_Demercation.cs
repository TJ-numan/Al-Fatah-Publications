using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public class Li_Demercation
{
    public Li_Demercation()
    {
    }

    public Li_Demercation
        (
       
        int demID, 
        string demName
         
        )
    {
       
        this.DemID = demID;
        this.DemName = demName;
    }

    private int _demID;
    public int DemID
    {
        get { return _demID; }
        set { _demID = value; }
    }

    private string _demName;
    public string DemName
    {
        get { return _demName; }
        set { _demName = value; }
    }

}

}
