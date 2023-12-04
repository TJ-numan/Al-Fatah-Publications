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
    public partial class HrmAssetBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    btnUpdate.Enabled = false;

                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvAssetBrand.DataSource = Li_AssetBrandManager.GetAllLi_AssetBrands();
                    gvAssetBrand.DataBind();


                }
            }
            catch (Exception)
            {
                
                
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

                Li_AssetBrand assetBrand = new Li_AssetBrand();
                assetBrand.BrandId = 0;
                assetBrand.BrandName = txtBrandName.Text;
                assetBrand.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                assetBrand.CreatedDate = DateTime.Now;
                assetBrand.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                assetBrand.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                assetBrand.ModifiedDate = DateTime.Now;
                Li_AssetBrandManager.InsertLi_AssetBrand(assetBrand);

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

                Li_AssetBrand assetBrand = new Li_AssetBrand();
                assetBrand.BrandId = int.Parse(ViewState["BrandID"].ToString());
                assetBrand.BrandName = txtBrandName.Text;
                assetBrand.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                assetBrand.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                assetBrand.ModifiedDate = DateTime.Now;
                Li_AssetBrandManager.UpdateLi_AssetBrand(assetBrand);

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

        protected void gvAssetBrand_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void gvAssetBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;

                GridViewRow row = gvAssetBrand.SelectedRow;
                ViewState["BrandID"] = row.Cells[1].Text;

                DataTable dtAssetCat = Li_AssetBrandManager.GetAllLi_AssetBrandByID(int.Parse(ViewState["BrandID"].ToString())).Tables[0];

                txtBrandName.Text = dtAssetCat.Rows[0]["BrandName"].ToString();
                ddlInfoStatus.SelectedValue = dtAssetCat.Rows[0]["InfStId"].ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}