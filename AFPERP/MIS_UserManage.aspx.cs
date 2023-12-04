using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.MIS;
using Common.MIS;
using System.Data;

namespace BLL
{
    public partial class MIS_UserManage : System.Web.UI.Page
    {
        string FormID = "MISF004";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();
            if (!IsPostBack)
            {
                BindUser();
                BindForm();
            }

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
                        Response.Redirect("~/MISHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void BindForm()
        {
            ddlForm.DataSource = Li_FormListManager.GetAllForm();
            ddlForm.DataTextField = "FormName";
            ddlForm.DataValueField = "FormId";
            ddlForm.DataBind();
            ddlForm.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        private void BindUser()
        {
            ddlUser.DataSource = Li_UserAccessManager.GetAllUser();
            ddlUser.DataTextField = "UserName";
            ddlUser.DataValueField = "UserID";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            li_UserAccess access = new li_UserAccess();
            access.UserId = Convert.ToInt32(ddlUser.SelectedValue);
            access.FormId = ddlForm.SelectedValue;
            access.View = chkView.Checked ? true : false;
            access.Insert = chkInsert.Checked ? true : false;
            access.Update = chkUpdate.Checked ? true : false;
            access.Delete = chkDelete.Checked ? true : false;
            bool success = Convert.ToBoolean(Li_UserAccessManager.InsertUserAccess(access));
            if (success)
            {
                string message = "Saved Successfully!";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script,
                    true);

            }
           
        }
    }
}