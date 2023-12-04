using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmLeaveType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvLeaveTypes.DataSource = Li_LeaveTypeManager.GetAllLi_LeaveTypes();
                    gvLeaveTypes.DataBind();
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



                if (txtLvTypeName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Leave Type Name');", true);
                    return;
                }






                Li_LeaveType lvType = new Li_LeaveType();
                lvType.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                lvType.CreatedDate = DateTime.Now;
                lvType.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                lvType.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                lvType.ModifiedDate = DateTime.Now;
                lvType.LeTyName = txtLvTypeName.Text;
                lvType.LeTypId = 0;
                lvType.DayCount = decimal.Parse(txtDayCount.Text);
                lvType.BalForword = chkBalForward.Checked ? true : false;
                Li_LeaveTypeManager.InsertLi_LeaveType(lvType);


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