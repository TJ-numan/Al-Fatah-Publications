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
    public partial class TaskWiseBookReport : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        public int pageNumber;
        public int pageSize = 10;
        public int totalPages;
        public int count;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {

                pagetext.Visible = false;
                totalText.Visible = false;
                LoadBookInformation_ForGVW();
                LoadCategory();
                LoadBookSize();
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
        private void LoadBookSize()
        {
            ddlBookSize.DataSource = Li_BookSizeBasicManager.GetAllLi_BookSizeBasics();
            ddlBookSize.DataTextField = "SizeType";
            ddlBookSize.DataValueField = "BookSizeID";
            ddlBookSize.DataBind();
            ddlBookSize.Items.Insert(0, new ListItem("--select--", "0"));
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


        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            LoadBookInformation_ForGVW();
        }







        //protected void ddlSection_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (ddlSection.SelectedIndex >= 0)
        //        {

        //            LoadEmployee(int.Parse(ddlSection.SelectedValue.ToString()), int.Parse(ddlEmplyeeFor.SelectedValue.ToString()));
        //        }
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}










        //protected void txtSearchLibraryName_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LoadBookInformation_ForGVW();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
         ReportDocument rd = new ReportDocument();
        protected void gvwBookInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            try
            {
                GridViewRow selectedRow = gvwBookInformation.SelectedRow;

                string BookID = selectedRow.Cells[0].Text;
                int ClassID = 0; 
                string Edition= selectedRow.Cells[3].Text;
                string SizeID = selectedRow.Cells[4].Text; ;
                bool? TaskStatus=null;//If any one Wants It  cn added To send data


                rd.Load(Server.MapPath(@"~/Reports/RND/RNDTaskReport.rpt"));

                
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);

                rd.SetParameterValue("@BookID", BookID);
                rd.SetParameterValue("@ClassID", ClassID);
                rd.SetParameterValue("@Edition", Edition);
                rd.SetParameterValue("@SizeID", SizeID);
                rd.SetParameterValue("@TaskStatus", TaskStatus);


                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Task Report");

                rd.Close();
                rd.Dispose();

            }
            catch (Exception ex)
            {


            }

        }

        protected void gvwBookInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {
           try
           {
               //gvwLibraryInformation.PageIndex = e.NewPageIndex;

               //string LibraryName = txtSearchLibraryName.Text;
               //string LibID = ""; //= txtLibraryID.Text;
               //gvwLibraryInformation.DataSource = Li_LibraryInformationManager.GetALLLibraryInformation(LibraryName, LibID).Tables[0];
               //gvwLibraryInformation.DataBind();
           }
           catch (Exception ex)
           {

           }
       }


        protected void gvwBookInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

            //}

        }

 protected void gvwBookInformation_RowCommand(object sender, GridViewCommandEventArgs e)
{
 
    if (e.CommandName == "Details")
    {
        int rowIndex = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = gvwBookInformation.Rows[rowIndex];

        // Assuming "BookID" is stored in the first cell of the row (adjust if needed)
        string bookID = row.Cells[0].Text;
        string BookName = row.Cells[1].Text;
        string Class = row.Cells[2].Text;
        string Edition = row.Cells[3].Text;
        string BookSize = row.Cells[4].Text;

        // Redirect to TaskDetail page with the BookID
        Response.Redirect("TaskDetail.aspx?BookID=" + bookID + "&BookName=" + Server.UrlEncode(BookName) + "&Class=" + Server.UrlEncode(Class) + "&Edition=" + Server.UrlEncode(Edition) + "&BookSize=" + Server.UrlEncode(BookSize));


       
    }
  
}


        

        protected void btnPrevious_Click(object sender, EventArgs e)
        {

            int count = Convert.ToInt32(pagetext.Text);
            int pageSize = Convert.ToInt32(idPageSize.SelectedValue);

            if (count >= 0)
            {
                pageNumber--;
                count--;
                idPageSize.SelectedValue = pageSize.ToString();
                pagetext.Text = count.ToString();
                lblPageNo.Text = "Page " + count + " of " + totalPages;



                LoadBookInformation_ForGVW();
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {

            count = Convert.ToInt32(pagetext.Text);
            int pageSize = Convert.ToInt32(idPageSize.SelectedValue);
            totalPages = Convert.ToInt32(totalText.Text);
            if (count >= 0)
            {
                if (count < totalPages)
                {
                    count++;
                    idPageSize.SelectedValue = pageSize.ToString();
                    pagetext.Text = count.ToString();
                    pageNumber++;
                    lblPageNo.Text = "Page " + count + " of " + totalPages;


                    LoadBookInformation_ForGVW();
                }

            }
        }

        private void LoadBookInformation_ForGVW()
        {
            try
            {

                string BookID = ddlBookName.SelectedValue.ToString();
                
                int ClassID;
                if (int.TryParse(ddlClass.SelectedValue, out ClassID))
                {
                    // Parsing successful, use the parsed value
                    ClassID = Int32.Parse(ddlClass.SelectedValue.ToString());
                }
                else
                {
                    // Parsing failed, set ClassID to 0
                    ClassID = 0;
                }
                string Edition = txtEdition.Text.ToString();
                string SizeID = ddlBookSize.SelectedValue.ToString();

                if (SizeID == "0")
                {
                    SizeID = "";
                }
                var at = TaskWiseBookManager.GetALLLBookInformation(BookID, ClassID, Edition, SizeID).Tables[0];
                pageSize = Convert.ToInt32(idPageSize.Text);

                int totalElements = at.Rows.Count;
                count = Convert.ToInt32(pagetext.Text);
                totalPages = (int)Math.Ceiling((double)totalElements / pageSize);
                totalText.Text = totalPages.ToString();

                if (count == null || count == 0)
                {
                    count = 1;
                    pagetext.Text = count.ToString();
                }
                else
                {
                    lblPageNo.Text = "Page " + count + " of " + totalPages;


                }


                lblTotalData.Text = "Total Data: " + totalElements;

                var paginatedData = at.AsEnumerable()
                    .Skip((count - 1) * pageSize)
                    .Take(pageSize)
                    .Select((dt, index) => new
                    {
                        sl = index + 1 + (count - 1) * pageSize,
                        BookID = dt.Field<string>("BookID") == null ? "" : dt.Field<string>("BookID"),
                        BookName = dt.Field<string>("BookName") == null ? "NameNotFound" : dt.Field<string>("BookName"),
                        ClassName = dt.Field<string>("ClassName") == null ? "" : dt.Field<string>("ClassName"),
                        Edition = dt.Field<string>("Edition") == null ? "" : dt.Field<string>("Edition"),
                        BookSize = dt.Field<string>("BookSize") == null ? "" : dt.Field<string>("BookSize"),
                        WorkPlanID = dt.Field<int?>("WorkPlanID") == null ? 0 : dt.Field<int>("WorkPlanID")
                    })
                    .ToList();

                gvwBookInformation.DataSource = paginatedData;

                gvwBookInformation.DataBind();


            }
            catch (Exception ex)
            {

            }
        }

        protected void pageSizeChange(object sender, EventArgs e)
        {

            pageSize = Convert.ToInt32(idPageSize.Text);
            LoadBookInformation_ForGVW();
        }
      





        }
    }
