using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class MktTeritory : System.Web.UI.Page
    {
        string FormID = "MF030";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadZone();
                    gvwAllTeritories();
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
        private void LoadZone()
        {
            List<Li_Zone> Zone = new List<Li_Zone>();
            Zone = Li_ZoneManager.GetAllLi_Zones();


            ddlZone.DataSource = Zone;
            ddlZone.DataTextField = "ZonName";
            ddlZone.DataValueField = "ZonID";
            ddlZone.DataBind();
            //ddlZone.Items.Insert(0, new ListItem("--select--", "0"));
        }

        private void gvwAllTeritories()
        {
            gvwTeritory.DataSource = Li_TeritoryManager.GetAllLi_Teritories("");
            gvwTeritory.DataBind();
        }

        protected void gvwTeritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwTeritory.SelectedRow;
                ViewState["TeritoryID"] = row.Cells[1].Text;
                DataTable dtTer = Li_TeritoryManager.GetAll_TeritoriesWithTeritoryId(ViewState["TeritoryID"].ToString()).Tables[0];

                txtTeritoryName.Text = dtTer.Rows[0]["TeritoryName"].ToString();
                txtTeritoryBanglaName.Text = dtTer.Rows[0]["Territory_Bn"].ToString();
                ddlZone.SelectedValue = dtTer.Rows[0]["ZonID"].ToString();
                txtTeritoryCode.Text = dtTer.Rows[0]["TeritoryCode"].ToString();
            }
            catch (Exception)
            {

            }
        }

        protected void gvwTeritory_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                Li_Teritory _teritory = new Li_Teritory();

                _teritory.TeritoryCode = txtTeritoryCode.Text;
                _teritory.TeritoryName = txtTeritoryName.Text;
                _teritory.ZonID = Convert.ToInt32(ddlZone.SelectedValue);
                _teritory.Territory_Bn = txtTeritoryBanglaName.Text;
                _teritory.CreatedBy = int.Parse(Session["UserID"].ToString());
                _teritory.CreatedDate = DateTime.Now;
                _teritory.ModifiedBy = int.Parse(Session["UserID"].ToString());
                _teritory.ModifiedDate = DateTime.Now;

                int result = Li_TeritoryManager.InsertLi_Teritory(_teritory);
                if (result > -1)
                {
                    
                string message = "Save successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                //  ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                }
                gvwAllTeritories();
                ClearAll();
            }
            catch (Exception ex)
            {
            }
        }

        private void ClearAll()
        {

            ddlZone.SelectedIndex = -1;
            txtTeritoryName.Text = string.Empty;
            txtTeritoryCode.Text = string.Empty;
            txtTeritoryBanglaName.Text = string.Empty;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                Li_Teritory _teritory = new Li_Teritory();

                _teritory.TeritoryID = int.Parse(ViewState["TeritoryID"].ToString());
                _teritory.TeritoryCode = txtTeritoryCode.Text;
                _teritory.TeritoryName = txtTeritoryName.Text;
                _teritory.Territory_Bn = txtTeritoryBanglaName.Text;
                _teritory.ZonID = Convert.ToInt32(ddlZone.SelectedValue);
                _teritory.ModifiedBy = int.Parse(Session["UserID"].ToString());
                _teritory.ModifiedDate = DateTime.Now;
                Li_TeritoryManager.UpdateLi_Teritory(_teritory);


                string message = "Update successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                //  ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

                gvwAllTeritories();
                ClearAll();
            }
            catch (Exception)
            {


            }
        }
    }
}