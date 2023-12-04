using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;


namespace BLL
{
    public partial class HrmEmpClearance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    LoadComboData.LoadEmployeeInfo(ddlEmployee);
                    LoadComboData.LoadEmploymentStatus(ddlEmploymentSt);

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
                Li_EmpClearance empClearence = new Li_EmpClearance();
                empClearence.ClearId = 0;
                empClearence.ClearTitle = txtClearTitle.Text;
                empClearence.Comments = txtComments.Text;
                empClearence.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empClearence.CreatedDate = DateTime.Now;
                empClearence.EmploymentStId = Int32.Parse(ddlEmploymentSt.SelectedValue);
                empClearence.EmpSl = Int32.Parse(ddlEmployee.SelectedValue);
                empClearence .ModifiedBy =Int32.Parse(Session["UserID"].ToString());
                empClearence.ModifiedDate = DateTime.Now;
                Li_EmpClearanceManager.InsertLi_EmpClearance(empClearence);

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