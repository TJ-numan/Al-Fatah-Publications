using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmOrganogram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    LoadComboData.LoadJobTitle(ddlJobTitle);
                    LoadComboData.LoadDepartments(ddlDepartment);
                    LoadComboData.LoadDesignation(ddlDesignation);
                    LoadComboData.LoadJobCategory(ddlJobCategory);
                    LoadComboData.LoadJobTitle(ddlReportToPosition);

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
                if (Int32.Parse(ddlInfoStatus.SelectedValue) <= 0 ||
                    Int32.Parse(ddlJobTitle.SelectedValue) <= 0 ||
                    Int32.Parse(ddlDepartment.SelectedValue) <= 0 ||
                    Int32.Parse(ddlDesignation.SelectedValue) <= 0 ||
                    Int32.Parse(ddlJobCategory.SelectedValue) <= 0 ||
                            Int32.Parse(ddlReportToPosition.SelectedValue) <= 0
                    )
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information.');", true);
                    return;

                }

                if (ddlJobTitle.SelectedValue == ddlReportToPosition.SelectedValue)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Working Position and Report Position Should not be same.');", true);
                    return;
                }

                Li_Organogram organogram = new Li_Organogram();
                organogram.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                organogram.CreatedDate = DateTime.Now;
                organogram.DepId = Int32.Parse(ddlDepartment.SelectedValue);
                organogram.DesId = Int32.Parse(ddlDesignation.SelectedValue);
                organogram.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                organogram.IsDefault = chkIsDefault.Checked;
                organogram.JobNaId = Int32.Parse(ddlJobCategory.SelectedValue);
                organogram.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                organogram.ModifiedDate = DateTime.Now;
                organogram.PosId = 0;
                organogram.PosTitle = ddlJobTitle.SelectedValue;
                organogram.ReportToPosId = Int32.Parse(ddlReportToPosition.SelectedValue);
                Li_OrganogramManager.InsertLi_Organogram(organogram);

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
                if (Int32.Parse(ddlInfoStatus.SelectedValue) <= 0 ||
                    Int32.Parse(ddlJobTitle.SelectedValue) <= 0 ||
                    Int32.Parse(ddlDepartment.SelectedValue) <= 0 ||
                    Int32.Parse(ddlDesignation.SelectedValue) <= 0 ||
                    Int32.Parse(ddlJobCategory.SelectedValue) <= 0 ||
                            Int32.Parse(ddlReportToPosition.SelectedValue) <= 0
                    )
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information.');", true);
                    return;

                }

                Li_Organogram organogram = new Li_Organogram(); 
                organogram.DepId = Int32.Parse(ddlDepartment.SelectedValue);
                organogram.DesId = Int32.Parse(ddlDesignation.SelectedValue);
                organogram.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                organogram.IsDefault = chkIsDefault.Checked;
                organogram.JobNaId = Int32.Parse(ddlJobCategory.SelectedValue);
                organogram.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                organogram.ModifiedDate = DateTime.Now;
                organogram.PosId = Int32 .Parse (txtOrgId .Text );
                organogram.PosTitle = ddlJobTitle.SelectedValue;
                organogram.ReportToPosId = Int32.Parse(ddlReportToPosition.SelectedValue);
                Li_OrganogramManager.UpdateLi_Organogram(organogram);

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
    }
}