using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class MktRegion : System.Web.UI.Page     
    {
        string FormID = "MF027";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    gvwRegion.DataSource = li_RegionManager.GetRegion().Tables[0];
                    gvwRegion.DataBind();
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
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Update_"].ToString()) == true)
                    {
                        btnUpdate.Enabled = true;
                    }
                    else
                    {
                        btnUpdate.Enabled = false;
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
        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                li_Region _region = new li_Region();

                _region.RegionName = txtRegionName.Text;
                _region.Region_Bn = txtRegiBngName.Text;
                _region.CreatedBy = int.Parse(Session["UserID"].ToString());
                _region.CreatedDate = DateTime.Now;

                _region.ModifiedBy = int.Parse(Session["UserID"].ToString());
                _region.ModifiedDate = DateTime.Now;


                int result = li_RegionManager.Insert_Region(_region);

                if (result > -1)
                {

                    string message = "Saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    //  ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

                }
                txtRegionName.Text = "";
                txtRegiBngName.Text = "";
                gvwRegion.DataSource = li_RegionManager.GetRegion().Tables[0];
                gvwRegion.DataBind();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                li_Region _region = new li_Region();
                _region.RegionID = Int32.Parse(ViewState["RegionID"].ToString());
                _region.RegionName = txtRegionName.Text;
                _region.Region_Bn = txtRegiBngName.Text;


                _region.ModifiedBy = int.Parse(Session["UserID"].ToString());
                _region.ModifiedDate = DateTime.Now;


                li_RegionManager.Update_Region(_region);


                string message = "Information Update successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                //  ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);


                txtRegionName.Text = "";
                txtRegiBngName.Text = "";
                gvwRegion.DataSource = li_RegionManager.GetRegion().Tables[0];
                gvwRegion.DataBind();
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvwRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwRegion.SelectedRow;
                ViewState["RegionID"] = row.Cells[1].Text;

                DataTable dtReg = li_RegionManager.GetRegionById(ViewState["RegionID"].ToString()).Tables[0];

                txtRegionName.Text = dtReg.Rows[0]["RegionName"].ToString();
                txtRegiBngName.Text = dtReg.Rows[0]["Region_Bn"].ToString();

            }
            catch (Exception)
            {

            }
        }

        protected void gvwRegion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

        }
    }
}