using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;



namespace BLL
{
    public partial class HrmFinalSettlement : System.Web.UI.Page
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
                Li_FinalSettlement finalSettlement = new Li_FinalSettlement();
                finalSettlement.Comments = txtComments.Text;
                finalSettlement.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                finalSettlement.CreatedDate = DateTime.Now;
                finalSettlement.DoJ = Convert.ToDateTime(txtJoiningDate.Text);
                finalSettlement.EmploymentStId = Int32.Parse(ddlEmploymentSt.SelectedValue);
                finalSettlement.EmpSl = Int32.Parse(ddlEmployee.SelectedValue);
                finalSettlement.EoS = Convert.ToDateTime(txtEndOfService.Text);
                finalSettlement.EPOF = decimal.Parse(txtEndPOF.Text);
                finalSettlement.FiSetId = 0;
                finalSettlement.Gratuity = decimal.Parse(txtGratuity.Text);
                finalSettlement.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                finalSettlement.IsAssetClear = chkIsAssetClear.Checked;
                finalSettlement.IsDepClear = chkIsDeptClear.Checked;
                finalSettlement.Loan = decimal.Parse(txtLoan.Text);
                finalSettlement.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                finalSettlement.ModifiedDate = DateTime.Now;
                finalSettlement.NOCPath = "";
                finalSettlement.OthAmt = decimal.Parse(txtOtherAmt.Text);
                finalSettlement.ResPath = "";
                Li_FinalSettlementManager.InsertLi_FinalSettlement(finalSettlement);


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