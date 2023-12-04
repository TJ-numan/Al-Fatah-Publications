using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

public class DataAccessObject
{

    public string ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
    SqlConnectionStringBuilder builder;
    public string ServerName { get; set; }
    public string DatabaseName { get; set; }
    public string UserID { get; set; }
    public string Password { get; set; }    
    public DataAccessObject()
    {
        builder = new SqlConnectionStringBuilder(ConnectionString);
        ServerName = builder.DataSource;
        DatabaseName = builder.InitialCatalog;
        UserID = builder.UserID;
        Password = builder.Password;
    }
  
}

