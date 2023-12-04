using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BLL
{
    public partial class Mkt_UpdateChallanQty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddDefaultFirstRecord();

                LoadLibrary();
                LoadMemoType();
            }
        }
        private void AddDefaultFirstRecord()
        {
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblChalanDel";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BookCode", typeof(string));
            dt.Columns.Add("BookName", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("UnitPrice", typeof(Decimal));
            dt.Columns.Add("Qty", typeof(Decimal));
            dt.Columns.Add("DiscountPer", typeof(Decimal));
            dt.Columns.Add("TotalDiscount", typeof(Decimal));
            dt.Columns.Add("Total", typeof(Decimal));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblChalanDel"] = dt;
            //bind Gridview  
            gvwChlNew.DataSource = dt;
            gvwChlNew.DataBind();



        }


        private void LoadLibrary()
        {

            try
            {
                //LoadComboData.LoadLibrary(ddlLibName);
                ddlLibName.DataBind();
                ddlLibName.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception)
            {

            }
        }

        private void LoadMemoType()
        {
            //ddlMemoType.DataSource = Li_OfferManager.GetAllLi_Offers();
            ddlMemoType.DataTextField = "OffName";
            ddlMemoType.DataValueField = "OffID";
            ddlMemoType.DataBind();
            ddlMemoType.Items.Insert(0, new ListItem("--Select--", ""));
        }

        private void AddNewRecordRowToGrid(string ChalanID)
        {
            // check view state is not null  
            if (ViewState["tblChalanDel"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblChalanDel"];
                DataRow drCurrentRow = null;



                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                    txtTotalAmount.Text = "0.00";

                }
                else
                {




                    // New row for data table

                    DataTable dt = new DataTable();
                    dt = li_ChallanManager.GetChallanDetailsInformationByChallanID(ChalanID).Tables[0];



                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        //add each row into data table  
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Serial"] = i + 1;
                        drCurrentRow["BookCode"] = dt.Rows[i]["BookAcCode"].ToString();
                        drCurrentRow["BookName"] = dt.Rows[i]["BookName"].ToString();
                        drCurrentRow["Class"] = dt.Rows[i]["Class"].ToString();
                        drCurrentRow["Type"] = dt.Rows[i]["Type"].ToString();
                        drCurrentRow["Edition"] = dt.Rows[i]["Edition"].ToString();
                        drCurrentRow["UnitPrice"] = decimal.Round(decimal.Parse(dt.Rows[i]["Price"].ToString()));
                        drCurrentRow["Qty"] = decimal.Parse(dt.Rows[i]["Quantity"].ToString());
                        drCurrentRow["DiscountPer"] = 0.0m;
                        drCurrentRow["TotalDiscount"] = 0.0m;//decimal.Parse(dt.Rows[i]["Qty"].ToString()) * decimal.Parse(dt.Rows[i]["UnitPrice"].ToString()) * decimal.Parse(dt.Rows[i]["DiscountPercent"].ToString());
                        drCurrentRow["Total"] = decimal.Round(decimal.Parse(dt.Rows[i]["SellAmount"].ToString()));
                        dtCurrentTable.Rows.Add(drCurrentRow);

                    }

                    //Remove initial blank row  
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count;
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }


                    //Save Data table into view state after creating each row  

                    ViewState["tblChalanDel"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvwChlNew.DataSource = dtCurrentTable;
                    gvwChlNew.DataBind();

                    decimal subTotal = 0.0m;
                    decimal Discount = 0.0m;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["Total"].ToString());
                            subTotal += unitTotal;

                            decimal totDis = decimal.Parse(dtCurrentTable.Rows[i]["TotalDiscount"].ToString());
                            Discount += totDis;
                        }
                    }

                    txtTotalAmount.Text = (subTotal - Discount).ToString();




                }

            }
        }

        protected void txtChlNewMemoNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gvwChlNew.DataSource = null;
                ViewState.Remove("tblChalanDel");
                AddDefaultFirstRecord();
                DataSet ds = new DataSet();
                ds = li_ChallanManager.Get_AllChallanInfoByMemoNo(txtMemoNo.Text, ddlLibName.SelectedValue);

                int rowNumber = ds.Tables[0].Rows.Count;

                if (rowNumber > 0)
                {


                    for (int i = 0; i < rowNumber; i++)
                    {
                        string ChalanID = ds.Tables[0].Rows[i]["ChalanID"].ToString();
                        txtChalanID.Text = ChalanID;
                        ddlLibName.SelectedValue = ds.Tables[0].Rows[i]["LibraryID"].ToString();
                        ddlMemoType.SelectedValue = ds.Tables[0].Rows[i]["OfferID"].ToString();
                        string challanDate = ds.Tables[0].Rows[i]["ChalanDate"].ToString();
                        txtChlNewDate.Text = DateTime.Parse(challanDate).ToString("yyyy-MM-dd");
                        txtPacketNo.Text = ds.Tables[0].Rows[i]["PackQty"].ToString();
                        txtPerPacketCost.Text = ds.Tables[0].Rows[i]["PerPackCost"].ToString();
                        txtDiscountTotal.Text = ds.Tables[0].Rows[i]["TotalDiscount"].ToString();
                        txtAmountReceivable.Text = ds.Tables[0].Rows[i]["AmountReceivable"].ToString();



                        AddNewRecordRowToGrid(ChalanID);

                    }
                }



            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    //DataTable dtest = (DataTable)ViewState["tblChalanDel"];

                    DataTable dtCurrentTable = (DataTable)ViewState["tblChalanDel"];
                    if (dtCurrentTable.Rows.Count > 0)
                    {

                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {

                            string BookCode = dtCurrentTable.Rows[i]["BookCode"].ToString() + "/" + dtCurrentTable.Rows[i]["Edition"].ToString();

                            decimal Qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());

                            li_ChallanManager.UpdateStock(BookCode, Qty);

                        }

                        string ChalId = txtChalanID.Text;
                        int Delby = int.Parse(Session["UserID"].ToString());
                        string del_cause = txtCauseOfDelete.Text;

                        li_ChallanManager.Delete_Challan(ChalId, del_cause, Delby);



                        dtCurrentTable.Rows.Clear();
                        txtTotalAmount.Text = "";
                        AddDefaultFirstRecord();


                        string message = "Delete successfully.";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "');";
                        script += "window.location = '";
                        script += Request.Url.AbsoluteUri;
                        script += "'; }";
                        //  ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script,
                            true);


                    }
                }

            }
            catch (Exception)
            {


            }

        }
    }
}