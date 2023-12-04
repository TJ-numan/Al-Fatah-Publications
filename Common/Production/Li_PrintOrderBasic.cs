using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintOrderBasic
{
    public Li_PrintOrderBasic()
    {
    }

    public Li_PrintOrderBasic
        (
   
        int print_Sl, 
        string print_N 
         
        )
    {
  
        this.Print_Sl = print_Sl;
        this.Print_N = print_N;
        
    }

 
    private int _print_Sl;
    public int Print_Sl
    {
        get { return _print_Sl; }
        set { _print_Sl = value; }
    }

    private string _print_N;
    public string Print_N
    {
        get { return _print_N; }
        set { _print_N = value; }
    }

    
}
