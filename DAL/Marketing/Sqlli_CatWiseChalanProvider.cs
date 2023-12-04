using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_CatWiseChalanProvider:DataAccessObject
{
	public SqlLi_CatWiseChalanProvider()
    {
    }


    public bool DeleteLi_CatWiseChalan(int li_CatWiseChalanID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_CatWiseChalan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_CatWiseChalanID", SqlDbType.Int).Value = li_CatWiseChalanID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_CatWiseChalan> GetAllLi_CatWiseChalans()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_CatWiseChalans", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_CatWiseChalansFromReader(reader);
        }
    }
    public List<Li_CatWiseChalan> GetLi_CatWiseChalansFromReader(IDataReader reader)
    {
        List<Li_CatWiseChalan> li_CatWiseChalans = new List<Li_CatWiseChalan>();

        while (reader.Read())
        {
            li_CatWiseChalans.Add(GetLi_CatWiseChalanFromReader(reader));
        }
        return li_CatWiseChalans;
    }

    public Li_CatWiseChalan GetLi_CatWiseChalanFromReader(IDataReader reader)
    {
        try
        {
            Li_CatWiseChalan li_CatWiseChalan = new Li_CatWiseChalan
                (
                   
                    reader["LibraryID"].ToString(),
                    (decimal)reader["Dak_Bonus"],
                    (decimal)reader["Cha_A"],
                    (decimal)reader["Cha_B"],
                    (decimal)reader["Cha_C"],
                    (decimal)reader["Cha_D"],
                    (decimal)reader["Cha_E"],
                    (decimal)reader["Cha_F"],
                    (decimal)reader["Ret_A"],
                    (decimal)reader["Ret_B"],
                    (decimal)reader["Ret_C"],
                    (decimal)reader["Ret_D"],
                    (decimal)reader["Ret_E"],
                    (decimal)reader["Ret_F"],
                    (decimal)reader["Net_ChaA"],
                    (decimal)reader["Net_ChaB"],
                    (decimal)reader["Net_ChaC"],
                    (decimal)reader["Net_ChaD"],
                    (decimal)reader["Net_ChaE"],
                    (decimal)reader["Net_ChaF"],
                    (decimal)reader["Tot_Cha"],
                    (decimal)reader["Tot_Ret"],
                    (decimal)reader["Tot_Net"],
                    (decimal)reader["Tot_Depo"],
                    (decimal)reader["Ac_Depo"],
                    (decimal)reader["Dak_Chalan"],
                    (decimal)reader["PC_Cost"],
                    (decimal)reader["Op_Balance"],
                    (decimal)reader["GenB_A"],
                    (decimal)reader["GenB_B"],
                    (decimal)reader["GenB_C"],
                    (decimal)reader["GenB_D"],
                    (decimal)reader["GenB_E"],
                    (decimal)reader["GenB_F"],
                    (decimal)reader["GenB_Tot"],
                    (decimal)reader["Bon_Sal"],
                    (decimal)reader["Bon_Ret"],
                    (decimal)reader["Bon_Depo"],
                    (decimal)reader["Total_Bonus"],
                    (decimal)reader["Bon_p_Sal"],
                    (decimal)reader["Bon_p_Ret"],
                    (decimal)reader["Bon_p_Depo"],
                    (decimal)reader["RoundUp"],
                    (int)reader["IsShow"],
                    (decimal)reader["DakB_A"],
                    (decimal)reader["DakB_B"],
                    (decimal)reader["DakB_C"],
                    (decimal)reader["DakB_D"],
                    (decimal)reader["DakB_E"],
                    (decimal)reader["DakB_F"],
                    (decimal)reader["AlmB_A"],
                    (decimal)reader["AlmB_B"],
                    (decimal)reader["AlmB_C"],
                    (decimal)reader["AlmB_D"],
                    (decimal)reader["AlmB_E"],
                    (decimal)reader["AlmB_F"],
                    (decimal)reader["AlmChalan"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"] 
                );
             return li_CatWiseChalan;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_CatWiseChalan GetLi_CatWiseChalanByID(int li_CatWiseChalanID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_CatWiseChalanByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_CatWiseChalanID", SqlDbType.Int).Value = li_CatWiseChalanID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_CatWiseChalanFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_CatWiseChalan(Li_CatWiseChalan li_CatWiseChalan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_CatWiseChalan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_CatWiseChalan.LibraryID;
            cmd.Parameters.Add("@Dak_Bonus", SqlDbType.Decimal).Value = li_CatWiseChalan.Dak_Bonus;
            cmd.Parameters.Add("@Cha_A", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_A;
            cmd.Parameters.Add("@Cha_B", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_B;
            cmd.Parameters.Add("@Cha_C", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_C;
            cmd.Parameters.Add("@Cha_D", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_D;
            cmd.Parameters.Add("@Cha_E", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_E;
            cmd.Parameters.Add("@Cha_F", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_F;
            cmd.Parameters.Add("@Ret_A", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_A;
            cmd.Parameters.Add("@Ret_B", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_B;
            cmd.Parameters.Add("@Ret_C", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_C;
            cmd.Parameters.Add("@Ret_D", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_D;
            cmd.Parameters.Add("@Ret_E", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_E;
            cmd.Parameters.Add("@Ret_F", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_F;
            cmd.Parameters.Add("@Net_ChaA", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaA;
            cmd.Parameters.Add("@Net_ChaB", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaB;
            cmd.Parameters.Add("@Net_ChaC", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaC;
            cmd.Parameters.Add("@Net_ChaD", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaD;
            cmd.Parameters.Add("@Net_ChaE", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaE;
            cmd.Parameters.Add("@Net_ChaF", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaF;
            cmd.Parameters.Add("@Tot_Cha", SqlDbType.Decimal).Value = li_CatWiseChalan.Tot_Cha;
            cmd.Parameters.Add("@Tot_Ret", SqlDbType.Decimal).Value = li_CatWiseChalan.Tot_Ret;
            cmd.Parameters.Add("@Tot_Net", SqlDbType.Decimal).Value = li_CatWiseChalan.Tot_Net;
            cmd.Parameters.Add("@Tot_Depo", SqlDbType.Decimal).Value = li_CatWiseChalan.Tot_Depo;
            cmd.Parameters.Add("@Ac_Depo", SqlDbType.Decimal).Value = li_CatWiseChalan.Ac_Depo;
            cmd.Parameters.Add("@Dak_Chalan", SqlDbType.Decimal).Value = li_CatWiseChalan.Dak_Chalan;
            cmd.Parameters.Add("@PC_Cost", SqlDbType.Decimal).Value = li_CatWiseChalan.PC_Cost;
            cmd.Parameters.Add("@Op_Balance", SqlDbType.Decimal).Value = li_CatWiseChalan.Op_Balance;
            cmd.Parameters.Add("@GenB_A", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_A;
            cmd.Parameters.Add("@GenB_B", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_B;
            cmd.Parameters.Add("@GenB_C", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_C;
            cmd.Parameters.Add("@GenB_D", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_D;
            cmd.Parameters.Add("@GenB_E", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_E;
            cmd.Parameters.Add("@GenB_F", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_F;
            cmd.Parameters.Add("@GenB_Tot", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_Tot;
            cmd.Parameters.Add("@Bon_Sal", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_Sal;
            cmd.Parameters.Add("@Bon_Ret", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_Ret;
            cmd.Parameters.Add("@Bon_Depo", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_Depo;
            cmd.Parameters.Add("@Total_Bonus", SqlDbType.Decimal).Value = li_CatWiseChalan.Total_Bonus;
            cmd.Parameters.Add("@Bon_p_Sal", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_p_Sal;
            cmd.Parameters.Add("@Bon_p_Ret", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_p_Ret;
            cmd.Parameters.Add("@Bon_p_Depo", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_p_Depo;
            cmd.Parameters.Add("@RoundUp", SqlDbType.Decimal).Value = li_CatWiseChalan.RoundUp;
            cmd.Parameters.Add("@IsShow", SqlDbType.Int).Value = li_CatWiseChalan.IsShow;
            cmd.Parameters.Add("@DakB_A", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_A;
            cmd.Parameters.Add("@DakB_B", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_B;
            cmd.Parameters.Add("@DakB_C", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_C;
            cmd.Parameters.Add("@DakB_D", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_D;
            cmd.Parameters.Add("@DakB_E", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_E;
            cmd.Parameters.Add("@DakB_F", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_F;
            cmd.Parameters.Add("@AlmB_A", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_A;
            cmd.Parameters.Add("@AlmB_B", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_B;
            cmd.Parameters.Add("@AlmB_C", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_C;
            cmd.Parameters.Add("@AlmB_D", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_D;
            cmd.Parameters.Add("@AlmB_E", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_E;
            cmd.Parameters.Add("@AlmB_F", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_F;
            cmd.Parameters.Add("@AlmChalan", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmChalan;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CatWiseChalan.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CatWiseChalan.CreatedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_CatWiseChalanID"].Value;
        }
    }

    public bool UpdateLi_CatWiseChalan(Li_CatWiseChalan li_CatWiseChalan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_CatWiseChalan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_CatWiseChalan.LibraryID;
            cmd.Parameters.Add("@Dak_Bonus", SqlDbType.Decimal).Value = li_CatWiseChalan.Dak_Bonus;
            cmd.Parameters.Add("@Cha_A", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_A;
            cmd.Parameters.Add("@Cha_B", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_B;
            cmd.Parameters.Add("@Cha_C", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_C;
            cmd.Parameters.Add("@Cha_D", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_D;
            cmd.Parameters.Add("@Cha_E", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_E;
            cmd.Parameters.Add("@Cha_F", SqlDbType.Decimal).Value = li_CatWiseChalan.Cha_F;
            cmd.Parameters.Add("@Ret_A", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_A;
            cmd.Parameters.Add("@Ret_B", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_B;
            cmd.Parameters.Add("@Ret_C", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_C;
            cmd.Parameters.Add("@Ret_D", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_D;
            cmd.Parameters.Add("@Ret_E", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_E;
            cmd.Parameters.Add("@Ret_F", SqlDbType.Decimal).Value = li_CatWiseChalan.Ret_F;
            cmd.Parameters.Add("@Net_ChaA", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaA;
            cmd.Parameters.Add("@Net_ChaB", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaB;
            cmd.Parameters.Add("@Net_ChaC", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaC;
            cmd.Parameters.Add("@Net_ChaD", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaD;
            cmd.Parameters.Add("@Net_ChaE", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaE;
            cmd.Parameters.Add("@Net_ChaF", SqlDbType.Decimal).Value = li_CatWiseChalan.Net_ChaF;
            cmd.Parameters.Add("@Tot_Cha", SqlDbType.Decimal).Value = li_CatWiseChalan.Tot_Cha;
            cmd.Parameters.Add("@Tot_Ret", SqlDbType.Decimal).Value = li_CatWiseChalan.Tot_Ret;
            cmd.Parameters.Add("@Tot_Net", SqlDbType.Decimal).Value = li_CatWiseChalan.Tot_Net;
            cmd.Parameters.Add("@Tot_Depo", SqlDbType.Decimal).Value = li_CatWiseChalan.Tot_Depo;
            cmd.Parameters.Add("@Ac_Depo", SqlDbType.Decimal).Value = li_CatWiseChalan.Ac_Depo;
            cmd.Parameters.Add("@Dak_Chalan", SqlDbType.Decimal).Value = li_CatWiseChalan.Dak_Chalan;
            cmd.Parameters.Add("@PC_Cost", SqlDbType.Decimal).Value = li_CatWiseChalan.PC_Cost;
            cmd.Parameters.Add("@Op_Balance", SqlDbType.Decimal).Value = li_CatWiseChalan.Op_Balance;
            cmd.Parameters.Add("@GenB_A", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_A;
            cmd.Parameters.Add("@GenB_B", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_B;
            cmd.Parameters.Add("@GenB_C", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_C;
            cmd.Parameters.Add("@GenB_D", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_D;
            cmd.Parameters.Add("@GenB_E", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_E;
            cmd.Parameters.Add("@GenB_F", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_F;
            cmd.Parameters.Add("@GenB_Tot", SqlDbType.Decimal).Value = li_CatWiseChalan.GenB_Tot;
            cmd.Parameters.Add("@Bon_Sal", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_Sal;
            cmd.Parameters.Add("@Bon_Ret", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_Ret;
            cmd.Parameters.Add("@Bon_Depo", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_Depo;
            cmd.Parameters.Add("@Total_Bonus", SqlDbType.Decimal).Value = li_CatWiseChalan.Total_Bonus;
            cmd.Parameters.Add("@Bon_p_Sal", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_p_Sal;
            cmd.Parameters.Add("@Bon_p_Ret", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_p_Ret;
            cmd.Parameters.Add("@Bon_p_Depo", SqlDbType.Decimal).Value = li_CatWiseChalan.Bon_p_Depo;
            cmd.Parameters.Add("@RoundUp", SqlDbType.Decimal).Value = li_CatWiseChalan.RoundUp;
            cmd.Parameters.Add("@IsShow", SqlDbType.Int).Value = li_CatWiseChalan.IsShow;
            cmd.Parameters.Add("@DakB_A", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_A;
            cmd.Parameters.Add("@DakB_B", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_B;
            cmd.Parameters.Add("@DakB_C", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_C;
            cmd.Parameters.Add("@DakB_D", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_D;
            cmd.Parameters.Add("@DakB_E", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_E;
            cmd.Parameters.Add("@DakB_F", SqlDbType.Decimal).Value = li_CatWiseChalan.DakB_F;
            cmd.Parameters.Add("@AlmB_A", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_A;
            cmd.Parameters.Add("@AlmB_B", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_B;
            cmd.Parameters.Add("@AlmB_C", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_C;
            cmd.Parameters.Add("@AlmB_D", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_D;
            cmd.Parameters.Add("@AlmB_E", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_E;
            cmd.Parameters.Add("@AlmB_F", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmB_F;
            cmd.Parameters.Add("@AlmChalan", SqlDbType.Decimal).Value = li_CatWiseChalan.AlmChalan;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CatWiseChalan.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CatWiseChalan.CreatedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
