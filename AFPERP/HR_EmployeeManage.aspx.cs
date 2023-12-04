using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;

namespace BLL
{
    public partial class HR_EmployeeManage : System.Web.UI.Page
    {/*
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<EmployeeInformation> employees = Li_EmployeeManager.GetAllEmployee();
                BindDepartments();
                BindDesignation();
                BindBloodGroup();
                BindWorkArea();
                BindSection();
            }
        }

        private void BindSection()
        {
            ddlSection.DataSource = Li_SectionManager.GetAllLi_Sections();
            ddlSection.DataTextField = "SectionName";
            ddlSection.DataValueField = "SectionID";
            ddlSection.DataBind();
            ddlSection.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        private void BindWorkArea()
        {
            ddlWorkArea.DataSource = Li_DemercationManager.GetAllLi_Demercations();
            ddlWorkArea.DataTextField = "DemName";
            ddlWorkArea.DataValueField = "DemID";
            ddlWorkArea.DataBind();
        }
        protected void ddlWorkArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlWorkPalce.DataSource = DemLocationManager.GetLocationsByDemarcation(int.Parse(ddlWorkArea.SelectedValue.ToString()));
                ddlWorkPalce.DataTextField = "Location";
                ddlWorkPalce.DataValueField = "locID";
                ddlWorkPalce.DataBind();
                ddlWorkPalce.Items.Insert(1,new ListItem("N/A","0"));
            }
            catch (Exception)
            {


            }
        }
        protected void BindDepartments()
        {
            try
            {
                ddlDepartment.DataSource = Li_DepartmentManager.GetAllDepartment();
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepartmentId";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            catch (Exception)
            {


            }
        }

        protected void BindDesignation()
        {
            try
            {
                ddlDesignation.DataSource = Li_DesignationManager.GetAllDesignation();
                ddlDesignation.DataTextField = "Designation";
                ddlDesignation.DataValueField = "DesignationID";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            catch (Exception)
            {


            }
        }

        //protected void BindBloodGroup()
        //{

        //    ddlBloodGroup.DataSource = Li_BloodGroupManager.GetAllBloodGroup();
        //    ddlBloodGroup.DataTextField = "GroupName";
        //    ddlBloodGroup.DataValueField = "BloodGroupId";
        //    ddlBloodGroup.DataBind();
        //    ddlBloodGroup.Items.Insert(0, new ListItem("-Select-", "0"));

        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.IdNo = txtEmpId.Text;
                employee.EmployeeName = txtName.Text;
                employee.PresentAddress = txtPresentAddress.Text;
                employee.PermanentAddress = txtPermanentAddress.Text;
                employee.MobileNo = txtMobNo.Text;
                employee.PhoneNo = txtPhoneNo.Text;
                employee.Email = txtEmail.Text;
                employee.BloodGroupId = int.Parse(ddlBloodGroup.Text);
                employee.DepartmentId = Int32.Parse(ddlDepartment.SelectedValue);
                employee.DesignationId = Int32.Parse(ddlDesignation.SelectedValue);
                employee.SectionId = Int32.Parse(ddlSection.SelectedValue.ToString());
                employee.CreatedBy = int.Parse(Session["UserId"].ToString());
                employee.CreatedDate = DateTime.Now;
                employee.ModifiedBy = int.Parse(Session["UserId"].ToString());
                employee.ModifiedDate = DateTime.Now;
                employee.JoiningDate = txtJoiningDate.Text;
                employee.EmpStatus =1;
                employee.WorkAreaId = Convert.ToInt32(ddlWorkArea.SelectedValue);
                employee.WorkPlaceId = Convert.ToInt32(ddlWorkPalce.SelectedValue);
                Li_EmployeeManager.InsertLi_Employee(employee);
                string message = "Saved Successfully!";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
            }
            catch (Exception tr)
            {
            }


        }
      * */
    }
}