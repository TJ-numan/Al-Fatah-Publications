using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmEmpIncrePromoTrans : System.Web.UI.Page
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
                    LoadComboData.LoadEmploymentStatus(ddlEmploymentSt);
                    ddlEmploymentSt.DataBind();

                    //Previous Load
                    LoadComboData.LoadDepartments(ddlPrevDept);
                    ddlPrevDept.DataBind();
                    LoadComboData.LoadDesignation(ddlPrevDesig);
                    ddlPrevDesig.DataBind();
                    LoadComboData.LoadSection(ddlPrevSec);
                    ddlPrevSec.DataBind();
                    LoadComboData.LoadPayGrade(ddlPrevPayGrade);
                    ddlPrevPayGrade.DataBind();

                    //Present Load
                    LoadComboData.LoadDepartments(ddlPresDept);
                    ddlPresDept.DataBind();
                    LoadComboData.LoadDesignation(ddlPresDesig);
                    ddlPresDesig.DataBind();
                    LoadComboData.LoadSection(ddlPresSec);
                    ddlPresSec.DataBind();
                    LoadComboData.LoadPayGrade(ddlPresPayGrade);
                    ddlPresPayGrade.DataBind();

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlPrevPayGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Previous Pay Scale
                DataTable dtGetPayScale = Li_PayScaleDetailManager.GetPayScale_ByPayGradeID(int.Parse(ddlPrevPayGrade.SelectedValue)).Tables[0];
                ddlPrevPayScale.DataSource = dtGetPayScale;
                ddlPrevPayScale.DataTextField = "PSAmt";
                ddlPrevPayScale.DataValueField = "PScId";
                ddlPrevPayScale.DataBind();
                ddlPrevPayScale.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ddlPresPayGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Present Pay Scale
                DataTable dtGetPayScale = Li_PayScaleDetailManager.GetPayScale_ByPayGradeID(int.Parse(ddlPresPayGrade.SelectedValue)).Tables[0];
                ddlPresPayScale.DataSource = dtGetPayScale;
                ddlPresPayScale.DataTextField = "PSAmt";
                ddlPresPayScale.DataValueField = "PScId";
                ddlPresPayScale.DataBind();
                ddlPresPayScale.Items.Insert(0, new ListItem("--select--", "0"));
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



                Li_EmpIncrePromoTran empIncProTr = new Li_EmpIncrePromoTran();
                empIncProTr.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empIncProTr.CreatedDate = DateTime.Now;
                empIncProTr.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empIncProTr.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empIncProTr.ModifiedDate = DateTime.Now;
                empIncProTr.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                empIncProTr.EmploymentStId = int.Parse(ddlEmploymentSt.SelectedValue);
                empIncProTr.Comments = txtComments.Text;
                empIncProTr.InPrTrId = 0;

                //Previous
                empIncProTr.PreDepId = int.Parse(ddlPrevDept.SelectedValue);
                empIncProTr.PreDesId = int.Parse(ddlPrevDesig.SelectedValue);
                empIncProTr.PreSecId = int.Parse(ddlPrevSec.SelectedValue);  
                empIncProTr.PrePayGrId = int.Parse(ddlPrevPayGrade.SelectedValue);  
                empIncProTr.PrePScId =  int.Parse(ddlPrevPayScale.SelectedValue);  


                //Present
                empIncProTr.CurDepId = int.Parse(ddlPresDept.SelectedValue);
                empIncProTr.CurDesId = int.Parse(ddlPresDesig.SelectedValue);
                empIncProTr.CurSecId = int.Parse(ddlPresSec.SelectedValue);
                empIncProTr.CurPayGrId = int.Parse(ddlPresPayGrade.SelectedValue);
                empIncProTr.CurPScId = int.Parse(ddlPresPayScale.SelectedValue); 

                Li_EmpIncrePromoTranManager.InsertLi_EmpIncrePromoTran(empIncProTr);


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
            catch (Exception ex)
            {
                
            }
        }
    }
}