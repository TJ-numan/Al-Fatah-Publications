using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_AssetListProvider:DataAccessObject
{
	public SqlLi_AssetListProvider()
    {
    }


    public bool DeleteLi_AssetList(int li_AssetListID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_AssetList", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AssetId", SqlDbType.Int).Value = li_AssetListID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_AssetList> GetAllLi_AssetLists()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_AssetLists", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AssetListsFromReader(reader);
        }
    }
    public List<Li_AssetList> GetLi_AssetListsFromReader(IDataReader reader)
    {
        List<Li_AssetList> li_AssetLists = new List<Li_AssetList>();

        while (reader.Read())
        {
            li_AssetLists.Add(GetLi_AssetListFromReader(reader));
        }
        return li_AssetLists;
    }

    public Li_AssetList GetLi_AssetListFromReader(IDataReader reader)
    {
        try
        {
            Li_AssetList li_AssetList = new Li_AssetList
                (
                  
                    (int)reader["AssetId"],
                    reader ["AssetCode"].ToString (),
                    reader["AssetName"].ToString(),
                    reader["ModelNo"].ToString(),
                    (int)reader["BrandId"],
                    (int)reader["AssetCatId"],
                    (int)reader["AssetVenId"],

                    (Decimal)reader["PurchaseAmt"],
                    (DateTime)reader["PurchaseDate"],
                    (DateTime)reader["WarrantyPeriod"],
                    (DateTime)reader["Life_Time"],

                    (int)reader["DepId"],
                    (int)reader["EmployeID"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_AssetList;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_AssetList GetLi_AssetListByID(int li_AssetListID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_AssetListByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AssetId", SqlDbType.Int).Value = li_AssetListID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AssetListFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string InsertLi_AssetList(Li_AssetList li_AssetList)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_AssetList", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@AssetId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AssetCode", SqlDbType.VarChar,50).Direction  = ParameterDirection.Output;
            cmd.Parameters.Add("@AssetName", SqlDbType.VarChar).Value = li_AssetList.AssetName;
            cmd.Parameters.Add("@ModelNo", SqlDbType.VarChar).Value = li_AssetList.ModelNo;
            cmd.Parameters.Add("@BrandId", SqlDbType.Int).Value = li_AssetList.BrandId;
            cmd.Parameters.Add("@AssetCatId", SqlDbType.Int).Value = li_AssetList.AssetCatId;
            cmd.Parameters.Add("@AssetVenId", SqlDbType.Int).Value = li_AssetList.AssetVenId;

            cmd.Parameters.Add("@PurchaseAmt", SqlDbType.Decimal).Value = li_AssetList.PurchaseAmt;
            cmd.Parameters.Add("@PurchaseDate", SqlDbType.DateTime).Value = li_AssetList.PurchaseDate;
            cmd.Parameters.Add("@WarrantyPeriod", SqlDbType.DateTime).Value = li_AssetList.WarrantyPeriod;
            cmd.Parameters.Add("@Life_Time", SqlDbType.DateTime).Value = li_AssetList.Life_Time;

            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_AssetList.DepId;
            cmd.Parameters.Add("@EmployeID", SqlDbType.Int).Value = li_AssetList.EmployeID;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetList.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetList.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetList.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetList.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetList.InfStId;
            connection.Open();

            cmd.ExecuteNonQuery();
            return cmd.Parameters["@AssetCode"].Value.ToString();
        }
    }

    public bool UpdateLi_AssetList(Li_AssetList li_AssetList)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_AssetList", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@AssetId", SqlDbType.Int).Value = li_AssetList.AssetId;
            //cmd.Parameters.Add("@AssetCode", SqlDbType.VarChar).Value = li_AssetList.AssetCode;
            cmd.Parameters.Add("@AssetName", SqlDbType.VarChar).Value = li_AssetList.AssetName;
            cmd.Parameters.Add("@ModelNo", SqlDbType.VarChar).Value = li_AssetList.ModelNo;
            cmd.Parameters.Add("@BrandId", SqlDbType.Int).Value = li_AssetList.BrandId;
            cmd.Parameters.Add("@AssetCatId", SqlDbType.Int).Value = li_AssetList.AssetCatId;
            cmd.Parameters.Add("@AssetVenId", SqlDbType.Int).Value = li_AssetList.AssetVenId;

            cmd.Parameters.Add("@PurchaseAmt", SqlDbType.Decimal).Value = li_AssetList.PurchaseAmt;
            cmd.Parameters.Add("@PurchaseDate ", SqlDbType.DateTime).Value = li_AssetList.PurchaseDate;
            cmd.Parameters.Add("@WarrantyPeriod ", SqlDbType.DateTime).Value = li_AssetList.WarrantyPeriod;
            cmd.Parameters.Add("@Life_Time ", SqlDbType.DateTime).Value = li_AssetList.Life_Time;

            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_AssetList.DepId;
            cmd.Parameters.Add("@EmployeID", SqlDbType.Int).Value = li_AssetList.EmployeID;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetList.CreatedBy;
            //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetList.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetList.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetList.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetList.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataTable LoadGvAssetList()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.LoadGvAssetList", connection);
            cmd.CommandType = CommandType.StoredProcedure; 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
    public DataTable GetAllLi_AssetList_Load()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.SMPM_li_GetAllAssetList", connection);
            cmd.CommandType = CommandType.StoredProcedure; 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }

    public DataTable GetAllLi_AssetList_ByAssetId(int AssetId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.SMPM_li_GetAllAssetListById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AssetId", SqlDbType.Int).Value = AssetId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }

}
