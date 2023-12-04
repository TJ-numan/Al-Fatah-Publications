using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmLeaveTypeRule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    ddlInfoStatus.DataBind();

                    LoadComboData.LoadLeaveType(ddlLeaveType);
                    ddlLeaveType.DataBind();

                    LoadComboData.LoadLeaveRule(ddlLeaveRule);
                    ddlLeaveRule.DataBind();
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



                if (Int32.Parse(ddlLeaveType.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Leave Type');", true);
                    return;
                }

                if (Int32.Parse(ddlLeaveRule.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Leave Rule');", true);
                    return;
                }






                Li_LeaveTypeRule lvTypeRule = new Li_LeaveTypeRule();
                lvTypeRule.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                lvTypeRule.CreatedDate = DateTime.Now;
                lvTypeRule.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                lvTypeRule.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                lvTypeRule.ModifiedDate = DateTime.Now;
                lvTypeRule.LeTyRuId = 0;
                lvTypeRule.LeTypId = Int32.Parse(ddlLeaveType.SelectedValue);
                lvTypeRule.LeRuId = Int32.Parse(ddlLeaveRule.SelectedValue);
                Li_LeaveTypeRuleManager.InsertLi_LeaveTypeRule(lvTypeRule);


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