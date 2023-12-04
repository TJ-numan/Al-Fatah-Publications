using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmAssetVendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnUpdate.Enabled = false;
                LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                gvAssetVendor.DataSource = Li_AssetVendorManager.GetAllLi_AssetVendors();
                gvAssetVendor.DataBind();
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

                Li_AssetVendor assetVendor = new Li_AssetVendor();
                assetVendor.AssetVenId = 0;
                assetVendor.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                assetVendor.CreatedDate = DateTime.Now;
                assetVendor.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                assetVendor.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                assetVendor.ModifiedDate = DateTime.Now;
                assetVendor.VendorName = txtAssetVendor.Text;
                Li_AssetVendorManager.InsertLi_AssetVendor(assetVendor);


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

                Li_AssetVendor assetVendor = new Li_AssetVendor();
                assetVendor.AssetVenId = int.Parse(ViewState["AssetVendorId"].ToString());
                assetVendor.VendorName = txtAssetVendor.Text;
                assetVendor.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                assetVendor.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                assetVendor.ModifiedDate = DateTime.Now;
                Li_AssetVendorManager.UpdateLi_AssetVendor(assetVendor);

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

        protected void gvAssetVendor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void gvAssetVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;

                GridViewRow row = gvAssetVendor.SelectedRow;
                ViewState["AssetVendorId"] = row.Cells[1].Text;

                DataTable dtAssetVendor = Li_AssetVendorManager.GetAllLi_AssetVendorByID(int.Parse(ViewState["AssetVendorId"].ToString())).Tables[0];

                txtAssetVendor.Text = dtAssetVendor.Rows[0]["VendorName"].ToString();
                ddlInfoStatus.SelectedValue = dtAssetVendor.Rows[0]["InfStId"].ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}