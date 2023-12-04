using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using Common.Marketing;
using System.Data;
using Common;
using BLL.Classes;

namespace BLL
{
    public partial class MktBookCode : System.Web.UI.Page
    {
        string FormID = "MF004";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadBookName();
                    LoadEdition();
                    GetAllBookVersionInfo();
                    LoadLibraryInformation_ForGVW();
                    btnVersionUpdate.Enabled = false; 
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
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadBookName()
        {
            ddlBookName.DataSource = li_BookInformationManager.Get_BookInformations_ComboSourceData();
            ddlBookName.DataTextField = "BookName";
            ddlBookName.DataValueField = "BookID";
            ddlBookName.DataBind();
            ddlBookName.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        private void LoadEdition()
        {
            ddlEdition.DataSource = li_BookEditionManager.GetAllEdition();
            ddlEdition.DataTextField = "Edition";
            ddlEdition.DataValueField = "Id";
            ddlEdition.DataBind();
            ddlEdition.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        protected void btnVersionUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                li_BookVersionInfo aVersionInfo = new li_BookVersionInfo();
                aVersionInfo.BookID = ddlBookName.SelectedValue;
                aVersionInfo.Edition = ddlEdition.SelectedValue.ToString(); ;
                aVersionInfo.BookAcCode = " ";
                aVersionInfo.IsReprinted = false;
                aVersionInfo.IsRebinding = false;
                aVersionInfo.IsOpeningStock = false;
                aVersionInfo.Price = decimal.Parse(txtPrice.Text);
                aVersionInfo.Printdate = DateTime.Now;
                aVersionInfo.Quantity = int.Parse(txtQty.Text);
                aVersionInfo.Bonus = txtBonus.Text != "" ? decimal.Parse(txtBonus.Text) : 0.0m;
                aVersionInfo.CreatedBy = int.Parse(Session["UserID"].ToString());
                int result = li_BookVersionInfoManager.Insert_BookVersionInfo(aVersionInfo);
                if (result > 0)
                {
                    string message = "Update successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                    script, true);
                }

                txtEntryNo.Text = result.ToString();
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", msg, true);
            }
        }
      
        protected void btnVersionSave_Click(object sender, EventArgs e)
        {
            try
            {
                li_BookVersionInfo aVersionInfo = new li_BookVersionInfo();
                aVersionInfo.BookID = ddlBookName.SelectedValue;
                aVersionInfo.Edition = ddlEdition.SelectedValue.ToString(); ;
                aVersionInfo.BookAcCode = " ";
                aVersionInfo.IsReprinted = false;
                aVersionInfo.IsRebinding = false;
                aVersionInfo.IsOpeningStock = false;
                aVersionInfo.Price = decimal.Parse(txtPrice.Text);
                aVersionInfo.Printdate = DateTime.Now;
                aVersionInfo.Quantity = int.Parse(txtQty.Text);
                aVersionInfo.Bonus = txtBonus.Text != "" ? decimal.Parse(txtBonus.Text) : 0.0m;
                aVersionInfo.CreatedBy = int.Parse(Session["UserID"].ToString());
                int result = li_BookVersionInfoManager.Insert_BookVersionInfo(aVersionInfo);
                if (result > 0)
                {
                    string message = "Saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                    script, true);
                }

                txtEntryNo.Text = result.ToString();
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", msg, true);
            }

        }

        protected void GetAllBookVersionInfo()
        {
            List<BookVersionInfo> versionInfos = li_StockManager.GetAllStocksInformations();
        }
        protected void gvwBookInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

        }
        protected void gvwLibraryInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = gvwLibraryInformation.SelectedRow;
                ViewState["LibraryID"] = row.Cells[1].Text;

                DataTable dtLibrary = Li_LibraryInformationManager.GetLibraryInformationByLibraryIDForEdit(ViewState["LibraryID"].ToString()).Tables[0];

               // txtLibraryID.Text = dtLibrary.Rows[0]["Edit"].ToString();
               // txtLibraryName.Text = dtLibrary.Rows[0]["LibraryName"].ToString();
                //txtLibraryOwnerName.Text = dtLibrary.Rows[0]["LibraryOwnerID"].ToString();
              //  txtShortAddress.Text = dtLibrary.Rows[0]["ShortAddress"].ToString();
              //  txtLibraryAddress.Text = dtLibrary.Rows[0]["LibraryAddress"].ToString();
              //  txtLibraryNameB.Text = dtLibrary.Rows[0]["Lib_Bn"].ToString();
               // txtShortAddressB.Text = dtLibrary.Rows[0]["ShAdd_Bn"].ToString();
              //  txtLibraryAddressB.Text = dtLibrary.Rows[0]["LibAdd_Bn"].ToString();
              //  ddlDristrict.SelectedValue = dtLibrary.Rows[0]["DistrictID"].ToString();

               // ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(dtLibrary.Rows[0]["DistrictID"].ToString()));
              //  ddlThana.DataTextField = "ThanaName";
              //  ddlThana.DataValueField = "ThanaID";
              //  ddlThana.DataBind();

             //   ddlThana.SelectedValue = dtLibrary.Rows[0]["ThanaID"].ToString();
                //ddlTerritory.SelectedValue = dtLibrary.Rows[0]["TeritoryID"].ToString();
              //  ddlType.SelectedValue = dtLibrary.Rows[0]["Type"].ToString();
              //  ddlCategory.SelectedValue = dtLibrary.Rows[0]["Category"].ToString();
              //  txtPhoneNo.Text = dtLibrary.Rows[0]["Telephone"].ToString();
             //   ddlTransportMain.SelectedValue = dtLibrary.Rows[0]["TransportID"].ToString() == "" ? "0" : dtLibrary.Rows[0]["TransportID"].ToString();
              //  ddlTransportAlter.SelectedValue = dtLibrary.Rows[0]["TransportID2"].ToString() == "" ? "0" : dtLibrary.Rows[0]["TransportID2"].ToString();

                btnVersionUpdate.Enabled = true;
                btnSave.Enabled = false;
            }
            catch (Exception)
            {

            }
        }
        protected void txtSearchBookName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadLibraryInformation_ForGVW();
            }
            catch (Exception)
            {

            }
        }
        private void LoadLibraryInformation_ForGVW()
        {
            try
            {
                string BookName = txtSearchBookName.Text;
                gvwLibraryInformation.DataSource = li_BookInformationManager.Get_BookInformationByBookName(BookName);
                gvwLibraryInformation.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvwLibraryInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvwLibraryInformation.PageIndex = e.NewPageIndex;

                string BookName = txtSearchBookName.Text;
                string BookID = ""; //= txtLibraryID.Text;
                gvwLibraryInformation.DataSource = li_BookInformationManager.GetAll_BookInformation(BookName, BookID).Tables[0];
                gvwLibraryInformation.DataBind();
            }
            catch (Exception ex)
            {

            }
        }


    }
}