using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmMaritalStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvwMaritalStatus.DataSource = Li_MaritalStatusManager.GetAllLi_MaritalStatuss();
                    gvwMaritalStatus.DataBind();
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

                if (txtMaritalStatus.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Marital Status.');", true);
                    return;  
                }

                Li_MaritalStatus maritalStatus = new Li_MaritalStatus();
                maritalStatus.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                maritalStatus.CreatedDate = DateTime.Now;
                maritalStatus.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                maritalStatus.MarStId = 0;
                maritalStatus.MarStName = txtMaritalStatus.Text;
                maritalStatus.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                maritalStatus.ModifiedDate = DateTime.Now;
                Li_MaritalStatusManager.InsertLi_MaritalStatus(maritalStatus);

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

                if (txtMaritalStatus.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Marital Status.');", true);
                    return;
                }

                Li_MaritalStatus maritalStatus = new Li_MaritalStatus(); 
                maritalStatus.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                maritalStatus.MarStId = Int32.Parse (txtMaritalStatusId .Text );
                maritalStatus.MarStName = txtMaritalStatus.Text;
                maritalStatus.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                maritalStatus.ModifiedDate = DateTime.Now;
                Li_MaritalStatusManager.UpdateLi_MaritalStatus(maritalStatus);

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

        protected void gvwMaritalStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
							
        }

        protected void gvwMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwMaritalStatus.SelectedRow;
                ViewState["MarStId"] = row.Cells[1].Text;

                Li_MaritalStatus maritalStatus = new Li_MaritalStatus();
                maritalStatus = Li_MaritalStatusManager.GetLi_MaritalStatusByID(Int32.Parse(ViewState["MarStId"].ToString()));

                txtMaritalStatusId.Text = maritalStatus.MarStId.ToString();
                txtMaritalStatus.Text = maritalStatus.MarStName;
                ddlInfoStatus.SelectedValue = maritalStatus.InfStId.ToString();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                
                
            }
        }
    }
}