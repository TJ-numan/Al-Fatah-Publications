using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;
using System.Data;


namespace BLL
{
    public partial class AssetCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                btnUpdate.Enabled = false;
                LoadComboData.LoadHRInfoStatus(ddlInfoStatus);

                gvAssetCategory.DataSource = Li_AssetCategoryManager.GetAllLi_AssetCategories();
                gvAssetCategory.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(ddlInfoStatus.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                    return;
                }

                Li_AssetCategory assetCategory = new Li_AssetCategory();
                assetCategory.AssetCatId = 0;
                assetCategory.Category = txtAssetCategory.Text;
                assetCategory.CatePrefix = txtCategoryPrefix.Text;
                assetCategory.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                assetCategory.CreatedDate = DateTime.Now;
                assetCategory.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                assetCategory.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                assetCategory.ModifiedDate = DateTime.Now;
                Li_AssetCategoryManager.InsertLi_AssetCategory(assetCategory);

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
            catch (Exception)
            {
                
                
            }
				
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(ddlInfoStatus.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                    return;
                }

                Li_AssetCategory assetCategory = new Li_AssetCategory();
                assetCategory.AssetCatId = int.Parse(ViewState["AssetId"].ToString());
                assetCategory.Category = txtAssetCategory.Text;
                assetCategory.CatePrefix = txtCategoryPrefix.Text;
                assetCategory.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                assetCategory.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                assetCategory.ModifiedDate = DateTime.Now;
                Li_AssetCategoryManager.UpdateLi_AssetCategory(assetCategory);

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
            catch (Exception)
            {


            }
        }

        protected void gvAssetCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void gvAssetCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;

                GridViewRow row = gvAssetCategory.SelectedRow;
                ViewState["AssetId"] = row.Cells[1].Text;

                DataTable dtAssetCat = Li_AssetCategoryManager.GetAllLi_AssetCategoryByID(int.Parse(ViewState["AssetId"].ToString())).Tables[0];

                txtAssetCategory.Text = dtAssetCat.Rows[0]["Category"].ToString();
                txtCategoryPrefix.Text = dtAssetCat.Rows[0]["CatePrefix"].ToString();
                ddlInfoStatus.SelectedValue = dtAssetCat.Rows[0]["InfStId"].ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}