 using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;
using Common;
using Common.Marketing;

namespace BLL
{
    public partial class Mkt_SPCAdjustment : System.Web.UI.Page
    {
        string FormID = "MF018";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            try
            {
                if (!IsPostBack)
                {
                    AddDefaultFirstRecord();
                    LoadTso();
                    getUserAccess();
                    //dtpReturnDate.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                    LoadYear();
                    AddDefaultRowToGrid();

                }
            }
            catch (Exception)
            {

            }

        }
        private void getUserAccess()
        {
            DataTable dt = Li_AdminUserManager.GetUserAccess(int.Parse(Session["UserID"].ToString()), FormID).Tables[0];
            if (dt.Rows.Count > 0)
            {

                if (Session["UserID"].ToString() == dt.Rows[0]["UserID"].ToString() && FormID == dt.Rows[0]["FormId"].ToString())
                {
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        btnSave.Enabled = true;
                        btnPrint.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                        btnPrint.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Update_"].ToString()) == true)
                    {
                        //btnUpdate.Enabled = true;
                    }
                    else
                    {
                        //btnUpdate.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Delete_"].ToString()) == true)
                    {
                        //btnDelete.Enabled = true;
                    }
                    else
                    {
                        //btnDelete.Enabled = false;
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void LoadTso()
        {

            //ddlTSOName.DataSource = Li_SalesPersonManager.GetAllLi_SalesPersons(ddlTSOName.text);
            LoadComboData.LoadTSOIndo(ddlTSOName);
            ddlTSOName.DataTextField = "Name";
            //ddlTSOName.DataTextField = "TName";
            ddlTSOName.DataValueField = "TSOID";     
            ddlTSOName.DataBind();
            ddlTSOName.Items.Insert(0, new ListItem("-Select-", "0"));

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
                        drCurrentRow["BookAcCode"] = dt.Rows[i]["BookAcCode"].ToString();
                        drCurrentRow["BookID"] = dt.Rows[i]["BookID"].ToString();
                        drCurrentRow["BookName"] = dt.Rows[i]["BookName"].ToString();
                        drCurrentRow["Class"] = dt.Rows[i]["Class"].ToString();
                        drCurrentRow["Type"] = dt.Rows[i]["Type"].ToString();
                        drCurrentRow["Edition"] = dt.Rows[i]["Edition"].ToString();
                        drCurrentRow["UnitPrice"] = decimal.Parse(dt.Rows[i]["UnitPrice"].ToString());
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

                    ViewState["tblChalanDel"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvwReturn.DataSource = dtCurrentTable;
                    gvwReturn.DataBind();
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

        protected void txtChlNewMemoNo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                gvwReturn.DataSource = null;
                ViewState.Remove("tblChalanDel");
                AddDefaultFirstRecord();

                DataSet ds = new DataSet();
                ds = li_ChallanManager.Get_AllSPChallanInfoByMemoNo(txtMemoNo.Text);
                int rowNumber = ds.Tables[0].Rows.Count;

                if (rowNumber > 0)
                {


                    for (int i = 0; i < rowNumber; i++)
                    {
                        string ChalanID = ds.Tables[0].Rows[i]["ChallanID"].ToString();
                        txtChalanID.Text = ChalanID;
                        string challanDate = ds.Tables[0].Rows[i]["CreatedDate"].ToString();
                        txtChlNewDate.Text = DateTime.Parse(challanDate).ToString("yyyy-MM-dd");
                        LoadTso();
                        string TSOID = ds.Tables[0].Rows[i]["TSO"].ToString();
                        ddlTSOName.SelectedValue = TSOID;
                        //string TName = ds.Tables[0].Rows[i]["TName"].ToString();
                        //ddlTSOName.SelectedValue = TName;
                        //ddlTSOName.SelectedValue = ds.Tables[0].Rows[i]["TSOID"].ToString();
                        //txtPacketNo.Text = ds.Tables[0].Rows[i]["Qty"].ToString();
                        //txtPerPacketCost.Text = ds.Tables[0].Rows[i]["UnitPrice"].ToString();
                        //txtDiscountTotal.Text = ds.Tables[0].Rows[i]["TotalDiscount"].ToString();
                        //txtTotalAmount.Text = ds.Tables[0].Rows[i]["TotalAmount"].ToString();
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

                            string BookCode = dtCurrentTable.Rows[i]["BookID"].ToString() + "/" + dtCurrentTable.Rows[i]["Edition"].ToString();

                            decimal Qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());

                            li_ChallanManager.UpdateStock(BookCode, Qty);

                        }

                        string ChalId = txtChalanID.Text;
                        int Delby = int.Parse(Session["UserID"].ToString());
                        //string del_cause = txtCauseOfDelete.Text;

                        //li_ChallanManager.Delete_ChallanSpeciman(ChalId, del_cause, Delby);



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


        private void LoadYear()
        {
            ddlEdition.DataSource = li_ChallanManager.LoadYear().Tables[0];
            ddlEdition.DataTextField = "Edition";
            ddlEdition.DataBind();
            ddlEdition.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        private void AddDefaultFirstRecord()
        {
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblChalanDel";
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
            ViewState["tblChalanDel"] = dt;
            //bind Gridview  
            gvwReturn.DataSource = dt;
            gvwReturn.DataBind();




        }
        private void AddDefaultRowToGrid()
        {
            bool linkClick = false;
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblChalanDel";
            dt.Columns.Add("Serial", typeof(int));
            dt.Columns.Add("BookID", typeof(string));
            dt.Columns.Add("BookName", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("Qty", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            gvwReturn.DataSource = dt;
            gvwReturn.DataBind();
            ViewState["tblChalanDel"] = dt;
            ViewState["LinkClick"] = linkClick;
        }
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
            ClearTextData();
          
        }
        private void AddNewRecordRowToGrid()
        {

            // check view state is not null  
            if (ViewState["tblChalanDel"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblChalanDel"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultRowToGrid();
                  
                }
                else
                {
                    if ((bool)ViewState["LinkClick"] == true)
                    {


                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            dtCurrentTable.Rows[i][0] = i + 1;
                            dtCurrentTable.AcceptChanges();
                        }

                        ViewState["LinkClick"] = false;
                    }
                    else
                    {


                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {

                            //add each row into data table  
                            drCurrentRow = dtCurrentTable.NewRow();
                            drCurrentRow["Serial"] = dtCurrentTable.Rows.Count + 1;

                        }

                        // New row for data table

                        drCurrentRow["BookID"] = txtBookCode.Text;
                        drCurrentRow["BookName"] = txtBookName.Text;
                        drCurrentRow["Class"] = txtClass.Text;
                        drCurrentRow["Type"] = txtType.Text;
                        drCurrentRow["Edition"] = ddlEdition.SelectedValue;
                        drCurrentRow["UnitPrice"] = decimal.Parse(txtUnitPrice.Text);
                        drCurrentRow["Qty"] = decimal.Parse(txtAdjustmentQty.Text);
                        drCurrentRow["Total"] = decimal.Parse(txtUnitPrice.Text) * decimal.Parse(txtAdjustmentQty.Text);

                        //Remove initial blank row  
                        if (dtCurrentTable.Rows[0][0].ToString() == "")
                        {
                            drCurrentRow["Serial"] = dtCurrentTable.Rows.Count;
                            dtCurrentTable.Rows[0].Delete();
                            dtCurrentTable.AcceptChanges();

                        }

                        //add created Rows into dataTable  
                        dtCurrentTable.Rows.Add(drCurrentRow);
                    }

                    //Save Data table into view state after creating each row  

                    ViewState["tblReturn"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvwReturn.DataSource = dtCurrentTable;
                    gvwReturn.DataBind();
                    decimal adjustmentAmount = 0.0m;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            decimal adAmount = decimal.Parse(dtCurrentTable.Rows[i]["Total"].ToString());
                            adjustmentAmount += adAmount;
                        }
                        //txtTotalReturnAmount.Text = string.Format("{0:0.##}", returnAmount);
                        txtTotalAmount.Text = String.Format("{0:0.##}", adjustmentAmount);
                    }

                }
            }
        }
        private void ClearTextData()
        {
            txtBookCode.Text = string.Empty;
            txtBookName.Text = string.Empty;
            txtClass.Text = string.Empty;
            txtType.Text = string.Empty;
            ddlEdition.SelectedIndex = 0;
            txtUnitPrice.Text = string.Empty;
            txtAdjustmentQty.Text = string.Empty;
        }
        protected void txtBookCode_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBookCode.Text != "")
                {


                    DataSet ds = new DataSet();
                    ds = li_BookVersionInfoManager.GetAll_BookVersionInfosWithRelation(txtBookCode.Text);
                    txtBookName.Text = ds.Tables[0].Rows[0]["BookName"].ToString();
                    txtType.Text = ds.Tables[0].Rows[0]["BookType"].ToString();
                    txtClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                    ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                    txtUnitPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();

                }
                else
                {
                    txtBookName.Text = "";
                    txtType.Text = "";
                    txtClass.Text = "";
                    ddlEdition.SelectedIndex = 0;
                    txtUnitPrice.Text = "";
                }

            }
            catch (Exception)
            {
               
              
            }
        }

        protected void lblDelete_OnClick(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblChalanDel"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();


            }
            catch (Exception)
            {


            }
           
        }       
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Decimal.Parse(txtTotalAmount.Text) > 0.0m)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["tblChalanDel"];


               // Li_Specimen_Return spreturn = new Li_Specimen_Return();
               // spreturn.AdjustedAmount = decimal.Parse(txtTotalAmount.Text);
               // //spreturn.AmountPayable = txtAmountReceivable.Text != "" ? decimal.Parse(txtAmountReceivable.Text) : 0.0m;
               // spreturn.AmountPayable = 0.0m;
               // spreturn.CreatedBy = Session["UserID"].ToString();
               // spreturn.CreatedDate = Convert.ToDateTime(txtChlNewDate.Text);
               // spreturn.MemoNo = txtMemoNo.Text;
               // spreturn.DeliveredBy = txtDeliveredBy.Text;              
               // spreturn.ModifiedBy = int.Parse(Session["UserID"].ToString());
               // spreturn.ModifiedDate = DateTime.Now;
               // //spreturn.PacketNo = txtPecketNo.Text != "" ? Int32.Parse(txtPecketNo.Text) : 0;
               // spreturn.PacketNo = 0;
               ////spreturn.PerPacketCost = txtPerPacketCost.Text != "" ? decimal.Parse(txtPerPacketCost.Text) : 0.0m;
               // spreturn.PerPacketCost = 0.0m;
               // spreturn.ReceiveDate = DateTime.Now;
               // //spreturn.TotalAmount = decimal.Parse(txtTotalReturnAmount.Text);
               // spreturn.TSO = ddlTSOName.SelectedValue.ToString();
               // spreturn.Donation = chkIsDonation.Checked ? true : false;
               // string retID = Li_Specimen_ReturnManager.InsertLi_Specimen_Return(spreturn);

               // for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
               // {
               //     Li_Specimen_ReturnDetail specimenDetails = new Li_Specimen_ReturnDetail();
               //     specimenDetails.ReturnDetailsID = Guid.NewGuid().ToString();
               //     specimenDetails.ReturnID = retID;
               //     specimenDetails.BookAcCode = dtCurrentTable.Rows[i]["BookID"].ToString() + "/" +
               //                                  dtCurrentTable.Rows[i]["Edition"].ToString();
               //     specimenDetails.Qty = int.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
               //     specimenDetails.UnitPrice = decimal.Parse(dtCurrentTable.Rows[i]["UnitPrice"].ToString());
               //     specimenDetails.AdjustQty = Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());

               //     Li_Specimen_ReturnDetailManager.InsertLi_Specimen_ReturnDetail(specimenDetails);
               // }

                Li_Specimen_Return spreturn = new Li_Specimen_Return();
                spreturn.AdjustedAmount = decimal.Parse(txtTotalAmount.Text);
                spreturn.AmountPayable =0.0m; // txtAmountReceivable.Text != "" ? decimal.Parse(txtAmountReceivable.Text) : 0.0m;
                spreturn.CreatedBy = Session["UserID"].ToString();
                spreturn.CreatedDate = Convert.ToDateTime(txtSlipDate.Text); // dtpChalandate.Value;
                spreturn.DeliveredBy = txtDeliveredBy.Text;
                spreturn.MemoNo = txtSlipNo.Text;
                spreturn.ModifiedBy = int.Parse(Session["UserID"].ToString());
                spreturn.ModifiedDate = DateTime.Now;
                spreturn.PacketNo = 0;  // txtPecketNo.Text != "" ? Int32.Parse(txtPecketNo.Text) : 0;
                spreturn.PerPacketCost = 0.0m; // txtPerPacketCost.Text != "" ? decimal.Parse(txtPerPacketCost.Text) : 0.0m;
                spreturn.ReceiveDate = DateTime.Now;
                spreturn.TotalAmount = 0.0m; //decimal.Parse(txtTotalAmount.Text);
                spreturn.TSO = ddlTSOName.SelectedValue.ToString(); // cmbTSO.SelectedValue.ToString();
                spreturn.Donation = chkIsDonation.Checked ? true : false; //chkDonation.Checked ? true : false;
                string retID = Li_Specimen_ReturnManager.InsertLi_Specimen_Return(spreturn);

                for (int i = 0; i < gvwReturn.Rows.Count; i++)
                {
                    Li_Specimen_ReturnDetail specimenDetails = new Li_Specimen_ReturnDetail();
                    specimenDetails.ReturnDetailsID = Guid.NewGuid().ToString();
                    specimenDetails.ReturnID = retID;
                    //specimenDetails.BookAcCode = gvChalan.Rows[i].Cells["BookAcCode"].Value.ToString() + "/" + gvChalan.Rows[i].Cells["Edition"].Value.ToString();
                    //specimenDetails.Qty = int.Parse(gvChalan.Rows[i].Cells["Quantity"].Value.ToString());
                    //specimenDetails.UnitPrice = decimal.Parse(gvChalan.Rows[i].Cells["UnitPrice"].Value.ToString());
                    //specimenDetails.AdjustQty = Int32.Parse(gvChalan.Rows[i].Cells["AdjustQty"].Value.ToString());
                    specimenDetails.BookAcCode = gvwReturn.Rows[i].Cells[1].Text + "/" + gvwReturn.Rows[i].Cells[5].Text;
                    specimenDetails.Qty = 0;  // int.Parse(gvwReturn.Rows[i].Cells[7].ToString()) 
                    specimenDetails.UnitPrice = decimal.Parse(((TextBox)gvwReturn.Rows[i].FindControl("UnitPrice")).Text);
                    specimenDetails.AdjustQty = Int32.Parse(((TextBox)gvwReturn.Rows[i].FindControl("Qty")).Text); //Int32.Parse(gvwReturn.Rows[i].Cells[7].ToString());

                    Li_Specimen_ReturnDetailManager.InsertLi_Specimen_ReturnDetail(specimenDetails);
                }


                string message = "Saved Successfully!";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script,
                    true);
                //txtReturnId.Text = retID.ToString();
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Mkt_Rpt_SpecimanAdjustmentMemo.aspx");
            }
            catch (Exception)
            {


            }
        }

    }
}