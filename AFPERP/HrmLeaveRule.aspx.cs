using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmLeaveRule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvLeaveRules.DataSource = Li_LeaveRuleManager.GetAllLi_LeaveRules();
                    gvLeaveRules.DataBind();
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



                if (txtLeaveRuleName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Leave Rule Name');", true);
                    return;
                }






                Li_LeaveRule lvRule = new Li_LeaveRule();
                lvRule.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                lvRule.CreatedDate = DateTime.Now;
                lvRule.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                lvRule.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                lvRule.ModifiedDate = DateTime.Now;
                lvRule.LeRuName = txtLeaveRuleName.Text;
                lvRule.LeRuId = 0;
                Li_LeaveRuleManager.InsertLi_LeaveRule(lvRule);


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