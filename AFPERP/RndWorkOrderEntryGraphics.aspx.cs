using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using System.Data;

namespace BLL
{
    public partial class RndWorkOrderEntryGraphics : System.Web.UI.Page
    {
        string FormID = "RF004";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    //LoadCategory();
                    LoadTask();
                    LoadClassByUserID();
                    dtpWorkDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    AddDefaultFirstRecord();

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
        private void LoadClassByUserID()
        {
            ddlClass.DataSource = Li_ClassesManager.GetLi_ClassesByUserIDGraphics(int.Parse(Session["UserID"].ToString()));
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("--select--", "0"));
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlBookName.DataSource = li_BookInformationManager.Get_BookInformations_Combo_BySectionbyUserAndClassIDGraphics(int.Parse(Session["UserID"].ToString()), int.Parse(ddlClass.SelectedValue.ToString()));
                ddlBookName.DataTextField = "BookName";
                ddlBookName.DataValueField = "BookID";
                ddlBookName.DataBind();

            }
            catch (Exception)
            {
            }


        }

        protected void ddlBookName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Classes.LoadCategory.LoadEditionByBookID(ddlEdition, ddlBookName);
                //ddlEdition.DataBind();

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

                    LoadEmployee(int.Parse(ddlSection.SelectedValue.ToString()), int.Parse(ddlEmplyeeFor.SelectedValue.ToString()));
                }
            }
            catch (Exception)
            {


            }
        }
        private void LoadTask()
        {
            ddlTask.DataSource = Li_TaskManager.GetAllLi_TasksGraphics();
            ddlTask.DataTextField = "TaskName";
            ddlTask.DataValueField = "TaskID";
            ddlTask.DataBind();
            ddlTask.Items.Insert(0, new ListItem("-Select-", "0"));
        }
       
        private void LoadEmployee(int id, int employeer)
        {

            ddlEmpName.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListRZBySecID(id, employeer);
            ddlEmpName.DataTextField = "Name";
            ddlEmpName.DataValueField = "EmployeeID";
            ddlEmpName.DataBind();
            ddlEmpName.Items.Insert(0, new ListItem("--Select--", ""));

        }
        protected void ddlEmpName_OnTextChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlEmpName.SelectedIndex >= 0)
                {
                    //LoadDesignation(int.Parse(ddlEmpName.SelectedValue.ToString()));
                }
            }
            catch (Exception)
            {


            }

        }
        protected void ddlEmployeeFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmplyeeFor.SelectedValue.ToString() == "1")
            {
                //ddlSection.DataSource = Li_SectionManager.LoadAllSection();
                ddlSection.DataSource = Li_SectionManager.LoadSectionByUser(int.Parse(Session["UserID"].ToString()));
                ddlSection.DataTextField = "SectionName";
                ddlSection.DataValueField = "SectionID";
                ddlSection.DataBind();
                ddlSection.Items.Insert(0, new ListItem("--Select--", ""));
            }
            else if (ddlEmplyeeFor.SelectedValue.ToString() == "2")
            {
                ddlSection.DataSource = Li_SectionManager.LoadHireSection();
                ddlSection.DataTextField = "SectionName";
                ddlSection.DataValueField = "SectionID";
                ddlSection.DataBind();
                ddlSection.Items.Insert(0, new ListItem("--Select--", ""));
            }
        }
        private void AddDefaultFirstRecord()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            bool fromLinkButton = false;
            dt.TableName = "tblEntryWorks";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BookID", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("ClassID", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("WorkType", typeof(string));
            dt.Columns.Add("WorkTypeID", typeof(int));
            dt.Columns.Add("FileNo", typeof(string));
            dt.Columns.Add("WorkDate", typeof(string));
            dt.Columns.Add("Unit", typeof(string));
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
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            try
            {
                AddNewRecordRowToGrid();
            }

            catch (Exception oo)
            {
            }
        }
        private void AddNewRecordRowToGrid()
        {
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
                        drCurrentRow["BookID"] = ddlBookName.SelectedValue;
                        drCurrentRow["Subject"] = ddlBookName.SelectedItem;
                        drCurrentRow["ClassID"] = ddlClass.SelectedValue;
                        drCurrentRow["Class"] = ddlClass.SelectedItem;
                        drCurrentRow["Edition"] = txtEdition.Text;
                        drCurrentRow["WorkTypeID"] = ddlTask.SelectedValue;
                        drCurrentRow["WorkType"] = ddlTask.SelectedItem.Text;
                        drCurrentRow["WorkDate"] = dtpWorkDate.Text;
                        drCurrentRow["Unit"] = txtUnit.Text != "" ? decimal.Parse(txtUnit.Text) : 0.0m;
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
                //Save Data table into view state after creating each row  
                decimal subTotalCharacter = 0;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        decimal unitTotalCharacter = decimal.Parse(dtCurrentTable.Rows[i]["Unit"].ToString());
                        subTotalCharacter += unitTotalCharacter;

                    }
                }
                TxtTotUnit.Text = subTotalCharacter.ToString();
            }
            else
            {
                AddDefaultFirstRecord();
            }

        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["tblEntryWorks"];

            try
            {
                if (dtCurrentTable.Rows.Count > 0)
                {

                    Li_RnDWorkOrderDetails _workOrder = new Li_RnDWorkOrderDetails();
                    _workOrder.SectionID = Int32.Parse(ddlSection.SelectedValue.ToString());
                    _workOrder.IsHired = Int32.Parse(ddlEmplyeeFor.SelectedValue.ToString());
                    _workOrder.EmployeeID = ddlEmpName.SelectedValue.ToString();
                    _workOrder.WorkDate = DateTime.Parse(dtpWorkorderDate.Text);
                    _workOrder.TotalCharacter = decimal.Parse(TxtTotUnit.Text.ToString());
                    _workOrder.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    _workOrder.CreatedDate = DateTime.Now;
                    string returnworkOrderID = Li_RnDWorkOrderDetailsManager.InsertLi_RnDWorkOrderGraphics(_workOrder);
                    txtWorkID.Text = returnworkOrderID;
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        Li_RnDWorkOrderDetails workOrderDetails = new Li_RnDWorkOrderDetails();
                        workOrderDetails.WorkOrderID = Int32.Parse(returnworkOrderID);
                        workOrderDetails.SectionID = Int32.Parse(ddlSection.SelectedValue.ToString());
                        workOrderDetails.IsHired = Int32.Parse(ddlEmplyeeFor.SelectedValue.ToString());
                        workOrderDetails.EmployeeID = ddlEmpName.SelectedValue.ToString();
                        workOrderDetails.WorkDate = DateTime.Parse(dtCurrentTable.Rows[i]["WorkDate"].ToString());
                        workOrderDetails.BookID = dtCurrentTable.Rows[i]["BookID"].ToString();
                        workOrderDetails.Edition = dtCurrentTable.Rows[i]["Edition"].ToString();
                        workOrderDetails.ClassID = int.Parse(dtCurrentTable.Rows[i]["ClassID"].ToString());
                        workOrderDetails.WorkTypeID = int.Parse(dtCurrentTable.Rows[i]["WorkTypeID"].ToString());                      
                        workOrderDetails.TotalCharacter = decimal.Parse(dtCurrentTable.Rows[i]["Unit"].ToString());
                        workOrderDetails.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        workOrderDetails.CreatedDate = DateTime.Now;
                        Li_RnDWorkOrderDetailsManager.InsertLi_RnDWorkOrderDetailsGraphics(workOrderDetails);
                        dtpWorkDate.Focus();
                    }
                    txtWorkID.Text = returnworkOrderID;
                    string message = "Saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                        script, true);
                    //ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                    gvDailyWorks.DataSource = null;
                    txtWorkID.Text = returnworkOrderID;
                }
            }
            catch (Exception)
            {

            }
        }
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            rd.Load(Server.MapPath(@"~/Reports/RND/rptPrintRnDWorkOrderGraphics.rpt"));
            //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
            rd.DataSourceConnections.Clear();
            rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            rd.SetParameterValue("@WorkOrderID", txtWorkID.Text);
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "PrintRnDWorkOrder");
            rd.Close();
            rd.Dispose();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            try
            {
                rd.Dispose();
            }
            catch (Exception)
            {


            }
        }
    }
}