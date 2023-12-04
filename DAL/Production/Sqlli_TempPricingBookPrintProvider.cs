using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_TempPricingBookPrintProvider:DataAccessObject
{
	public SqlLi_TempPricingBookPrintProvider()
    {
    }


    public bool DeleteLi_TempPricingBookPrint()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_TempPricingBookPrint", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TempPricingBookPrint> GetAllLi_TempPricingBookPrints()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_TempPricingBookPrints", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TempPricingBookPrintsFromReader(reader);
        }
    }
    public List<Li_TempPricingBookPrint> GetLi_TempPricingBookPrintsFromReader(IDataReader reader)
    {
        List<Li_TempPricingBookPrint> li_TempPricingBookPrints = new List<Li_TempPricingBookPrint>();

        while (reader.Read())
        {
            li_TempPricingBookPrints.Add(GetLi_TempPricingBookPrintFromReader(reader));
        }
        return li_TempPricingBookPrints;
    }

    public Li_TempPricingBookPrint GetLi_TempPricingBookPrintFromReader(IDataReader reader)
    {
        try
        {
            Li_TempPricingBookPrint li_TempPricingBookPrint = new Li_TempPricingBookPrint
                (
                     
                    reader["BookCode"].ToString(),
                    reader["BookName"].ToString(),
                    reader["BookForma"].ToString(),
                    reader["BookSize"].ToString(),
                    reader["BookQty"].ToString(),
                    reader["BookEddition"].ToString(),
                    reader["LaminationType"].ToString(),
                    reader["BindingType"].ToString(),
                    (bool)reader["IsCreasing"],
                    reader["CoverPaper"].ToString(),
                    reader["CoverColor"].ToString(),
                    reader["CoverSize"].ToString(),
                    reader["CoverWeight"].ToString(),
                    reader["CoverBrand"].ToString(),
                    reader["InnerSize"].ToString(),
                    reader["InnerArt4Color"].ToString(),
                    reader["InnerOffset4Qty"].ToString(),
                    reader["InnerOffset2Qty"].ToString(),
                    reader["InnerNewsPaper"].ToString(),
                    reader["InnerArt4ColorWeight"].ToString(),
                    reader["InnerOffset4QtyWeight"].ToString(),
                    reader["InnerOffset2QtyWeight"].ToString(),
                    reader["InnerNewsPaperWeight"].ToString(),
                    reader["FormaPaper"].ToString(),
                    reader["FormaColor"].ToString(),
                    reader["FormaSize"].ToString(),
                    reader["FormaWeight"].ToString(),
                    reader["FormaBrand"].ToString(),
                    reader["WriterBillType"].ToString(),
                    reader["WriterRate"].ToString(),
                    reader["EditRate"].ToString(),
                    reader["ComposeRate"].ToString(),
                    reader["ProofRate"].ToString(),
                    reader["ProofTimes"].ToString(),
                    reader["LaminationRate"].ToString(),
                    reader["BindingRate"].ToString(),
                    reader["CoverPrintRate"].ToString(),
                    reader["InnerPrintRate"].ToString(),
                    reader["FormaPrintRate"].ToString(),
                    reader["ManufacturingOver"].ToString(),
                    reader["AdministrativeOver"].ToString(),
                    reader["MKTPromotionalOver"].ToString(),
                    reader["Wastage"].ToString(),
                    reader["Bonus"].ToString(),
                    reader["Commission"].ToString(),
                    reader["MarkUp"].ToString(),
                    reader["CoverPageQty"].ToString(),
                    reader["CoverPageRate"].ToString(),
                    reader["CoverAmount"].ToString(),
                    reader["InnerPaperQty"].ToString(),
                    reader["InnerPaperRate"].ToString(),
                    reader["InnerPaperAmount"].ToString(),
                    reader["FormaPaperQty"].ToString(),
                    reader["FormaPaperRate"].ToString(),
                    reader["FormaPaperAmount"].ToString(),
                    reader["WriterBill"].ToString(),
                    reader["EditingCharge"].ToString(),
                    reader["ProofCharge"].ToString(),
                    reader["ComposingCharge"].ToString(),
                    reader["CoverDesign"].ToString(),
                    reader["InnerDesign"].ToString(),
                    reader["Illustration"].ToString(),
                    reader["CoverPlateCharge"].ToString(),
                    reader["InnerPlateCharge"].ToString(),
                    reader["FormaPlateCharge"].ToString(),
                    reader["CoverPrint"].ToString(),
                    reader["InnerPrint"].ToString(),
                    reader["FormaPrint"].ToString(),
                    reader["LaminationBill"].ToString(),
                    reader["BindingBill"].ToString(),
                    reader["TotalDirectCost"].ToString(),
                    reader["DirectCostPerBook"].ToString(),
                    reader["TotalCostOfSales"].ToString(),
                    reader["FinalRevenue"].ToString(),
                    reader["NetPrice"].ToString(),
                    reader["WrittenPrice"].ToString(),
                    reader["TCSPerforma"].ToString(),
                    reader["FinalRevenuePerForma"].ToString(),
                    reader["FormaPaperUnit"].ToString(),
                    reader["MRPpPerForma"].ToString() 
                     
                );
             return li_TempPricingBookPrint;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TempPricingBookPrint GetLi_TempPricingBookPrintByID(int li_TempPricingBookPrintID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_TempPricingBookPrintByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_TempPricingBookPrintID", SqlDbType.Int).Value = li_TempPricingBookPrintID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TempPricingBookPrintFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TempPricingBookPrint(Li_TempPricingBookPrint li_TempPricingBookPrint)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_TempPricingBookPrint", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookCode;
            cmd.Parameters.Add("@BookName", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookName;
            cmd.Parameters.Add("@BookForma", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookForma;
            cmd.Parameters.Add("@BookSize", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookSize;
            cmd.Parameters.Add("@BookQty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookQty;
            cmd.Parameters.Add("@BookEddition", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookEddition;
            cmd.Parameters.Add("@LaminationType", SqlDbType.VarChar).Value = li_TempPricingBookPrint.LaminationType;
            cmd.Parameters.Add("@BindingType", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BindingType;
            cmd.Parameters.Add("@IsCreasing", SqlDbType.Bit).Value = li_TempPricingBookPrint.IsCreasing;
            cmd.Parameters.Add("@CoverPaper", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPaper;
            cmd.Parameters.Add("@CoverColor", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverColor;
            cmd.Parameters.Add("@CoverSize", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverSize;
            cmd.Parameters.Add("@CoverWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverWeight;
            cmd.Parameters.Add("@CoverBrand", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverBrand;
            cmd.Parameters.Add("@InnerSize", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerSize;
            cmd.Parameters.Add("@InnerArt4Color", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerArt4Color;
            cmd.Parameters.Add("@InnerOffset4Qty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerOffset4Qty;
            cmd.Parameters.Add("@InnerOffset2Qty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerOffset2Qty;
            cmd.Parameters.Add("@InnerNewsPaper", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerNewsPaper;
            cmd.Parameters.Add("@InnerArt4ColorWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerArt4ColorWeight;
            cmd.Parameters.Add("@InnerOffset4QtyWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerOffset4QtyWeight;
            cmd.Parameters.Add("@InnerOffset2QtyWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerOffset2QtyWeight;
            cmd.Parameters.Add("@InnerNewsPaperWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerNewsPaperWeight;
            cmd.Parameters.Add("@FormaPaper", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPaper;
            cmd.Parameters.Add("@FormaColor", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaColor;
            cmd.Parameters.Add("@FormaSize", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaSize;
            cmd.Parameters.Add("@FormaWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaWeight;
            cmd.Parameters.Add("@FormaBrand", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaBrand;
            cmd.Parameters.Add("@WriterBillType", SqlDbType.VarChar).Value = li_TempPricingBookPrint.WriterBillType;
            cmd.Parameters.Add("@WriterRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.WriterRate;
            cmd.Parameters.Add("@EditRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.EditRate;
            cmd.Parameters.Add("@ComposeRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ComposeRate;
            cmd.Parameters.Add("@ProofRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ProofRate;
            cmd.Parameters.Add("@ProofTimes", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ProofTimes;
            cmd.Parameters.Add("@LaminationRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.LaminationRate;
            cmd.Parameters.Add("@BindingRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BindingRate;
            cmd.Parameters.Add("@CoverPrintRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPrintRate;
            cmd.Parameters.Add("@InnerPrintRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPrintRate;
            cmd.Parameters.Add("@FormaPrintRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPrintRate;
            cmd.Parameters.Add("@ManufacturingOver", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ManufacturingOver;
            cmd.Parameters.Add("@AdministrativeOver", SqlDbType.VarChar).Value = li_TempPricingBookPrint.AdministrativeOver;
            cmd.Parameters.Add("@MKTPromotionalOver", SqlDbType.VarChar).Value = li_TempPricingBookPrint.MKTPromotionalOver;
            cmd.Parameters.Add("@Wastage", SqlDbType.VarChar).Value = li_TempPricingBookPrint.Wastage;
            cmd.Parameters.Add("@Bonus", SqlDbType.VarChar).Value = li_TempPricingBookPrint.Bonus;
            cmd.Parameters.Add("@Commission", SqlDbType.VarChar).Value = li_TempPricingBookPrint.Commission;
            cmd.Parameters.Add("@MarkUp", SqlDbType.VarChar).Value = li_TempPricingBookPrint.MarkUp;
            cmd.Parameters.Add("@CoverPageQty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPageQty;
            cmd.Parameters.Add("@CoverPageRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPageRate;
            cmd.Parameters.Add("@CoverAmount", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverAmount;
            cmd.Parameters.Add("@InnerPaperQty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPaperQty;
            cmd.Parameters.Add("@InnerPaperRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPaperRate;
            cmd.Parameters.Add("@InnerPaperAmount", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPaperAmount;
            cmd.Parameters.Add("@FormaPaperQty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPaperQty;
            cmd.Parameters.Add("@FormaPaperRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPaperRate;
            cmd.Parameters.Add("@FormaPaperAmount", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPaperAmount;
            cmd.Parameters.Add("@WriterBill", SqlDbType.VarChar).Value = li_TempPricingBookPrint.WriterBill;
            cmd.Parameters.Add("@EditingCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.EditingCharge;
            cmd.Parameters.Add("@ProofCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ProofCharge;
            cmd.Parameters.Add("@ComposingCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ComposingCharge;
            cmd.Parameters.Add("@CoverDesign", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverDesign;
            cmd.Parameters.Add("@InnerDesign", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerDesign;
            cmd.Parameters.Add("@Illustration", SqlDbType.VarChar).Value = li_TempPricingBookPrint.Illustration;
            cmd.Parameters.Add("@CoverPlateCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPlateCharge;
            cmd.Parameters.Add("@InnerPlateCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPlateCharge;
            cmd.Parameters.Add("@FormaPlateCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPlateCharge;
            cmd.Parameters.Add("@CoverPrint", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPrint;
            cmd.Parameters.Add("@InnerPrint", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPrint;
            cmd.Parameters.Add("@FormaPrint", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPrint;
            cmd.Parameters.Add("@LaminationBill", SqlDbType.VarChar).Value = li_TempPricingBookPrint.LaminationBill;
            cmd.Parameters.Add("@BindingBill", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BindingBill;
            cmd.Parameters.Add("@TotalDirectCost", SqlDbType.VarChar).Value = li_TempPricingBookPrint.TotalDirectCost;
            cmd.Parameters.Add("@DirectCostPerBook", SqlDbType.VarChar).Value = li_TempPricingBookPrint.DirectCostPerBook;
            cmd.Parameters.Add("@TotalCostOfSales", SqlDbType.VarChar).Value = li_TempPricingBookPrint.TotalCostOfSales;
            cmd.Parameters.Add("@FinalRevenue", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FinalRevenue;
            cmd.Parameters.Add("@NetPrice", SqlDbType.VarChar).Value = li_TempPricingBookPrint.NetPrice;
            cmd.Parameters.Add("@WrittenPrice", SqlDbType.VarChar).Value = li_TempPricingBookPrint.WrittenPrice;
            cmd.Parameters.Add("@TCSPerforma", SqlDbType.VarChar).Value = li_TempPricingBookPrint.TCSPerforma;
            cmd.Parameters.Add("@FinalRevenuePerForma", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FinalRevenuePerForma;
            cmd.Parameters.Add("@FormaPaperUnit", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPaperUnit;
            cmd.Parameters.Add("@MRPpPerForma", SqlDbType.VarChar).Value = li_TempPricingBookPrint.MRPpPerForma;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_TempPricingBookPrint(Li_TempPricingBookPrint li_TempPricingBookPrint)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_TempPricingBookPrint", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookCode;
            cmd.Parameters.Add("@BookName", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookName;
            cmd.Parameters.Add("@BookForma", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookForma;
            cmd.Parameters.Add("@BookSize", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookSize;
            cmd.Parameters.Add("@BookQty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookQty;
            cmd.Parameters.Add("@BookEddition", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BookEddition;
            cmd.Parameters.Add("@LaminationType", SqlDbType.VarChar).Value = li_TempPricingBookPrint.LaminationType;
            cmd.Parameters.Add("@BindingType", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BindingType;
            cmd.Parameters.Add("@IsCreasing", SqlDbType.Bit).Value = li_TempPricingBookPrint.IsCreasing;
            cmd.Parameters.Add("@CoverPaper", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPaper;
            cmd.Parameters.Add("@CoverColor", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverColor;
            cmd.Parameters.Add("@CoverSize", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverSize;
            cmd.Parameters.Add("@CoverWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverWeight;
            cmd.Parameters.Add("@CoverBrand", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverBrand;
            cmd.Parameters.Add("@InnerSize", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerSize;
            cmd.Parameters.Add("@InnerArt4Color", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerArt4Color;
            cmd.Parameters.Add("@InnerOffset4Qty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerOffset4Qty;
            cmd.Parameters.Add("@InnerOffset2Qty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerOffset2Qty;
            cmd.Parameters.Add("@InnerNewsPaper", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerNewsPaper;
            cmd.Parameters.Add("@InnerArt4ColorWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerArt4ColorWeight;
            cmd.Parameters.Add("@InnerOffset4QtyWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerOffset4QtyWeight;
            cmd.Parameters.Add("@InnerOffset2QtyWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerOffset2QtyWeight;
            cmd.Parameters.Add("@InnerNewsPaperWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerNewsPaperWeight;
            cmd.Parameters.Add("@FormaPaper", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPaper;
            cmd.Parameters.Add("@FormaColor", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaColor;
            cmd.Parameters.Add("@FormaSize", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaSize;
            cmd.Parameters.Add("@FormaWeight", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaWeight;
            cmd.Parameters.Add("@FormaBrand", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaBrand;
            cmd.Parameters.Add("@WriterBillType", SqlDbType.VarChar).Value = li_TempPricingBookPrint.WriterBillType;
            cmd.Parameters.Add("@WriterRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.WriterRate;
            cmd.Parameters.Add("@EditRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.EditRate;
            cmd.Parameters.Add("@ComposeRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ComposeRate;
            cmd.Parameters.Add("@ProofRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ProofRate;
            cmd.Parameters.Add("@ProofTimes", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ProofTimes;
            cmd.Parameters.Add("@LaminationRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.LaminationRate;
            cmd.Parameters.Add("@BindingRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BindingRate;
            cmd.Parameters.Add("@CoverPrintRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPrintRate;
            cmd.Parameters.Add("@InnerPrintRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPrintRate;
            cmd.Parameters.Add("@FormaPrintRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPrintRate;
            cmd.Parameters.Add("@ManufacturingOver", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ManufacturingOver;
            cmd.Parameters.Add("@AdministrativeOver", SqlDbType.VarChar).Value = li_TempPricingBookPrint.AdministrativeOver;
            cmd.Parameters.Add("@MKTPromotionalOver", SqlDbType.VarChar).Value = li_TempPricingBookPrint.MKTPromotionalOver;
            cmd.Parameters.Add("@Wastage", SqlDbType.VarChar).Value = li_TempPricingBookPrint.Wastage;
            cmd.Parameters.Add("@Bonus", SqlDbType.VarChar).Value = li_TempPricingBookPrint.Bonus;
            cmd.Parameters.Add("@Commission", SqlDbType.VarChar).Value = li_TempPricingBookPrint.Commission;
            cmd.Parameters.Add("@MarkUp", SqlDbType.VarChar).Value = li_TempPricingBookPrint.MarkUp;
            cmd.Parameters.Add("@CoverPageQty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPageQty;
            cmd.Parameters.Add("@CoverPageRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPageRate;
            cmd.Parameters.Add("@CoverAmount", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverAmount;
            cmd.Parameters.Add("@InnerPaperQty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPaperQty;
            cmd.Parameters.Add("@InnerPaperRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPaperRate;
            cmd.Parameters.Add("@InnerPaperAmount", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPaperAmount;
            cmd.Parameters.Add("@FormaPaperQty", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPaperQty;
            cmd.Parameters.Add("@FormaPaperRate", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPaperRate;
            cmd.Parameters.Add("@FormaPaperAmount", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPaperAmount;
            cmd.Parameters.Add("@WriterBill", SqlDbType.VarChar).Value = li_TempPricingBookPrint.WriterBill;
            cmd.Parameters.Add("@EditingCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.EditingCharge;
            cmd.Parameters.Add("@ProofCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ProofCharge;
            cmd.Parameters.Add("@ComposingCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.ComposingCharge;
            cmd.Parameters.Add("@CoverDesign", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverDesign;
            cmd.Parameters.Add("@InnerDesign", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerDesign;
            cmd.Parameters.Add("@Illustration", SqlDbType.VarChar).Value = li_TempPricingBookPrint.Illustration;
            cmd.Parameters.Add("@CoverPlateCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPlateCharge;
            cmd.Parameters.Add("@InnerPlateCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPlateCharge;
            cmd.Parameters.Add("@FormaPlateCharge", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPlateCharge;
            cmd.Parameters.Add("@CoverPrint", SqlDbType.VarChar).Value = li_TempPricingBookPrint.CoverPrint;
            cmd.Parameters.Add("@InnerPrint", SqlDbType.VarChar).Value = li_TempPricingBookPrint.InnerPrint;
            cmd.Parameters.Add("@FormaPrint", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPrint;
            cmd.Parameters.Add("@LaminationBill", SqlDbType.VarChar).Value = li_TempPricingBookPrint.LaminationBill;
            cmd.Parameters.Add("@BindingBill", SqlDbType.VarChar).Value = li_TempPricingBookPrint.BindingBill;
            cmd.Parameters.Add("@TotalDirectCost", SqlDbType.VarChar).Value = li_TempPricingBookPrint.TotalDirectCost;
            cmd.Parameters.Add("@DirectCostPerBook", SqlDbType.VarChar).Value = li_TempPricingBookPrint.DirectCostPerBook;
            cmd.Parameters.Add("@TotalCostOfSales", SqlDbType.VarChar).Value = li_TempPricingBookPrint.TotalCostOfSales;
            cmd.Parameters.Add("@FinalRevenue", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FinalRevenue;
            cmd.Parameters.Add("@NetPrice", SqlDbType.VarChar).Value = li_TempPricingBookPrint.NetPrice;
            cmd.Parameters.Add("@WrittenPrice", SqlDbType.VarChar).Value = li_TempPricingBookPrint.WrittenPrice;
            cmd.Parameters.Add("@TCSPerforma", SqlDbType.VarChar).Value = li_TempPricingBookPrint.TCSPerforma;
            cmd.Parameters.Add("@FinalRevenuePerForma", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FinalRevenuePerForma;
            cmd.Parameters.Add("@FormaPaperUnit", SqlDbType.VarChar).Value = li_TempPricingBookPrint.FormaPaperUnit;
            cmd.Parameters.Add("@MRPpPerForma", SqlDbType.VarChar).Value = li_TempPricingBookPrint.MRPpPerForma;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
