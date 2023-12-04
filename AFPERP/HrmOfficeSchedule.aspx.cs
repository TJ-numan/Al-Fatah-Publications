using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmOfficeSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    LoadComboData.LoadJobLocation(ddlOfficeLocation);
                    gvOfficeSchedule.DataSource = Li_OffScheduleManager.GetAllLi_OffSchedules();
                    gvOfficeSchedule.DataBind();
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


                Li_OffSchedule officeSchedule = new Li_OffSchedule();
                officeSchedule.Comment = txtComments.Text;
                officeSchedule.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                officeSchedule.CreatedDate = DateTime.Now;
                 
                officeSchedule.EndTime = txtEndingTime.Text ;
                officeSchedule.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                officeSchedule.MaxLateDay = decimal.Parse(txtMaxLateDay.Text);
                officeSchedule.NextLateDay = decimal.Parse(txtNextLateDay.Text);
                officeSchedule.MaxOutH = decimal.Parse(txtMaxOutH.Text);
                officeSchedule.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                officeSchedule.ModifiedDate = DateTime.Now;
                officeSchedule.OfficeLocation = ddlOfficeLocation.SelectedValue;
                officeSchedule.SchId = 0;
                officeSchedule.SchName = txtScheduleName.Text;
                
                officeSchedule.StartTime = txtStartingTime.Text ;
                Li_OffScheduleManager.InsertLi_OffSchedule(officeSchedule);


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

        }
    }
}