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
    public partial class Mkt_AdjustmentChalan : System.Web.UI.Page
    {
        string FormID = "MF015";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {
                try
                {
                    getUserAccess();
                    Session["test"] = 0;
                    txtDate.Focus();
                    LoadYear();
                    LoadAgent();
                    LoadMemoType();
                    txtDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);                
                    txtDate.Attributes.Add("autocomplete", "off");
                    txtBookCode.Attributes.Add("autocomplete", "off");
                    AddDefaultFirstRecord();
                  
                }
                catch (Exception)
                {

                }
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
        private void LoadMemoType()
        {
           
        }
        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            int result = 0;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblAdjustChallan";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BookCode", typeof(string));
            dt.Columns.Add("BookName", typeof(string));          
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("ShortQty", typeof(Decimal));
            dt.Columns.Add("OverQty", typeof(Decimal));
            dt.Columns.Add("Price", typeof(Decimal));
            dt.Columns.Add("ShortAmount", typeof(Decimal));
            dt.Columns.Add("OverAmount", typeof(Decimal));
            dt.Columns.Add("ShortDisAmount", typeof(Decimal));
            dt.Columns.Add("OverDisAmount", typeof(Decimal));            
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblAdjustChallan"] = dt;
            //bind Gridview  
            gvwChlAdjust.DataSource = dt;
            gvwChlAdjust.DataBind();
            ViewState["LinkClick"] = fromLinkButton;
            Session["ResultMemo"] = result;


        }


        private void AddNewRecordRowToGrid()
        {
            // check view state is not null  
            if (ViewState["tblAdjustChallan"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblAdjustChallan"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                   
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

                        drCurrentRow["BookCode"] = txtBookCode.Text;
                        drCurrentRow["BookName"] = txtBookName.Text;
                        drCurrentRow["Type"] = txtType.Text;
                        drCurrentRow["Class"] = txtClass.Text;
                        drCurrentRow["Edition"] = ddlEdition.SelectedItem.Text;
                        drCurrentRow["ShortQty"] =txtShortQty.Text;
                        drCurrentRow["OverQty"] = txtOverQty.Text;
                        drCurrentRow["Price"] = txtPrice.Text;
                        drCurrentRow["ShortAmount"]= decimal.Parse(txtPrice.Text) * Int32.Parse(txtShortQty.Text);
                        drCurrentRow["OverAmount"] =  decimal.Parse(txtPrice.Text) * Int32.Parse(txtOverQty.Text);
                        drCurrentRow["ShortDisAmount"] = decimal.Parse( txtPrice.Text) * decimal.Parse(txtShortQty.Text) * (decimal.Parse( txtDiscount.Text) / 100.0m);
                        drCurrentRow["OverDisAmount"] = decimal.Parse(txtPrice.Text) * decimal.Parse(txtOverQty.Text) * (decimal.Parse(txtDiscount.Text) / 100.0m); 

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

                    ViewState["tblAdjustChallan"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvwChlAdjust.DataSource = dtCurrentTable;
                    gvwChlAdjust.DataBind();

                    decimal totalShortAmount = 0.0m;
                    decimal totalOverAmount = 0.0m;
                    decimal totalShDiscount = 0.0m;
                    decimal totalOVDiscount = 0.0m;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            decimal shortAmount = decimal.Parse(dtCurrentTable.Rows[i]["ShortAmount"].ToString());

                            decimal overAmount = decimal.Parse(dtCurrentTable.Rows[i]["OverAmount"].ToString());

                            decimal ShDiscAmount = decimal.Parse(dtCurrentTable.Rows[i]["ShortDisAmount"].ToString());

                            decimal OvDiscAmount = decimal.Parse(dtCurrentTable.Rows[i]["OverDisAmount"].ToString());

                            totalShortAmount += shortAmount;

                            totalOverAmount += overAmount;

                            totalShDiscount += ShDiscAmount;


                            totalOVDiscount += OvDiscAmount;
                           
                        }
                        txtTotalShortAmount.Text = String.Format("{0:0.##}", totalShortAmount);
                        txtTotalOverAmount.Text = String.Format("{0:0.##}", totalOverAmount);
                        txtTotalDiscount.Text = String.Format("{0:0.##}", totalShDiscount - totalOVDiscount);
                        txtAdjustAmount.Text = String.Format("{0:0.##}", (totalShortAmount - totalOverAmount) - (totalShDiscount - totalOVDiscount));
                    }
                                  
                }

            }
        }

        protected void BindGrid()
        {
            gvwChlAdjust.DataSource = (DataTable)ViewState["BookInfo"];
            gvwChlAdjust.DataBind();
        }

        private void LoadYear()
        {
            ddlEdition.DataSource = li_ChallanManager.LoadYear().Tables[0];
            ddlEdition.DataTextField = "Edition";
            ddlEdition.DataBind();


        }

        private void LoadAgent()
        {
            try
            {
                LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            catch (Exception)
            {

            }
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
                    ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                    txtDiscount.Text = "0"; // ds.Tables[0].Rows[0]["SPDiscountPer"].ToString();
                    txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                }
                else
                {
                    txtBookName.Text = "";
                    txtType.Text = "";
                    txtClass.Text = "";
                    ddlEdition.Text = "";                 
                    txtPrice.Text = "";
                }

            }
            catch (Exception er)
            {
                txtBookName.Text = "";
                txtType.Text = "";
                txtClass.Text = "";
                ddlEdition.Text = "";              
                txtPrice.Text = "";


            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblAdjustChallan"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }

        protected void ddlChlNewEdition_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void txtPacketNo_TextChanged(object sender, EventArgs e)
        {
           
        }
      
        protected void btnChlNewPrint_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtBookCode.Text.Trim() == "" || txtShortQty.Text.Trim() == "" || txtOverQty.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give book code and qty.');", true);
                txtBookCode.Focus();
                return;
            }

            AddNewRecordRowToGrid();
        }

        protected void lblDelete_OnClick(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblChallan"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();


            }
            catch (Exception)
            {


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["tblAdjustChallan"];
            try
            {
              
                Li_AdjustChalan li_AdjustChalan = new Li_AdjustChalan();
                li_AdjustChalan.RefNo = txtRefChalanNo.Text;               
                li_AdjustChalan.LibraryID = ddlLibraryName.SelectedValue.ToString();
                li_AdjustChalan.SHAmount = Decimal.Parse(txtTotalShortAmount.Text);
                li_AdjustChalan.OVAmount = Decimal.Parse(txtTotalOverAmount.Text);
                li_AdjustChalan.BonusAmount = Decimal.Parse(txtTotalDiscount.Text);
                li_AdjustChalan.PacQty = txtPktNo.Text != "" ? Int32.Parse(txtPktNo.Text) : 0;
                li_AdjustChalan.Per_Pac_Cost = txtPerPktCost.Text != "" ? decimal.Parse(txtPerPktCost.Text) : 0.0m;
                li_AdjustChalan.AmoutReceivable = Decimal.Parse(txtAdjustAmount.Text);
                li_AdjustChalan.Trans_Date = Convert.ToDateTime(txtDate.Text);
                li_AdjustChalan.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                li_AdjustChalan.CreatedDate = DateTime.Now;
                li_AdjustChalan.IsBoishki = radBoishakhi.Checked ? true : false;
                li_AdjustChalan.IsBoishki_Bonus = radBoishakhiBonus.Checked ? true : false;
                li_AdjustChalan.IsAlim = radAlim.Checked ? true : false;
                li_AdjustChalan.IsAlim_bonus = radAlimBonus.Checked ? true : false;
                li_AdjustChalan.Status_D = 'C';
                li_AdjustChalan.DeleteBy = Convert.ToInt32(Session["UserID"].ToString());
                li_AdjustChalan.Dele_Date = DateTime.Now;
                li_AdjustChalan.Cause_Del = "";
                li_AdjustChalan.ForReturn = chkForReturn.Checked ? true : false;
                string resutl = Li_AdjustChalanManager.InsertLi_AdjustChalan(li_AdjustChalan);

                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {


                    Li_AdjustChalan_Datail li_AdjustChalan_Datail = new Li_AdjustChalan_Datail();
                    li_AdjustChalan_Datail.ID = resutl;
                    li_AdjustChalan_Datail.BookCode = dtCurrentTable.Rows[i]["BookCode"].ToString() + "/" + dtCurrentTable.Rows[i]["Edition"].ToString();
                    li_AdjustChalan_Datail.SHQty = Int32.Parse(dtCurrentTable.Rows[i]["ShortQty"].ToString());
                    li_AdjustChalan_Datail.OvQty = Int32.Parse(dtCurrentTable.Rows[i]["OverQty"].ToString());
                    li_AdjustChalan_Datail.SHDisAmount = decimal.Parse(dtCurrentTable.Rows[i]["ShortDisAmount"].ToString());
                    li_AdjustChalan_Datail.OverDisAmount = decimal.Parse(dtCurrentTable.Rows[i]["OverDisAmount"].ToString());
                    li_AdjustChalan_Datail.IsBoishki = radBoishakhi.Checked ? true : false;
                    li_AdjustChalan_Datail.IsBoishaki_Bonus = radBoishakhiBonus.Checked ? true : false;
                    li_AdjustChalan_Datail.IsAlim = radAlim.Checked ? true : false;
                    li_AdjustChalan_Datail.IsAlim_Bonus = radAlimBonus.Checked ? true : false;

                    li_AdjustChalan_Datail.Status_D = 'C';

                    Li_AdjustChalan_DatailManager.InsertLi_AdjustChalan_Datail(li_AdjustChalan_Datail);



                }

                txtMemoNo.Text = resutl.Substring(13).ToString();
                string message = "Saved Successfully!";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script,
                    true);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
