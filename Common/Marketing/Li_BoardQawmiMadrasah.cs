using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_BoardQawmiMadrasah
{
    public Li_BoardQawmiMadrasah()
    {
    }

    public Li_BoardQawmiMadrasah
        (
  
        int boardID, 
        string boardName 
         
        )
    {
 
        this.BoardID = boardID;
        this.BoardName = boardName;
     
    }


 

    private int _boardID;
    public int BoardID
    {
        get { return _boardID; }
        set { _boardID = value; }
    }

    private string _boardName;
    public string BoardName
    {
        get { return _boardName; }
        set { _boardName = value; }
    }

    
}
