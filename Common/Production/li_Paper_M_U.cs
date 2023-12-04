using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Paper_M_U
{
    public Li_Paper_M_U()
    {
    }

    public Li_Paper_M_U
        (
        
        int pap_U_ID, 
        string pap_U_Name, 
        string paperType 
         
        )
    {
      
        this.Pap_U_ID = pap_U_ID;
        this.Pap_U_Name = pap_U_Name;
        this.PaperType = paperType;
        
    }


  

    private int _pap_U_ID;
    public int Pap_U_ID
    {
        get { return _pap_U_ID; }
        set { _pap_U_ID = value; }
    }

    private string _pap_U_Name;
    public string Pap_U_Name
    {
        get { return _pap_U_Name; }
        set { _pap_U_Name = value; }
    }

    private string _paperType;
    public string PaperType
    {
        get { return _paperType; }
        set { _paperType = value; }
    }

}
