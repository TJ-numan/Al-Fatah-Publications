using BLL.Classes;
using BLL.Marketing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Mkt_Rpt_DatewiseBookStockQty : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");

                getUserAccess();
                if (!IsPostBack)
                {
                    getUserAccess();
                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;
                    int day = DateTime.Now.Day;

                    if (day >= 7)
                    {
                        var mydate = new DateTime(year, month, day - 6);

                        dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    }

                    else
                    {
                        var mydate = new DateTime(year, month - 1, day-6);
                        dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    }
                    dtpToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    
                }
            }
            catch (Exception ex)
            { }
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
                        Response.Redirect("~/MarketingHome.aspx");
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
            ddlCategory.Items.Insert(0, new ListItem("All", "0"));
            ddlGroup.Items.Clear();
            ddlGroup.Items.Insert(0, new ListItem("All", "0"));
            ddlClass.Items.Clear();
            ddlClass.Items.Insert(0, new ListItem("All", ""));
            ddlType.Items.Clear();
            ddlType.Items.Insert(0, new ListItem("All", ""));
            ddlBookName.Items.Clear();
            ddlBookName.Items.Insert(0, new ListItem("All", ""));

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlGroup.DataSource = Li_Book_GManager.GetLi_Book_GByID(ddlCategory.SelectedValue.ToString());
                ddlGroup.DataTextField = "GName";
                ddlGroup.DataValueField = "GID";
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, new ListItem("All", "0"));
                ddlClass.Items.Clear();
                ddlClass.Items.Insert(0, new ListItem("All", ""));
                ddlType.Items.Clear();
                ddlType.Items.Insert(0, new ListItem("All", ""));
                ddlBookName.Items.Clear();
                ddlBookName.Items.Insert(0, new ListItem("All", ""));
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
                ddlClass.Items.Insert(0, new ListItem("All", ""));
                ddlType.Items.Clear();
                ddlType.Items.Insert(0, new ListItem("All", ""));
                ddlBookName.Items.Clear();
                ddlBookName.Items.Insert(0, new ListItem("All", ""));
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
                ddlType.Items.Insert(0, new ListItem("All", ""));
                ddlBookName.Items.Clear();
                ddlBookName.Items.Insert(0, new ListItem("All", ""));
            }
            catch (Exception)
            {
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlBookName.DataSource = li_BookInformationManager.Get_BookInformationsByCompany(ddlCom.SelectedValue.ToString(), int.Parse(ddlClass.SelectedValue.ToString()), int.Parse(ddlType.SelectedValue.ToString()));
                ddlBookName.DataTextField = "BookName";
                ddlBookName.DataValueField = "BookID";
                ddlBookName.DataBind();
                ddlBookName.Items.Insert(0, new ListItem("All", ""));
            }
            catch (Exception)
            {
            }
        }


        protected void ddlCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCategory();

            }
            catch
            {

            }
        }

        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                rd.Load(Server.MapPath(@"~/Reports/MKT/rpt_Print_DatewiseBookStockQty.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@FromDate", dtpFromDate.Text);
                rd.SetParameterValue("@ToDate", dtpToDate.Text);
                rd.SetParameterValue("@BookID", ddlBookName.SelectedValue);
                rd.SetParameterValue("@ClassID", ddlClass.SelectedValue);
                rd.SetParameterValue("@Type", ddlType.SelectedValue);
                rd.SetParameterValue("@Comp", ddlCom.SelectedValue);

                //rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Book Stock report");
                if (ddlViewers.SelectedValue == "0")
                {

                }

                else if (ddlViewers.SelectedValue == "1")
                {
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Book Stock report");
                }

                else if (ddlViewers.SelectedValue == "2")
                {
                    rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "Book Stock report");
                }


                else if (ddlViewers.SelectedValue == "3")
                {
                    rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "Book Stock report");
                }

                else
                {

                }
                rd.Close();
                rd.Dispose();
            }
            catch (Exception ex)
            {

            }
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