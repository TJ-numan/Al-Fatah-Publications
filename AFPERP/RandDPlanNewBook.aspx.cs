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
    public partial class RandDPlanNewBook : System.Web.UI.Page
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
                    LoadCategory();
                    LoadTask();
                    dtpFromDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    dtpToDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    AddDefaultFirstRecord();
                    LoadBookSize();


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
        private void LoadCategory()
        {
            ddlCategory.DataSource = Li_CategoryManager.GetAllCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlGroup.DataSource = Li_Book_GManager.GetLi_Book_GByID(ddlCategory.SelectedValue.ToString());
                ddlGroup.DataTextField = "GName";
                ddlGroup.DataValueField = "GID";
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlClass.Items.Clear();
                ddlType.Items.Clear();
                ddlBookName.Items.Clear();
                //ddlEdition.Items.Clear();
            }
            catch (Exception)
            {
            }
        }

        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Classes.LoadCategory.LoadBookCalssByBookGroup(ddlClass, ddlCategory, ddlGroup);
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, new ListItem("--Select--", ""));
                ddlType.Items.Clear();
                ddlBookName.Items.Clear();
                //ddlEdition.Items.Clear();
            }
            catch (Exception)
            {
            }

        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Classes.LoadCategory.LoadBookTypeByClass(ddlType, ddlClass, ddlCategory);
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("--Select--", ""));
                ddlBookName.Items.Clear();
                //ddlEdition.Items.Clear();
            }
            catch (Exception)
            {
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Classes.LoadCategory.LoadBookByType(ddlBookName, ddlCategory, ddlClass, ddlType);
                ddlBookName.DataBind();
                ddlBookName.Items.Insert(0, new ListItem("--Select--", ""));
                //ddlEdition.Items.Clear();
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
            ddlTask.DataSource = Li_TaskManager.GetAllLi_Tasks();
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
                ddlSection.DataSource = Li_SectionManager.LoadAllSection();
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
            dt.Columns.Add("WorkStart", typeof(string));
            dt.Columns.Add("WorkEnd", typeof(string));
            dt.Columns.Add("Day", typeof(decimal));
            dt.Columns.Add("BookID", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("WorkType", typeof(string));
            dt.Columns.Add("WorkTypeID", typeof(int));
            dt.Columns.Add("EmployeeFor", typeof(string));
            dt.Columns.Add("EmployeeForID", typeof(int));
            dt.Columns.Add("SectionID", typeof(int));
            dt.Columns.Add("Employee", typeof(string));
            dt.Columns.Add("EmployeeID", typeof(string));
            dt.Columns.Add("TotalForma", typeof(string));
            dt.Columns.Add("FromPage", typeof(string));
            dt.Columns.Add("ToPage", typeof(string));
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
            try {
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
                        drCurrentRow["WorkStart"] = dtpFromDate.Text;
                        drCurrentRow["WorkEnd"] = dtpToDate.Text;
                        string startTime = drCurrentRow["WorkStart"].ToString();
                        string endTime = drCurrentRow["WorkEnd"].ToString();
                        TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                        drCurrentRow["Day"] = (duration.TotalDays) + 1;
                        drCurrentRow["BookID"] = ddlBookName.SelectedValue;
                        drCurrentRow["Subject"] = ddlBookName.SelectedItem;
                        drCurrentRow["WorkTypeID"] = ddlTask.SelectedValue;
                        drCurrentRow["WorkType"] = ddlTask.SelectedItem.Text;
                        drCurrentRow["EmployeeFor"] = ddlEmplyeeFor.SelectedItem.Text;
                        drCurrentRow["SectionID"] = ddlSection.SelectedValue;
                        drCurrentRow["EmployeeForID"] = ddlEmplyeeFor.SelectedValue;
                        drCurrentRow["Employee"] = ddlEmpName.SelectedItem.Text;
                        drCurrentRow["EmployeeID"] = ddlEmpName.SelectedValue;
                        decimal toPage = Decimal.Parse(txtToPage.Text);
                        decimal fromPage = Decimal.Parse(txtFromPage.Text);
                        drCurrentRow["ToPage"] = toPage;
                        drCurrentRow["FromPage"] =fromPage;

                        //---------------Calculation Book Forma---------------------------------
                        string bookSize = ddlBookSize.SelectedValue.ToString();
                        decimal Setting;
                        decimal formaQty = toPage - fromPage + 1;
                        // for DC 1/8 
                        if (ddlBookSize.SelectedValue.ToString() == "BS-001")
                          {
                              Setting = 8;
                              string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                              drCurrentRow["TotalForma"] = TotalForma;
                          }
                        // for DD 1/16 
                        else if (ddlBookSize.SelectedValue.ToString() == "BS-002")
                          {
                             Setting = 16;
                             string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                             drCurrentRow["TotalForma"] = TotalForma;
                          }
                        // for SDD 1/8
                        else if (ddlBookSize.SelectedValue.ToString() == "BS-003")
                          {
                             Setting = 8;
                             string TotalForma =  string.Format("{0:0.##}", ((formaQty / Setting)));
                             drCurrentRow["TotalForma"] = TotalForma;
                          }

                        // for RL 1/8
                        else if (ddlBookSize.SelectedValue.ToString() == "BS-004")
                        {
                            Setting = 8;
                            string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                            drCurrentRow["TotalForma"] = TotalForma;
                        }

                        // for DD 1/8
                        else if (ddlBookSize.SelectedValue.ToString() == "BS-005")
                        {
                            Setting = 8;
                            string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                            drCurrentRow["TotalForma"] = TotalForma;
                        }

                        // for SDD 1/4
                        else if (ddlBookSize.SelectedValue.ToString() == "BS-006")
                        {
                            Setting = 4;
                            string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                            drCurrentRow["TotalForma"] = TotalForma;
                        }

                        // for DC 1/4
                        else if (ddlBookSize.SelectedValue.ToString() == "BS-0011")
                        {
                            Setting = 4;
                            string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                            drCurrentRow["TotalForma"] = TotalForma;
                        }

                        // for DC 1/16
                        else if (ddlBookSize.SelectedValue.ToString() == "BS-0021")
                        {
                            Setting = 16;
                            string TotalForma = string.Format("{0:0.##}", ((formaQty / Setting)));
                            drCurrentRow["TotalForma"] = TotalForma;
                        }

                        // for RL 1/12

                        else if (ddlBookSize.SelectedValue.ToString() == "BS-007")
                          {
                             Setting = 9;
                             string TotalForma =  string.Format("{0:0.##}", ((formaQty / Setting)));
                             drCurrentRow["TotalForma"] = TotalForma;
                          }

                        else
                          {
                          }

                        //drCurrentRow["TotalForma"] = TotalForma;
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
                int subTotal = 0;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        int unitTotal = Int32.Parse(dtCurrentTable.Rows[i]["Day"].ToString());
                        subTotal += unitTotal;
                    }
                }

                txtSelectedDay.Text = subTotal.ToString();
                txtSelectedTask.Text= dtCurrentTable.Rows.Count.ToString();
            }
            else
            {
                AddDefaultFirstRecord();
            }

        }
        private void LoadBookSize()
        {
            ddlBookSize.DataSource = Li_BookSizeBasicManager.GetAllLi_BookSizeBasics();
            ddlBookSize.DataTextField = "SizeType";
            ddlBookSize.DataValueField = "BookSizeID";
            ddlBookSize.DataBind();
            ddlBookSize.Items.Insert(0, new ListItem("--select--", "0"));
        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["tblEntryWorks"];

            try
            {
                if (dtCurrentTable.Rows.Count > 0)
                {

                    Li_RnDWorkOrderDetails _workPlan = new Li_RnDWorkOrderDetails();
                    _workPlan.BookID = ddlBookName.SelectedValue.ToString();
                    _workPlan.Edition = txtEdition.Text.ToString();
                    _workPlan.SizeID = ddlBookSize.SelectedValue.ToString();
                    _workPlan.TotalPage = Int32.Parse(txtSelectedTask.Text.ToString());
                    _workPlan.ClassID = Int32.Parse(ddlClass.SelectedValue.ToString());
                    _workPlan.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    _workPlan.CreatedDate = DateTime.Now;
                    string returnWorkPlanID = Li_RnDWorkOrderDetailsManager.InsertLi_RnDWorkPlanForNewBook(_workPlan);
                    txtWorkPlanID.Text = returnWorkPlanID;
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        Li_RnDWorkOrderDetails workOrderPlanDetails = new Li_RnDWorkOrderDetails();
                        workOrderPlanDetails.WorkOrderID = Int32.Parse(returnWorkPlanID);
                        workOrderPlanDetails.SectionID = Int32.Parse(dtCurrentTable.Rows[i]["SectionID"].ToString());
                        workOrderPlanDetails.IsHired = Int32.Parse(dtCurrentTable.Rows[i]["EmployeeForID"].ToString());
                        workOrderPlanDetails.EmployeeID = dtCurrentTable.Rows[i]["EmployeeID"].ToString();
                        workOrderPlanDetails.WorkTypeID = Int32.Parse(dtCurrentTable.Rows[i]["WorkTypeID"].ToString());
                        workOrderPlanDetails.CreatedDate = DateTime.Parse(dtCurrentTable.Rows[i]["WorkStart"].ToString());
                        workOrderPlanDetails.WorkDate = DateTime.Parse(dtCurrentTable.Rows[i]["WorkEnd"].ToString());
                        workOrderPlanDetails.PageStart = Int32.Parse(dtCurrentTable.Rows[i]["FromPage"].ToString());
                        workOrderPlanDetails.PageEnd = Int32.Parse(dtCurrentTable.Rows[i]["ToPage"].ToString());
                        workOrderPlanDetails.TotalPage = ((Int32.Parse(dtCurrentTable.Rows[i]["ToPage"].ToString()) - Int32.Parse(dtCurrentTable.Rows[i]["FromPage"].ToString()))+1);
                        workOrderPlanDetails.TotalForma = 0;// decimal.Parse(dtCurrentTable.Rows[i]["TotalForma"].ToString());
                        workOrderPlanDetails.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        Li_RnDWorkOrderDetailsManager.InsertLi_RnDWorkPlanForNewBookDetails(workOrderPlanDetails);
                        txtWorkPlanID.Focus();
                    }
                    txtWorkPlanID.Text = returnWorkPlanID;
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
                    txtWorkPlanID.Text = returnWorkPlanID;
                }
            }
            catch (Exception)
            {

            }
        }
        DataAccessObject DAO = new DataAccessObject();
      //  ReportDocument rd = new ReportDocument();
        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            //rd.Load(Server.MapPath(@"~/Reports/RND/rptPrintRnDBookPlanForAlia.rpt"));
            ////rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
            //rd.DataSourceConnections.Clear();
            //rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            //rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            //rd.SetParameterValue("@PlanID", txtWorkPlanID.Text);
            //rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "PrintRnDWorkOrder");
            //rd.Close();
            //rd.Dispose();
        }
        protected void gvDailyWorks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}