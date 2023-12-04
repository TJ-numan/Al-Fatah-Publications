using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_TransectionType
{
    public Li_TransectionType()
    {
    }

    public Li_TransectionType
        (
         
        int tannID, 
        string tranbType 
         
        )
    {
       
        this.TannID = tannID;
        this.TranbType = tranbType;
        
    }


  

    private int _tannID;
    public int TannID
    {
        get { return _tannID; }
        set { _tannID = value; }
    }

    private string _tranbType;
    public string TranbType
    {
        get { return _tranbType; }
        set { _tranbType = value; }
    }

    
}
