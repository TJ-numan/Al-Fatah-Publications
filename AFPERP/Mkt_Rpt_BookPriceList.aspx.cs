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
    public partial class Mkt_Rpt_BookPriceList : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "MR026";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();

                    //LoadYear();
                   // LoadBook();
                   // LoadBookType();
                   // LoadClass();
                    LoadCategory();
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
        //private void LoadBook()
        //{
        //    ddlBookName.DataSource = li_BookInformationManager.Get_BookInformations_ComboSourceData();
        //    ddlBookName.DataTextField = "BookName";
        //    ddlBookName.DataValueField = "BookID";
        //    ddlBookName.DataBind();

        //}
        //private void LoadBookType()
        //{
        //    LoadComboData loadClass = new LoadComboData();
        //    loadClass.BookType(ddlBookType);
        //    ddlBookType.DataBind();
        //    ddlBookType.Items.Insert(0, new ListItem("All", "0"));
        //}



        //private void LoadClass()
        //{
        //    ddlClass.DataSource = Li_ClassesManager.GetAllLi_Classess();
        //    ddlClass.DataTextField = "ClassName";
        //    ddlClass.DataValueField = "ClassID";
        //    ddlClass.DataBind();
        //    ddlClass.Items.Insert(0, new ListItem("All", "0"));
        //}

        //private void LoadYear()
        //{
        //    ddlEdition.DataSource = li_ChallanManager.LoadYear().Tables[0];
        //    ddlEdition.DataTextField = "Edition";
        //    ddlEdition.DataBind();
        //    //ddlEdition.Items.Insert(0, new ListItem("--select--", ""));
        //}

        private void LoadCategory()
        {
            ddlCategory.DataSource = Li_CategoryManager.GetAllCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("All", ""));
            ddlGroup.Items.Insert(0, new ListItem("All", "0"));
            ddlClass.Items.Insert(0, new ListItem("All", "0"));
            ddlBookType.Items.Insert(0, new ListItem("All", "0"));
            ddlBookName.Items.Insert(0, new ListItem("All", ""));
            ddlEdition.Items.Insert(0, new ListItem("All", ""));

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
                //ddlClass.Items.Clear();
                //ddlBookType.Items.Clear();
                //ddlBookName.Items.Clear();
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
                ddlClass.Items.Insert(0, new ListItem("All", "0"));
                //ddlBookType.Items.Clear();
                //ddlBookName.Items.Clear();
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
                Classes.LoadCategory.LoadBookTypeByClass(ddlBookType, ddlClass, ddlCategory);
                ddlBookType.DataBind();
                ddlBookType.Items.Insert(0, new ListItem("All", "0"));
                //ddlBookName.Items.Clear();
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
                Classes.LoadCategory.LoadBookByType(ddlBookName, ddlCategory, ddlClass, ddlBookType);
                ddlBookName.DataBind();
                ddlBookName.Items.Insert(0, new ListItem("All", ""));
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
                Classes.LoadCategory.LoadEditionByBookID(ddlEdition, ddlBookName);
                ddlEdition.DataBind();

            }
            catch (Exception)
            {
            }
        }
       ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                rd.Load(Server.MapPath(@"~/Reports/MKT/rptBookPriceList.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@BookID", ddlBookName.SelectedValue);
                rd.SetParameterValue("@Class", ddlClass.SelectedValue);
                rd.SetParameterValue("@BookType", ddlBookType.SelectedValue);
                rd.SetParameterValue("@Group", ddlCategory.SelectedValue);
                rd.SetParameterValue("@Edition", ddlEdition.SelectedItem.Text);
                //rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Book Price List Report");
                if (ddlViewers.SelectedValue == "0")
                {

                }

                else if (ddlViewers.SelectedValue == "1")
                {
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "BookPriceListReport");
                }

                else if (ddlViewers.SelectedValue == "2")
                {
                    rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "BookPriceListReport");
                }


                else if (ddlViewers.SelectedValue == "3")
                {
                    rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "BookPriceListReport");
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