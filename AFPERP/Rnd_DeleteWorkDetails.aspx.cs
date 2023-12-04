using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace BLL
{
    public partial class Rnd_DeleteWorkDetails : System.Web.UI.Page
    {
        string FormID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");

                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadSection();
                    string toDay = DateTime.Now.ToString("yyyy-MM-dd");
                    dtpFromDate.Text = toDay;
                    dtpToDate.Text = toDay;
                    gvDateWiseWorkDetails.DataSource = Li_RnDWorkDetailsManager.Get_DateWiseRnDWorkDetails(dtpFromDate.Text, dtpToDate.Text, ddlEmpName.SelectedValue);
                    gvDateWiseWorkDetails.DataBind();

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
                        btnShow.Enabled = true;
                    }
                    else
                    {
                        btnShow.Enabled = false;
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
                        Response.Redirect("~/RandDHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/RandDHome.aspx");
            }
        }
        private void LoadEmployee(int id)
        {

            ddlEmpName.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListBySecID(id);
            ddlEmpName.DataTextField = "Name";
            ddlEmpName.DataValueField = "EmployeeID";
            ddlEmpName.DataBind();
            ddlEmpName.Items.Insert(0, new ListItem("--Select--", ""));

        }
        private void LoadSection()
        {
            ddlSection.DataSource = Li_SectionManager.LoadAllSection();
            ddlSection.DataTextField = "SectionName";
            ddlSection.DataValueField = "SectionID";
            ddlSection.DataBind();
            ddlSection.Items.Insert(0, new ListItem("--Select--", ""));
        }
        protected void ddlSection_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlSection.SelectedIndex >= 0)
                {

                    LoadEmployee(int.Parse(ddlSection.SelectedValue.ToString()));                  
                }
            }
            catch (Exception)
            {


            }
        }
       
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                gvDateWiseWorkDetails.DataSource = Li_RnDWorkDetailsManager.Get_DateWiseRnDWorkDetails(dtpFromDate.Text, dtpToDate.Text, ddlEmpName.SelectedValue);
                gvDateWiseWorkDetails.DataBind();
                for (int i = 0; i < gvDateWiseWorkDetails.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvDateWiseWorkDetails.Rows[i].Cells[0].FindControl("chkWorkSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        ((Button)gvDateWiseWorkDetails.Rows[i].FindControl("btnCancel")).Enabled = true;
                        ((TextBox)gvDateWiseWorkDetails.Rows[i].FindControl("txtRemarks")).Enabled = true;

                    }
                    else
                    {
                        ((Button)gvDateWiseWorkDetails.Rows[i].FindControl("btnCancel")).Enabled = false;
                        ((TextBox)gvDateWiseWorkDetails.Rows[i].FindControl("txtRemarks")).Enabled = false;

                    }

                }



            }
            catch (Exception)
            {

            }
        }

        protected void gvDateWiseWorkDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
        protected void chkWorkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvDateWiseWorkDetails.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvDateWiseWorkDetails.Rows[i].Cells[0].FindControl("chkWorkSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {

                        ((Button)gvDateWiseWorkDetails.Rows[i].FindControl("btnCancel")).Enabled = true;
                        ((TextBox)gvDateWiseWorkDetails.Rows[i].FindControl("txtRemarks")).Enabled = true;

                    }
                    else
                    {
                        ((Button)gvDateWiseWorkDetails.Rows[i].FindControl("btnCancel")).Enabled = false;
                        ((TextBox)gvDateWiseWorkDetails.Rows[i].FindControl("txtRemarks")).Enabled = false;


                    }

                }
            }
            catch (Exception)
            {


            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvDateWiseWorkDetails.Rows.Count; i++)
                {
                    CheckBox chkRow = (gvDateWiseWorkDetails.Rows[i].Cells[0].FindControl("chkWorkSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        Li_RnDWorkDetails WorkDetails = new Li_RnDWorkDetails();
                        WorkDetails.WorkDetailID = int.Parse(gvDateWiseWorkDetails.Rows[i].Cells[1].Text);
                        string Remarks = (((TextBox)gvDateWiseWorkDetails.Rows[i].FindControl("txtRemarks")).Text);
                        WorkDetails.Comments = Remarks;
                        WorkDetails.CreatedBy = int.Parse(Session["UserID"].ToString());
                        WorkDetails.CreatedDate = DateTime.Now;
                        Li_RnDWorkDetailsManager.Delete_Li_RnDWorkDetails(WorkDetails);
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Delete Successfully');", true);
                        gvDateWiseWorkDetails.DataSource = Li_RnDWorkDetailsManager.Get_DateWiseRnDWorkDetails(dtpFromDate.Text, dtpToDate.Text, ddlEmpName.SelectedValue);
                        gvDateWiseWorkDetails.DataBind();
                    }

                }

            }
            catch (Exception)
            {

            }
        }
    }

}