using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class RandDHome : System.Web.UI.Page
    {
        string FormID = "RF001";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();
        }
        private void getUserAccess()
        {
            DataTable dt = Li_AdminUserManager.GetUserAccess(int.Parse(Session["UserID"].ToString()), FormID).Tables[0];
            if (dt.Rows.Count > 0)
            {

                if (Session["UserID"].ToString() == dt.Rows[0]["UserID"].ToString() && FormID == dt.Rows[0]["FormId"].ToString())
                {
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }

            }
            else
            {

            string TaskAmount = TaskDetailManager.SearchEmployeeInTaskforStartingDate(Session["UserID"].ToString());


            if (TaskAmount != "0")
            { 
             string message = "You have "+ TaskAmount + " Incompleated task for a new book";
             string script = "window.onload = function(){ alert('";
             script += message;
             script += "'); };";
             ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

             //string message = "Task Update Successfully";
             //string script = "window.onload = function(){ alert('";
             //script += message;
             //script += "'); };";
             //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
            }
            }
        }
    }
}