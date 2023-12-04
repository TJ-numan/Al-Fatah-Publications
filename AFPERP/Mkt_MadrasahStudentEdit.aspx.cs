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
    public partial class Mkt_MadrasahStudentEdit : System.Web.UI.Page
    {
        string FormID = "MF032";
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");

                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadComboData.LoadDonYear(ddlAgreementYear);
                    gvwNoOfStudent.DataSource = null;
                    gvwNoOfStudent.DataBind();

                    ddlAgreementYear.SelectedValue = "2018-2019";
                }
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
                        btnUpdate.Enabled = true;
                    }
                    else
                    {
                        btnUpdate.Enabled = false;
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

        protected void txtAgrNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Li_MadrasahInfoManager.GetLi_MadrasahInfoBy_AgrNo(txtAgrNo.Text.Trim(), ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2)).Tables[0];
                ddlMadrashaName.DataSource = dt;
                ddlMadrashaName.DataValueField = "MadId";
                ddlMadrashaName.DataTextField = "MadName";
                ddlMadrashaName.DataBind();
                ddlMadrashaName.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception)
            {
                
            }

        }

        protected void ddlMadrashaName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtStudent = Li_StudentR2Manager.GetLi_StudentR2By_MadId(ddlMadrashaName.SelectedValue).Tables[0];
                gvwNoOfStudent.DataSource = dtStudent;
                gvwNoOfStudent.DataBind();
            }
            catch (Exception)
            {
                
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Li_StudentR2 li_StudentR2 = new Li_StudentR2();
                

                    for (int i = 0; i < gvwNoOfStudent.Rows.Count; i++)
                    {
                        li_StudentR2.MadId = ddlMadrashaName.SelectedValue;
                        li_StudentR2.ClassID = int.Parse(gvwNoOfStudent.Rows[i].Cells[0].Text);
                        li_StudentR2.NoOfStudents = int.Parse(((TextBox)gvwNoOfStudent.Rows[i].FindControl("txtNoOfStudent")).Text);
                        Li_StudentR2Manager.UpdateLi_StudentR2(li_StudentR2);
                    }
                
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);
            }
            catch (Exception)
            {
                
            }
        }

    }
}