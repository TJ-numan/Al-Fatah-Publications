using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmEmpMembership : System.Web.UI.Page
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

                    gvEmpMembership.DataSource = Li_EmpMembershipManager.LoadGvEmployeeMembership();
                    gvEmpMembership.DataBind();

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



                if (txtMembership.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Membership.');", true);
                    return;
                }



                Li_EmpMembership empMembership = new Li_EmpMembership();
                empMembership.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empMembership.CreatedDate = DateTime.Now;
                empMembership.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empMembership.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empMembership.ModifiedDate = DateTime.Now;
                empMembership.Membership = txtMembership.Text;
                empMembership.MemId = 0;
                empMembership.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                empMembership.SubPaidBy = txtSubPaidBy.Text;
                empMembership.SubsFee = txtSubsFee.Text;
                empMembership.Currency = txtCurrency.Text;
                empMembership.SubsReDate = DateTime.Parse(txtSubsReDate.Text);
                empMembership.SubsCommenceDate = DateTime.Parse(txtSubscCommncDate.Text);
                empMembership.MemDes = txtMemberDesc.Text;
                Li_EmpMembershipManager.InsertLi_EmpMembership(empMembership);


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