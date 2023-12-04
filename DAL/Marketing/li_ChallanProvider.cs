using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sql_li_ChallanProvider:DataAccessObject
{
	public Sql_li_ChallanProvider()
    {
    }



    public List<li_Challan> GetAll_Challans()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_Challans", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_ChallansFromReader(reader);
        }
    }
    public List<li_Challan> Get_ChallansFromReader(IDataReader reader)
    {
        List<li_Challan> li_Challans = new List<li_Challan>();

        while (reader.Read())
        {
            li_Challans.Add(Get_ChallanFromReader(reader));
        }
        return li_Challans;
    }

    public li_Challan Get_ChallanFromReader(IDataReader reader)
    {
        try
        {
            li_Challan li_Challan = new li_Challan
                (
                    reader["ChallanID"].ToString(),
                    reader["MemoNo"].ToString(),
                    (decimal)reader["TotalAmount"],
                    (decimal)reader["AmountReceivable"],
                    reader["CreatedBy"].ToString(),
                    reader["DeliveredBy"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (DateTime)reader["DeliveryDate"],
                    (decimal)reader["Bonus"],
                    reader["LibraryID"].ToString(),
                    (bool)reader["IsBonuChalan"],
                    (int)reader["PacketNo"],
                    (decimal)reader["PerPacketCost"],                     
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (bool)reader["IsPaid"],
                    (int)reader["IsComplete"],
                    (bool)reader["DakhilBonus"],
                    (bool)reader["AlimBonus"],
                    (bool)reader["AlimSpecial"],
                    reader ["Comp"].ToString ()
                    
                    );
             return li_Challan;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public li_Challan Get_ChallanByChallanID(string   challanID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ChallanByChallanID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChallanID", SqlDbType.Int).Value = challanID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_ChallanFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  Insert_Challan(li_Challan li_Challan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_Challan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_Challan.ChallanID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_Challan.MemoNo;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Money).Value = li_Challan.TotalAmount;
            cmd.Parameters.Add("@AmountReceivable", SqlDbType.Money).Value = li_Challan.AmountReceivable;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_Challan.CreatedBy;
            cmd.Parameters.Add("@DeliveredBy", SqlDbType.VarChar).Value = li_Challan.DeliveredBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Challan.CreatedDate;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_Challan.DeliveryDate;
            cmd.Parameters.Add("@Bonus", SqlDbType.Money).Value = li_Challan.Bonus;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Challan.LibraryID;
            cmd.Parameters.Add("@IsBonuChalan", SqlDbType.Bit).Value = li_Challan.IsBonuChalan;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_Challan.PacketNo;
            cmd.Parameters.Add("@perpacCost", SqlDbType.Decimal).Value = li_Challan.PerPacketCost;             
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Challan.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Challan.ModifiedDate;
            cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = li_Challan.IsPaid;
            cmd.Parameters.Add("@IsComplete", SqlDbType.Int).Value = li_Challan.IsComplete;
            cmd.Parameters.Add("@DakhilBonus", SqlDbType.Bit).Value = li_Challan.DakhilBonus;
            cmd.Parameters.Add("@AlimBonus", SqlDbType.Bit).Value = li_Challan.AlimBonus;
            cmd.Parameters.Add("@AlimSpecial", SqlDbType.Bit).Value = li_Challan.AlimSpecial;
            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comp", SqlDbType.VarChar ).Value  =li_Challan.Comp  ;

            connection.Open();
            cmd.ExecuteNonQuery();
            return cmd.Parameters["@ReturnID"].Value.ToString();
        }
    }

    public string Insert_Challan_Qawmi(li_Challan li_Challan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_Challan_Qawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_Challan.ChallanID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_Challan.MemoNo;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Money).Value = li_Challan.TotalAmount;
            cmd.Parameters.Add("@AmountReceivable", SqlDbType.Money).Value = li_Challan.AmountReceivable;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_Challan.CreatedBy;
            cmd.Parameters.Add("@DeliveredBy", SqlDbType.VarChar).Value = li_Challan.DeliveredBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Challan.CreatedDate;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_Challan.DeliveryDate;
            cmd.Parameters.Add("@Bonus", SqlDbType.Money).Value = li_Challan.Bonus;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Challan.LibraryID;
            cmd.Parameters.Add("@IsBonuChalan", SqlDbType.Bit).Value = li_Challan.IsBonuChalan;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_Challan.PacketNo;
            cmd.Parameters.Add("@perpacCost", SqlDbType.Decimal).Value = li_Challan.PerPacketCost;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Challan.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Challan.ModifiedDate;
            cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = li_Challan.IsPaid;
            cmd.Parameters.Add("@IsComplete", SqlDbType.Int).Value = li_Challan.IsComplete;
            cmd.Parameters.Add("@DakhilBonus", SqlDbType.Bit).Value = li_Challan.DakhilBonus;
            cmd.Parameters.Add("@AlimBonus", SqlDbType.Bit).Value = li_Challan.AlimBonus;
            cmd.Parameters.Add("@AlimSpecial", SqlDbType.Bit).Value = li_Challan.AlimSpecial;
            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comp", SqlDbType.VarChar).Value = li_Challan.Comp;

            connection.Open();
            cmd.ExecuteNonQuery();
            return cmd.Parameters["@ReturnID"].Value.ToString();
        }
    }

    public bool Update_Challan(li_Challan li_Challan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Challan", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_Challan.ChallanID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_Challan.MemoNo;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Money).Value = li_Challan.TotalAmount;
            cmd.Parameters.Add("@AmountReceivable", SqlDbType.Money).Value = li_Challan.AmountReceivable;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_Challan.CreatedBy;
            cmd.Parameters.Add("@DeliveredBy", SqlDbType.VarChar).Value = li_Challan.DeliveredBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Challan.CreatedDate;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_Challan.DeliveryDate;
            cmd.Parameters.Add("@Bonus", SqlDbType.Money).Value = li_Challan.Bonus;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Challan.LibraryID;
            cmd.Parameters.Add("@IsBonuChalan", SqlDbType.Bit).Value = li_Challan.IsBonuChalan;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_Challan.PacketNo;
            cmd.Parameters.Add("@PerPacketCost", SqlDbType.Decimal).Value = li_Challan.PerPacketCost;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Challan.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Challan.ModifiedDate;
            cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = li_Challan.IsPaid;
            cmd.Parameters.Add("@IsComplete", SqlDbType.Int).Value = li_Challan.IsComplete;
            cmd.Parameters.Add("@DakhilBonus", SqlDbType.Bit).Value = li_Challan.DakhilBonus;
            cmd.Parameters.Add("@AlimBonus", SqlDbType.Bit).Value = li_Challan.AlimBonus;
            cmd.Parameters.Add("@AlimSpecial", SqlDbType.Bit).Value = li_Challan.AlimSpecial;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    public DataSet LoadYear()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_LoadYear", connection);
            command.CommandType = CommandType.StoredProcedure;
             connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet Get_ChallanBy_ChallanID(string challanID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_rpt_Chalan_by_ChalanID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChalanID", SqlDbType.VarChar).Value = challanID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet Get_ChallanAmountByChallanIDFromDetails(string ChallanID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_challanAmountFromChallanDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@challanID", SqlDbType.VarChar).Value = ChallanID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    
    public DataSet Get_SpecimenChallanAmountByChallanIDFromDetails(string ChallanID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_SpecimenchallanAmountFromChallanDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@challanID", SqlDbType.VarChar).Value = ChallanID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet Get_AllChallan(string fromDate, string toDate)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_ViewAllChalan", connection);
            command.CommandType = CommandType.StoredProcedure;
           
            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromDate;
           
            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = toDate ;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }






    public DataSet Get_BoishakiChalan(string fromDate, string toDate,string libraryID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_ShowBoishakiCHalanBYLibraty", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromDate;

            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = toDate;


            command.Parameters.Add("@library", SqlDbType.VarChar).Value =  libraryID; 
   
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet Get_DailyPackingCost(string fromdate, string todate, string libraryName, string MemoNo, bool ISQawmi)
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SMPM_li_rptPrintPacketCostByDate", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromdate ;
                    command.Parameters.Add("@todate", SqlDbType.VarChar).Value = todate ;
                    command.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value =  libraryName ;
                    command.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MemoNo ;
                    command.Parameters.Add("@ISQawmi", SqlDbType.Bit).Value =  ISQawmi  ;                    
                    connection.Open();
                    SqlDataAdapter myadapter = new SqlDataAdapter(command);
                    myadapter.Fill(ds);
                    myadapter.Dispose();
                    connection.Close();

                    return ds;
                }
            }


    public DataSet Get_DailyPackingCostByNameOrMemo(  string libraryName, string MemoNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_rptPrintPacketCostByLibraryOrMemo", connection);
            command.CommandType = CommandType.StoredProcedure;
 
            command.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = libraryName;
            command.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MemoNo;


            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet Get_DailyPackingCost_Web(string fromdate, string todate, string libraryName, string MemoNo,int Area)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_li_rptPrintPacketCostByDate", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromdate;
            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = todate;
            command.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = libraryName;
            command.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MemoNo;
            command.Parameters.Add("@Area", SqlDbType.Int).Value = Area ;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet Get_DailyPackingCostDifference(string fromdate, string todate, string libraryName, string MemoNo)
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SMPM_li_PacketCostDifference", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromdate ;
                    command.Parameters.Add("@todate", SqlDbType.VarChar).Value = todate ;
                    command.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value =  libraryName ;
                    command.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MemoNo ;
          
                    
                    connection.Open();
                    SqlDataAdapter myadapter = new SqlDataAdapter(command);
                    myadapter.Fill(ds);
                    myadapter.Dispose();
                    connection.Close();

                    return ds;
                }
            }


    public DataSet Get_DailyPaidChalan(string fromdate, string todate, string libraryName, string MemoNo,bool ISQawmi)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_rptPrintPacketInPaid", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromdate;
            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = todate;
            command.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = libraryName;
            command.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MemoNo;
            command.Parameters.Add("@ISQawmi", SqlDbType.Bit).Value = ISQawmi;  

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet Get_DailyPaidChalan_Web(string fromdate, string todate, string libraryName, string MemoNo,int Area)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_li_rptPrintPacketInPaid", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromdate;
            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = todate;
            command.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = libraryName;
            command.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MemoNo;
            command.Parameters.Add("@Area", SqlDbType.Int).Value =  Area ;   
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet Get_SpecimenBookQtyByChallan(string ChalanID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetSpecimenBookQtyByChalanID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@chalanID", SqlDbType.VarChar).Value = ChalanID;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }




    public DataSet Get_BookQtyByChallan(string ChalanID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetBookQtyByChalanID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@chalanID", SqlDbType.VarChar).Value = ChalanID;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }




    public DataSet Get_AllChallanByName( string name  )
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(@"select COUNT(*) as [Number of 
Entry] from li_Challan where
DeliveredBy="+"'"+name+"'" , connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet Get_AllChallanIDByMemoNo(string MemoNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllChallanIDByMemoNoForCancel", connection);
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

 public DataSet Get_AllSpecimenDByMemoNo(string MemoNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllSpecimenIDByMemoNoForCancel", connection);
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


    public bool Delete_Challan(string challanID, string Cause, int DeleBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_Challan", connection);
             cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = challanID;
             cmd.Parameters.Add("@Cause", SqlDbType.VarChar).Value = Cause ;
             cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value =DeleBy;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }




    public bool Delete_SpecimenChallan(string challanID, string Cause, int DeleBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_SpecimenChallan", connection);
             cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = challanID;
             cmd.Parameters.Add("@Cause", SqlDbType.VarChar).Value = Cause ;
             cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value =DeleBy;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
    //public DataSet GetChallanDetailsInformationByChallanIDForEdit( string ChallanID)  
    //{
    //    DataSet ds = new DataSet();
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("select COUNT(*) as [Number of Entry] from li_Challan where DeliveredBy=" + "'" + name + "'", connection);
    //        command.CommandType = CommandType.Text;
    //        connection.Open();
    //        SqlDataAdapter myadapter = new SqlDataAdapter(command);
    //        myadapter.Fill(ds);
    //        myadapter.Dispose();
    //        connection.Close();

    //        return ds;
    //    }
    //}


    public DataSet GetChallanDetailsInformationByChallanIDForEdit(string ChallanID)  
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_ChallanDetailsByChallanIDForEdit", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChllanID", SqlDbType.VarChar).Value = ChallanID;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet UpdateStock(string BookCode, int Qty) 
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_UpdateStock", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value =  BookCode;
            command.Parameters.Add("@Qty", SqlDbType.VarChar).Value = Qty ;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetChallanInformationByMemoForEdit(string MemoNo) 
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {   //SMPM_li_ChallanDetailsByChallanIDForEdit
            SqlCommand command = new SqlCommand("SMPM_li_ChallanByMemo", connection);
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



    public DataSet Get_BookQtyByFromReceive(   )
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("receive", connection);
            command.CommandType = CommandType.StoredProcedure;
 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

   public DataSet Get_BookQtyByFromChalan(   )
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Chalan", connection);
            command.CommandType = CommandType.StoredProcedure;
 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }



   public DataSet Get_AllChallanForDelivery(string fromDate, string toDate,string FromMemoNo, string ToMemo)
   {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_li_ViewAllChalanForDelivery", connection);
           command.CommandType = CommandType.StoredProcedure;

           command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromDate;

           command.Parameters.Add("@todate", SqlDbType.VarChar).Value = toDate;

           command.Parameters.Add("@fromMemoNo", SqlDbType.VarChar).Value = FromMemoNo ;
           
           command.Parameters.Add("@toMemo", SqlDbType.VarChar).Value = ToMemo  ;

           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(ds);
           myadapter.Dispose();
           connection.Close();

           return ds;
       }
   }

   public DataSet UpdateStock(string BookCode, decimal Qty,bool IsCentralStore)
   {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_li_UpdateStock", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
           command.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Qty;
           command.Parameters.Add("@IsCentralStore", SqlDbType. Bit ).Value =  IsCentralStore;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(ds);
           myadapter.Dispose();
           connection.Close();

           return ds;
       }
   }


   public DataTable DatewiseChallan(string fromdate, string todate, bool Boishaki, bool Alim, bool IsQawmi, int userID)
   {
       DataTable  dt = new  DataTable ();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("web_SMPM_li_rptChalanByDateRangeModified_XML", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@fromdate", SqlDbType.NVarChar).Value = fromdate;
           command.Parameters.Add("@todate", SqlDbType.NVarChar).Value = todate;
           command.Parameters.Add("@Boishaki", SqlDbType.Bit).Value = Boishaki;
           command.Parameters.Add("@Alim", SqlDbType.Bit).Value = Alim;
           command.Parameters.Add("@IsQawmi", SqlDbType.Bit).Value = IsQawmi;
           command.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(dt);
           myadapter.Dispose();
           connection.Close();

           return dt;
       }
   }

    //--------------------Rezaul Hossain------------------------------
   public DataSet GetChallanDetailsInformationByChallanID(string ChalanID)
   {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_li_SPChallanDetailsByChallanIDForEdit", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@ChalanID", SqlDbType.VarChar).Value = ChalanID;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(ds);
           myadapter.Dispose();
           connection.Close();

           return ds;
       }
   }
   public DataSet UpdateStock(string BookAcCode, decimal Qty)
   {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_li_UpdateStockSP", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookAcCode;
           command.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Qty;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(ds);
           myadapter.Dispose();
           connection.Close();

           return ds;
       }
   }
   public DataSet Get_AllSPChallanInfoByMemoNo(string MemoNo)
   {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_li_SPChalanInfoByMemoNo", connection);
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

   public bool Delete_ChallanSpeciman(string challanID, string Cause, int DeleBy)
   {
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand cmd = new SqlCommand("SMPM_li_Delete_ChallanSpeciman", connection);
           cmd.CommandType = CommandType.StoredProcedure;

           cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = challanID;
           cmd.Parameters.Add("@Cause", SqlDbType.VarChar).Value = Cause;
           cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = DeleBy;

           connection.Open();

           int result = cmd.ExecuteNonQuery();
           return (result == 1);
       }
   }

   public List<li_Challan> GetChallanInformationByMemoNo(string memoNo)
   {
       List<li_Challan> ChallanInformations = new List<li_Challan>();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("GetChallanInformationByMemoNo", connection);
           command.CommandType = CommandType.StoredProcedure;
           SqlParameter parameter = new SqlParameter("@MemoNo", memoNo);
           command.Parameters.Add(parameter);
           connection.Open();
           SqlDataReader reader = command.ExecuteReader();
           while (reader.Read())
           {
               li_Challan aChallanInformation = new li_Challan();
               aChallanInformation.CreatedDate = (DateTime)reader["CreatedDate"];
               aChallanInformation.TotalAmount = (decimal)reader["TotalAmount"];
               aChallanInformation.PacketNo = (int)reader["PacketNo"];
               aChallanInformation.PerPacketCost = (decimal)reader["PerPacketCost"];
               aChallanInformation.AmountReceivable = (decimal)reader["AmountReceivable"];
               aChallanInformation.LibraryID = (string)reader["LibraryID"];
               ChallanInformations.Add(aChallanInformation);
           }
       }
       return ChallanInformations;
   }

   public bool UpdateLi_Challan(li_Challan li_Challan)
   {
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand cmd = new SqlCommand("SMPM_li_Update_Challan", connection);
           cmd.CommandType = CommandType.StoredProcedure;



           cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_Challan.MemoNo;
           //cmd.Parameters.Add("@TotalAmount", SqlDbType.Money).Value = li_Challan.TotalAmount;
           cmd.Parameters.Add("@AmountReceivable", SqlDbType.Money).Value = li_Challan.AmountReceivable;
           cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_Challan.PacketNo;
           cmd.Parameters.Add("@PerPacketCost", SqlDbType.Decimal).Value = li_Challan.PerPacketCost;
           cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Challan.ModifiedBy;
           cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Challan.ModifiedDate;

           connection.Open();

           int result = cmd.ExecuteNonQuery();
           return result == 1;
       }
   }
   public List<li_Challan> GetChallanInformationByMemoNoQ(string memoNo)
   {
       List<li_Challan> ChallanInformations = new List<li_Challan>();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("GetChallanInformationByMemoNoQ", connection);
           command.CommandType = CommandType.StoredProcedure;
           SqlParameter parameter = new SqlParameter("@MemoNo", memoNo);
           command.Parameters.Add(parameter);
           connection.Open();
           SqlDataReader reader = command.ExecuteReader();
           while (reader.Read())
           {
               li_Challan aChallanInformation = new li_Challan();
               aChallanInformation.CreatedDate = (DateTime)reader["CreatedDate"];
               aChallanInformation.TotalAmount = (decimal)reader["TotalAmount"];
               aChallanInformation.PacketNo = (int)reader["PacketNo"];
               aChallanInformation.PerPacketCost = (decimal)reader["PerPacketCost"];
               aChallanInformation.AmountReceivable = (decimal)reader["AmountReceivable"];
               aChallanInformation.LibraryID = (string)reader["LibraryID"];
               ChallanInformations.Add(aChallanInformation);
           }
       }
       return ChallanInformations;
   }
   public bool UpdateLi_ChallanQ(li_Challan li_Challan)
   {
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand cmd = new SqlCommand("SMPM_li_Update_ChallanQ", connection);
           cmd.CommandType = CommandType.StoredProcedure;



           cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_Challan.MemoNo;
           //cmd.Parameters.Add("@TotalAmount", SqlDbType.Money).Value = li_Challan.TotalAmount;
           cmd.Parameters.Add("@AmountReceivable", SqlDbType.Money).Value = li_Challan.AmountReceivable;
           cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_Challan.PacketNo;
           cmd.Parameters.Add("@PerPacketCost", SqlDbType.Decimal).Value = li_Challan.PerPacketCost;
           cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Challan.ModifiedBy;
           cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Challan.ModifiedDate;

           connection.Open();

           int result = cmd.ExecuteNonQuery();
           return result == 1;
       }
   }
   public DataSet Get_AllChallanInfoByMemoNo(string MemoNo, string ComID)
   {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_li_ChalanInfoByMemoNo", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@memoNo", SqlDbType.VarChar).Value = MemoNo;
           command.Parameters.Add("@ComID", SqlDbType.VarChar).Value = ComID;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(ds);
           myadapter.Dispose();
           connection.Close();

           return ds;
       }
   }
   public DataSet Get_AllSpecimenChallanInfoByMemoNo(string MemoNo)
   {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_li_SPChalanInfoByMemoNo", connection);
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
   //---------------------------01.04.2023-----------------------------------
   public DataSet Get_DatewiseMemoForSummary(string fromdate, string todate, int comp)
   {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("Web_SMPM_Get_DatewiseMemoForSummary", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromdate;
           command.Parameters.Add("@todate", SqlDbType.VarChar).Value = todate;
           command.Parameters.Add("@Comp", SqlDbType.Int).Value = comp;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(ds);
           myadapter.Dispose();
           connection.Close();

           return ds;
       }
   }
   public string Insert_InvoiceSummaryChallan(li_Challan li_Challan)
   {
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand cmd = new SqlCommand("SMPM_Li_Insert_InvoiceSummaryChallan", connection);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@TotalAmount", SqlDbType.Money).Value = li_Challan.TotalAmount;
           cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Challan.CreatedDate;
           cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_Challan.PacketNo;
           cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Challan.ModifiedBy;
           cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
           cmd.Parameters.Add("@Comp", SqlDbType.VarChar).Value = li_Challan.Comp;

           connection.Open();
           cmd.ExecuteNonQuery();
           return cmd.Parameters["@ReturnID"].Value.ToString();
       }
   }
   public int Insert_InvoiceSummaryChallanDetails(li_Challan li_Challan)
   {
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand cmd = new SqlCommand("SMPM_Li_Insert_InvoiceSummaryChallanDetails", connection);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@Inv_Details", SqlDbType.Int).Direction = ParameterDirection.Output;
           cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar,150).Value = li_Challan.MemoNo;
           cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Challan.CreatedDate;
           cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Challan.ModifiedBy;
           cmd.Parameters.Add("@Inv_SL", SqlDbType.VarChar).Value = li_Challan.ChallanID;
           connection.Open();
           cmd.ExecuteNonQuery();
           return (int)cmd.Parameters["@Inv_Details"].Value;

       }
   }

   public bool Update_InvoiceSummaryForPrint(Int32 InvSL)
   {
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand cmd = new SqlCommand("SMPM_Li_Update_InvoiceSummaryForPrint", connection);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@Inv_SL", SqlDbType.Int).Value = InvSL;
           cmd.Parameters.Add("@Inv_IsPrint", SqlDbType.Bit).Value = true;

           connection.Open();
          

           int result = cmd.ExecuteNonQuery();
           return result == 1;
       }
   }

   public DataSet GetBookOrderDetailsByOrderNoForEdit(string OrderNo)
   {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_li_BookReceiveDetailsByMemoNoForEdit", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = OrderNo;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(ds);
           myadapter.Dispose();
           connection.Close();

           return ds;
       }
   }

}

