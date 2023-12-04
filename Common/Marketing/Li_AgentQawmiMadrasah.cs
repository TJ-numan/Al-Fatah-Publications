using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_AgentQawmiMadrasah
{
    public Li_AgentQawmiMadrasah()
    {
    }

    public Li_AgentQawmiMadrasah
        (
  
        int agentID, 
        string agentName 
         
        )
    {
 
        this.AgentID = agentID;
        this.AgentName = agentName;
    
    }

 
    private int _agentID;
    public int AgentID
    {
        get { return _agentID; }
        set { _agentID = value; }
    }

    private string _agentName;
    public string AgentName
    {
        get { return _agentName; }
        set { _agentName = value; }
    }
 
}
