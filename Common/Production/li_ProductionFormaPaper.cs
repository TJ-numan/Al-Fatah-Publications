using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_ProductionFormaPaper
{
    public Li_ProductionFormaPaper()
    {
    }

    public Li_ProductionFormaPaper
        (
         
        string bookCode, 
        string formaPaper, 
        string formaColor, 
        string formaSize, 
        string formaWeight, 
        string formaBrand 
         
        )
    {
        
        this.BookCode = bookCode;
        this.FormaPaper = formaPaper;
        this.FormaColor = formaColor;
        this.FormaSize = formaSize;
        this.FormaWeight = formaWeight;
        this.FormaBrand = formaBrand;
         
    }


   

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _formaPaper;
    public string FormaPaper
    {
        get { return _formaPaper; }
        set { _formaPaper = value; }
    }

    private string _formaColor;
    public string FormaColor
    {
        get { return _formaColor; }
        set { _formaColor = value; }
    }

    private string _formaSize;
    public string FormaSize
    {
        get { return _formaSize; }
        set { _formaSize = value; }
    }

    private string _formaWeight;
    public string FormaWeight
    {
        get { return _formaWeight; }
        set { _formaWeight = value; }
    }

    private string _formaBrand;
    public string FormaBrand
    {
        get { return _formaBrand; }
        set { _formaBrand = value; }
    }

    
}
