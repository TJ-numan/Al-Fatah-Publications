using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmLeaveStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    ddlInfoStatus.DataBind();

                    LoadComboData.LoadEmployeeInfo(ddlEmployee);
                    ddlEmployee.DataBind();

                    LoadComboData.LoadLeavePeriod(ddlPeriod);
                    ddlPeriod.DataBind();

                    LoadComboData.LoadLeaveType(ddlLeaveType);
                    ddlLeaveType.DataBind();

                }
            }
            catch (Exception ex)
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



                if (Int32.Parse(ddlEmployee.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Employee');", true);
                    return;
                }

                if (Int32.Parse(ddlPeriod.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Leave Period');", true);
                    return;
                }

                if (Int32.Parse(ddlLeaveType.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Leave Type');", true);
                    return;
                }
                if (txtAlotment.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Alotment');", true);
                    return;
                }






                Li_EmpLeaveStatus empLvStatus = new Li_EmpLeaveStatus();
                empLvStatus.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empLvStatus.CreatedDate = DateTime.Now;
                empLvStatus.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empLvStatus.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empLvStatus.ModifiedDate = DateTime.Now;
                empLvStatus.EmpLeEnId = 0;
                empLvStatus.EmpSl = Int32.Parse(ddlEmployee.SelectedValue);
                empLvStatus.PerId = Int32.Parse(ddlPeriod.SelectedValue);
                empLvStatus.LeTypId = Int32.Parse(ddlLeaveType.SelectedValue);
                empLvStatus.Alotment = decimal.Parse(txtAlotment.Text);
                empLvStatus.LeaveTaken =  decimal.Parse(txtLeaveTaken.Text);
                empLvStatus.Comments = txtComments.Text;
                Li_EmpLeaveStatusManager.InsertLi_EmpLeaveStatus(empLvStatus);


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
    }
}