using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;
using BLL;
using BLL.Marketing;
using Common;
using Common.Marketing;

namespace BLL
{
    public partial class MktAddNewBook : System.Web.UI.Page
    {
        string FormID = "MF003";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadBookType();
                    LoadClass();
                    LoadSession();
                    LoadGroup();
                    LoadSection();
                    loadBookInformationToGrid();
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
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/MarketingHome.aspx");
                    }
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
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadBookType()
        {
            LoadComboData loadType = new LoadComboData();
            loadType.BookType(ddlBookType);
            ddlBookType.DataBind();
            ddlBookType.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        private void LoadClass()
        {
            ddlClass.DataSource = Li_ClassesManager.GetAllLi_Classess();
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        private void LoadGroup()
        {
            ddlGroup.DataSource = Li_CategoryManager.GetAllCategories();
            ddlGroup.DataTextField = "CategoryName";
            ddlGroup.DataValueField = "ID";
            ddlGroup.DataBind();
            ddlGroup.Items.Insert(0, new ListItem("-Select-", "0"));

        }
        private void LoadSession()
        {
            ddlSession.DataSource = Li_Book_SessionManager.GetAllLi_Book_Sessions();
            ddlSession.DataTextField = "SessionName";
            ddlSession.DataValueField = "SessionID";
            ddlSession.DataBind();
            ddlSession.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        private void LoadSection()
        {
            gvSection.DataSource = Li_SectionManager.GetAllLi_Sections();
            gvSection.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                              
                li_BookInformation _bookInformation = new li_BookInformation();

                _bookInformation.BookName = txtBookName.Text;
                _bookInformation.ClassID = Int32.Parse(ddlClass.SelectedValue.ToString());              
                _bookInformation.CreatedBy = int.Parse(Session["UserID"].ToString());
                _bookInformation.CreatedDate = DateTime.Now;
                _bookInformation.ModifiedBy = int.Parse(Session["UserID"].ToString());
                _bookInformation.ModifiedDate = DateTime.Now;                
                _bookInformation.BookType = int.Parse(ddlBookType.SelectedValue.ToString());               
                object bookRow = getTotalBookRow();
                string nextID = bookRow.ToString();
                string BookNewID = txtBookCode.Text;
               
                _bookInformation.BookID = BookNewID;
                _bookInformation.BookGroup = char.Parse(ddlGroup.SelectedValue.ToString());
                _bookInformation.B_Name = txtBookNameBangla.Text;
                _bookInformation.Book_Session = Int32.Parse(ddlSession.SelectedValue.ToString());

                li_BookInformationManager.Insert_BookInformation(_bookInformation);

                if (ddlGroup.SelectedValue.ToString() == "R" || ddlGroup.SelectedValue.ToString() == "K")
                {
                    for (int i = 0; i < gvSection.Rows.Count; i++)
                    {
                        Li_BookInfo_Section section = new Li_BookInfo_Section();
                        section.BookID = txtBookCode.Text;
                        section.CreatedBy = int.Parse(Session["UserID"].ToString());
                        section.CreatedDate = DateTime.Now;
                        section.SectionID = Int32.Parse(gvSection.Rows[i].Cells[1].ToString());
                        section.IsSelect = bool.Parse(gvSection.Rows[i].Cells[2].ToString());
                        Li_BookInfo_SectionManager.InsertLi_BookInfo_Section(section);

                    }
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
                loadBookInformationToGrid();            
                txtBookCode.Focus();
            }
            catch (Exception ex)
            {

            }
        }
        public static int getTotalBookRow()
        {
            DataAccessObject dsa = new DataAccessObject();
            using (SqlConnection connection = new SqlConnection(dsa.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_GetNext_Book", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@lastin", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();

                int result = cmd.ExecuteNonQuery();

                return (int)cmd.Parameters["@lastin"].Value;
            }
        }
        private void loadBookInformationToGrid()
        {

            List<BookInformation> informations = li_BookInformationManager.GetAll_BookInformations();

        }

    }

    
}