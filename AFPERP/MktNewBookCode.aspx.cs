using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using Common.Marketing;
using System.Data;

namespace BLL
{
    public partial class MktNewBookCode : System.Web.UI.Page
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                li_BookVersionInfo aVersionInfo = new li_BookVersionInfo();
                aVersionInfo.BookID = ddlBookName.SelectedValue;
                aVersionInfo.Edition = ddlEdition.SelectedValue;
                aVersionInfo.BookAcCode = " ";
                aVersionInfo.IsReprinted = false;
                aVersionInfo.IsRebinding = false;
                aVersionInfo.IsOpeningStock = false;
                aVersionInfo.Price = decimal.Parse(txtPrice.Text);
                aVersionInfo.Printdate = DateTime.Now;
                aVersionInfo.Quantity = int.Parse(txtQty.Text);
                aVersionInfo.Bonus = txtBonus.Text != "" ? decimal.Parse(txtBonus.Text) : 0.0m;
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

    }
}
