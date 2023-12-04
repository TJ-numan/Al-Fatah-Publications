using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
 
using System.Web;
using DAL;
using Common;


public class SqlLi_AdminUserProvider:DataAccessObject
{
	public SqlLi_AdminUserProvider()
    {
    }


    public bool DeleteLi_AdminUser(int li_AdminUserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ALFWEB_DeleteLi_AdminUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_AdminUserID", SqlDbType.Int).Value = li_AdminUserID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_AdminUser> GetAllLi_AdminUsers()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("ALFWEB_GetAllLi_AdminUsers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AdminUsersFromReader(reader);
        }
    }
    public List<Li_AdminUser> GetLi_AdminUsersFromReader(IDataReader reader)
    {
        List<Li_AdminUser> li_AdminUsers = new List<Li_AdminUser>();

        while (reader.Read())
        {
            li_AdminUsers.Add(GetLi_AdminUserFromReader(reader));
        }
        return li_AdminUsers;
    }

    public Li_AdminUser GetLi_AdminUserFromReader(IDataReader reader)
    {
        try
        {
            Li_AdminUser li_AdminUser = new Li_AdminUser
                (
                    
                    (int)reader["UserID"],
                    reader["UserName"].ToString(),
                    reader["Password"].ToString(),
                    (bool)reader["InRule"],
                    (bool)reader["UpRule"],
                    (int)reader["DelRule"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (bool)reader["IsActive"],
                    (bool)reader["IsSupAd"] 
                );
             return li_AdminUser;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_AdminUser GetLi_AdminUserByID(int li_AdminUserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("ALFWEB_GetLi_AdminUserByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_AdminUserID", SqlDbType.Int).Value = li_AdminUserID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AdminUserFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_AdminUser(Li_AdminUser li_AdminUser)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ALFWEB_InsertLi_AdminUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@UserID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = li_AdminUser.UserName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = li_AdminUser.Password;
            cmd.Parameters.Add("@InRule", SqlDbType.Bit).Value = li_AdminUser.InRule;
            cmd.Parameters.Add("@UpRule", SqlDbType.Bit).Value = li_AdminUser.UpRule;
            cmd.Parameters.Add("@DelRule", SqlDbType.Int).Value = li_AdminUser.DelRule;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AdminUser.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AdminUser.CreatedBy;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = li_AdminUser.IsActive;
            cmd.Parameters.Add("@IsSupAd", SqlDbType.Bit).Value = li_AdminUser.IsSupAd;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@UserID"].Value;
        }
    }

    public bool UpdateLi_AdminUser(Li_AdminUser li_AdminUser)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ALFWEB_UpdateLi_AdminUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = li_AdminUser.UserID;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = li_AdminUser.UserName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = li_AdminUser.Password;
            cmd.Parameters.Add("@InRule", SqlDbType.Bit).Value = li_AdminUser.InRule;
            cmd.Parameters.Add("@UpRule", SqlDbType.Bit).Value = li_AdminUser.UpRule;
            cmd.Parameters.Add("@DelRule", SqlDbType.Int).Value = li_AdminUser.DelRule;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AdminUser.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AdminUser.CreatedBy;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = li_AdminUser.IsActive;
            cmd.Parameters.Add("@IsSupAd", SqlDbType.Bit).Value = li_AdminUser.IsSupAd;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetUserInfo(string userName, string password)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_SMPM_li_Get_EmployeeByUserName", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@VerSion", SqlDbType.Int).Value =  0;
            connection.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(ds);

            return ds;
        }

    }

    public DataSet GetUserAccess(int UserID, string FormId)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetUser_Access", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
            command.Parameters.Add("@FormID", SqlDbType.VarChar).Value = FormId;
            connection.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(ds);

            return ds;
        }

    }


    public int InsertLi_UserAccessLog(li_UserAccessLog li_UserAccessLog)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_UserAccessLog", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = li_UserAccessLog.UserId;
            cmd.Parameters.Add("@IPAdd", SqlDbType.VarChar).Value = li_UserAccessLog.IPAdd;
            cmd.Parameters.Add("@PhyAdd", SqlDbType.VarChar).Value = li_UserAccessLog.PhyAdd;
            cmd.Parameters.Add("@login_time", SqlDbType.DateTime).Value = li_UserAccessLog.login_time;
            cmd.Parameters.Add("@logout_time", SqlDbType.DateTime).Value = li_UserAccessLog.logout_time;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SlNo"].Value;
        }
    }

    public bool UpdateLi_UserAccessLog(li_UserAccessLog li_UserAccessLog)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_UserAccessLog", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = li_UserAccessLog.SlNo;
            //cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = li_UserAccessLog.UserId;
            //cmd.Parameters.Add("@IPAdd", SqlDbType.VarChar).Value = li_UserAccessLog.IPAdd;
            //cmd.Parameters.Add("@PhyAdd", SqlDbType.VarChar).Value = li_UserAccessLog.PhyAdd;
            //cmd.Parameters.Add("@login_time", SqlDbType.DateTime).Value = li_UserAccessLog.login_time;
            cmd.Parameters.Add("@logout_time", SqlDbType.DateTime).Value = li_UserAccessLog.logout_time;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public string UpdateLi_ChangePassword(int User_ID, string Name, string OldPassword, string NewPassword)
    {
        
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
             
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_ChangePasswordByUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = User_ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@OldPassword", SqlDbType.VarChar).Value = OldPassword;
            cmd.Parameters.Add("@NewPassword", SqlDbType.VarChar).Value =  NewPassword;
            cmd.Parameters.Add("@ExistUserID", SqlDbType.Int).Direction = ParameterDirection.Output;
            connection.Open();

            cmd.ExecuteNonQuery();
            return cmd.Parameters["@ExistUserID"].Value.ToString();
        }
    }
}
