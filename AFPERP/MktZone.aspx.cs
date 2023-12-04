using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class MktZone : System.Web.UI.Page
    {
        string FormID = "MF029";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {

                    getUserAccess();
                    LoadDivision();
                    Loadgvw_Zone();

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
        private void LoadDivision()
        {

            List<Li_Division> division = new List<Li_Division>();
            division = Li_DivisionManager.GetAllLi_Divisions();


            ddlDivision.DataSource = division;
            ddlDivision.DataTextField = "DivName";
            ddlDivision.DataValueField = "DivID";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(0, new ListItem("--select--", "0"));

        }

        private void Loadgvw_Zone()
        {
            gvwZone.DataSource = Li_ZoneManager.GetAllLi_Zones();
            gvwZone.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                Li_Zone Zone = new Li_Zone();
                Zone.CreatedBy = int.Parse(Session["UserID"].ToString());
                Zone.CreatedDate = DateTime.Now;
                Zone.Zon_Bn = txtZoneBanglaName.Text;
                Zone.ZonName = txtZoneName.Text;

                Zone.ModifiedBy = int.Parse(Session["UserID"].ToString());
                Zone.ModifiedDate = DateTime.Now;
                Zone.DivID = Int32.Parse(ddlDivision.SelectedValue);
                Li_ZoneManager.InsertLi_Zone(Zone);

                string message = "Saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                //  ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

                Loadgvw_Zone();
                ClearAll();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Li_Zone Zone = new Li_Zone();
                Zone.CreatedBy = int.Parse(Session["UserID"].ToString());
                Zone.CreatedDate = DateTime.Now;
                Zone.Zon_Bn = txtZoneBanglaName.Text;
                Zone.ZonName = txtZoneName.Text;

                Zone.ModifiedBy = int.Parse(Session["UserID"].ToString());
                Zone.ModifiedDate = DateTime.Now;
                Zone.DivID = Int32.Parse(ddlDivision.SelectedValue);
                Zone.ZonID = Int32.Parse(ViewState["ZoneID"].ToString());
                Li_ZoneManager.UpdateLi_Zone(Zone);

                string message = "Update successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                //  ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

                Loadgvw_Zone();
                ClearAll();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void ClearAll()
        {
            ddlDivision.SelectedIndex = -1;
            txtZoneName.Text = string.Empty;
            txtZoneBanglaName.Text = string.Empty;
        }

        protected void gvwZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwZone.SelectedRow;
                ViewState["ZoneID"] = row.Cells[1].Text;

                DataTable dtZone = Li_ZoneManager.GetAll_ZoneWithZoneId(ViewState["ZoneID"].ToString()).Tables[0];

                txtZoneName.Text = dtZone.Rows[0]["ZonName"].ToString();
                txtZoneBanglaName.Text = dtZone.Rows[0]["Zon_Bn"].ToString();
                ddlDivision.SelectedValue = dtZone.Rows[0]["DivID"].ToString();
            }
            catch (Exception)
            {

            }
        }

        protected void gvwZone_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
}