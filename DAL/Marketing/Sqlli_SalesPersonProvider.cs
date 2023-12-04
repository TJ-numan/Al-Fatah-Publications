using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Common;
using Common.Marketing;
using DAL;

public class SqlLi_SalesPersonProvider : DataAccessObject
{
    public SqlLi_SalesPersonProvider()
    {
    }



    public List<Li_SalesPerson> GetAllLi_SalesPersons(string tsoName)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_SalesPersons_Modified", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@tsoName", SqlDbType.VarChar).Value = tsoName;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SalesPersonsFromReader(reader);
        }
    }

    public bool DeleteLi_SalesPerson(int li_SalesPersonID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_SalesPerson", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_SalesPersonID", SqlDbType.Int).Value = li_SalesPersonID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SalesPerson> GetLi_SalesPersonsByTerritory(string Territory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetTSOByTerritoryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.Add("@Ter", SqlDbType.VarChar).Value = Territory;
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SalesPersonsFromReader(reader);
        }
    }



    public List<Li_SalesPerson> GetLi_SalesPersonsFromReader(IDataReader reader)
    {
        List<Li_SalesPerson> li_SalesPersons = new List<Li_SalesPerson>();

        while (reader.Read())
        {
            li_SalesPersons.Add(GetLi_SalesPersonFromReader(reader));
        }
        return li_SalesPersons;
    }

    public Li_SalesPerson GetLi_SalesPersonFromReader(IDataReader reader)
    {
        try
        {
            Li_SalesPerson li_SalesPerson = new Li_SalesPerson
                (
                    reader["TSOID"].ToString(),
                    reader["EmployeeCode"].ToString(),
                    reader["Name"].ToString(),
                    reader["Mobile"].ToString(),
                    reader["EmailID"].ToString(),
                    reader["Address"].ToString(),
                    reader["TransportID"].ToString(),
                    reader["TransportID2"].ToString(),
                    (int)reader["RegionID"],
                    (int)reader["AreaID"],
                    reader["TeritoryID"].ToString(),
                    reader["ThanaID"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"]  
                  
                );
            return li_SalesPerson;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<Li_SalesPerson> GetLi_SalesPersonByID(string TerritotyID, bool showAll)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_SMPM_GetLi_SalesPersonByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TerritotyID", SqlDbType.VarChar).Value = TerritotyID;
            command.Parameters.Add("@IsShowAll", SqlDbType.Bit).Value = showAll;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


            return GetLi_SalesPersonsFromReader(reader);
        
        }
    }

    public string InsertLi_SalesPerson(Li_SalesPerson li_SalesPerson)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_SalesPerson", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TSOID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar).Value = li_SalesPerson.EmployeeCode;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_SalesPerson.Name;
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = li_SalesPerson.Mobile;
            cmd.Parameters.Add("EmailID", SqlDbType.VarChar).Value = li_SalesPerson.EmailID;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_SalesPerson.Address;
            cmd.Parameters.Add("@TransportID", SqlDbType.VarChar).Value = li_SalesPerson.TransportID;
            cmd.Parameters.Add("@TransportID2", SqlDbType.VarChar).Value = li_SalesPerson.TransportID2;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = li_SalesPerson.RegionID;
            cmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = li_SalesPerson.AreaID;
            cmd.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = li_SalesPerson.TeritoryID;
            cmd.Parameters.Add("@ThanaID", SqlDbType.VarChar).Value = li_SalesPerson.ThanaID;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_SalesPerson.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SalesPerson.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SalesPerson.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SalesPerson.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@TSOID"].Value.ToString();
        }
    }

    public int UpdateLi_SalesPerson(Li_SalesPerson li_SalesPerson)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_SalesPerson", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TSOID", SqlDbType.VarChar).Value = li_SalesPerson.TSOID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_SalesPerson.Name;
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = li_SalesPerson.Mobile;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_SalesPerson.Address;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = li_SalesPerson.RegionID;
            cmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = li_SalesPerson.AreaID;
            cmd.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = li_SalesPerson.TeritoryID;
            //  cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_SalesPerson.CreatedBy;
            // cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SalesPerson.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SalesPerson.ModifiedBy;
            // cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SalesPerson.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result;
        }
    }

    public DataSet Get_AllTSO(string tsoName)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_liAllTSO", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TSOName", SqlDbType.VarChar).Value = tsoName;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet Get_TSOByID(string ID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_getTsoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetAllLi_SalesPersonsByUserID(int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_SMPM_GetAllLi_SalesPersons_ByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetLi_SalesPersonByID(string ID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_SalesPersonByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TerritotyID", SqlDbType.VarChar).Value = ID;
            command.Parameters.Add("@IsShowAll", SqlDbType.Bit).Value = false;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public List<TSoInformation> Get_AllTSO()
    {
        List<TSoInformation> salesPersons = new List<TSoInformation>();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllTso",connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TSoInformation aTSoInformation = new TSoInformation();
                aTSoInformation.Name = (string)reader["Name"];
                //aTSoInformation.TName = (string)reader["TName"];
                aTSoInformation.TSOID = (string)reader["TSOID"];
                aTSoInformation.Mobile = (string)reader["Mobile"];
                aTSoInformation.Address = (string)reader["Address"];
                aTSoInformation.TerritoryName = (string) reader["Teritory Name"];
                aTSoInformation.AreaName = (string) reader["Area Name"];
                aTSoInformation.Region = (string) reader["Region"];
                aTSoInformation.Status = (string) reader["Status"];
                salesPersons.Add(aTSoInformation);
            }
        }
        return salesPersons;
    }

    //--------------------------Rezaul hossain---------------------
    //public static  List<Li_SalesPerson> GetAll_ComboBox_TSOInformations()
    //{
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("SMPM_GetAllLi_TSOInformation", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        connection.Open();
    //        IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

    //        return Get_TSOInformations_ComboBoxFromReader(reader);
    //    }
    //}
    //public static List<Li_SalesPerson> Get_TSOInformations_ComboBoxFromReader(IDataReader reader)
    //{
    //    List<Li_SalesPerson> li_TSOInformations = new List<Li_SalesPerson>();

    //    while (reader.Read())
    //    {
    //        li_TSOInformations.Add(Get_TSOInformation_ComboBoxFromReader(reader));
    //    }
    //    return li_TSOInformations;
    //}
    //public static  Li_SalesPerson Get_TSOInformation_ComboBoxFromReader(IDataReader reader)
    //{
    //    try
    //    {
    //        Li_SalesPerson li_TSOInformation = new Li_SalesPerson
    //            (

    //            reader["TSOID"].ToString(),
    //            reader["Name"].ToString()

    //            );
    //        return li_TSOInformation;
    //    }
    //    catch (Exception ex)
    //    {
    //        return null;
    //    }
    //}


    public List<Li_SalesPerson> GetLi_SalesPersonsByTerritory_OnlyActiveTSO(string Territory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetTSOByTerritoryID_OnlyActiveTSO", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.Add("@Ter", SqlDbType.VarChar).Value = Territory;
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SalesPersonsFromReader(reader);
        }
    }
}
