using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookProductionCostProvider:DataAccessObject
{
	public SqlLi_BookProductionCostProvider()
    {
    }


    public bool DeleteLi_BookProductionCost(int li_BookProductionCostID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookProductionCost", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookProductionCostID", SqlDbType.Int).Value = li_BookProductionCostID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookProductionCost> GetAllLi_BookProductionCosts()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookProductionCosts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookProductionCostsFromReader(reader);
        }
    }
    public List<Li_BookProductionCost> GetLi_BookProductionCostsFromReader(IDataReader reader)
    {
        List<Li_BookProductionCost> li_BookProductionCosts = new List<Li_BookProductionCost>();

        while (reader.Read())
        {
            li_BookProductionCosts.Add(GetLi_BookProductionCostFromReader(reader));
        }
        return li_BookProductionCosts;
    }

    public Li_BookProductionCost GetLi_BookProductionCostFromReader(IDataReader reader)
    {
        try
        {
            Li_BookProductionCost li_BookProductionCost = new Li_BookProductionCost
                (
                     reader["BookCode"].ToString(),
                    (decimal)reader["WriterBillRate"],
                    (decimal)reader["EditingRate"],
                    (decimal)reader["ComposingRate"],
                    (decimal)reader["ProofRate"],
                    reader["ProofTimes"].ToString(),
                    (decimal)reader["Pesting"],
                    (decimal)reader["CoverDesign"],
                    (decimal)reader["InnerDesign"],
                    (decimal)reader["Illustration"],
                    (decimal)reader["CoverPlateRate"],
                    (int)reader["CoverPlateQty"],
                    (decimal)reader["CoverPlateProcesingRate"],
                    (decimal)reader["InnerPlateRate"],
                    (int)reader["InnerPlateQty"],
                    (decimal)reader["InnerPlateProcessingRate"],
                    (decimal)reader["FormaPlateProcessingRate"],
                    (decimal)reader["CoverPaperQty"],
                    (decimal)reader["CoverPaperRate"],
                    (decimal)reader["InnerPaperQty"],
                    (decimal)reader["InnerPaperRate"],
                    (decimal)reader["FormaPaperQty"],
                    (decimal)reader["FormaPaperRate"],
                    (decimal)reader["CoverPrintRate"],
                    (decimal)reader["InnerPrintRate"],
                    (decimal)reader["FormaPrintRate"],
                    (decimal)reader["CoverLaminationRate"],
                    (decimal)reader["CoverCreaseRate"],
                    (decimal)reader["BookBindingRate"],
                    (decimal)reader["BookTransportRate"] ,
                    (decimal )reader ["BookBindingRate"],
                     (decimal )reader ["BookTransportRate"]

                    
                     
                );
             return li_BookProductionCost;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookProductionCost GetLi_BookProductionCostByID(int li_BookProductionCostID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookProductionCostByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookProductionCostID", SqlDbType.Int).Value = li_BookProductionCostID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookProductionCostFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BookProductionCost(Li_BookProductionCost li_BookProductionCost)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookProductionCost", connection);
            cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookProductionCost.BookCode;
            cmd.Parameters.Add("@WriterBillRate", SqlDbType.Decimal).Value = li_BookProductionCost.WriterBillRate;
            cmd.Parameters.Add("@EditingRate", SqlDbType.Decimal).Value = li_BookProductionCost.EditingRate;
            cmd.Parameters.Add("@ComposingRate", SqlDbType.Decimal).Value = li_BookProductionCost.ComposingRate;
            cmd.Parameters.Add("@ProofRate", SqlDbType.Decimal).Value = li_BookProductionCost.ProofRate;
            cmd.Parameters.Add("@ProofTimes", SqlDbType.VarChar).Value = li_BookProductionCost.ProofTimes;
            cmd.Parameters.Add("@Pesting", SqlDbType.Decimal).Value = li_BookProductionCost.Pesting;
            cmd.Parameters.Add("@CoverDesign", SqlDbType.Decimal).Value = li_BookProductionCost.CoverDesign;
            cmd.Parameters.Add("@InnerDesign", SqlDbType.Decimal).Value = li_BookProductionCost.InnerDesign;
            cmd.Parameters.Add("@Illustration", SqlDbType.Decimal).Value = li_BookProductionCost.Illustration;
            cmd.Parameters.Add("@CoverPlateRate", SqlDbType.Decimal).Value = li_BookProductionCost.CoverPlateRate;
            cmd.Parameters.Add("@CoverPlateQty", SqlDbType.Int).Value = li_BookProductionCost.CoverPlateQty;
            cmd.Parameters.Add("@CoverPlateProcesingRate", SqlDbType.Decimal).Value = li_BookProductionCost.CoverPlateProcesingRate;
            cmd.Parameters.Add("@InnerPlateRate", SqlDbType.Decimal).Value = li_BookProductionCost.InnerPlateRate;
            cmd.Parameters.Add("@InnerPlateQty", SqlDbType.Int).Value = li_BookProductionCost.InnerPlateQty;
            cmd.Parameters.Add("@InnerPlateProcessingRate", SqlDbType.Decimal).Value = li_BookProductionCost.InnerPlateProcessingRate;
            cmd.Parameters.Add("@FormaPlateQty", SqlDbType.Int).Value = li_BookProductionCost.FormaPlateQty;
            cmd.Parameters.Add("@FormaPlateRate", SqlDbType.Decimal).Value = li_BookProductionCost.FormaPlateRate;
            cmd.Parameters.Add("@FormaPlateProcessingRate", SqlDbType.Decimal).Value = li_BookProductionCost.FormaPlateProcessingRate;
            cmd.Parameters.Add("@CoverPrintRate", SqlDbType.Decimal).Value = li_BookProductionCost.CoverPrintRate;
            cmd.Parameters.Add("@InnerPrintRate", SqlDbType.Decimal).Value = li_BookProductionCost.InnerPrintRate;
            cmd.Parameters.Add("@FormaPrintRate", SqlDbType.Decimal).Value = li_BookProductionCost.FormaPrintRate;
            cmd.Parameters.Add("@CoverLaminationRate", SqlDbType.Decimal).Value = li_BookProductionCost.CoverLaminationRate;
            cmd.Parameters.Add("@CoverCreaseRate", SqlDbType.Decimal).Value = li_BookProductionCost.CoverCreaseRate;
            cmd.Parameters.Add("@BookBindingRate", SqlDbType.Decimal).Value = li_BookProductionCost.BookBindingRate;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;//(int)cmd.Parameters["@Li_BookProductionCostID"].Value;
        }
    }

    public bool UpdateLi_BookProductionCost(Li_BookProductionCost li_BookProductionCost)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookProductionCost", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookProductionCost.BookCode;
            cmd.Parameters.Add("@WriterBillRate", SqlDbType.Decimal).Value = li_BookProductionCost.WriterBillRate;
            cmd.Parameters.Add("@EditingRate", SqlDbType.Decimal).Value = li_BookProductionCost.EditingRate;
            cmd.Parameters.Add("@ComposingRate", SqlDbType.Decimal).Value = li_BookProductionCost.ComposingRate;
            cmd.Parameters.Add("@ProofRate", SqlDbType.Decimal).Value = li_BookProductionCost.ProofRate;
            cmd.Parameters.Add("@ProofTimes", SqlDbType.VarChar).Value = li_BookProductionCost.ProofTimes;
            cmd.Parameters.Add("@Pesting", SqlDbType.Decimal).Value = li_BookProductionCost.Pesting;
            cmd.Parameters.Add("@CoverDesign", SqlDbType.Decimal).Value = li_BookProductionCost.CoverDesign;
            cmd.Parameters.Add("@InnerDesign", SqlDbType.Decimal).Value = li_BookProductionCost.InnerDesign;
            cmd.Parameters.Add("@Illustration", SqlDbType.Decimal).Value = li_BookProductionCost.Illustration;
            cmd.Parameters.Add("@CoverPlateRate", SqlDbType.Decimal).Value = li_BookProductionCost.CoverPlateRate;
            cmd.Parameters.Add("@CoverPlateQty", SqlDbType.Int).Value = li_BookProductionCost.CoverPlateQty;
            cmd.Parameters.Add("@CoverPlateProcesingRate", SqlDbType.Decimal).Value = li_BookProductionCost.CoverPlateProcesingRate;
            cmd.Parameters.Add("@InnerPlateRate", SqlDbType.Decimal).Value = li_BookProductionCost.InnerPlateRate;
            cmd.Parameters.Add("@InnerPlateQty", SqlDbType.Int).Value = li_BookProductionCost.InnerPlateQty;
            cmd.Parameters.Add("@InnerPlateProcessingRate", SqlDbType.Decimal).Value = li_BookProductionCost.InnerPlateProcessingRate;
            cmd.Parameters.Add("@FormaPlateProcessingRate", SqlDbType.Decimal).Value = li_BookProductionCost.FormaPlateProcessingRate;
            cmd.Parameters.Add("@CoverPaperQty", SqlDbType.Decimal).Value = li_BookProductionCost.CoverPaperQty;
            cmd.Parameters.Add("@CoverPaperRate", SqlDbType.Decimal).Value = li_BookProductionCost.CoverPaperRate;
            cmd.Parameters.Add("@InnerPaperQty", SqlDbType.Decimal).Value = li_BookProductionCost.InnerPaperQty;
            cmd.Parameters.Add("@InnerPaperRate", SqlDbType.Decimal).Value = li_BookProductionCost.InnerPaperRate;
            cmd.Parameters.Add("@FormaPaperQty", SqlDbType.Decimal).Value = li_BookProductionCost.FormaPaperQty;
            cmd.Parameters.Add("@FormaPaperRate", SqlDbType.Decimal).Value = li_BookProductionCost.FormaPaperRate;
            cmd.Parameters.Add("@CoverPrintRate", SqlDbType.Decimal).Value = li_BookProductionCost.CoverPrintRate;
            cmd.Parameters.Add("@InnerPrintRate", SqlDbType.Decimal).Value = li_BookProductionCost.InnerPrintRate;
            cmd.Parameters.Add("@FormaPrintRate", SqlDbType.Decimal).Value = li_BookProductionCost.FormaPrintRate;
            cmd.Parameters.Add("@CoverLaminationRate", SqlDbType.Decimal).Value = li_BookProductionCost.CoverLaminationRate;
            cmd.Parameters.Add("@CoverCreaseRate", SqlDbType.Decimal).Value = li_BookProductionCost.CoverCreaseRate;
            cmd.Parameters.Add("@BookBindingRate", SqlDbType.Decimal).Value = li_BookProductionCost.BookBindingRate;
            cmd.Parameters.Add("@BookTransportRate", SqlDbType.Decimal).Value = li_BookProductionCost.BookTransportRate;
          
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
