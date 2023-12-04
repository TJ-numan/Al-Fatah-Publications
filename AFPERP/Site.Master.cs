using Common;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null && Session["UserName"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }
            else
            {
                lblUserName.Text = Session["UserName"].ToString();
            }
           
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            UserAccessLog();
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        private void UserAccessLog()
        {
            li_UserAccessLog li_UserAccessLog = new li_UserAccessLog();
            li_UserAccessLog.SlNo = int.Parse(Session["SlNo"].ToString());
            //li_UserAccessLog.UserId = int.Parse(Session["UserID"].ToString());
            //li_UserAccessLog.IPAdd = Session["myIp"].ToString();
            //li_UserAccessLog.PhyAdd = Session["PhyAdd"].ToString();
            //li_UserAccessLog.login_time = DateTime.Parse(Session["LoginTime"].ToString());
            li_UserAccessLog.logout_time = DateTime.Now;

            Li_AdminUserManager.UpdateLi_UserAccessLog(li_UserAccessLog);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Name= txtUserName.Text;
            string OldPassword= txtOldPassword.Text;
            string NewPassword= txtNewPassword.Text;

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Password and Confirm Password Unmatched !');", true);
                return;
            }
            int User_ID = int.Parse(Session["UserID"].ToString());
            string ExistID = Li_AdminUserManager.UpdateLi_ChangePassword(User_ID, Name, OldPassword, NewPassword);
            if (ExistID != User_ID.ToString ())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('User Name or Password is wrong !');", true);
                return;
            }
            else
            {
               

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Password Update Successfully');", true);
                txtOldPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
                Session.Clear();
                
            }
        }

    }

}