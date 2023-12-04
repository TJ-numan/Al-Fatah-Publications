using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace BLL
{
    public partial class Rnd_UpdateWorkDetails : System.Web.UI.Page
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
                    txtDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    LoadTask();
                    txtStartTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
                    txtEndTime.Text = DateTime.Now.ToString("hh:mm:ss tt");  
                    
                           

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
                    LoadBookBySection(int.Parse(ddlSection.SelectedValue.ToString()));
                }
            }
            catch (Exception)
            {


            }
        }
        private void LoadBookBySection(int secID)
        {
            ddlSubject.DataSource = li_BookInformationManager.Get_BookInformations_Combo_BySectionForUpdate(secID);
            ddlSubject.DataTextField = "BookName";
            ddlSubject.DataValueField = "BookID";
            ddlSubject.DataBind();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                gvDateWiseWorkDetails.DataSource = Li_RnDWorkDetailsManager.Get_DateWiseRnDWorkDetails(dtpFromDate.Text, dtpToDate.Text, ddlEmpName.SelectedValue);
                gvDateWiseWorkDetails.DataBind();



            }
            catch (Exception)
            {

            }
        }

        protected void gvDateWiseWorkDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void gvDateWiseWorkDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePanel.Visible = true;
            try
            {
                //GridViewRow row = gvDateWiseWorkDetails.SelectedRow;
                //string WorkDetailID = row.Cells[0].Text;
                //ViewState["WorkDetailID"] = row.Cells[1].Text;
                try
                {
                    GridViewRow row = gvDateWiseWorkDetails.SelectedRow;
                    ViewState["WorkDetailID"] = row.Cells[1].Text;
                    txtComments.Text = "";
                    ddlTask.Enabled = true;
                    DataTable dtLibrary = Li_RnDWorkDetailsManager.GetLi_RnDWorkDetailsByWorkID(Int32.Parse(ViewState["WorkDetailID"].ToString())).Tables[0];
                    txtDetailsID.Text = dtLibrary.Rows[0]["WorkDetailID"].ToString();
                    DateTime Wdate = DateTime.Parse(dtLibrary.Rows[0]["WorkDate"].ToString());
                    txtDate.Text = string.Format("{0:yyyy-MM-dd}", Wdate);
                    txtStartTime.Text = dtLibrary.Rows[0]["WorkStartTime"].ToString();
                    txtEndTime.Text = dtLibrary.Rows[0]["WorkEndTime"].ToString();
                    ddlSubject.SelectedValue = dtLibrary.Rows[0]["BookID"].ToString();
                    ddlTask.SelectedValue = dtLibrary.Rows[0]["WorkTypeID"].ToString();
                    txtStartPage.Text = dtLibrary.Rows[0]["PageStart"].ToString();
                    txtEndPage.Text = dtLibrary.Rows[0]["PageEnd"].ToString();
                    txtComments.Text = dtLibrary.Rows[0]["Comments"].ToString();
                    try
                    {

                        if (ddlSubject.SelectedValue.ToString() == "SPCL")
                        {
                            ddlTask.SelectedIndex = 81;
                            ddlTask.Enabled = false;

                        }
                        else if (ddlSubject.SelectedValue.ToString() == "RDWE")
                        {
                            ddlTask.SelectedIndex = 77;
                            ddlTask.Enabled = false;

                        }
                        else
                        {
                            //ddlTask.SelectedIndex = 0;
                            ddlTask.Enabled = true;

                        }
                    }
                    catch (Exception)
                    {


                    }
                }
                catch (Exception)
                {

                }
            }
            catch (Exception)
            {


            }

        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            try
            {
                string com = txtComments.Text;
                if (ddlTask.SelectedIndex != 81 && ddlSubject.SelectedValue.ToString() == "SPCL" && com=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Must Select Special Task and Comments!');", true);
                    return;

                }
                else
                {
                    Li_RnDWorkDetails workDetails = new Li_RnDWorkDetails();
                    workDetails.WorkDetailID = Int32.Parse(txtDetailsID.Text.ToString());
                    workDetails.WorkDate = DateTime.Parse(txtDate.Text);
                    workDetails.EmployeeID = Int32.Parse(ddlEmpName.SelectedValue.ToString());
                    workDetails.WorkTypeID = Int32.Parse(ddlTask.SelectedValue.ToString());
                    workDetails.BookID = ddlSubject.SelectedValue.ToString();
                    workDetails.WorkStartTime = txtStartTime.Text.ToString();
                    workDetails.WorkEndTime = txtEndTime.Text.ToString();
                    TimeSpan duration = DateTime.Parse(workDetails.WorkEndTime).Subtract(DateTime.Parse(workDetails.WorkStartTime));
                    workDetails.WorkTimeSpan = Convert.ToDecimal(duration.TotalHours);
                    workDetails.PageStart = Int32.Parse(txtStartPage.Text.ToString());
                    workDetails.PageEnd = Int32.Parse(txtEndPage.Text.ToString());
                    workDetails.Comments = txtComments.Text.ToString();
                    Li_RnDWorkDetailsManager.UpdateLi_RnDWorkDetails(workDetails);


                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Update Successfully');", true);
                    UpdatePanel.Visible = false;
                    gvDateWiseWorkDetails.DataSource = Li_RnDWorkDetailsManager.Get_DateWiseRnDWorkDetails(dtpFromDate.Text, dtpToDate.Text, ddlEmpName.SelectedValue);
                    gvDateWiseWorkDetails.DataBind();
                }
            }
            catch (Exception)
            {
               
            }
        }
        private void LoadTask()
        {
            ddlTask.DataSource = Li_TaskManager.GetAllLi_Tasks();
            ddlTask.DataTextField = "TaskName";
            ddlTask.DataValueField = "TaskID";
            ddlTask.DataBind();
            ddlTask.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        protected void ddlSubject_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlSubject.SelectedValue.ToString() == "SPCL")
                {
                    ddlTask.SelectedIndex = 81;
                    ddlTask.Enabled = false;

                }
                else if (ddlSubject.SelectedValue.ToString() == "RDWE")
                {
                    ddlTask.SelectedIndex = 77;
                    ddlTask.Enabled = false;

                }
                else
                {
                    //ddlTask.SelectedIndex = 0;
                    ddlTask.Enabled = true;

                }
            }
            catch (Exception)
            {


            }

        }
    }

}