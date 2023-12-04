using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Employee
{
    public Li_Employee()
    {
    }


    public Li_Employee
       (

       int employeeID,
       string name,      
       int   designationID,
       int  departmentID,      
       int   section
      

       )
    {

        this.EmployeeID = employeeID;
        this.Name = name;       
        this.DesignationID = designationID ;
        this.DepartmentID = departmentID;       
        this.Section = section;
      
    }








    public Li_Employee
        (
        
        int employeeID, 
        string name, 
        string address, 
        string phoneNo, 
        string cellNo, 
        string email, 
        int designationID, 
        int departmentID, 
        DateTime dateTime, 
        string userName, 
        string password, 
        int ruleID, 
        string bloodGroup, 
        string signature, 
        int section,
        decimal salary,
        string   grade
         
        )
    {
        
        this.EmployeeID = employeeID;
        this.Name = name;
        this.Address = address;
        this.PhoneNo = phoneNo;
        this.CellNo = cellNo;
        this.Email = email;
        this.DesignationID = designationID;
        this.DepartmentID = departmentID;
        this.DateTime = dateTime;
        this.UserName = userName;
        this.Password = password;
        this.RuleID = ruleID;
        this.BloodGroup = bloodGroup;
        this.Signature = signature;
        this.Section = section;
        this.Salary = salary;
        this.Grade = grade;
        
    }

 

    private int _employeeID;
    public int EmployeeID
    {
        get { return _employeeID; }
        set { _employeeID = value; }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private string _address;
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    private string _phoneNo;
    public string PhoneNo
    {
        get { return _phoneNo; }
        set { _phoneNo = value; }
    }

    private string _cellNo;
    public string CellNo
    {
        get { return _cellNo; }
        set { _cellNo = value; }
    }

    private string _email;
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    private int _designationID;
    public int DesignationID
    {
        get { return _designationID; }
        set { _designationID = value; }
    }

    private int _departmentID;
    public int DepartmentID
    {
        get { return _departmentID; }
        set { _departmentID = value; }
    }

    private DateTime _dateTime;
    public DateTime DateTime
    {
        get { return _dateTime; }
        set { _dateTime = value; }
    }

    private string _userName;
    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }

    private string _password;
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    private int _ruleID;
    public int RuleID
    {
        get { return _ruleID; }
        set { _ruleID = value; }
    }

    private string _bloodGroup;
    public string BloodGroup
    {
        get { return _bloodGroup; }
        set { _bloodGroup = value; }
    }

    private string _signature;
    public string Signature
    {
        get { return _signature; }
        set { _signature = value; }
    }

    private int _section;
    public int Section
    {
        get { return _section; }
        set { _section = value; }
    }
   private decimal _salary;
    public  decimal Salary
    {
        get { return _salary ; }
        set {  _salary = value; }
    }
 private string  _grade;
    public string   Grade
    {
        get { return _grade; }
        set { _grade = value; }
    }

}
