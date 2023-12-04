using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HR_Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {                              

                    //ddlEmployeeStatus.DataSource = Li_EmpStatusBasicManager.GetAllLi_EmpStatusBasics();
                    //ddlEmployeeStatus.DataValueField = "EmpStatusID";
                    //ddlEmployeeStatus.DataTextField = "EmpStatus";
                    //ddlEmployeeStatus.DataBind();

                    ddlWorkArea.DataSource = Li_DemercationManager.GetAllLi_Demercations();
                    ddlWorkArea.DataTextField = "DemName";
                    ddlWorkArea.DataValueField = "DemID";
                    ddlWorkArea.DataBind();               

                }
            }
            catch (Exception)
            {


            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
           
        }




        private void Empty()
        {
            txtEmployeeName.Text = "";
            txtContactNo.Text = "";
            txtResidentAddress.Text = "";
            txtResidentContactNo.Text = "";
            dtpJoinigDate.Text = "";
            txtRemark.Text = "";
        }

 

        protected void ddlWorkArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 ddlWorkPlace  .DataSource = DemLocationManager.GetLocationsByDemarcation(int.Parse(ddlWorkArea.SelectedValue.ToString()));
                 ddlWorkPlace . DataTextField = "Location";
                 ddlWorkPlace .DataValueField = "locID";
                 ddlWorkPlace.DataBind();
            }
            catch (Exception)
            {


            }
        }

        protected void gvwEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void gvwEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = gvwEmployee.SelectedRow;
                Session["EmpID"] = row.Cells[1].Text;
                txtEmployeeName.Text=row.Cells[2].Text;
                ddlDepartment.Text = row.Cells[3].Text;
                ddlDesignation.Text = row.Cells[4].Text;
                dtpJoinigDate.Text=row.Cells[5].Text;
                txtContactNo.Text = row.Cells[6].Text.Replace("&nbsp;", "");
                txtResidentAddress.Text = row.Cells[7].Text.Replace("&nbsp;", "");
                txtResidentContactNo.Text = row.Cells[8].Text.Replace("&nbsp;","");
                ddlWorkArea.Text = row.Cells[9].Text;
                
                ddlWorkPlace.DataSource = DemLocationManager.GetLocationsByDemarcation(int.Parse(row.Cells[9].Text));
                ddlWorkPlace.DataTextField = "Location";
                ddlWorkPlace.DataValueField = "locID";
                ddlWorkPlace.DataBind();

                ddlWorkPlace.Text = row.Cells[10].Text;
                ddlEmployeeStatus.Text = row.Cells[11].Text;
                txtRemark.Text = row.Cells[12].Text.Replace("&nbsp;", "");
            }
            catch (Exception)
            {

      
            }
        }
                   
    }
}