using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpAssetGivenProvider:DataAccessObject
{
	public SqlLi_EmpAssetGivenProvider()
    {
    }


    public bool DeleteLi_EmpAssetGiven(int li_EmpAssetGivenID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpAssetGiven", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UiTiId", SqlDbType.Int).Value = li_EmpAssetGivenID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpAssetGiven> GetAllLi_EmpAssetGivens()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpAssetGivens", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpAssetGivensFromReader(reader);
        }
    }
    public List<Li_EmpAssetGiven> GetLi_EmpAssetGivensFromReader(IDataReader reader)
    {
        List<Li_EmpAssetGiven> li_EmpAssetGivens = new List<Li_EmpAssetGiven>();

        while (reader.Read())
        {
            li_EmpAssetGivens.Add(GetLi_EmpAssetGivenFromReader(reader));
        }
        return li_EmpAssetGivens;
    }

    public Li_EmpAssetGiven GetLi_EmpAssetGivenFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpAssetGiven li_EmpAssetGiven = new Li_EmpAssetGiven
                (
                   
                    (int)reader["UiTiId"],
                    (int)reader["EmpSl"],
                    (DateTime)reader["GivenDate"],
                    (int)reader["ReqNo"],
                    (int)reader["ItemId"],
                    (decimal)reader["Qty"],
                    reader["MoU"].ToString(),
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpAssetGiven;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpAssetGiven GetLi_EmpAssetGivenByID(int li_EmpAssetGivenID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpAssetGivenByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UiTiId", SqlDbType.Int).Value = li_EmpAssetGivenID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpAssetGivenFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpAssetGiven(Li_EmpAssetGiven li_EmpAssetGiven)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpAssetGiven", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@UiTiId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpAssetGiven.EmpSl;
            cmd.Parameters.Add("@GivenDate", SqlDbType.DateTime).Value = li_EmpAssetGiven.GivenDate;
            cmd.Parameters.Add("@ReqNo", SqlDbType.Int).Value = li_EmpAssetGiven.ReqNo;
            cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = li_EmpAssetGiven.ItemId;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_EmpAssetGiven.Qty;
            cmd.Parameters.Add("@MoU", SqlDbType.VarChar).Value = li_EmpAssetGiven.MoU;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpAssetGiven.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpAssetGiven.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpAssetGiven.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpAssetGiven.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpAssetGiven.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpAssetGiven.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@UiTiId"].Value;
        }
    }

    public bool UpdateLi_EmpAssetGiven(Li_EmpAssetGiven li_EmpAssetGiven)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpAssetGiven", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@UiTiId", SqlDbType.Int).Value = li_EmpAssetGiven.UiTiId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpAssetGiven.EmpSl;
            cmd.Parameters.Add("@GivenDate", SqlDbType.DateTime).Value = li_EmpAssetGiven.GivenDate;
            cmd.Parameters.Add("@ReqNo", SqlDbType.Int).Value = li_EmpAssetGiven.ReqNo;
            cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = li_EmpAssetGiven.ItemId;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_EmpAssetGiven.Qty;
            cmd.Parameters.Add("@MoU", SqlDbType.VarChar).Value = li_EmpAssetGiven.MoU;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpAssetGiven.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpAssetGiven.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpAssetGiven.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpAssetGiven.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpAssetGiven.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpAssetGiven.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
