using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmEmpPassportVisa : System.Web.UI.Page
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

                    gvEmployeePassport.DataSource = Li_EmpPassportVisaManager.LoadEmpPassport();
                    gvEmployeePassport.DataBind();

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



                if (txtPassportVisaNo.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid PassportVisaNo.');", true);
                    return;
                }



                Li_EmpPassportVisa empPassVisa = new Li_EmpPassportVisa();
                empPassVisa.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empPassVisa.CreatedDate = DateTime.Now;
                empPassVisa.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empPassVisa.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empPassVisa.ModifiedDate = DateTime.Now;
                empPassVisa.PaViNo = txtPassportVisaNo.Text;
                empPassVisa.PaViId = 0;
                empPassVisa.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                empPassVisa.PassOrVisa = txtPassOrVisa.Text;
                empPassVisa.IssuedBy = txtIssuedBy.Text;
                empPassVisa.IssueDate = DateTime.Parse(txtIssueDate.Text);
                empPassVisa.ExpiryDate = DateTime.Parse(txtExpiredDate.Text);
                empPassVisa.EligibleReviewDate = DateTime.Parse(txtEligiRevwDate.Text);
                empPassVisa.EligibleStatus = txtEligibleStatus.Text;
                empPassVisa.Comments = txtComments.Text;
                Li_EmpPassportVisaManager.InsertLi_EmpPassportVisa(empPassVisa);


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