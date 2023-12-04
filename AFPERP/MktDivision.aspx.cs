using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class MktDivision : System.Web.UI.Page
    {
        string FormID = "MF028";
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadRegion();
                    Loadgvw_Division();
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
        private void LoadRegion()
        {

            ddlRegion.DataSource = li_RegionManager.Getddl_Region().Tables[0];
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataValueField = "RegionID";
            ddlRegion.DataBind();
        }

        private void Loadgvw_Division()
        {
            gvwDivision.DataSource = Li_DivisionManager.GetAllLi_Divisions();
            gvwDivision.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
   
                Li_Division division = new Li_Division();
                division.CreatedBy = int.Parse(Session["UserID"].ToString());
                division.CreatedDate = DateTime.Now;
                division.Div_Bn = txtDivBanglaName.Text;
                division.DivName = txtDivisionName.Text;

                division.ModifiedBy = int.Parse(Session["UserID"].ToString());
                division.ModifiedDate = DateTime.Now;
                division.RegionID = Int32.Parse(ddlRegion.SelectedValue);
                int result= Li_DivisionManager.InsertLi_Division(division);
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
                Loadgvw_Division();
                ClearAll();
            }
            catch (Exception ex)
            {
            }
        }

        private void ClearAll()
        {
            ddlRegion.SelectedIndex = -1;
            txtDivisionName.Text = string.Empty;
            txtDivBanglaName.Text = string.Empty;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Li_Division division = new Li_Division();
            division.DivID = Int32.Parse(ViewState["DivID"].ToString());
            division.Div_Bn = txtDivBanglaName.Text;
            division.DivName = txtDivisionName.Text;

            division.ModifiedBy = int.Parse(Session["UserID"].ToString());
            division.ModifiedDate = DateTime.Now;
            division.RegionID = Int32.Parse(ddlRegion.SelectedValue.ToString());
            Li_DivisionManager.UpdateLi_Division(division);

            string message = "Update successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += Request.Url.AbsoluteUri;
            script += "'; }";
            //  ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

            Loadgvw_Division();
            ClearAll();
        }

        protected void gvwDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwDivision.SelectedRow;
                ViewState["DivID"] = row.Cells[1].Text;

                DataTable dtDiv = Li_DivisionManager.GetAll_DivisionWithDivId(ViewState["DivID"].ToString()).Tables[0];

                txtDivisionName.Text = dtDiv.Rows[0]["DivName"].ToString();
                txtDivBanglaName.Text = dtDiv.Rows[0]["Div_Bn"].ToString();
                ddlRegion.SelectedValue = dtDiv.Rows[0]["RegionID"].ToString();
            }
            catch (Exception)
            {

            }
        }

        protected void gvwDivision_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        } 
    }
}