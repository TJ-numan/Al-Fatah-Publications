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
    public partial class Mkt_RptTeacherInfoByMadrasah : System.Web.UI.Page
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
                    LoadTerritory();
                    LoadMadrasah();
                    //GetAllDistrict();
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
                        //btnSave.Enabled = true;
                    }
                    else
                    {
                        //btnSave.Enabled = false;
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
        private void LoadTerritory()
        {

            ddlTerritoryName.DataSource = Li_TeritoryManager.GetAllLi_Teritories(string.Empty);
            ddlTerritoryName.DataTextField = "TeritoryName";
            ddlTerritoryName.DataValueField = "TeritoryCode";
            ddlTerritoryName.DataBind();
            ddlTerritoryName.Items.Insert(0, new ListItem("All", " "));
        }
        //private void GetAllDistrict()
        //{
        //    try
        //    {
        //        ddlDristrict.DataSource = li_DistrictManager.GetAll_Districts();
        //        ddlDristrict.DataTextField = "DistrictName";
        //        ddlDristrict.DataValueField = "DistrictID";
        //        ddlDristrict.DataBind();
        //        ddlDristrict.Items.Insert(0, new ListItem("--Select District--", "0"));
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
        //protected void ddlDristrict_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(ddlDristrict.SelectedValue));
        //        ddlThana.DataTextField = "ThanaName";
        //        ddlThana.DataValueField = "ThanaID";
        //        ddlThana.DataBind();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
        protected void LoadMadrasah()
        {
            try
            {
                ddlMadrasahName.DataSource = Li_MadrasahInfoManager.GetAllLi_MadrasahInfoForTeacherInfo();
                ddlMadrasahName.DataValueField = "Mad_ID";
                ddlMadrasahName.DataTextField = "Mad_Name";
                ddlMadrasahName.DataBind();
                ddlMadrasahName.Items.Insert(0, new ListItem("All", "0"));
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
            ddlClass.Items.Insert(0, new ListItem("All", "0"));
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlBookName.DataSource = li_BookInformationManager.Get_BookInformations_Combo_ByUserAndClassIDForTeacherEntry(int.Parse(Session["UserID"].ToString()), int.Parse(ddlClass.SelectedValue.ToString()));
                ddlBookName.DataTextField = "BookName";
                ddlBookName.DataValueField = "BookID";
                ddlBookName.DataBind();
                ddlBookName.Items.Insert(0, new ListItem("All", "0"));
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
            dt.Columns.Add("MadrasahName", typeof(string));
            dt.Columns.Add("BookID", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("ClassID", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("TeacherName", typeof(string));
            dt.Columns.Add("Mobile", typeof(string));
            dt.Columns.Add("Territory", typeof(string));
            dt.Columns.Add("Thana", typeof(string)); 
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["tblTeacherEntry"] = dt;
            gvTeacherInfo.DataSource = dt;
            gvTeacherInfo.DataBind();
            ViewState["LinkClick"] = fromLinkButton;
        }
        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            try
            {
                AddDefaultFirstRecord();
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
                        // New row for data table

                        DataTable dt = new DataTable();
                        dt = Li_MadrasahInfoManager.GetTeacherInformationByMadrasahAndterritory(ddlTerritoryName.SelectedValue, ddlMadrasahName.SelectedValue,ddlClass.SelectedValue,ddlBookName.SelectedValue).Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            //add each row into data table  
                            drCurrentRow = dtCurrentTable.NewRow();
                            drCurrentRow["Serial"] = i + 1;
                            drCurrentRow["BookID"] = dt.Rows[i]["BookID"].ToString();
                            drCurrentRow["MadrasahName"] = dt.Rows[i]["MadrasahName"].ToString();
                            drCurrentRow["Subject"] = dt.Rows[i]["BookName"].ToString();
                            drCurrentRow["ClassID"] = dt.Rows[i]["ClassID"].ToString();
                            drCurrentRow["Class"] = dt.Rows[i]["ClassName"].ToString();
                            drCurrentRow["TeacherName"] = dt.Rows[i]["TeacherName"].ToString();
                            drCurrentRow["Mobile"] = dt.Rows[i]["Mobile"].ToString();
                            drCurrentRow["Territory"] = dt.Rows[i]["TeritoryName"].ToString();
                            drCurrentRow["Thana"] = dt.Rows[i]["ThanaName"].ToString();
                            //add created Rows into dataTable  
                            dtCurrentTable.Rows.Add(drCurrentRow);
                        }
                    }
                //Remove initial blank row  
                if (dtCurrentTable.Rows[0][0].ToString() == "")
                {
                    drCurrentRow["Serial"] = dtCurrentTable.Rows.Count;
                    dtCurrentTable.Rows[0].Delete();
                    dtCurrentTable.AcceptChanges();

                }
                //Save Data table into view state after creating each row  

                ViewState["tblTeacherEntry"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvTeacherInfo.DataSource = dtCurrentTable;
                gvTeacherInfo.DataBind();              
            }
            else
            {
                AddDefaultFirstRecord();
            }

        }
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            rd.Load(Server.MapPath(@"~/Reports/MKT/rptPrintTeacherInformationByMadrasah.rpt"));
            //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
            rd.DataSourceConnections.Clear();
            rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            rd.SetParameterValue("@TerID", ddlTerritoryName.SelectedValue);
            rd.SetParameterValue("@MadID", ddlMadrasahName.SelectedValue);
            rd.SetParameterValue("@ClassID", ddlClass.SelectedValue);
            rd.SetParameterValue("@BookID", ddlBookName.SelectedValue);
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "PrintQawmiTeacher");
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