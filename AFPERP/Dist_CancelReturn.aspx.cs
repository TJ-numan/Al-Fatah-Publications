using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;
using System.Data;
using Common;
using Common.Marketing;

namespace BLL
{
    public partial class Dist_CancelReturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddDefaultFirstRecord();

                LoadAgent();
            }
        }

        private void AddDefaultFirstRecord()
        {
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblReturnDel";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BookAcCode", typeof(string));
            dt.Columns.Add("BookID", typeof(string));
            dt.Columns.Add("BookName", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("UnitPrice", typeof(Decimal));
            dt.Columns.Add("Qty", typeof(Decimal));
            dt.Columns.Add("Total", typeof(Decimal));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblReturnDel"] = dt;
            //bind Gridview  
            gvwChlNew.DataSource = dt;
            gvwChlNew.DataBind();




        }


        private void LoadAgent()
        {
            try
            {
                LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
                ddlLibraryName.DataTextField = "LibraryName";
                ddlLibraryName.DataValueField = "LibraryID";
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            catch (Exception)
            {

            }
        }

        private void AddNewRecordRowToGrid(string ReturnID)
        {
            // check view state is not null  
            if (ViewState["tblReturnDel"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblReturnDel"];
                DataRow drCurrentRow = null;



                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                    txtTotalAmount.Text = "0.00";

                }
                else
                {




                    // New row for data table
                    String Comp = ddlCom.SelectedValue;
                    DataTable dt = new DataTable();
                    dt = li_ReturnManager.GetReturnDetailsInformationByReturnIDForEdit(ReturnID, Comp).Tables[0];



                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        //add each row into data table  
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Serial"] = i + 1;
                        drCurrentRow["BookAcCode"] = dt.Rows[i]["BookAcCode"].ToString();
                        drCurrentRow["BookID"] = dt.Rows[i]["BookID"].ToString();
                        drCurrentRow["BookName"] = dt.Rows[i]["BookName"].ToString();
                        drCurrentRow["Class"] = dt.Rows[i]["Class"].ToString();
                        drCurrentRow["Type"] = dt.Rows[i]["Type"].ToString();
                        drCurrentRow["Edition"] = dt.Rows[i]["Edition"].ToString();
                        drCurrentRow["UnitPrice"] = decimal.Round(decimal.Parse(dt.Rows[i]["UnitPrice"].ToString()));
                        drCurrentRow["Qty"] = decimal.Parse(dt.Rows[i]["Qty"].ToString());
                        //drCurrentRow["DiscountPer"] = 0.0m;
                        //drCurrentRow["TotalDiscount"] = 0.0m;//decimal.Parse(dt.Rows[i]["Qty"].ToString()) * decimal.Parse(dt.Rows[i]["UnitPrice"].ToString()) * decimal.Parse(dt.Rows[i]["DiscountPercent"].ToString());
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

                    ViewState["tblReturnDel"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvwChlNew.DataSource = dtCurrentTable;
                    gvwChlNew.DataBind();
                    decimal subTotal = 0.0m;
                    //decimal Discount = 0.0m;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["Total"].ToString());
                            subTotal += unitTotal;

                            //decimal totDis = decimal.Parse(dtCurrentTable.Rows[i]["TotalDiscount"].ToString());
                            //Discount += totDis;
                        }
                    }

                    //txtTotalAmount.Text = (subTotal - Discount).ToString();
                    txtTotalAmount.Text = subTotal.ToString();



                }

            }

        }

        protected void txtRtnNewMemoNo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                gvwChlNew.DataSource = null;
                ViewState.Remove("tblReturnDel");
                AddDefaultFirstRecord();


                String Comp = ddlCom.SelectedValue;
                DataSet ds = new DataSet();
                ds = li_ReturnManager.Get_AllReturnIDByMemoNo(txtMemoNo.Text, Comp);
                int rowNumber = ds.Tables[0].Rows.Count;

                if (rowNumber > 0)
                {


                    for (int i = 0; i < rowNumber; i++)
                    {
                        string ReturnID = ds.Tables[0].Rows[i]["ReturnID"].ToString();
                        txtReturnID.Text = ReturnID;
                        string ReturnDate = ds.Tables[0].Rows[i]["ReturnDate"].ToString();
                        txtRtnNewDate.Text = DateTime.Parse(ReturnDate).ToString("yyyy-MM-dd");
                        LoadAgent();
                        string LibraryID = ds.Tables[0].Rows[i]["LibraryID"].ToString();
                        ddlLibraryName.SelectedValue = LibraryID;

                        txtTotalAmount.Text = ds.Tables[0].Rows[i]["TotalAmount"].ToString();
                        txtPacketNo.Text = ds.Tables[0].Rows[i]["PacketNo"].ToString();
                        txtPerPacketCost.Text = ds.Tables[0].Rows[i]["PerPacketCost"].ToString();
                        txtAmountReceivable.Text = ds.Tables[0].Rows[i]["AmountReceivable"].ToString();
                        
                        AddNewRecordRowToGrid(ReturnID);

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
                    //DataTable dtest = (DataTable)ViewState["tblReturnDel"];

                    DataTable dtCurrentTable = (DataTable)ViewState["tblReturnDel"];
                    if (dtCurrentTable.Rows.Count > 0)
                    {

                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {

                            string BookCode = dtCurrentTable.Rows[i]["BookID"].ToString() + "/" + dtCurrentTable.Rows[i]["Edition"].ToString();

                            int Qty = int.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());

                            li_ReturnManager.UpdateReturnStock(BookCode, Qty);

                        }

                        string RtnId = txtReturnID.Text;
                        int Delby = int.Parse(Session["UserID"].ToString());
                        string del_cause = txtCauseOfDelete.Text;
                        String Comp = ddlCom.SelectedValue;
                        if(Comp=="A"){
                            li_ReturnManager.Cancel_Return(RtnId, del_cause, Delby);
                        }
                        else if (Comp == "Q")
                        {
                            li_ReturnManager.Cancel_Return_Q(RtnId, del_cause, Delby);
                        }



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