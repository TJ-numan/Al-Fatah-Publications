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
    public partial class HrmDesignation : System.Web.UI.Page
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
                        gvDesignation.DataSource = Li_DesignationManager.GetAllLi_Designations();
                        gvDesignation.DataBind();
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

                if (txtDesignation.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Department Name');", true);
                    return;
                }

                Li_Designation designation = new Li_Designation();
                designation.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                designation.CreatedDate = DateTime.Now;
                designation.DesId = 0;
                designation.DesName = txtDesignation.Text;
                designation.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                designation.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                designation.ModifiedDate = DateTime.Now;
                Li_DesignationManager.InsertLi_Designation(designation);


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

                if (txtDesignation.Text.Trim() == "" || txtDesignationId.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Department Name');", true);
                    return;
                }

                Li_Designation designation = new Li_Designation();
                designation.DesId = Int32.Parse(txtDesignationId.Text);
                designation.DesName = txtDesignation.Text;
                designation.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                designation.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                designation.ModifiedDate = DateTime.Now;
                Li_DesignationManager.UpdateLi_Designation(designation);

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

        protected void gvDesignation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

        }

        protected void gvDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvDesignation.SelectedRow;
                ViewState["DesId"] = row.Cells[1].Text;
                Li_Designation desination = new Li_Designation();
                desination = Li_DesignationManager.GetLi_DesignationByID(Int32.Parse(ViewState["DesId"].ToString()));
                txtDesignation.Text = desination.DesName;
                txtDesignationId.Text = desination.DesId.ToString();
                ddlInfoStatus.SelectedValue = desination.InfStId.ToString();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                               
            }
        }




    }
}