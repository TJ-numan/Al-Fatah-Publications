using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookPricingProvider:DataAccessObject
{
	public SqlLi_BookPricingProvider()
    {
    }


    public bool DeleteLi_BookPricing(int li_BookPricingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookPricing", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookPricingID", SqlDbType.Int).Value = li_BookPricingID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookPricing> GetAllLi_BookPricings()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookPricings", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookPricingsFromReader(reader);
        }
    }
    public List<Li_BookPricing> GetLi_BookPricingsFromReader(IDataReader reader)
    {
        List<Li_BookPricing> li_BookPricings = new List<Li_BookPricing>();

        while (reader.Read())
        {
            li_BookPricings.Add(GetLi_BookPricingFromReader(reader));
        }
        return li_BookPricings;
    }

    public Li_BookPricing GetLi_BookPricingFromReader(IDataReader reader)
    {
        try
        {
            Li_BookPricing li_BookPricing = new Li_BookPricing
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
                    reader["MRPpPerForma"].ToString(),
                    reader["PaperCostTotal"].ToString(),
                    reader["PrePressTotal"].ToString(),
                    reader["PrintingTotal"].ToString(),
                    reader["PostPressTotal"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                    
                );
             return li_BookPricing;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookPricing GetLi_BookPricingByID(int li_BookPricingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookPricingByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookPricingID", SqlDbType.Int).Value = li_BookPricingID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookPricingFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BookPricing(Li_BookPricing li_BookPricing)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookPricing", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookPricing.BookCode;
            cmd.Parameters.Add("@BookName", SqlDbType.VarChar).Value = li_BookPricing.BookName;
            cmd.Parameters.Add("@BookForma", SqlDbType.VarChar).Value = li_BookPricing.BookForma;
            cmd.Parameters.Add("@BookSize", SqlDbType.VarChar).Value = li_BookPricing.BookSize;
            cmd.Parameters.Add("@BookQty", SqlDbType.VarChar).Value = li_BookPricing.BookQty;
            cmd.Parameters.Add("@BookEddition", SqlDbType.VarChar).Value = li_BookPricing.BookEddition;
            cmd.Parameters.Add("@LaminationType", SqlDbType.VarChar).Value = li_BookPricing.LaminationType;
            cmd.Parameters.Add("@BindingType", SqlDbType.VarChar).Value = li_BookPricing.BindingType;
            cmd.Parameters.Add("@IsCreasing", SqlDbType.Bit).Value = li_BookPricing.IsCreasing;
            cmd.Parameters.Add("@CoverPaper", SqlDbType.VarChar).Value = li_BookPricing.CoverPaper;
            cmd.Parameters.Add("@CoverColor", SqlDbType.VarChar).Value = li_BookPricing.CoverColor;
            cmd.Parameters.Add("@CoverSize", SqlDbType.VarChar).Value = li_BookPricing.CoverSize;
            cmd.Parameters.Add("@CoverWeight", SqlDbType.VarChar).Value = li_BookPricing.CoverWeight;
            cmd.Parameters.Add("@CoverBrand", SqlDbType.VarChar).Value = li_BookPricing.CoverBrand;
            cmd.Parameters.Add("@InnerSize", SqlDbType.VarChar).Value = li_BookPricing.InnerSize;
            cmd.Parameters.Add("@InnerArt4Color", SqlDbType.VarChar).Value = li_BookPricing.InnerArt4Color;
            cmd.Parameters.Add("@InnerOffset4Qty", SqlDbType.VarChar).Value = li_BookPricing.InnerOffset4Qty;
            cmd.Parameters.Add("@InnerOffset2Qty", SqlDbType.VarChar).Value = li_BookPricing.InnerOffset2Qty;
            cmd.Parameters.Add("@InnerNewsPaper", SqlDbType.VarChar).Value = li_BookPricing.InnerNewsPaper;
            cmd.Parameters.Add("@InnerArt4ColorWeight", SqlDbType.VarChar).Value = li_BookPricing.InnerArt4ColorWeight;
            cmd.Parameters.Add("@InnerOffset4QtyWeight", SqlDbType.VarChar).Value = li_BookPricing.InnerOffset4QtyWeight;
            cmd.Parameters.Add("@InnerOffset2QtyWeight", SqlDbType.VarChar).Value = li_BookPricing.InnerOffset2QtyWeight;
            cmd.Parameters.Add("@InnerNewsPaperWeight", SqlDbType.VarChar).Value = li_BookPricing.InnerNewsPaperWeight;
            cmd.Parameters.Add("@FormaPaper", SqlDbType.VarChar).Value = li_BookPricing.FormaPaper;
            cmd.Parameters.Add("@FormaColor", SqlDbType.VarChar).Value = li_BookPricing.FormaColor;
            cmd.Parameters.Add("@FormaSize", SqlDbType.VarChar).Value = li_BookPricing.FormaSize;
            cmd.Parameters.Add("@FormaWeight", SqlDbType.VarChar).Value = li_BookPricing.FormaWeight;
            cmd.Parameters.Add("@FormaBrand", SqlDbType.VarChar).Value = li_BookPricing.FormaBrand;
            cmd.Parameters.Add("@WriterBillType", SqlDbType.VarChar).Value = li_BookPricing.WriterBillType;
            cmd.Parameters.Add("@WriterRate", SqlDbType.VarChar).Value = li_BookPricing.WriterRate;
            cmd.Parameters.Add("@EditRate", SqlDbType.VarChar).Value = li_BookPricing.EditRate;
            cmd.Parameters.Add("@ComposeRate", SqlDbType.VarChar).Value = li_BookPricing.ComposeRate;
            cmd.Parameters.Add("@ProofRate", SqlDbType.VarChar).Value = li_BookPricing.ProofRate;
            cmd.Parameters.Add("@ProofTimes", SqlDbType.VarChar).Value = li_BookPricing.ProofTimes;
            cmd.Parameters.Add("@LaminationRate", SqlDbType.VarChar).Value = li_BookPricing.LaminationRate;
            cmd.Parameters.Add("@BindingRate", SqlDbType.VarChar).Value = li_BookPricing.BindingRate;
            cmd.Parameters.Add("@CoverPrintRate", SqlDbType.VarChar).Value = li_BookPricing.CoverPrintRate;
            cmd.Parameters.Add("@InnerPrintRate", SqlDbType.VarChar).Value = li_BookPricing.InnerPrintRate;
            cmd.Parameters.Add("@FormaPrintRate", SqlDbType.VarChar).Value = li_BookPricing.FormaPrintRate;
            cmd.Parameters.Add("@ManufacturingOver", SqlDbType.VarChar).Value = li_BookPricing.ManufacturingOver;
            cmd.Parameters.Add("@AdministrativeOver", SqlDbType.VarChar).Value = li_BookPricing.AdministrativeOver;
            cmd.Parameters.Add("@MKTPromotionalOver", SqlDbType.VarChar).Value = li_BookPricing.MKTPromotionalOver;
            cmd.Parameters.Add("@Wastage", SqlDbType.VarChar).Value = li_BookPricing.Wastage;
            cmd.Parameters.Add("@Bonus", SqlDbType.VarChar).Value = li_BookPricing.Bonus;
            cmd.Parameters.Add("@Commission", SqlDbType.VarChar).Value = li_BookPricing.Commission;
            cmd.Parameters.Add("@MarkUp", SqlDbType.VarChar).Value = li_BookPricing.MarkUp;
            cmd.Parameters.Add("@CoverPageQty", SqlDbType.VarChar).Value = li_BookPricing.CoverPageQty;
            cmd.Parameters.Add("@CoverPageRate", SqlDbType.VarChar).Value = li_BookPricing.CoverPageRate;
            cmd.Parameters.Add("@CoverAmount", SqlDbType.VarChar).Value = li_BookPricing.CoverAmount;
            cmd.Parameters.Add("@InnerPaperQty", SqlDbType.VarChar).Value = li_BookPricing.InnerPaperQty;
            cmd.Parameters.Add("@InnerPaperRate", SqlDbType.VarChar).Value = li_BookPricing.InnerPaperRate;
            cmd.Parameters.Add("@InnerPaperAmount", SqlDbType.VarChar).Value = li_BookPricing.InnerPaperAmount;
            cmd.Parameters.Add("@FormaPaperQty", SqlDbType.VarChar).Value = li_BookPricing.FormaPaperQty;
            cmd.Parameters.Add("@FormaPaperRate", SqlDbType.VarChar).Value = li_BookPricing.FormaPaperRate;
            cmd.Parameters.Add("@FormaPaperAmount", SqlDbType.VarChar).Value = li_BookPricing.FormaPaperAmount;
            cmd.Parameters.Add("@WriterBill", SqlDbType.VarChar).Value = li_BookPricing.WriterBill;
            cmd.Parameters.Add("@EditingCharge", SqlDbType.VarChar).Value = li_BookPricing.EditingCharge;
            cmd.Parameters.Add("@ProofCharge", SqlDbType.VarChar).Value = li_BookPricing.ProofCharge;
            cmd.Parameters.Add("@ComposingCharge", SqlDbType.VarChar).Value = li_BookPricing.ComposingCharge;
            cmd.Parameters.Add("@CoverDesign", SqlDbType.VarChar).Value = li_BookPricing.CoverDesign;
            cmd.Parameters.Add("@InnerDesign", SqlDbType.VarChar).Value = li_BookPricing.InnerDesign;
            cmd.Parameters.Add("@Illustration", SqlDbType.VarChar).Value = li_BookPricing.Illustration;
            cmd.Parameters.Add("@CoverPlateCharge", SqlDbType.VarChar).Value = li_BookPricing.CoverPlateCharge;
            cmd.Parameters.Add("@InnerPlateCharge", SqlDbType.VarChar).Value = li_BookPricing.InnerPlateCharge;
            cmd.Parameters.Add("@FormaPlateCharge", SqlDbType.VarChar).Value = li_BookPricing.FormaPlateCharge;
            cmd.Parameters.Add("@CoverPrint", SqlDbType.VarChar).Value = li_BookPricing.CoverPrint;
            cmd.Parameters.Add("@InnerPrint", SqlDbType.VarChar).Value = li_BookPricing.InnerPrint;
            cmd.Parameters.Add("@FormaPrint", SqlDbType.VarChar).Value = li_BookPricing.FormaPrint;
            cmd.Parameters.Add("@LaminationBill", SqlDbType.VarChar).Value = li_BookPricing.LaminationBill;
            cmd.Parameters.Add("@BindingBill", SqlDbType.VarChar).Value = li_BookPricing.BindingBill;
            cmd.Parameters.Add("@TotalDirectCost", SqlDbType.VarChar).Value = li_BookPricing.TotalDirectCost;
            cmd.Parameters.Add("@DirectCostPerBook", SqlDbType.VarChar).Value = li_BookPricing.DirectCostPerBook;
            cmd.Parameters.Add("@TotalCostOfSales", SqlDbType.VarChar).Value = li_BookPricing.TotalCostOfSales;
            cmd.Parameters.Add("@FinalRevenue", SqlDbType.VarChar).Value = li_BookPricing.FinalRevenue;
            cmd.Parameters.Add("@NetPrice", SqlDbType.VarChar).Value = li_BookPricing.NetPrice;
            cmd.Parameters.Add("@WrittenPrice", SqlDbType.VarChar).Value = li_BookPricing.WrittenPrice;
            cmd.Parameters.Add("@TCSPerforma", SqlDbType.VarChar).Value = li_BookPricing.TCSPerforma;
            cmd.Parameters.Add("@FinalRevenuePerForma", SqlDbType.VarChar).Value = li_BookPricing.FinalRevenuePerForma;
            cmd.Parameters.Add("@FormaPaperUnit", SqlDbType.VarChar).Value = li_BookPricing.FormaPaperUnit;
            cmd.Parameters.Add("@MRPpPerForma", SqlDbType.VarChar).Value = li_BookPricing.MRPpPerForma;
            cmd.Parameters.Add("@PaperCostTotal", SqlDbType.VarChar).Value = li_BookPricing.PaperCostTotal;
            cmd.Parameters.Add("@PrePressTotal", SqlDbType.VarChar).Value = li_BookPricing.PrePressTotal;
            cmd.Parameters.Add("@PrintingTotal", SqlDbType.VarChar).Value = li_BookPricing.PrintingTotal;
            cmd.Parameters.Add("@PostPressTotal", SqlDbType.VarChar).Value = li_BookPricing.PostPressTotal;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookPricing.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookPricing.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Li_BookPricingID"].Value;
        }
    }

    public bool UpdateLi_BookPricing(Li_BookPricing li_BookPricing)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookPricing", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookPricing.BookCode;
            cmd.Parameters.Add("@BookName", SqlDbType.VarChar).Value = li_BookPricing.BookName;
            cmd.Parameters.Add("@BookForma", SqlDbType.VarChar).Value = li_BookPricing.BookForma;
            cmd.Parameters.Add("@BookSize", SqlDbType.VarChar).Value = li_BookPricing.BookSize;
            cmd.Parameters.Add("@BookQty", SqlDbType.VarChar).Value = li_BookPricing.BookQty;
            cmd.Parameters.Add("@BookEddition", SqlDbType.VarChar).Value = li_BookPricing.BookEddition;
            cmd.Parameters.Add("@LaminationType", SqlDbType.VarChar).Value = li_BookPricing.LaminationType;
            cmd.Parameters.Add("@BindingType", SqlDbType.VarChar).Value = li_BookPricing.BindingType;
            cmd.Parameters.Add("@IsCreasing", SqlDbType.Bit).Value = li_BookPricing.IsCreasing;
            cmd.Parameters.Add("@CoverPaper", SqlDbType.VarChar).Value = li_BookPricing.CoverPaper;
            cmd.Parameters.Add("@CoverColor", SqlDbType.VarChar).Value = li_BookPricing.CoverColor;
            cmd.Parameters.Add("@CoverSize", SqlDbType.VarChar).Value = li_BookPricing.CoverSize;
            cmd.Parameters.Add("@CoverWeight", SqlDbType.VarChar).Value = li_BookPricing.CoverWeight;
            cmd.Parameters.Add("@CoverBrand", SqlDbType.VarChar).Value = li_BookPricing.CoverBrand;
            cmd.Parameters.Add("@InnerSize", SqlDbType.VarChar).Value = li_BookPricing.InnerSize;
            cmd.Parameters.Add("@InnerArt4Color", SqlDbType.VarChar).Value = li_BookPricing.InnerArt4Color;
            cmd.Parameters.Add("@InnerOffset4Qty", SqlDbType.VarChar).Value = li_BookPricing.InnerOffset4Qty;
            cmd.Parameters.Add("@InnerOffset2Qty", SqlDbType.VarChar).Value = li_BookPricing.InnerOffset2Qty;
            cmd.Parameters.Add("@InnerNewsPaper", SqlDbType.VarChar).Value = li_BookPricing.InnerNewsPaper;
            cmd.Parameters.Add("@InnerArt4ColorWeight", SqlDbType.VarChar).Value = li_BookPricing.InnerArt4ColorWeight;
            cmd.Parameters.Add("@InnerOffset4QtyWeight", SqlDbType.VarChar).Value = li_BookPricing.InnerOffset4QtyWeight;
            cmd.Parameters.Add("@InnerOffset2QtyWeight", SqlDbType.VarChar).Value = li_BookPricing.InnerOffset2QtyWeight;
            cmd.Parameters.Add("@InnerNewsPaperWeight", SqlDbType.VarChar).Value = li_BookPricing.InnerNewsPaperWeight;
            cmd.Parameters.Add("@FormaPaper", SqlDbType.VarChar).Value = li_BookPricing.FormaPaper;
            cmd.Parameters.Add("@FormaColor", SqlDbType.VarChar).Value = li_BookPricing.FormaColor;
            cmd.Parameters.Add("@FormaSize", SqlDbType.VarChar).Value = li_BookPricing.FormaSize;
            cmd.Parameters.Add("@FormaWeight", SqlDbType.VarChar).Value = li_BookPricing.FormaWeight;
            cmd.Parameters.Add("@FormaBrand", SqlDbType.VarChar).Value = li_BookPricing.FormaBrand;
            cmd.Parameters.Add("@WriterBillType", SqlDbType.VarChar).Value = li_BookPricing.WriterBillType;
            cmd.Parameters.Add("@WriterRate", SqlDbType.VarChar).Value = li_BookPricing.WriterRate;
            cmd.Parameters.Add("@EditRate", SqlDbType.VarChar).Value = li_BookPricing.EditRate;
            cmd.Parameters.Add("@ComposeRate", SqlDbType.VarChar).Value = li_BookPricing.ComposeRate;
            cmd.Parameters.Add("@ProofRate", SqlDbType.VarChar).Value = li_BookPricing.ProofRate;
            cmd.Parameters.Add("@ProofTimes", SqlDbType.VarChar).Value = li_BookPricing.ProofTimes;
            cmd.Parameters.Add("@LaminationRate", SqlDbType.VarChar).Value = li_BookPricing.LaminationRate;
            cmd.Parameters.Add("@BindingRate", SqlDbType.VarChar).Value = li_BookPricing.BindingRate;
            cmd.Parameters.Add("@CoverPrintRate", SqlDbType.VarChar).Value = li_BookPricing.CoverPrintRate;
            cmd.Parameters.Add("@InnerPrintRate", SqlDbType.VarChar).Value = li_BookPricing.InnerPrintRate;
            cmd.Parameters.Add("@FormaPrintRate", SqlDbType.VarChar).Value = li_BookPricing.FormaPrintRate;
            cmd.Parameters.Add("@ManufacturingOver", SqlDbType.VarChar).Value = li_BookPricing.ManufacturingOver;
            cmd.Parameters.Add("@AdministrativeOver", SqlDbType.VarChar).Value = li_BookPricing.AdministrativeOver;
            cmd.Parameters.Add("@MKTPromotionalOver", SqlDbType.VarChar).Value = li_BookPricing.MKTPromotionalOver;
            cmd.Parameters.Add("@Wastage", SqlDbType.VarChar).Value = li_BookPricing.Wastage;
            cmd.Parameters.Add("@Bonus", SqlDbType.VarChar).Value = li_BookPricing.Bonus;
            cmd.Parameters.Add("@Commission", SqlDbType.VarChar).Value = li_BookPricing.Commission;
            cmd.Parameters.Add("@MarkUp", SqlDbType.VarChar).Value = li_BookPricing.MarkUp;
            cmd.Parameters.Add("@CoverPageQty", SqlDbType.VarChar).Value = li_BookPricing.CoverPageQty;
            cmd.Parameters.Add("@CoverPageRate", SqlDbType.VarChar).Value = li_BookPricing.CoverPageRate;
            cmd.Parameters.Add("@CoverAmount", SqlDbType.VarChar).Value = li_BookPricing.CoverAmount;
            cmd.Parameters.Add("@InnerPaperQty", SqlDbType.VarChar).Value = li_BookPricing.InnerPaperQty;
            cmd.Parameters.Add("@InnerPaperRate", SqlDbType.VarChar).Value = li_BookPricing.InnerPaperRate;
            cmd.Parameters.Add("@InnerPaperAmount", SqlDbType.VarChar).Value = li_BookPricing.InnerPaperAmount;
            cmd.Parameters.Add("@FormaPaperQty", SqlDbType.VarChar).Value = li_BookPricing.FormaPaperQty;
            cmd.Parameters.Add("@FormaPaperRate", SqlDbType.VarChar).Value = li_BookPricing.FormaPaperRate;
            cmd.Parameters.Add("@FormaPaperAmount", SqlDbType.VarChar).Value = li_BookPricing.FormaPaperAmount;
            cmd.Parameters.Add("@WriterBill", SqlDbType.VarChar).Value = li_BookPricing.WriterBill;
            cmd.Parameters.Add("@EditingCharge", SqlDbType.VarChar).Value = li_BookPricing.EditingCharge;
            cmd.Parameters.Add("@ProofCharge", SqlDbType.VarChar).Value = li_BookPricing.ProofCharge;
            cmd.Parameters.Add("@ComposingCharge", SqlDbType.VarChar).Value = li_BookPricing.ComposingCharge;
            cmd.Parameters.Add("@CoverDesign", SqlDbType.VarChar).Value = li_BookPricing.CoverDesign;
            cmd.Parameters.Add("@InnerDesign", SqlDbType.VarChar).Value = li_BookPricing.InnerDesign;
            cmd.Parameters.Add("@Illustration", SqlDbType.VarChar).Value = li_BookPricing.Illustration;
            cmd.Parameters.Add("@CoverPlateCharge", SqlDbType.VarChar).Value = li_BookPricing.CoverPlateCharge;
            cmd.Parameters.Add("@InnerPlateCharge", SqlDbType.VarChar).Value = li_BookPricing.InnerPlateCharge;
            cmd.Parameters.Add("@FormaPlateCharge", SqlDbType.VarChar).Value = li_BookPricing.FormaPlateCharge;
            cmd.Parameters.Add("@CoverPrint", SqlDbType.VarChar).Value = li_BookPricing.CoverPrint;
            cmd.Parameters.Add("@InnerPrint", SqlDbType.VarChar).Value = li_BookPricing.InnerPrint;
            cmd.Parameters.Add("@FormaPrint", SqlDbType.VarChar).Value = li_BookPricing.FormaPrint;
            cmd.Parameters.Add("@LaminationBill", SqlDbType.VarChar).Value = li_BookPricing.LaminationBill;
            cmd.Parameters.Add("@BindingBill", SqlDbType.VarChar).Value = li_BookPricing.BindingBill;
            cmd.Parameters.Add("@TotalDirectCost", SqlDbType.VarChar).Value = li_BookPricing.TotalDirectCost;
            cmd.Parameters.Add("@DirectCostPerBook", SqlDbType.VarChar).Value = li_BookPricing.DirectCostPerBook;
            cmd.Parameters.Add("@TotalCostOfSales", SqlDbType.VarChar).Value = li_BookPricing.TotalCostOfSales;
            cmd.Parameters.Add("@FinalRevenue", SqlDbType.VarChar).Value = li_BookPricing.FinalRevenue;
            cmd.Parameters.Add("@NetPrice", SqlDbType.VarChar).Value = li_BookPricing.NetPrice;
            cmd.Parameters.Add("@WrittenPrice", SqlDbType.VarChar).Value = li_BookPricing.WrittenPrice;
            cmd.Parameters.Add("@TCSPerforma", SqlDbType.VarChar).Value = li_BookPricing.TCSPerforma;
            cmd.Parameters.Add("@FinalRevenuePerForma", SqlDbType.VarChar).Value = li_BookPricing.FinalRevenuePerForma;
            cmd.Parameters.Add("@FormaPaperUnit", SqlDbType.VarChar).Value = li_BookPricing.FormaPaperUnit;
            cmd.Parameters.Add("@MRPpPerForma", SqlDbType.VarChar).Value = li_BookPricing.MRPpPerForma;
            cmd.Parameters.Add("@PaperCostTotal", SqlDbType.VarChar).Value = li_BookPricing.PaperCostTotal;
            cmd.Parameters.Add("@PrePressTotal", SqlDbType.VarChar).Value = li_BookPricing.PrePressTotal;
            cmd.Parameters.Add("@PrintingTotal", SqlDbType.VarChar).Value = li_BookPricing.PrintingTotal;
            cmd.Parameters.Add("@PostPressTotal", SqlDbType.VarChar).Value = li_BookPricing.PostPressTotal;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookPricing.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookPricing.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
