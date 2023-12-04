using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_LaminationSizeBasic : System.Web.UI.Page
    {
        string FormID = "PF013";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                gvLaminationSize.DataSource = Li_LemiSizeBasicManager.GetAllLi_LemiSizeBasics();
                gvLaminationSize.DataBind();
            }
            catch (Exception)
            {
                
                
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
                        btnPaperSave.Enabled = true;
                    }
                    else
                    {
                        btnPaperSave.Enabled = false;
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
                        Response.Redirect("~/ProHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        protected void btnPaperUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnPaperSave_Click(object sender, EventArgs e)
        {
            try
            {
                Li_LemiSizeBasic lamiSize = new Li_LemiSizeBasic();
                lamiSize.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                lamiSize.CreatedDate = DateTime.Now;
                lamiSize.LemiSize = txtSizeLeft.Text + lblCross.Text + txtSizeRight.Text;
                lamiSize.LemiSizeID = "";
                txtSizeId.Text = Li_LemiSizeBasicManager.InsertLi_LemiSizeBasic(lamiSize);

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