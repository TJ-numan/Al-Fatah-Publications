using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   public   class li_GetAlwaysTotalRow : DataAccessObject
    {
       public li_GetAlwaysTotalRow()
       {
       }


       public static int getTotalLibOwnerRow()
       {
           DataAccessObject dsa = new DataAccessObject();
           using (SqlConnection connection = new SqlConnection(dsa.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_GetNext_LibraryOwner", connection);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@lastin", SqlDbType.Int).Direction = ParameterDirection.Output;

               connection.Open();

               int result = cmd.ExecuteNonQuery();

             return  (int )cmd.Parameters["@lastin"].Value;
           }
       }



       public static int getTotalLibRow()
       {
           DataAccessObject dsa = new DataAccessObject();
           using (SqlConnection connection = new SqlConnection(dsa.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_GetNext_Library", connection);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@lastin", SqlDbType.Int).Direction = ParameterDirection.Output;

               connection.Open();

               int result = cmd.ExecuteNonQuery();

               return (int)cmd.Parameters["@lastin"].Value;
           }
       }
       
       
       public static int getTotalBookRow()
       {
           DataAccessObject dsa = new DataAccessObject();
           using (SqlConnection connection = new SqlConnection(dsa.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_GetNext_Book", connection);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@lastin", SqlDbType.Int).Direction = ParameterDirection.Output;

               connection.Open();

               int result = cmd.ExecuteNonQuery();

               return (int)cmd.Parameters["@lastin"].Value;
           }
       }
    }
}
