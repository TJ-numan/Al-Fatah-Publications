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
    public partial class HrmJobLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!IsPostBack)
                    {
                        LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                        gvJobLocation.DataSource = Li_JobLocationManager.GetAllLi_JobLocations();
                        gvJobLocation.DataBind();
                    }
                }
                catch (Exception)
                {


                }
            } 

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlInfoStatus.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid info status.');", true);
                    return;
                }

                if (txtJobLocation.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Department Name');", true);
                    return;
                }

                Li_JobLocation  JLocation = new  Li_JobLocation ();
                JLocation.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                JLocation.CreatedDate = DateTime.Now;
                JLocation.LocId = 0;
                JLocation.LocName = txtJobLocation.Text;
                JLocation.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                JLocation.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                JLocation.ModifiedDate = DateTime.Now;
                Li_JobLocationManager. InsertLi_JobLocation( JLocation);


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
                if (ddlInfoStatus.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid info status.');", true);
                    return;
                }

                if (txtJobLocation.Text.Trim() == "" || txtJobLocationId.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Department Name');", true);
                    return;
                }

                Li_JobLocation JLocation = new Li_JobLocation(); 
                JLocation.LocId = Int32 .Parse (txtJobLocationId .Text) ;
                JLocation.LocName = txtJobLocation.Text;
                JLocation.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                JLocation.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                JLocation.ModifiedDate = DateTime.Now;
                Li_JobLocationManager. UpdateLi_JobLocation(JLocation);

                string message = "Updated successfully.";
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

        protected void gvJobLocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
        }

        protected void gvJobLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = gvJobLocation.SelectedRow;
                ViewState["LocId"] = row.Cells[1].Text;

                Li_JobLocation location = new Li_JobLocation();
                location = Li_JobLocationManager.GetLi_JobLocationByID(Int32.Parse(ViewState["LocId"].ToString()));

                txtJobLocation.Text = location.LocName;
                txtJobLocationId.Text = location.LocId.ToString();
                ddlInfoStatus.SelectedValue = location.InfStId.ToString();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                
                 
            }
        }

      

   


    }
}