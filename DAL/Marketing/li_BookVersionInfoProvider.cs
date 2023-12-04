using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sql_li_BookVersionInfoProvider : DataAccessObject
{
    public Sql_li_BookVersionInfoProvider()
    {
    }


    public List<li_BookVersionInfo> GetAll_BookVersionInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_BookVersionInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_BookVersionInfosFromReader(reader);
        }
    }


    public DataSet GetAll_BookVersionInfosWithRelation(string bookAcCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_BookStockInfoByCode", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetAll_BookVersionInfosWithRelation_Alia(string bookAcCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_BookStockInfoByCode_Alia", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetAll_BookVersionInfosWithRelation_Qawmi(string bookAcCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_BookStockInfoByCode_Qawmi", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetAll_BookVersionInfosWithDiscount(string bookAcCode,string LibraryID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_BookStockInfoByCodeWithLibray", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;
            command.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value =  LibraryID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetAll_BookVersionInfosWithEditionForReturn(string bookAcCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_BookInformationAllInfoByEditionForReturn", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }  
    public DataSet GetAll_BookVersionInfosWithEditionForReturnByLibrary(string bookAcCode,string LibraryID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_BookInformationAllInfoByEditionForReturnByLibrary", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;
            command.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = LibraryID ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetAll_BookVersionInfosWithEdition(string bookAcCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_BookInformationAllInfoByEdition", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetAll_BookVersionInfosWithEdition_Alia(string bookAcCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_BookInformationAllInfoByEdition_Alia", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetAll_BookVersionInfosWithEdition_Qawmi(string bookAcCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_BookInformationAllInfoByEdition_Qawmi", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public List<li_BookVersionInfo> Get_BookVersionInfosFromReader(IDataReader reader)
    {
        List<li_BookVersionInfo> li_BookVersionInfos = new List<li_BookVersionInfo>();

        while (reader.Read())
        {
            li_BookVersionInfos.Add(Get_BookVersionInfoFromReader(reader));
        }
        return li_BookVersionInfos;
    }
    public List<li_BookVersionInfo> Get_Combobox_BookVersionInfosFromReader(IDataReader reader)
    {
        List<li_BookVersionInfo> li_BookVersionInfos = new List<li_BookVersionInfo>();

        while (reader.Read())
        {
            li_BookVersionInfos.Add(Get_Combobox_BookVersionInfoFromReader(reader));
        }
        return li_BookVersionInfos;
    }
    public li_BookVersionInfo Get_Combobox_BookVersionInfoFromReader(IDataReader reader)
    {
        try
        {
            li_BookVersionInfo li_BookVersionInfo = new li_BookVersionInfo
                (

                    reader["BookAcCode"].ToString(),

                    reader["BookID"].ToString(),
                    reader["Edition"].ToString()
                );
            return li_BookVersionInfo;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public li_BookVersionInfo Get_BookVersionInfoFromReader(IDataReader reader)
    {
        try
        {
            li_BookVersionInfo li_BookVersionInfo = new li_BookVersionInfo
                (

                    reader["BookAcCode"].ToString(),

                    reader["BookID"].ToString(),
                    reader["Edition"].ToString(),
                    (DateTime)reader["Printdate"],
                    (bool)reader["IsReprinted"],
                    (bool)reader["IsRebinding"],
                    (decimal)reader["Price"],
                    (int)reader["Quantity"],
                    (bool)reader["IsOpeningStock"],
                    (decimal )reader ["Bonus"],
                    (int)reader["CreatedBy"]
                );
            return li_BookVersionInfo;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public li_BookVersionInfo Get_BookVersionInfoByBookAcCode(string bookAcCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_BookVersionInfoByBookAcCode", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_BookVersionInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int  Insert_BookVersionInfo(li_BookVersionInfo li_BookVersionInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_BookVersionInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_BookVersionInfo.BookAcCode;
            cmd.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = li_BookVersionInfo.Quantity;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_BookVersionInfo.BookID;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_BookVersionInfo.Edition;
            cmd.Parameters.Add("@Printdate", SqlDbType.DateTime).Value = li_BookVersionInfo.Printdate;
            cmd.Parameters.Add("@IsReprinted", SqlDbType.Bit).Value = li_BookVersionInfo.IsReprinted;
            cmd.Parameters.Add("@IsRebinding", SqlDbType.Bit).Value = li_BookVersionInfo.IsRebinding;
            cmd.Parameters.Add("@price", SqlDbType.Money).Value = li_BookVersionInfo.Price;
            cmd.Parameters.Add("@IsOpeningStock", SqlDbType.Bit).Value = li_BookVersionInfo.IsOpeningStock;
            cmd.Parameters.Add("@Bonus", SqlDbType.Decimal).Value = li_BookVersionInfo.Bonus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Decimal).Value = li_BookVersionInfo.CreatedBy;
            cmd.Parameters.Add("@EntrySl", SqlDbType.Decimal).Direction =  ParameterDirection . Output;      
            connection.Open();
            cmd.ExecuteNonQuery();
            return int.Parse(cmd.Parameters["@EntrySl"].Value.ToString());
        }
    }

    public bool Update_BookVersionInfo(li_BookVersionInfo li_BookVersionInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_BookVersionInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_BookVersionInfo.BookAcCode;
            
            cmd.Parameters.Add("@price", SqlDbType.Money).Value = li_BookVersionInfo.Price;
          
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_BookVersionInfo(int bookAcCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_BookVersionInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<li_BookVersionInfo> Get_BookInformationByBookID(string BookID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_BookAcCodeByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);


            return Get_BookVersionInfosFromReader(reader);
        }
    }


    public List<li_BookVersionInfo> GetAll_BookVersionInfosByBookID(string bookID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_BookVersionInfoByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = bookID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_BookVersionInfosFromReader(reader);
        }
    }
    public List<li_BookVersionInfo> GetAll_Combobox_BookVersionInfosByBookID(string bookID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ComboBox_BookVersionInfoByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = bookID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_Combobox_BookVersionInfosFromReader(reader);
        }
    }

    //-------------Rezaul Hossain----------2020-----------

}

