using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using Common.Marketing;

public class SqlLi_MadrasahInfoProvider:DataAccessObject
{
	public SqlLi_MadrasahInfoProvider()
    {
    }


    public bool DeleteLi_MadrasahInfo(int li_MadrasahInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(" ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ ", SqlDbType.Int).Value = li_MadrasahInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_MadrasahInfo> GetAllLi_MadrasahInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(" ", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_MadrasahInfosFromReader(reader);
        }
    }
    public List<Li_MadrasahInfo> GetLi_MadrasahInfosFromReader(IDataReader reader)
    {
        List<Li_MadrasahInfo> li_MadrasahInfos = new List<Li_MadrasahInfo>();

        while (reader.Read())
        {
            li_MadrasahInfos.Add(GetLi_MadrasahInfoFromReader(reader));
        }
        return li_MadrasahInfos;
    }

    public Li_MadrasahInfo GetLi_MadrasahInfoFromReader(IDataReader reader)
    {
        try
        {
            Li_MadrasahInfo li_MadrasahInfo = new Li_MadrasahInfo
                (
                
                    reader["MadId"].ToString(),
                    (int)reader["DetId"],
                    reader["MadName"].ToString(),
                    reader["VillRoBaz"].ToString(),
                    reader["PostOff"].ToString(),
                    (int)reader["MadLevelId"],
                    (int)reader["ThanaId"],
                    reader["PrinName"].ToString(),
                    reader["PrinCont"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
             return li_MadrasahInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_MadrasahInfo GetLi_MadrasahInfoByID(int li_MadrasahInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(" ", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ ", SqlDbType.Int).Value = li_MadrasahInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_MadrasahInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string InsertLi_MadrasahInfo(Li_MadrasahInfo li_MadrasahInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_MadrasahInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@MadId", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = li_MadrasahInfo.DetId;
            cmd.Parameters.Add("@MadName", SqlDbType.VarChar).Value = li_MadrasahInfo.MadName;
            cmd.Parameters.Add("@VillRoBaz", SqlDbType.VarChar).Value = li_MadrasahInfo.VillRoBaz;
            cmd.Parameters.Add("@PostOff", SqlDbType.VarChar).Value = li_MadrasahInfo.PostOff;
            cmd.Parameters.Add("@MadLevelId", SqlDbType.Int).Value = li_MadrasahInfo.MadLevelId;
            cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = li_MadrasahInfo.ThanaId;
            cmd.Parameters.Add("@PrinName", SqlDbType.VarChar).Value = li_MadrasahInfo.PrinName;
            cmd.Parameters.Add("@PrinCont", SqlDbType.VarChar).Value = li_MadrasahInfo.PrinCont;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MadrasahInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MadrasahInfo.CreatedDate;
            connection.Open();

            cmd.ExecuteNonQuery();
            return cmd.Parameters["@MadId"].Value.ToString();
        }
    }

    public bool UpdateLi_MadrasahInfo(Li_MadrasahInfo li_MadrasahInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AFPERP_UpdateLi_MadrasahInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@MadId", SqlDbType.VarChar).Value = li_MadrasahInfo.MadId;
            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = li_MadrasahInfo.DetId;
            cmd.Parameters.Add("@MadName", SqlDbType.VarChar).Value = li_MadrasahInfo.MadName;
            cmd.Parameters.Add("@VillRoBaz", SqlDbType.VarChar).Value = li_MadrasahInfo.VillRoBaz;
            cmd.Parameters.Add("@PostOff", SqlDbType.VarChar).Value = li_MadrasahInfo.PostOff;
            cmd.Parameters.Add("@MadLevelId", SqlDbType.Int).Value = li_MadrasahInfo.MadLevelId;
            cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = li_MadrasahInfo.ThanaId;
            cmd.Parameters.Add("@PrinName", SqlDbType.VarChar).Value = li_MadrasahInfo.PrinName;
            cmd.Parameters.Add("@PrinCont", SqlDbType.VarChar).Value = li_MadrasahInfo.PrinCont;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MadrasahInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MadrasahInfo.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetLi_MadrasahInfoBy_AgrNo(string AgrNo, string AgYear)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand  cmd= new SqlCommand("SMPM_li_MadrashaNameBy_AgrNo", connection);
            cmd .CommandType = CommandType.StoredProcedure;
            cmd .Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
            cmd.Parameters.Add("@AgYear", SqlDbType.VarChar).Value = AgYear;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;

        }
    }

    //--------------------Rezaul Hossain--------2021----------------------
    public DataSet GetTeacherInformationByMadrasahAndterritory(string TerID, string MadID, string ClassID, string BookID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_SMPM_li_GetTeacherInformationByMadrasahAndterritory", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TerID", SqlDbType.VarChar).Value = TerID;
            command.Parameters.Add("@MadID", SqlDbType.Int).Value = MadID;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = ClassID;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetAllLi_MadrasahInfoForTeacherInfo()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_MadrasahInfoQawmiList", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            adapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    //public DataSet GetLi_MadrasahInfoBy_AgrNo(string AgrNo)
    //{
    //    DataSet ds = new DataSet();
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand cmd = new SqlCommand("SMPM_li_Get_DonationTeritoryWisePaidBudget", connection);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("@AgrNo", SqlDbType.Int).Value = AgrNo;
    //        connection.Open();
    //        SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
    //        myadapter.Fill(ds);
    //        myadapter.Dispose();
    //        connection.Close();
    //        return ds;
    //    }

    //}

    public int InsertLi_MadrasahInfoAdvanced(Li_MadrasahInfoAdvanced li_MadrasahInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_MadrasahInfoAdvanced", connection);
            cmd.CommandType = CommandType.StoredProcedure;

             
            cmd.Parameters.Add("@EiinNo", SqlDbType.VarChar).Value = li_MadrasahInfo.EIIN;
            cmd.Parameters.Add("@MadName", SqlDbType.VarChar).Value = li_MadrasahInfo.MadName;
            cmd.Parameters.Add("@VillRoBaz", SqlDbType.VarChar).Value = li_MadrasahInfo.VillRoBaz;
            cmd.Parameters.Add("@PostOff", SqlDbType.VarChar).Value = li_MadrasahInfo.PostOff;
            cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = li_MadrasahInfo.ThanaId;
            cmd.Parameters.Add("@MadLevelId", SqlDbType.Int).Value = li_MadrasahInfo.MadLevelId;
            cmd.Parameters.Add("@DevelopIndex", SqlDbType.Int).Value = li_MadrasahInfo.DevelopIndex;
            cmd.Parameters.Add("@PrinName", SqlDbType.VarChar).Value = li_MadrasahInfo.PrinName;
            cmd.Parameters.Add("@PrinCont", SqlDbType.VarChar).Value = li_MadrasahInfo.PrinCont;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MadrasahInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MadrasahInfo.CreatedDate;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_MadrasahInfo.Remarks;
            connection.Open();

           int result= cmd.ExecuteNonQuery();
            return   1;
        }
    }
    public int UpdateLi_MadrasahInfoAdvanced(Li_MadrasahInfoAdvanced li_MadrasahInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_MadrasahInfoAdvanced", connection);
            cmd.CommandType = CommandType.StoredProcedure;

             
            cmd.Parameters.Add("@EiinNo", SqlDbType.VarChar).Value = li_MadrasahInfo.EIIN;
            cmd.Parameters.Add("@MadName", SqlDbType.VarChar).Value = li_MadrasahInfo.MadName;
            cmd.Parameters.Add("@VillRoBaz", SqlDbType.VarChar).Value = li_MadrasahInfo.VillRoBaz;
            cmd.Parameters.Add("@PostOff", SqlDbType.VarChar).Value = li_MadrasahInfo.PostOff;
            cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = li_MadrasahInfo.ThanaId;
            cmd.Parameters.Add("@MadLevelId", SqlDbType.Int).Value = li_MadrasahInfo.MadLevelId;
            cmd.Parameters.Add("@DevelopIndex", SqlDbType.Int).Value = li_MadrasahInfo.DevelopIndex;
            cmd.Parameters.Add("@PrinName", SqlDbType.VarChar).Value = li_MadrasahInfo.PrinName;
            cmd.Parameters.Add("@PrinCont", SqlDbType.VarChar).Value = li_MadrasahInfo.PrinCont;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MadrasahInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MadrasahInfo.CreatedDate;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_MadrasahInfo.Remarks;
            connection.Open();

           int result= cmd.ExecuteNonQuery();
            return   1;
        }
    }


    public DataSet GetLi_MadrasahEIIN_ForExistingEIIN(string EIIN)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("GetMadrasahInfoExistingByEIIN", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EIIN", SqlDbType.VarChar).Value = EIIN;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataSet GetLi_MadrasahInfo_ForExistingEIIN_ForUpdate(string EIIN)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("GetMadrasahInfoForDataEntryByEIIN_ForUpdate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EIIN", SqlDbType.VarChar).Value = EIIN;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }

}
