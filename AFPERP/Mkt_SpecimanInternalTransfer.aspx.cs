using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;

namespace BLL
{
    public partial class Mkt_SpecimanInternalTransfer : System.Web.UI.Page
    {
        string FormID = "MF019";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadTerritory();
                    int year = DateTime.Now.Year;
                    ddlEdition.Text = year.ToString();
                    LoadYear();
                    ddlTerritoryTo.Text = "";
                    ddlTerritoryFrom.Text = "";
                    AddDefaultFirstRecord();
                }

            }
            catch (Exception ex)
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
                    }
                    else
                    {
                        btnSave.Enabled = false;
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
        protected void ddlTerritoryFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlTsoNameFrom.DataSource =    Li_SalesPersonManager.GetLi_SalesPersonsByTerritory(ddlTerritoryFrom.SelectedValue.ToString());
                ddlTsoNameFrom.DataTextField = "Name";
                ddlTsoNameFrom.DataValueField = "TSOID";
                ddlTsoNameFrom.DataBind();
            }
            catch
            {

            }

        }
        protected void ddlTerritoryTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddlTsoNameTo.DataSource =
                    Li_SalesPersonManager.GetLi_SalesPersonsByTerritory(ddlTerritoryTo.SelectedValue.ToString());
                ddlTsoNameTo.DataTextField = "Name";
                ddlTsoNameTo.DataValueField = "TSOID";
                ddlTsoNameTo.DataBind();

            }
            catch
            {

            }
        }

        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            int result = 0;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblInternalChallanTra";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BookCode", typeof(string));
            dt.Columns.Add("BookName", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("UnitPrice", typeof(Decimal));
            dt.Columns.Add("Qty", typeof(Decimal));
            dt.Columns.Add("DisAmount", typeof(Decimal));
            dt.Columns.Add("Total", typeof(Decimal));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblInternalChallanTra"] = dt;
            //bind Gridview  
            gvwSpTransfer.DataSource = dt;
            gvwSpTransfer.DataBind();

            ViewState["LinkClick"] = fromLinkButton;
            Session["ResultMemo"] = result;


        }


        private void AddNewRecordRowToGrid()
        {
            // check view state is not null  
            if (ViewState["tblInternalChallanTra"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblInternalChallanTra"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                    txtTotalDiscount.Text = "0.00";
                    txtTotalAmount.Text = "0.00";
                    txtTotalTransferred.Text = "0.00";

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

                            //if ( decimal .Parse  ( txtChlNewQty.Text )_== 0.0m ) 
                            //{
                            //    return;
                            //}

                        }

                        // New row for data table

                        drCurrentRow["BookCode"] = txtBookCode.Text;
                        drCurrentRow["BookName"] = txtBookName.Text;

                        drCurrentRow["Class"] = txtClass.Text;
                        drCurrentRow["Type"] = txtType.Text;
                        drCurrentRow["Edition"] = ddlEdition.SelectedItem.Text;
                        drCurrentRow["UnitPrice"] = decimal.Parse(txtPrice.Text);
                        drCurrentRow["Qty"] = decimal.Parse(txtQty.Text);
                        drCurrentRow["DisAmount"] = decimal.Round(decimal.Parse(txtQty.Text) * decimal.Parse(txtPrice.Text) * decimal.Parse(txtDiscount.Text) * 0.01m);
                        drCurrentRow["Total"] = decimal.Round((decimal.Parse(txtQty.Text) * decimal.Parse(txtPrice.Text)), 2);






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

                    ViewState["tblInternalChallanTra"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvwSpTransfer.DataSource = dtCurrentTable;
                    gvwSpTransfer.DataBind();

                    decimal subTotal = 0.0m;
                    decimal totalDiscount = 0.0m;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["Total"].ToString());
                            subTotal += unitTotal;

                            decimal totDis = decimal.Parse(dtCurrentTable.Rows[i]["DisAmount"].ToString());
                            totalDiscount += totDis;

                        }
                    }

                    // decimal spDiscount = txtChlNewSpeDis.Text != "" ? decimal.Parse(txtChlNewSpeDis.Text) : 0.0m;

                    txtTotalAmount.Text = subTotal.ToString();
                    txtTotalDiscount.Text = totalDiscount.ToString();
                    txtTotalTransferred.Text = String.Format("{0:0.##}", (subTotal - totalDiscount));



                }

            }
        }

        private void LoadTerritory()
        {
            // Load Territory for Transfer From Library
            ddlTerritoryFrom.DataSource = Li_TeritoryManager.GetAllLi_Teritories(string.Empty);
            ddlTerritoryFrom.DataTextField = "TeritoryName";
            ddlTerritoryFrom.DataValueField = "TeritoryCode";
            ddlTerritoryFrom.DataBind();
            ddlTerritoryFrom.Items.Insert(0, new ListItem("--Select--", ""));

            // Load Territory for Transfer to Library
            ddlTerritoryTo.DataSource = Li_TeritoryManager.GetAllLi_Teritories(string.Empty);
            ddlTerritoryTo.DataTextField = "TeritoryName";
            ddlTerritoryTo.DataValueField = "TeritoryCode";
            ddlTerritoryTo.DataBind();
            ddlTerritoryTo.Items.Insert(0, new ListItem("--Select--", ""));


        }

        private void LoadYear()
        {
            ddlEdition.DataSource = li_ChallanManager.LoadYear().Tables[0];
            ddlEdition.DataTextField = "Edition";
            //txtEdition.ValueMember = "Edition";
            ddlEdition.DataBind();
            ddlEdition.Items.Insert(0, new ListItem("-Select-", "0"));

        }


        protected void txtBookCode_TextChanged(object sender, EventArgs e)
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
                    ddlEdition.SelectedItem.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                    txtDiscount.Text = "0";
                    txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    txtQty.Focus();
                }
                else
                {

                    txtBookName.Text = "";
                    txtClass.Text = "";
                    //ddlChlNewEdition.Text = "";
                    txtPrice.Text = "";
                    txtDiscount.Text = "";
                    txtType.Text = "";
                    txtQty.Text = "";
                }


            }
            catch (Exception)
            {

            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblInternalChallanTra"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                AddNewRecordRowToGrid();

                txtBookCode.Text = string.Empty;
                txtBookName.Text = string.Empty;
                txtType.Text = string.Empty;
                txtClass.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtDiscount.Text = string.Empty;
                ddlEdition.SelectedIndex = 0;
                txtQty.Text = string.Empty;
                txtBookCode.Focus();
            }
            catch (Exception)
            {


            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dtCurrentTable = (DataTable)ViewState["tblInternalChallanTra"];
                Li_Int_From from = new Li_Int_From();
                from.AmoutReceivable = decimal.Parse(txtTotalAmount.Text);
                from.Cause_Del = "";
                from.CreatedBy = int.Parse(Session["UserID"].ToString()); 
                from.CreatedDate = DateTime.Now;
                from.Dele_Date = DateTime.Now;
                from.DeleteBy = int.Parse(Session["UserID"].ToString());
                from.IsAlim = false;
                from.IsAlim_bonus = false;
                from.IsBoishki = false;
                from.IsBoishki_Bonus = false;
                from.IsRegular = false;
                from.LibraryID = ddlTsoNameFrom.SelectedValue.ToString();
                from.PacQty = 0;
                from.Per_Pac_Cost = 0;
                from.SlipNo = txtSlipNo.Text;
                from.Status_D = 'C';
                from.TotalAmount = decimal.Parse(txtTotalAmount.Text);
                from.Trans_Date = Convert.ToDateTime(txtDate.Text);
                from.BonusAmount = decimal.Parse(txtTotalDiscount.Text);
                string FromID = Li_Int_FromManager.InsertLi_Int_From(from, false);

                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {

                    Li_Int_From_Datail from_Detail = new Li_Int_From_Datail();
                    from_Detail.BookCode = dtCurrentTable.Rows[i]["BookCode"].ToString() + "/" + dtCurrentTable.Rows[i]["Edition"].ToString();
                    from_Detail.ID = FromID;
                    from_Detail.IsAlim = false;
                    from_Detail.IsAlim_Bonus = false;
                    from_Detail.IsBoishki = false;
                    from_Detail.IsBoishaki_Bonus = false;
                    from_Detail.IsRegular = false;
                    from_Detail.Qty = Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                    from_Detail.Status_D = 'C';
                    from_Detail.DisAmount = decimal.Parse(dtCurrentTable.Rows[i]["DisAmount"].ToString());
                    Li_Int_From_DatailManager.InsertLi_Int_From_Datail(from_Detail, false);


                }


                // saving data for party B


                Li_Int_To to = new Li_Int_To();
                to.AmoutReceivable = decimal.Parse(txtTotalAmount.Text);
                to.Cause_Del = "";
                to.CreatedBy = int.Parse(Session["UserID"].ToString());
                to.CreatedDate = DateTime.Now;
                to.Dele_Date = DateTime.Now;
                to.DeleteBy = int.Parse(Session["UserID"].ToString());
                to.IsAlim = false;
                to.IsAlim_bonus = false;
                to.IsBoishki = false;
                to.IsBoishki_Bonus = false;
                to.IsRegular = false;

                to.LibraryID = ddlTsoNameTo.SelectedValue.ToString();
                to.PacQty = 0;
                to.Per_Pac_Cost = 0;
                to.SlipNo = txtSlipNo.Text;
                to.Status_D = 'C';
                to.TotalAmount = decimal.Parse(txtTotalAmount.Text);
                to.Trans_Date = Convert.ToDateTime(txtDate.Text);
                to.BonusAmount = decimal.Parse(txtTotalDiscount.Text);

                string toID = Li_Int_ToManager.InsertLi_Int_To(to, false);

                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {

                    Li_Int_To_Detail to_Detail = new Li_Int_To_Detail();

                    to_Detail.BookCode = dtCurrentTable.Rows[i]["BookCode"].ToString() + "/" + dtCurrentTable.Rows[i]["Edition"].ToString();
                    to_Detail.ID = toID;

                    to_Detail.IsAlim = false;
                    to_Detail.IsAlim_Bonus = false;
                    to_Detail.IsBoishki = false;
                    to_Detail.IsBoishaki_Bonus = false;
                    to_Detail.IsRegular = false;


                    to_Detail.Qty = Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString()); ;
                    to_Detail.Status_D = 'C';
                    to_Detail.DisAmount = decimal.Parse(dtCurrentTable.Rows[i]["DisAmount"].ToString());

                    Li_Int_To_DetailManager.InsertLi_Int_To_Detail(to_Detail, false);


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
                ddlTerritoryFrom.Focus();
            }
            catch (Exception)
            {


            }

        }
    }
}
