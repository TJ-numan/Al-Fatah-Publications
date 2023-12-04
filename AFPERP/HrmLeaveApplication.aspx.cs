using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmLeaveApplication : System.Web.UI.Page
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

                    LoadComboData.LoadLeaveType(ddlLeaveType);
                    ddlLeaveType.DataBind();

                    LoadComboData.LoadEmployeeInfo(ddlResponsibleEmpl);
                    ddlResponsibleEmpl.DataBind();



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


                if (Int32.Parse(ddlLeaveType.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Leave Type');", true);
                    return;
                }
                if (txtLeaveQty.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid leave Quantity');", true);
                    return;
                }






                Li_EmpLeaveApplicaton empLvApplication = new Li_EmpLeaveApplicaton();
                empLvApplication.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empLvApplication.CreatedDate = DateTime.Now;
                empLvApplication.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empLvApplication.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empLvApplication.ModifiedDate = DateTime.Now;
                empLvApplication.LeavSl = 0;
                empLvApplication.EmpSl = Int32.Parse(ddlEmployee.SelectedValue);
                empLvApplication.LeTypId = Int32.Parse(ddlLeaveType.SelectedValue);
                empLvApplication.LeStDate = DateTime.Parse(txtLeStartDate.Text);
                empLvApplication.LeEnDate = DateTime.Parse(txtLeEndDate.Text);
                empLvApplication.LeQty = decimal.Parse(txtLeaveQty.Text);
                empLvApplication.IsDay = rdbIsDay.Checked ? true : false;
                empLvApplication.IsHalfDay = rdbIsHalfDay.Checked ? true : false;
                empLvApplication.IsHour = rdbIsHour.Checked ? true : false;
                empLvApplication.LeCause = txtLeaveCause.Text;
                empLvApplication.ConAddNPhone = txtConAddPhone.Text;
                empLvApplication.ResposibleEmpSl= Int32.Parse(ddlResponsibleEmpl.SelectedValue);

                Li_EmpLeaveApplicatonManager.InsertLi_EmpLeaveApplicaton(empLvApplication);


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