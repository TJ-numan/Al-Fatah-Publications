using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms.VisualStyles;
using BLL;
using Microsoft.Ajax.Utilities;

namespace BLL
{
    public partial class RndEntryWorksQawmi : System.Web.UI.Page
    {
        string FormID = "RF012";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();

            if (!IsPostBack)
            {
                lblHireSection.Visible = false;
                ddlHireSection.Visible = false;
                txtDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                AddDefaultFirstRecord();
                LoadSection();
                LoadTask();
                txtStartTime.Text = DateTime.Now.ToString("hh:mm tt");
                txtEndTime.Text = DateTime.Now.ToString("hh:mm tt");
                txtStartTime.Text = "09:00 AM";
                txtEndTime.Text = "06:00 PM";


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
                        Response.Redirect("~/RandDHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void LoadHireSection()
        {
            ddlHireSection.DataSource = Li_SectionManager.LoadAllSection();
            ddlHireSection.DataTextField = "SectionName";
            ddlHireSection.DataValueField = "SectionID";
            ddlHireSection.DataBind();
            ddlHireSection.Items.Insert(0, new ListItem("--Select--", ""));
        }
        private void LoadSection()
        {
            ddlSection.DataSource = Li_SectionManager.LoadAllSectionQawmi();
            ddlSection.DataTextField = "SectionName";
            ddlSection.DataValueField = "SectionID";
            ddlSection.DataBind();
            ddlSection.Items.Insert(0, new ListItem("--Select--", ""));
        }
        private void LoadDesignation(int EmpID)
        {
            ddlDesignation.DataSource = Li_DesignationManager.GetLi_DesignationQawmiByEmpID(EmpID);
            ddlDesignation.DataTextField = "Designation";
            ddlDesignation.DataValueField = "DesignationID";
            ddlDesignation.DataBind();
        }
        private void LoadTask()
        {
            ddlTask.DataSource = Li_TaskManager.GetAllLi_TasksQawmi();
            ddlTask.DataTextField = "TaskName";
            ddlTask.DataValueField = "TaskID";
            ddlTask.DataBind();
            ddlTask.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        private void AddDefaultFirstRecord()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            bool fromLinkButton = false;
            dt.TableName = "tblEntryWorks";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("EmployeeID", typeof(string));
            dt.Columns.Add("Employee", typeof(string));
            dt.Columns.Add("SectionID", typeof(Int32));
            dt.Columns.Add("SectionName", typeof(string));
            dt.Columns.Add("WorkStart", typeof(string));
            dt.Columns.Add("WorkEnd", typeof(string));
            dt.Columns.Add("Time", typeof(decimal));
            dt.Columns.Add("BookID", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("WorkType", typeof(string));
            dt.Columns.Add("WorkTypeID", typeof(int));
            dt.Columns.Add("StartPage", typeof(string));
            dt.Columns.Add("EndPage", typeof(string));
            dt.Columns.Add("TotalPage", typeof(string));
            dt.Columns.Add("Comments", typeof(string));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["tblEntryWorks"] = dt;
            gvDailyWorks.DataSource = dt;
            gvDailyWorks.DataBind();
            ViewState["LinkClick"] = fromLinkButton;
        }
        protected void lblDelete_OnClick(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblEntryWorks"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();
                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                }
            }
            catch (Exception)
            {


            }
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
            ddlSubject.DataSource = li_BookInformationManager.Get_BookInformations_Combo_BySectionQawmi(secID);
            ddlSubject.DataTextField = "BookName";
            ddlSubject.DataValueField = "BookID";
            ddlSubject.DataBind();
        }
        private void LoadEmployee(int id)
        {

            ddlEmpName.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListBySecIDQawmi(id);
            ddlEmpName.DataTextField = "Name";
            ddlEmpName.DataValueField = "EmployeeID";
            ddlEmpName.DataBind();
            ddlEmpName.Items.Insert(0, new ListItem("--Select--", ""));

        }

        protected void ddlHireSection_TextChanged(object sender, EventArgs e)
        {
            try
            {

                int SecID = Int32.Parse(ddlHireSection.SelectedValue.ToString());
                LoadEmployee(SecID);
            }
            catch (Exception)
            {


            }
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            string com = txtComments.Text;
            if (ddlTask.SelectedIndex == 55 && com == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please Fill up the Comments box!');", true);
                return;

            }
            else
            {
                try
                {
                    AddNewRecordRowToGrid();
                }

                catch (Exception oo)
                {
                }
            }
        }
        private void AddNewRecordRowToGrid()
        {
            // check view state is not null
            //AddNewRecordRowToGrid();
            if (ViewState["tblEntryWorks"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblEntryWorks"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                }
                else
                {
                    if ((bool)ViewState["LinkClick"] == true)
                    {


                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            dtCurrentTable.Rows[i][0] = i + 1;
                            dtCurrentTable.AcceptChanges();
                        }

                        ViewState["LinkClick"] = false;
                    }
                    else
                    {

                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {

                            //add each row into data table  
                            drCurrentRow = dtCurrentTable.NewRow();
                            drCurrentRow["Serial"] = dtCurrentTable.Rows.Count + 1;

                        }
                        string StarTtime = ddlHour.SelectedValue.ToString() + ':' + ddlMin.SelectedValue.ToString() + ' ' + ddlExtend.SelectedValue.ToString();
                        string EndTime = ddlHour2.SelectedValue.ToString() + ':' + ddlMin2.SelectedValue.ToString() + ' ' + ddlExtend2.SelectedValue.ToString();
                        drCurrentRow["WorkStart"] = StarTtime;//txtStartTime.Text;
                        drCurrentRow["WorkEnd"] = EndTime;//txtEndTime.Text;
                        string startTime = drCurrentRow["WorkStart"].ToString();
                        string endTime = drCurrentRow["WorkEnd"].ToString();
                        TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                        double time = duration.TotalHours;
                        if (time < 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Wrong Time Selection');", true);
                            return;
                        }
                        if (ddlExtend.SelectedValue.ToString() == "AM" && ddlExtend2.SelectedValue.ToString() == "PM" && ddlHour2.SelectedValue.ToString() != "01" && ddlHour2.SelectedValue.ToString() != "12")
                        {
                            drCurrentRow["Time"] = (duration.TotalHours - 1);
                        }
                        else if (ddlExtend.SelectedValue.ToString() == "PM" && ddlExtend2.SelectedValue.ToString() == "PM" && (ddlHour.SelectedValue.ToString() == "01" || ddlHour.SelectedValue.ToString() == "12") && (ddlHour2.SelectedValue.ToString() != "01"))
                        {
                            drCurrentRow["Time"] = (duration.TotalHours - 1);
                        }
                        else
                        {
                            drCurrentRow["Time"] = duration.TotalHours;
                        }
                        drCurrentRow["EmployeeID"] = ddlEmpName.SelectedValue;
                        drCurrentRow["Employee"] = ddlEmpName.SelectedItem;
                        drCurrentRow["SectionID"] = ddlSection.SelectedValue;
                        drCurrentRow["SectionName"] = ddlSection.SelectedItem;
                        drCurrentRow["BookID"] = ddlSubject.SelectedValue;
                        drCurrentRow["Subject"] = ddlSubject.SelectedItem;
                        drCurrentRow["WorkTypeID"] = ddlTask.SelectedValue;
                        drCurrentRow["WorkType"] = ddlTask.SelectedItem.Text;
                        drCurrentRow["StartPage"] = txtStartPage.Text;
                        drCurrentRow["EndPage"] = txtEndPage.Text;
                        decimal toPage = txtEndPage.Text != "" ? decimal.Parse(txtEndPage.Text) : 0.0m;
                        decimal fromPage = txtStartPage.Text != "" ? decimal.Parse(txtStartPage.Text) : 0.0m;
                        if (fromPage > toPage)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('From Page is greater than To Page');", true);
                            return;
                        }
                        drCurrentRow["TotalPage"] = (decimal.Parse(txtEndPage.Text) - decimal.Parse(txtStartPage.Text)) + 1;
                        drCurrentRow["Comments"] = txtComments.Text;
                        //Remove initial blank row  
                        if (dtCurrentTable.Rows[0][0].ToString() == "")
                        {
                            drCurrentRow["Serial"] = dtCurrentTable.Rows.Count;
                            dtCurrentTable.Rows[0].Delete();
                            dtCurrentTable.AcceptChanges();

                        }

                        //add created Rows into dataTable  
                        dtCurrentTable.Rows.Add(drCurrentRow);
                    }

                }

                //Save Data table into view state after creating each row  

                ViewState["tblEntryWorks"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvDailyWorks.DataSource = dtCurrentTable;
                gvDailyWorks.DataBind();
                //-------------------Selected refresh----------------
                ddlHour.SelectedValue = "09";
                ddlHour2.SelectedValue = "06";
                ddlMin.SelectedValue = "00";
                ddlMin2.SelectedValue = "00";
                ddlExtend.SelectedValue = "AM";
                ddlExtend2.SelectedValue = "PM";
                txtComments.Text = "";
            }
            else
            {
                AddDefaultFirstRecord();
            }

        }

        protected void ddlEmpName_OnTextChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlEmpName.SelectedIndex >= 0)
                {
                    LoadDesignation(int.Parse(ddlEmpName.SelectedValue.ToString()));
                }
            }
            catch (Exception)
            {


            }

        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["tblEntryWorks"];

            try
            {
                DateTime Wdate = DateTime.Parse(txtDate.Text);
                if (Wdate > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Work date too advanced!');", true);
                    return;
                }
                else
                {
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            Li_RnDWorkDetails workDetails = new Li_RnDWorkDetails();
                            workDetails.EmployeeID = Int32.Parse(dtCurrentTable.Rows[i]["EmployeeID"].ToString());
                            workDetails.WorkDate = DateTime.Parse(txtDate.Text);
                            workDetails.WorkStartTime = dtCurrentTable.Rows[i]["WorkStart"].ToString();
                            workDetails.WorkEndTime = dtCurrentTable.Rows[i]["WorkEnd"].ToString();
                            workDetails.WorkTimeSpan = decimal.Parse(dtCurrentTable.Rows[i]["Time"].ToString());
                            workDetails.BookID = dtCurrentTable.Rows[i]["BookID"].ToString();
                            workDetails.WorkTypeID = int.Parse(dtCurrentTable.Rows[i]["WorkTypeID"].ToString());
                            workDetails.PageStart = Int32.Parse(dtCurrentTable.Rows[i]["StartPage"].ToString());
                            workDetails.PageEnd = Int32.Parse(dtCurrentTable.Rows[i]["EndPage"].ToString());
                            workDetails.Comments = dtCurrentTable.Rows[i]["Comments"].ToString();
                            workDetails.CreatedBy = Convert.ToInt32(Session["UserID"]);
                            workDetails.CreatedDate = DateTime.Now;
                            workDetails.IsHired = checkboxHireSection.Checked ? true : false;
                            workDetails.SectionID = checkboxHireSection.Checked ? 0 : Int32.Parse(dtCurrentTable.Rows[i]["SectionID"].ToString());
                            Li_RnDWorkDetailsManager.InsertLi_RnDWorkDetailsQawmi(workDetails);
                            txtDate.Focus();
                        }
                        string message = "Saved successfully.";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "');";
                        script += "window.location = '";
                        script += Request.Url.AbsoluteUri;
                        script += "'; }";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                            script, true);
                        gvDailyWorks.DataSource = null;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void checkboxHireSection_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxHireSection.Checked)
            {
                lblHireSection.Visible = true;
                ddlHireSection.Visible = true;
                LoadHireSection();
            }
            else
            {
                lblHireSection.Visible = false;
                ddlHireSection.Visible = false;
            }
        }
        protected void ddlSubject_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlSubject.SelectedValue.ToString() == "SPCL")
                {
                    ddlTask.SelectedIndex = 55;
                    ddlTask.Enabled = false;

                }
                else
                {
                    ddlTask.SelectedIndex = 0;
                    ddlTask.Enabled = true;

                }
            }
            catch (Exception)
            {


            }

        }
    }
}