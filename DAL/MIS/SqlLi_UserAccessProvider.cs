using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common.MIS;

namespace DAL.MIS
{
   public class SqlLi_UserAccessProvider:DataAccessObject
    {
       public  List<Li_AdminUser> GetAllUser()
       {
           List<Li_AdminUser> users = new List<Li_AdminUser>();
           using (SqlConnection connection= new SqlConnection(this.ConnectionString))
           {
               SqlCommand command = new SqlCommand("GetAllUserName",connection);
               command.CommandType= CommandType.StoredProcedure;
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                   Li_AdminUser aUser = new Li_AdminUser();
                   aUser.UserName = (string) reader["Name"];
                   aUser.UserID = (int) reader["UserID"];
                   users.Add(aUser);
               }

               connection.Close();
           }
           return users;
       }

       public int InsertUserAccess(li_UserAccess access)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand command = new SqlCommand("SMPM_InsertUserAccess",connection);
               command.CommandType=CommandType.StoredProcedure;
               command.Parameters.Add("@UserId", SqlDbType.VarChar).Value = access.UserId;
               command.Parameters.Add("@FormId", SqlDbType.VarChar).Value = access.FormId;
               command.Parameters.Add("@View", SqlDbType.Bit).Value = access.View;
               command.Parameters.Add("@Insert", SqlDbType.Bit).Value = access.Insert;
               command.Parameters.Add("@Update", SqlDbType.Bit).Value = access.Update;
               command.Parameters.Add("@Delete", SqlDbType.Bit).Value = access.Delete;
               connection.Open();
               int affectedRows= command.ExecuteNonQuery();
               connection.Close();
               return affectedRows;              
           }
          
       }
    }
}
