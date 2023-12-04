using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;

public class SqlLi_LibraryInformationProvider:DataAccessObject
{
	public SqlLi_LibraryInformationProvider()
    {
    }


    public bool DeleteLi_LibraryInformation(int li_LibraryInformationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_LibraryInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_LibraryInformationID", SqlDbType.Int).Value = li_LibraryInformationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LibraryInformation> GetAllLi_LibraryInformations()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ComboSourceData_LibraryInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LibraryInformationsFromReader(reader);
        }
    }



    public List<Li_LibraryInformation> GetLi_LibraryInformationsFromReader(IDataReader reader)
    {
        List<Li_LibraryInformation> li_LibraryInformations = new List<Li_LibraryInformation>();

        while (reader.Read())
        {
            li_LibraryInformations.Add(GetLi_LibraryInformationFromReader(reader));
        }
        return li_LibraryInformations;
    }


    public List<Li_LibraryInformation> GetAll_ComboBox_LibraryInformations()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ComboSourceData_LibraryInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_LibraryInformations_ComboBoxFromReader(reader);
        }
    }
    public DataSet GetAll_ComboBox_LibraryInformationsByUser(int UserId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ComboSourceData_LibraryInformationsByUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetAll_ComboBox_QCashLibraryInformationsByUser(int UserId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ComboSourceData_QCashLibraryInformationsByUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<Li_LibraryInformation> Get_LibraryInformations_ComboBoxFromReader(IDataReader reader)
    {
        List<Li_LibraryInformation> li_LibraryInformations = new List<Li_LibraryInformation>();

        while (reader.Read())
        {
            li_LibraryInformations.Add(Get_LibraryInformation_ComboBoxFromReader(reader));
        }
        return li_LibraryInformations;
    }



    public Li_LibraryInformation Get_LibraryInformation_ComboBoxFromReader(IDataReader reader)
    {
        try
        {
            Li_LibraryInformation li_LibraryInformation = new Li_LibraryInformation
                (
                
                reader["LibraryID"].ToString(),
                reader["LibraryName"].ToString() 

                );
            return li_LibraryInformation;
        }
        catch (Exception ex)
        {
            return null;
        }
    }








    public Li_LibraryInformation GetLi_LibraryInformationFromReader(IDataReader reader)
    {
        try
        {
            Li_LibraryInformation li_LibraryInformation = new Li_LibraryInformation
                (
                     
                    reader["LibraryID"].ToString(),
                    reader["LibraryName"].ToString(),
                    reader["LibraryAddress"].ToString(),
                    reader["ShortAddress"].ToString(),
                    (bool)reader["AnualBonusBase"],
                    (int)reader["Type"],
                    reader["Category"].ToString(),
                    reader["Telephone"].ToString(),
                    reader["LibraryOwnerName"].ToString(),
                    reader["SalesPersonID"].ToString(),
                    (int)reader["RegionID"],
                    (int)reader["AreaID"],
                     reader["TeritoryID"].ToString(),
                    (int)reader["DistrictID"],
                    (int)reader["ThanaID"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModefiedDate"],
                    reader["Lib_Bn"].ToString(),
                    reader["LibAdd_Bn"].ToString(),
                    reader["ShAdd_Bn"].ToString(),
                    (char)reader["Status"],
                    (int)reader["DeleBy"],
                    (DateTime)reader["DeleDate"] 
                );
             return li_LibraryInformation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LibraryInformation GetLi_LibraryInformationByID(int li_LibraryInformationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_LibraryInformationByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_LibraryInformationID", SqlDbType.Int).Value = li_LibraryInformationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LibraryInformationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public String  InsertLi_LibraryInformation(Li_LibraryInformation li_LibraryInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_LibraryInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;            //cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryID;
            cmd.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryName;
            cmd.Parameters.Add("@LibraryAddress", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryAddress;
            cmd.Parameters.Add("@ShortAddress", SqlDbType.VarChar).Value = li_LibraryInformation.ShortAddress;
            cmd.Parameters.Add("@AnualBonusBase", SqlDbType.Bit).Value = li_LibraryInformation.AnualBonusBase;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = li_LibraryInformation.Type;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = li_LibraryInformation.Category;
            cmd.Parameters.Add("@Telephone", SqlDbType.VarChar).Value = li_LibraryInformation.Telephone;
            cmd.Parameters.Add("@LibraryOwnerName", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryOwnerName;
            cmd.Parameters.Add("@SalesPersonID", SqlDbType.VarChar).Value = li_LibraryInformation.SalesPersonID;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = li_LibraryInformation.RegionID;
            cmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = li_LibraryInformation.AreaID;
            cmd.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = li_LibraryInformation.TeritoryID;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = li_LibraryInformation.DistrictID;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = li_LibraryInformation.ThanaID;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LibraryInformation.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LibraryInformation.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LibraryInformation.ModifiedBy;
            cmd.Parameters.Add("@ModefiedDate", SqlDbType.DateTime).Value = li_LibraryInformation.ModefiedDate;
            cmd.Parameters.Add("@Lib_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.Lib_Bn;
            cmd.Parameters.Add("@LibAdd_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.LibAdd_Bn;
            cmd.Parameters.Add("@ShAdd_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.ShAdd_Bn;


            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@ReturnID"].Value.ToString();
        }
    }

    public bool UpdateLi_LibraryInformation(Li_LibraryInformation li_LibraryInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_LibraryInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryID;
            cmd.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryName;
            cmd.Parameters.Add("@LibraryAddress", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryAddress;
            cmd.Parameters.Add("@ShortAddress", SqlDbType.VarChar).Value = li_LibraryInformation.ShortAddress;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = li_LibraryInformation.Type;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = li_LibraryInformation.Category;
            cmd.Parameters.Add("@Telephone", SqlDbType.VarChar).Value = li_LibraryInformation.Telephone;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = li_LibraryInformation.DistrictID;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = li_LibraryInformation.ThanaID;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LibraryInformation.ModifiedBy;
            cmd.Parameters.Add("@ModefiedDate", SqlDbType.DateTime).Value = li_LibraryInformation.ModefiedDate;
            cmd.Parameters.Add("@Lib_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.Lib_Bn;
            cmd.Parameters.Add("@LibAdd_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.LibAdd_Bn;
            cmd.Parameters.Add("@ShAdd_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.ShAdd_Bn;
             
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet GetAll_LibraryInformationsWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_LibraryInformationsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }




    public DataSet GetSearchLibraryInformation(string LibraryName)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_SearchLibraryInformation", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@libraryName", SqlDbType.VarChar).Value = LibraryName;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet GetALLLibraryInformation(string LibraryName, string ID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_AllLibraryInformation", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@libraryID", SqlDbType.VarChar).Value = ID;
            command.Parameters.Add("@libraryName", SqlDbType.VarChar).Value = LibraryName;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet GetLibraryInformationByLibraryIDForEdit(string libID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetLibraryInformationByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@libraryID", SqlDbType.VarChar).Value = libID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet GetLibraryChalanReturnByLibraryID(string libID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_Agentwise_ChalanReturn", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = libID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetDakhilBonusByLibraryID(string libID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_DakhilBonusByLibraryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = libID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetALLLibraryInformationByLibraryID(string libID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetLibraryInformationByLibID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@libID", SqlDbType.VarChar).Value = libID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public Li_LibraryInformation Get_LibraryInformationByLibraryID(int libraryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_LibraryInformationByLibraryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LibraryID", SqlDbType.Int).Value = libraryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LibraryInformationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }


    public bool Delete_LibraryInformation(string libraryID, int userid)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_LibraryInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = libraryID;
            cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userid;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public void GetAllEmployee()
    {
       
    }
    //------------------------Rezaul Hossain---------------------
    public List<Li_LibraryInformation> GetAll_ComboBox_CashLibraryInformations()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ComboSourceData_LibraryInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_LibraryInformations_ComboBoxFromReader(reader);
        }
    }
}
