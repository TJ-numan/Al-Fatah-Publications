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
    public partial class Mkt_TeacherInfo : System.Web.UI.Page
    {
        string FormID = "MF039";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");

            if (!IsPostBack)
            {
                getUserAccess();
                GetAllDepositType();
                GetAllAcountType();

                LoadComboData.LoadTeritoryR2(ddlTerritory);
                 
            }
            txtPaperSl.Focus();
        }

        private void getUserAccess()
        {
            DataTable dt = Li_AdminUserManager.GetUserAccess(int.Parse(Session["UserID"].ToString()), FormID).Tables[0];
            if (dt.Rows.Count > 0)
            {

                if (Session["UserID"].ToString() == dt.Rows[0]["UserID"].ToString() && FormID == dt.Rows[0]["FormId"].ToString())
                {
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Update_"].ToString()) == true)
                    {
                        //btnUpdate.Enabled = true;
                    }
                    else
                    {
                        //btnUpdate.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Delete_"].ToString()) == true)
                    {
                        //btnDelete.Enabled = true;
                    }
                    else
                    {
                        //btnDelete.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void GetAllAcountType()
        {
            try
            {
                ddlAccountType.DataSource = Li_DonPayTypeManager.GetAllLi_DonAcountTypes();
                ddlAccountType.DataTextField = "AcTypeName";
                ddlAccountType.DataValueField = "AcTypeId";
                ddlAccountType.DataBind();
                ddlAccountType.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }
        private void GetAllDepositType()
        {
            try
            {
                ddlDepositType.DataSource = Li_DonPayTypeManager.GetAllLi_DonPayTypes();
                ddlDepositType.DataTextField = "PayTypName";
                ddlDepositType.DataValueField = "PayTypId";
                ddlDepositType.DataBind();
                ddlDepositType.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtSubject.Text.Trim() == "" && txtClassName.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Subject or Class Name missing');", true);
                    txtSubject.Focus();
                    return;
                }
                if(txtTeacherName.Text.Trim()=="" && txtMadrasahName.Text.Trim()=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Teacher Name or Madrasah Name missing');", true);
                    txtTeacherName.Focus();
                    return;
                }
                if(txtMobileNo.Text=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Mobile No missing');", true);
                    txtMobileNo.Focus();
                    return;
                }

                if(txtMobileNo.Text.Length!=11)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Mobile No must 11 digit');", true);
                    txtMobileNo.Focus();
                    return;
                }

                Li_TeacherInfo li_teacherInfo = new Li_TeacherInfo();
                li_teacherInfo.PaperSl = txtPaperSl.Text;
                li_teacherInfo.VerifyDate = DateTime.Parse(txtVerifyDate.Text);
                li_teacherInfo.Territory = ddlTerritory.SelectedValue;
                li_teacherInfo.TeachderName = txtTeacherName.Text;
                li_teacherInfo.DesignationId = Int32.Parse(ddlDesignation.SelectedValue);
                li_teacherInfo.SubjectName = txtSubject.Text;
                li_teacherInfo.ClassName = txtClassName.Text;
                li_teacherInfo.MadrasahName = txtMadrasahName.Text;
                li_teacherInfo.MadrasahAdd = txtMadrasahAddress.Text;
                li_teacherInfo.MobileNo = txtMobileNo.Text;
                li_teacherInfo.AccTitle = txtAccountTitle.Text;
                li_teacherInfo.AccNo = txtAccountNo.Text;
                li_teacherInfo.AccType = ddlAccountType.SelectedValue;
                li_teacherInfo.DepositType = ddlDepositType.SelectedValue;
                li_teacherInfo.BankName = txtBankName.Text;
                li_teacherInfo.BankAddress = txtBankAddress.Text;
                li_teacherInfo.CreatedBy = int.Parse(Session["UserID"].ToString());
                li_teacherInfo.CreatedDate = DateTime.Now;

                Li_TeacherInfoManager.InsertLi_TeacherInfo(li_teacherInfo);

                string message = "Saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
            }
            catch (Exception ex)
            {
                
                
            }

        }
    }
}