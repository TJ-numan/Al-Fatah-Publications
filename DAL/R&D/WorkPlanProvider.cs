using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;


public    class WorkPlanProvider : DataAccessObject 
    {
     
     public  WorkPlanProvider()
         {
         }

     public DataSet GetSessionWiseBook( int Section,string Sess)
     {
         using (SqlConnection connection = new SqlConnection(this.ConnectionString))
         {
             SqlCommand command = new SqlCommand("SMPM_li_SectionSessionwiseBookList", connection);
             command.CommandType = CommandType.StoredProcedure;
             command.Parameters.Add("@SectionID", SqlDbType.Int).Value =  Section ;
             command.Parameters.Add("@Session", SqlDbType.VarChar).Value =  Sess ;
             connection.Open();

             DataSet ds = new DataSet();
             SqlDataAdapter sda = new SqlDataAdapter(command);
             sda.Fill(ds);

             return ds;
         }

     }

    }
 
