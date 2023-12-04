using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using Common;
using Common.Marketing;

public class li_libraryInformationProvider : DataAccessObject
{
    public li_libraryInformationProvider()
    {
    }

    public List<li_LibraryInformation> GetAll_ComboBox_LibraryInformations(bool RSM, bool ASM, bool TSO, int RegionID, int AreaID, string TerritoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_li_GetAll_ComboBox_LibraryInformations", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RSM", SqlDbType.Bit).Value = RSM;
            command.Parameters.Add("@ASM", SqlDbType.Bit).Value = ASM;
            command.Parameters.Add("@TSO", SqlDbType.Bit).Value = TSO;
            command.Parameters.Add("@RegionID", SqlDbType.Int).Value = RegionID;
            command.Parameters.Add("@AreaID", SqlDbType.Int).Value = AreaID;
            command.Parameters.Add("@TerritoryID", SqlDbType.VarChar).Value = TerritoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_LibraryInformations_ComboBoxFromReader(reader);
        }
    }

    public List<li_LibraryInformation> GetAll_LibraryInformations(bool IsQawmi)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_LibraryInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IsQawmi", SqlDbType.Bit).Value = IsQawmi;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_LibraryInformations_ComboBoxFromReader(reader);
        }
    }
    public List<li_LibraryInformation> GetAll_ComboBox_LibraryInformations()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ComboBox_LibraryInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_LibraryInformations_ComboBoxFromReader(reader);
        }
    }



    public List<li_LibraryInformation> GetAll_ComboBox_LibraryInformationsByTerritoryID(string TerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_ComboBox_LibraryInformationsByTerritory", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TerID", SqlDbType.VarChar).Value = TerID;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_LibraryInformations_ComboBoxFromReader(reader);
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
    //public DataSet GetSearchLibraryInformation(string LibraryName)
    //    {
    //        DataSet ds = new DataSet();
    //        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand command = new SqlCommand("SMPM_li_SearchLibraryInformation", connection);
    //            command.CommandType = CommandType.StoredProcedure;
    //            command.Parameters.Add("@libraryName", SqlDbType.VarChar).Value = LibraryName;

    //            connection.Open();
    //            SqlDataAdapter myadapter = new SqlDataAdapter(command);
    //            myadapter.Fill(ds);
    //            myadapter.Dispose();
    //            connection.Close();

    //            return ds;
    //        }
    //    }

    public DataSet GetLibraryInformationByLibraryIDForEdit(string libID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_AllLibraryInformationForEdit", connection);
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

    public List<li_LibraryInformation> Get_LibraryInformations_ComboBoxFromReader(IDataReader reader)
    {
        List<li_LibraryInformation> li_LibraryInformations = new List<li_LibraryInformation>();

        while (reader.Read())
        {
            li_LibraryInformations.Add(Get_LibraryInformation_ComboBoxFromReader(reader));
        }
        return li_LibraryInformations;
    }

    public List<li_LibraryInformation> Get_LibraryInformationsFromReader(IDataReader reader)
    {
        List<li_LibraryInformation> li_LibraryInformations = new List<li_LibraryInformation>();

        while (reader.Read())
        {
            li_LibraryInformations.Add(Get_LibraryInformationFromReader(reader));
        }
        return li_LibraryInformations;
    }

    public li_LibraryInformation Get_LibraryInformation_ComboBoxFromReader(IDataReader reader)
    {
        try
        {
            li_LibraryInformation li_LibraryInformation = new li_LibraryInformation
                (

                    reader["LibraryID"].ToString(),
                    reader["LibraryName"].ToString()
                );
            return li_LibraryInformation;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }
    public li_LibraryInformation Get_LibraryInformationFromReader(IDataReader reader)
    {
        try
        {
            li_LibraryInformation li_LibraryInformation = new li_LibraryInformation
                (
                    reader["LibraryID"].ToString(),
                    reader["LibraryName"].ToString(),
                    reader["Lib_Bn"].ToString(),
                    reader["LibraryAddress"].ToString(),
                    reader["AddressforGettingBook"].ToString(),
                    reader["Sustainability"].ToString(),
                    reader["BuildingName"].ToString(),
                    reader["HoldingNo"].ToString(),
                    reader["PostOffice"].ToString(),
                    reader["MarketName"].ToString(),
                    reader["SquireFoot"].ToString(),
                    reader["ShopNumber"].ToString(),
                    reader["LibAdd_Bn"].ToString(),
                    (decimal)reader["OpeningBalance"],
                    (bool)reader["CashParty"],
                    (int)reader["Type"],
                    reader["Category"].ToString(),
                    reader["DeliveryType"].ToString(),
                    reader["Ownership"].ToString(),
                    reader["Partnership"].ToString(),
                    reader["ResponsiblePersonName"].ToString(),
                    reader["RpPhoneNo"].ToString(),
                    reader["Phone"].ToString(),
                    reader["EmailID"].ToString(),
                    reader["LibraryOwnerID"].ToString(),
                    reader["OwnerPermanentAddress"].ToString(),
                    reader["OwnerPresentAddress"].ToString(),
                    reader["OwnerEducation"].ToString(),
                    reader["SalesPersonID"].ToString(),
                    (int)reader["RegionID"],
                    (int)reader["AreaID"],
                     reader["TeritoryID"].ToString(),
                    (int)reader["DistrictID"],
                    (int)reader["ThanaID"],
                    reader["TransportID"].ToString(),
                    reader["TransportID2"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["AddedBy"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModefiedDate"],
                    reader["ShortAddress"].ToString(),
                    reader["ShAdd_Bn"].ToString(),
                    (bool)reader["IsQawmi"],
                    (bool)reader["IsBoth"],
                    (bool)reader["IsSMS"],
                    (bool)reader["IsOwned"],
                    (bool)reader["IsGodown"],
                    reader["Code"].ToString(),
                    reader["TradeLicense"].ToString(),
                    reader["NID"].ToString(),
                    reader["BapusCard"].ToString(),
                    reader["AmountofMoney"].ToString(),
                    reader["MoneyInWord"].ToString(),
                    reader["WayofPayment"].ToString()
                );
            return li_LibraryInformation;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }

    public li_LibraryInformation Get_LibraryInformationByLibraryID(int libraryID)
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
                return Get_LibraryInformationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }
    //----------------shopNumber added by Numan 2023-------------------
    public string Insert_LibraryInformation(li_LibraryInformation li_LibraryInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_LibraryInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryName;
            cmd.Parameters.Add("@ShopNumber", SqlDbType.VarChar).Value = li_LibraryInformation.ShopNumber;
            cmd.Parameters.Add("@BuldingName", SqlDbType.VarChar).Value = li_LibraryInformation.BuildingName;
            cmd.Parameters.Add("@HoldingNo", SqlDbType.VarChar).Value = li_LibraryInformation.HoldingNo;
            cmd.Parameters.Add("@PostOffice", SqlDbType.VarChar).Value = li_LibraryInformation.PostOffice;
            cmd.Parameters.Add("@MarketName", SqlDbType.VarChar).Value = li_LibraryInformation.MarketName;
            cmd.Parameters.Add("@SquireFoot", SqlDbType.VarChar).Value = li_LibraryInformation.SquireFoot;
            cmd.Parameters.Add("@Lib_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.Lib_Bn;
            cmd.Parameters.Add("@LibraryAddress", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryAddress;
            cmd.Parameters.Add("@AddressforGettingBook", SqlDbType.VarChar).Value = li_LibraryInformation.AddressforGettingBook;
            cmd.Parameters.Add("@LibAdd_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.LibAdd_Bn;
            cmd.Parameters.Add("@OpeningBalance", SqlDbType.Decimal).Value = li_LibraryInformation.OpeningBalance;
            cmd.Parameters.Add("@CashParty", SqlDbType.Bit).Value = li_LibraryInformation.CashParty;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = li_LibraryInformation.Type;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = li_LibraryInformation.Category;
            cmd.Parameters.Add("@DeliveryType", SqlDbType.VarChar).Value = li_LibraryInformation.DeliveryType;
            cmd.Parameters.Add("@Ownership", SqlDbType.VarChar).Value = li_LibraryInformation.Ownership;
            cmd.Parameters.Add("@Partnership", SqlDbType.VarChar).Value = li_LibraryInformation.Partnership;
            cmd.Parameters.Add("@ResponsiblePersonName", SqlDbType.VarChar).Value = li_LibraryInformation.ResponsiblePersonName;
            cmd.Parameters.Add("@RpPhoneNo", SqlDbType.VarChar).Value = li_LibraryInformation.RpPhoneNo;
            cmd.Parameters.Add("@Telephone", SqlDbType.VarChar).Value = li_LibraryInformation.Telephone;
            cmd.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = li_LibraryInformation.EmailID;
            cmd.Parameters.Add("@LibraryOwnerID", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryOwnerID;
            cmd.Parameters.Add("@OwnerPermanentAddress", SqlDbType.VarChar).Value = li_LibraryInformation.OwnerPermanentAddress;

            cmd.Parameters.Add("@OwnerPresentAddress", SqlDbType.VarChar).Value = li_LibraryInformation.OwnerPresentAddress;

            cmd.Parameters.Add("@OwnerEducation", SqlDbType.VarChar).Value = li_LibraryInformation.OwnerEducation;

            cmd.Parameters.Add("@SalesPersonID", SqlDbType.VarChar).Value = li_LibraryInformation.SalesPersonID;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = li_LibraryInformation.RegionID;
            cmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = li_LibraryInformation.AreaID;
            cmd.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = li_LibraryInformation.TeritoryID;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = li_LibraryInformation.DistrictID;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = li_LibraryInformation.ThanaID;
            cmd.Parameters.Add("@TransportID", SqlDbType.VarChar).Value = li_LibraryInformation.TransportID;
            cmd.Parameters.Add("@TransportID2", SqlDbType.VarChar).Value = li_LibraryInformation.TransportID2;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LibraryInformation.CreatedDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = li_LibraryInformation.AddedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LibraryInformation.ModifiedBy;
            cmd.Parameters.Add("@ModefiedDate", SqlDbType.DateTime).Value = li_LibraryInformation.ModefiedDate;
            cmd.Parameters.Add("@ShortAddress", SqlDbType.VarChar).Value = li_LibraryInformation.ShortAddress;
            cmd.Parameters.Add("@ShAdd_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.ShAdd_Bn;
            cmd.Parameters.Add("@IsQawmi", SqlDbType.Bit).Value = li_LibraryInformation.IsQawmi;
            cmd.Parameters.Add("@IsSMS", SqlDbType.Bit).Value = li_LibraryInformation.IsSMS;
            cmd.Parameters.Add("@IsBoth", SqlDbType.Bit).Value = li_LibraryInformation.IsBoth;
            cmd.Parameters.Add("@IsOwned", SqlDbType.Bit).Value = li_LibraryInformation.IsOwned;
            cmd.Parameters.Add("@IsGodown", SqlDbType.Bit).Value = li_LibraryInformation.IsGodown;
            cmd.Parameters.Add("@Sustainability", SqlDbType.VarChar).Value = li_LibraryInformation.Sustainability;
            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = li_LibraryInformation.Code;
            cmd.Parameters.Add("@TradeLicense", SqlDbType.VarChar).Value = li_LibraryInformation.TradeLicense;
            cmd.Parameters.Add("@NID", SqlDbType.VarChar).Value = li_LibraryInformation.NID;
            cmd.Parameters.Add("@BapusCard", SqlDbType.VarChar).Value = li_LibraryInformation.BapusCard;
            cmd.Parameters.Add("@AmountofMoney", SqlDbType.VarChar).Value = li_LibraryInformation.AmountofMoney;
            cmd.Parameters.Add("@MoneyInWord", SqlDbType.VarChar).Value = li_LibraryInformation.MoneyInWord;
            cmd.Parameters.Add("@WayofPayment", SqlDbType.VarChar).Value = li_LibraryInformation.WayofPayment;

            connection.Open();

            cmd.ExecuteNonQuery();
            return cmd.Parameters["@ReturnID"].Value.ToString();



        }
    }
    // --------------------Rezaul Hossain---------------
    public DataSet GetLibraryInfoByTeritoryID(string TerCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetLibraryInformationsByTerritory", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TerID", SqlDbType.VarChar).Value = TerCode;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public bool Update_LibraryOpeningBalance(li_LibraryInformation li_LibraryInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_LibraryInformation_OpeningBalance", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryID;
            cmd.Parameters.Add("@OpeningBalance", SqlDbType.Money).Value = li_LibraryInformation.OpeningBalance;
            cmd.Parameters.Add("@createdBy", SqlDbType.Money).Value = li_LibraryInformation.AddedBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Update_LibraryInformation(li_LibraryInformation li_LibraryInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_LibraryInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryID;
            cmd.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryName;
            cmd.Parameters.Add("@ShopNumber", SqlDbType.VarChar).Value = li_LibraryInformation.ShopNumber;
            cmd.Parameters.Add("@BuldingName", SqlDbType.VarChar).Value = li_LibraryInformation.BuildingName;
            cmd.Parameters.Add("@HoldingNo", SqlDbType.VarChar).Value = li_LibraryInformation.HoldingNo;
            cmd.Parameters.Add("@PostOffice", SqlDbType.VarChar).Value = li_LibraryInformation.PostOffice;
            cmd.Parameters.Add("@MarketName", SqlDbType.VarChar).Value = li_LibraryInformation.MarketName;
            cmd.Parameters.Add("@SquireFoot", SqlDbType.VarChar).Value = li_LibraryInformation.SquireFoot;
            cmd.Parameters.Add("@Lib_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.Lib_Bn;
            cmd.Parameters.Add("@LibraryAddress", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryAddress;
            cmd.Parameters.Add("@AddressforGettingBook", SqlDbType.VarChar).Value = li_LibraryInformation.AddressforGettingBook;
            cmd.Parameters.Add("@LibAdd_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.LibAdd_Bn;
            cmd.Parameters.Add("@OpeningBalance", SqlDbType.Decimal).Value = li_LibraryInformation.OpeningBalance;
            cmd.Parameters.Add("@CashParty", SqlDbType.Bit).Value = li_LibraryInformation.CashParty;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = li_LibraryInformation.Type;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = li_LibraryInformation.Category;
            cmd.Parameters.Add("@DeliveryType", SqlDbType.VarChar).Value = li_LibraryInformation.DeliveryType;
            cmd.Parameters.Add("@Ownership", SqlDbType.VarChar).Value = li_LibraryInformation.Ownership;
            cmd.Parameters.Add("@Partnership", SqlDbType.VarChar).Value = li_LibraryInformation.Partnership;
            cmd.Parameters.Add("@ResponsiblePersonName", SqlDbType.VarChar).Value = li_LibraryInformation.ResponsiblePersonName;
            cmd.Parameters.Add("@RpPhoneNo", SqlDbType.VarChar).Value = li_LibraryInformation.RpPhoneNo;
            cmd.Parameters.Add("@Telephone", SqlDbType.VarChar).Value = li_LibraryInformation.Telephone;
            cmd.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = li_LibraryInformation.EmailID;
            cmd.Parameters.Add("@LibraryOwnerID", SqlDbType.VarChar).Value = li_LibraryInformation.LibraryOwnerID;
            cmd.Parameters.Add("@OwnerPermanentAddress", SqlDbType.VarChar).Value = li_LibraryInformation.OwnerPermanentAddress;

            cmd.Parameters.Add("@OwnerPresentAddress", SqlDbType.VarChar).Value = li_LibraryInformation.OwnerPresentAddress;

            cmd.Parameters.Add("@OwnerEducation", SqlDbType.VarChar).Value = li_LibraryInformation.OwnerEducation;
            cmd.Parameters.Add("@SalesPersonID", SqlDbType.VarChar).Value = li_LibraryInformation.SalesPersonID;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = li_LibraryInformation.RegionID;
            cmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = li_LibraryInformation.AreaID;
            cmd.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = li_LibraryInformation.TeritoryID;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = li_LibraryInformation.DistrictID;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = li_LibraryInformation.ThanaID;
            cmd.Parameters.Add("@TransportID", SqlDbType.VarChar).Value = li_LibraryInformation.TransportID;
            cmd.Parameters.Add("@TransportID2", SqlDbType.VarChar).Value = li_LibraryInformation.TransportID2;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LibraryInformation.CreatedDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = li_LibraryInformation.AddedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LibraryInformation.ModifiedBy;
            cmd.Parameters.Add("@ModefiedDate", SqlDbType.DateTime).Value = li_LibraryInformation.ModefiedDate;
            cmd.Parameters.Add("@ShortAddress", SqlDbType.VarChar).Value = li_LibraryInformation.ShortAddress;
            cmd.Parameters.Add("@ShAdd_Bn", SqlDbType.VarChar).Value = li_LibraryInformation.ShAdd_Bn;
            cmd.Parameters.Add("@IsQawmi", SqlDbType.Bit).Value = li_LibraryInformation.IsQawmi;
            cmd.Parameters.Add("@IsSMS", SqlDbType.Bit).Value = li_LibraryInformation.IsSMS;
            cmd.Parameters.Add("@IsBoth", SqlDbType.Bit).Value = li_LibraryInformation.IsBoth;
            cmd.Parameters.Add("@IsOwned", SqlDbType.Bit).Value = li_LibraryInformation.IsOwned;
            cmd.Parameters.Add("@IsGodown", SqlDbType.Bit).Value = li_LibraryInformation.IsGodown;
            cmd.Parameters.Add("@Sustainability", SqlDbType.VarChar).Value = li_LibraryInformation.Sustainability;
            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = li_LibraryInformation.Code;
            cmd.Parameters.Add("@TradeLicense", SqlDbType.VarChar).Value = li_LibraryInformation.TradeLicense;
            cmd.Parameters.Add("@NID", SqlDbType.VarChar).Value = li_LibraryInformation.NID;
            cmd.Parameters.Add("@BapusCard", SqlDbType.VarChar).Value = li_LibraryInformation.BapusCard;
            cmd.Parameters.Add("@AmountofMoney", SqlDbType.VarChar).Value = li_LibraryInformation.AmountofMoney;
            cmd.Parameters.Add("@MoneyInWord", SqlDbType.VarChar).Value = li_LibraryInformation.MoneyInWord;
            cmd.Parameters.Add("@WayofPayment", SqlDbType.VarChar).Value = li_LibraryInformation.WayofPayment;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
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


    public List<li_LibraryInformation> GetAll_ComboBox_LibraryInformations(int UserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_SMPM_li_GetAll_ComboBox_LibraryInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_LibraryInformations_ComboBoxFromReader(reader);
        }
    }

    public List<LibraryInformation> GetALLLibraryInformation()
    {
        List<LibraryInformation> informations = new List<LibraryInformation>();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLibraryInformation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                LibraryInformation aInformation = new LibraryInformation();
                aInformation.LibraryID = (string)reader["LibraryID"];
                aInformation.LibraryName = (string)reader["LibraryName"];

                aInformation.LibraryAddress = (string)reader["LibraryAddress"];
                aInformation.Telephone = (string)reader["Telephone"];
                aInformation.RegionName = (string)reader["RegionName"];
                aInformation.DivName = (string)reader["DivName"];
                aInformation.ZoneName = (string)reader["ZonName"];
                aInformation.TerritoryName = (string)reader["TeritoryName"];
                aInformation.DistrictName = (string)reader["DistrictName"];
                aInformation.ThanaName = (string)reader["ThanaName"];
                informations.Add(aInformation);
            }
        }
        return informations;
    }

    public List<li_LibraryInformation> GetAll_ComboBox_TsoInformations(int UserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_SMPM_li_GetAll_ComboBox_LibraryInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_LibraryInformations_ComboBoxFromReader(reader);
        }
    }
    //-----------------Rezaul Hossain---------------------2020-------------
    public DataSet GetLibraryInfoByRegionID(string RegionID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetLibraryInformationsByRegionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RegionID", SqlDbType.Int).Value = RegionID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetLibraryInfoByTeritoryIDQCash(string TerCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetLibraryInformationsByTerritoryQcash", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TerID", SqlDbType.VarChar).Value = TerCode;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

}

