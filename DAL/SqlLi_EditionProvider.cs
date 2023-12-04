using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
   public class SqlLi_EditionProvider:DataAccessObject
    {
       public List<BookEdition> GetAllEdition()
       {
           List<BookEdition> books = new List<BookEdition>();
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_GetAllBookEdition",connection);
               cmd.CommandType= CommandType.StoredProcedure;
               connection.Open();
               SqlDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   BookEdition aBookEdition = new BookEdition();
                   aBookEdition.Id = (int) reader["Id"];
                   aBookEdition.Edition = (string) reader["Edition"];
                   books.Add(aBookEdition);
               }
               reader.Close();
               connection.Close();
           }
           return books;
       }
    }
}
