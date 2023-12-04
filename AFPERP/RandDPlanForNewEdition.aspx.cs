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
    public partial class RandDPlanForNewEdition : System.Web.UI.Page
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
                    LoadSection();
                    LoadTask();
                    lblHireSection.Visible = false;
                    ddlHireSection.Visible = false;

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
                ddlEdition.Items.Clear();
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
                ddlEdition.Items.Clear();
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
                ddlEdition.Items.Clear();
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
                ddlEdition.Items.Clear();
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
        private void LoadSection()
        {
            ddlSection.DataSource = Li_SectionManager.LoadAllSection();
            ddlSection.DataTextField = "SectionName";
            ddlSection.DataValueField = "SectionID";
            ddlSection.DataBind();
            ddlSection.Items.Insert(0, new ListItem("--Select--", ""));
        }
        private void LoadHireSection()
        {
            ddlHireSection.DataSource = Li_SectionManager.LoadAllSection();
            ddlHireSection.DataTextField = "SectionName";
            ddlHireSection.DataValueField = "SectionID";
            ddlHireSection.DataBind();
            ddlHireSection.Items.Insert(0, new ListItem("--Select--", ""));
        }
        protected void ddlSection_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlSection.SelectedIndex >= 0)
                {

                    LoadEmployee(int.Parse(ddlSection.SelectedValue.ToString())); 
                }
            }
            catch (Exception)
            {


            }
        }
        private void LoadDesignation(int EmpID)
        {
            ddlDesignation.DataSource = Li_DesignationManager.GetLi_DesignationByEmpID(EmpID);
            ddlDesignation.DataTextField = "Designation";
            ddlDesignation.DataValueField = "DesignationID";
            ddlDesignation.DataBind();
        }
        private void LoadTask()
        {
            ddlTask.DataSource = Li_TaskManager.GetAllLi_Tasks();
            ddlTask.DataTextField = "TaskName";
            ddlTask.DataValueField = "TaskID";
            ddlTask.DataBind();
            ddlTask.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        private void LoadEmployee(int id)
        {

            ddlEmpName.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListBySecID(id);
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
                    LoadDesignation(int.Parse(ddlEmpName.SelectedValue.ToString()));
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
        protected void ddlHireSection_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadEmployee(int.Parse(ddlHireSection.SelectedValue.ToString())); 
            }
            catch (Exception)
            {


            }
        }
    }
}