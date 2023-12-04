using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;
using BLL.Marketing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using System.Data;

namespace BLL
{
    public partial class Mkt_TeacherInfoByMadrasah : System.Web.UI.Page
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
                    LoadsalesPerson();
                    GetAllDistrict();
                    LoadClassByUserID();
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
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadsalesPerson()
        {

            ddlTSOName.DataSource = Li_SalesPersonManager.GetAllLi_SalesPersonsByUserID(int.Parse(Session["UserID"].ToString()));
            ddlTSOName.DataTextField = "Name";
            ddlTSOName.DataValueField = "TSOID";
            ddlTSOName.DataBind();
        }
        private void GetAllDistrict()
        {
            try
            {
                ddlDristrict.DataSource = li_DistrictManager.GetAll_Districts();
                ddlDristrict.DataTextField = "DistrictName";
                ddlDristrict.DataValueField = "DistrictID";
                ddlDristrict.DataBind();
                ddlDristrict.Items.Insert(0, new ListItem("--Select District--", "0"));
            }
            catch (Exception)
            {

            }
        }

        protected void ddlDristrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(ddlDristrict.SelectedValue));
                ddlThana.DataTextField = "ThanaName";
                ddlThana.DataValueField = "ThanaID";
                ddlThana.DataBind();
            }
            catch (Exception)
            {

            }
        }
        private void LoadClassByUserID()
        {
            ddlClass.DataSource = Li_ClassesManager.GetLi_ClassesByUserIDForTecherEntry(int.Parse(Session["UserID"].ToString()));
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("--select--", "0"));
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlBookName.DataSource = li_BookInformationManager.Get_BookInformations_Combo_ByUserAndClassIDForTeacherEntry(int.Parse(Session["UserID"].ToString()), int.Parse(ddlClass.SelectedValue.ToString()));
                ddlBookName.DataTextField = "BookName";
                ddlBookName.DataValueField = "BookID";
                ddlBookName.DataBind();

            }
            catch (Exception)
            {
            }


        }

        private void AddDefaultFirstRecord()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            bool fromLinkButton = false;
            dt.TableName = "tblTeacherEntry";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BookID", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("ClassID", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("TeacherName", typeof(string));
            dt.Columns.Add("Mobile", typeof(string));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["tblTeacherEntry"] = dt;
            gvTeacherInfo.DataSource = dt;
            gvTeacherInfo.DataBind();
            ViewState["LinkClick"] = fromLinkButton;
        }

        protected void lblDelete_OnClick(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblTeacherEntry"];
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
            if (ViewState["tblTeacherEntry"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblTeacherEntry"];
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
                        drCurrentRow["TeacherName"] = txtTeacherName.Text;
                        drCurrentRow["Mobile"] = txtMobileNo.Text;                  
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

                ViewState["tblTeacherEntry"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvTeacherInfo.DataSource = dtCurrentTable;
                gvTeacherInfo.DataBind();
                txtTeacherName.Text="";
                txtMobileNo.Text = "";
            }
            else
            {
                AddDefaultFirstRecord();
            }

        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["tblTeacherEntry"];

            try
            {
                if (dtCurrentTable.Rows.Count > 0)
                {

                    Li_TeacherInfo _teacherInfo = new Li_TeacherInfo();
                    _teacherInfo.MadrasahName = txtMadrasahName.Text;
                    _teacherInfo.MadrasahAdd = txtMadrasahAddress.Text;
                    _teacherInfo.TeachderName = ddlTSOName.SelectedValue.ToString();
                    _teacherInfo.DesignationId = Int32.Parse(ddlThana.SelectedValue.ToString());
                    _teacherInfo.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    _teacherInfo.CreatedDate = DateTime.Now;
                    string returnmadID = Li_TeacherInfoManager.InsertLi_QawmiTeacherInfoByMad(_teacherInfo);
                    txtEntryNo.Text = returnmadID;
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        Li_TeacherInfo _teacherInfoDetails = new Li_TeacherInfo();
                        _teacherInfoDetails.TeacherId = Int32.Parse(returnmadID);
                        _teacherInfoDetails.SubjectName = dtCurrentTable.Rows[i]["BookID"].ToString();
                        _teacherInfoDetails.ClassName = dtCurrentTable.Rows[i]["ClassID"].ToString();
                        _teacherInfoDetails.TeachderName = dtCurrentTable.Rows[i]["TeacherName"].ToString();
                        _teacherInfoDetails.MobileNo = dtCurrentTable.Rows[i]["Mobile"].ToString();
                        _teacherInfoDetails.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        _teacherInfoDetails.CreatedDate = DateTime.Now;
                        Li_TeacherInfoManager.InsertLi_QawmiTeacherInfoByMadDetails(_teacherInfoDetails);
                    }
                    txtEntryNo.Text = returnmadID;
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
                    gvTeacherInfo.DataSource = null;
                    txtEntryNo.Text = returnmadID;
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
            Response.Redirect("~/Mkt_RptTeacherInfoByMadrasah.aspx");
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