using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_ProductionInnerPaper
{
    public Li_ProductionInnerPaper()
    {
    }

    public Li_ProductionInnerPaper
        (
        
        string bookCode, 
        string innerSize, 
        int art4Qty, 
        string art4QtyWeight, 
        string art4QtyBrand, 
        int offset4Qty, 
        string offset4QtyWeight, 
        string offset4QtyBrand, 
        int offset2Qty, 
        string offset2QtyWeight, 
        string offset2QtyBrand, 
        int newsQty, 
        string newsQtyWeight, 
        string newsQtyBrand  
         
        )
    {
        
        this.BookCode = bookCode;
        this.InnerSize = innerSize;
        this.Art4Qty = art4Qty;
        this.Art4QtyWeight = art4QtyWeight;
        this.Art4QtyBrand = art4QtyBrand;
        this.Offset4Qty = offset4Qty;
        this.Offset4QtyWeight = offset4QtyWeight;
        this.Offset4QtyBrand = offset4QtyBrand;
        this.Offset2Qty = offset2Qty;
        this.Offset2QtyWeight = offset2QtyWeight;
        this.Offset2QtyBrand = offset2QtyBrand;
        this.NewsQty = newsQty;
        this.NewsQtyWeight = newsQtyWeight;
        this.NewsQtyBrand = newsQtyBrand;
         
    }


  

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _innerSize;
    public string InnerSize
    {
        get { return _innerSize; }
        set { _innerSize = value; }
    }

    private int _art4Qty;
    public int Art4Qty
    {
        get { return _art4Qty; }
        set { _art4Qty = value; }
    }

    private string _art4QtyWeight;
    public string Art4QtyWeight
    {
        get { return _art4QtyWeight; }
        set { _art4QtyWeight = value; }
    }

    private string _art4QtyBrand;
    public string Art4QtyBrand
    {
        get { return _art4QtyBrand; }
        set { _art4QtyBrand = value; }
    }

    private int _offset4Qty;
    public int Offset4Qty
    {
        get { return _offset4Qty; }
        set { _offset4Qty = value; }
    }

    private string _offset4QtyWeight;
    public string Offset4QtyWeight
    {
        get { return _offset4QtyWeight; }
        set { _offset4QtyWeight = value; }
    }

    private string _offset4QtyBrand;
    public string Offset4QtyBrand
    {
        get { return _offset4QtyBrand; }
        set { _offset4QtyBrand = value; }
    }

    private int _offset2Qty;
    public int Offset2Qty
    {
        get { return _offset2Qty; }
        set { _offset2Qty = value; }
    }

    private string _offset2QtyWeight;
    public string Offset2QtyWeight
    {
        get { return _offset2QtyWeight; }
        set { _offset2QtyWeight = value; }
    }

    private string _offset2QtyBrand;
    public string Offset2QtyBrand
    {
        get { return _offset2QtyBrand; }
        set { _offset2QtyBrand = value; }
    }

    private int _newsQty;
    public int NewsQty
    {
        get { return _newsQty; }
        set { _newsQty = value; }
    }

    private string _newsQtyWeight;
    public string NewsQtyWeight
    {
        get { return _newsQtyWeight; }
        set { _newsQtyWeight = value; }
    }

    private string _newsQtyBrand;
    public string NewsQtyBrand
    {
        get { return _newsQtyBrand; }
        set { _newsQtyBrand = value; }
    }

     
}
