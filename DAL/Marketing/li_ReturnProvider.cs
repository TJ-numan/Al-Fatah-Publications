using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sql_li_ReturnProvider : DataAccessObject
{
    public Sql_li_ReturnProvider()
    {
    }


    public List<li_Return> GetAll_Returns()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_Returns", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_ReturnsFromReader(reader);
        }
    }

    public DataSet GetAll_ReturnsWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ReturnsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<li_Return> Get_ReturnsFromReader(IDataReader reader)
    {
        List<li_Return> li_Returns = new List<li_Return>();

        while (reader.Read())
        {
            li_Returns.Add(Get_ReturnFromReader(reader));
        }
        return li_Returns;
    }




    public li_Return Get_ReturnFromReader(IDataReader reader)
    {
        try
        {
            li_Return li_Return = new li_Return
                (
                    reader["ReturnID"].ToString(),
                    reader["ChallanID"].ToString(),
                    reader["LibraryID"].ToString(),
                    (decimal)reader["TotalAmount"],
                    (DateTime)reader["ReturnDate"],
                    (int)reader["BookReceivedBy"],
                    (decimal)reader["DamageAmount"],
                    reader["MemoNo"].ToString(),
                    (decimal)reader["AmountReceivable"],
                    (int)reader["PacketNo"],
                    (decimal)reader["PerPacketCost"],
                    (decimal)reader["SpcimenTotal"],
                    (int)reader["SerialNo"],
                    (decimal)reader["dicountAmount"]
                );
            return li_Return;
        }

        catch (Exception ex)
        {
            return null;
        }
    }


    public li_Return Get_ReturnByReturnID(int returnID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ReturnByReturnID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReturnID", SqlDbType.Int).Value = returnID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_ReturnFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }



    public string Insert_Return(li_Return li_Return)
    {

        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Alfatah_InsertLi_Return", connection);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;


            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_Return.ChallanID;

            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Return.LibraryID;

            cmd.Parameters.Add("@TotalAmount", SqlDbType.Money).Value = li_Return.TotalAmount;

            cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = li_Return.ReturnDate;

            cmd.Parameters.Add("@BookReceivedBy", SqlDbType.Int).Value = li_Return.BookReceivedBy;

            cmd.Parameters.Add("@DamageAmount", SqlDbType.Money).Value = li_Return.DamageAmount;

            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_Return.MemoNo;

            cmd.Parameters.Add("@AmountReceivable", SqlDbType.Money).Value = li_Return.AmountReceivable;

            cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_Return.PacketNo;

            cmd.Parameters.Add("@PerPacketCost", SqlDbType.Money).Value = li_Return.PerPacketCost;


            cmd.Parameters.Add("@SpecimenTotal", SqlDbType.Money).Value = li_Return.SpcimenTotal;

            cmd.Parameters.Add("@TotalDiscount", SqlDbType.Money).Value = li_Return.DiscountAmount;
            connection.Open();


            int result = cmd.ExecuteNonQuery();


            return cmd.Parameters["@ReturnID"].Value.ToString();

        }

    }

    public bool Update_Return(li_Return li_Return)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Alfatah_UpdateLi_Return", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar).Value = li_Return.ReturnID;
            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_Return.ChallanID;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Return.LibraryID;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Money).Value = li_Return.TotalAmount;
            cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = li_Return.ReturnDate;
            cmd.Parameters.Add("@BookReceivedBy", SqlDbType.Int).Value = li_Return.BookReceivedBy;
            cmd.Parameters.Add("@DamageAmount", SqlDbType.Money).Value = li_Return.DamageAmount;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_Return.MemoNo;
            cmd.Parameters.Add("@AmountReceivable", SqlDbType.Money).Value = li_Return.AmountReceivable;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_Return.PacketNo;
            cmd.Parameters.Add("@PerPacketCost", SqlDbType.Decimal).Value = li_Return.PerPacketCost;
            cmd.Parameters.Add("@SpecimenTotal", SqlDbType.Money).Value = li_Return.SpcimenTotal;
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_Return.SerialNo;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet Get_AllReturn(string fromdate, string todate)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_AllReturn", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromdate;

            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = todate;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }





    public DataSet GetReturnInformationByMemoForEdit(string MemoNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {   //SMPM_li_ChallanDetailsByChallanIDForEdit
            SqlCommand command = new SqlCommand("SMPM_li_ReturnByMemo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@memoNo", SqlDbType.VarChar).Value = MemoNo;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    //--------------Rezaul Hossain Using Procedure----------------------
    public DataSet GetReturnDetailsInformationByReturnIDForEdit(string ReturnID, String Comp)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_ReturnDetailsByReturnIDForEdit", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReturnID", SqlDbType.VarChar).Value = ReturnID;
            command.Parameters.Add("@Comp", SqlDbType.VarChar).Value = Comp;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet Get_AllReturnIDByMemoNo(string MemoNo, String Comp)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllReturnIDByMemoNoForCancel", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@memoNo", SqlDbType.VarChar).Value = MemoNo;
            command.Parameters.Add("@Comp", SqlDbType.VarChar).Value = Comp;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
//----------------------------------------------end--------------------------------------------------------------

    public DataSet Get_ReturnAmountByReturnIDFromDetails(string ReturnID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_ReturnAmountFromReturnDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReturnID", SqlDbType.VarChar).Value = ReturnID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }

    public bool Delete_Return_Q(string ReturnID, string Cause, int DeleBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_Return_Q", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar).Value = ReturnID;

            cmd.Parameters.Add("@Cause", SqlDbType.VarChar).Value = Cause;

            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = DeleBy;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet Get_BookQtyByReturn(string ReturnID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetBookQtyByReturnID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReturnID", SqlDbType.VarChar).Value = ReturnID;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet UpdateReturnStock(string BookCode, int Qty)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_UpdateStock_Return", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
            command.Parameters.Add("@Qty", SqlDbType.VarChar).Value = Qty;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public bool Delete_Return(string ReturnID, string Cause, int DeleBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_Return", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar).Value = ReturnID;

            cmd.Parameters.Add("@Cause", SqlDbType.VarChar).Value = Cause;

            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = DeleBy;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public DataTable  DatewiseReturn(string FromDate, string ToDate, int MemoFrom, int MemoTo, bool IsQawmi, int UserID)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_SMPM_li_rptReturnByDateRangeModified_R2", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = FromDate;
            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = ToDate;
            command.Parameters.Add("@MemoFrom", SqlDbType.VarChar).Value = MemoFrom;
            command.Parameters.Add("@MemoTo", SqlDbType.VarChar).Value = MemoTo;
            command.Parameters.Add("@IsQawmi", SqlDbType.VarChar).Value = IsQawmi;
            command.Parameters.Add("@userID", SqlDbType.VarChar).Value = UserID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();

            return dt;
        }
    }

    //--------------------Rezaul Hossain------------------------------

}



