using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HR_EmployeeStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtEmployeeStatus.Attributes.Add("autocomplete", "off");

                  //  gvwEmployeeStatus.DataSource = Li_EmpStatusBasicManager.GetAllLi_EmpStatusBasics();
                    gvwEmployeeStatus.DataBind();
                    gvwEmployeeStatus.Columns[1].Visible = false;
                }
            }
            catch (Exception)
            {


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Li_EmpStatusBasic EmpStatus = new Li_EmpStatusBasic();
                //EmpStatus.EmpStatus = txtEmployeeStatus.Text;
                //EmpStatus.EmpStatusID = 0;
                //EmpStatus.CreatedBy = 0;
                //EmpStatus.CreatedDate = DateTime.Now;
                ////Li_EmpStatusBasicManager.InsertLi_EmpStatusBasic(EmpStatus);
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Saved Sucessfully');", true);
                //txtEmployeeStatus.Text = "";

            }
            catch (Exception)
            {


            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
             //   Li_EmpStatusBasic EmpStatus = new Li_EmpStatusBasic();
             //   EmpStatus.EmpStatus = txtEmployeeStatus.Text;
             //   EmpStatus.EmpStatusID = int.Parse(Session["EmpStatusID"].ToString());
             //   EmpStatus.CreatedBy = 0;
             //   EmpStatus.CreatedDate = DateTime.Now;
             ////   Li_EmpStatusBasicManager.UpdateLi_EmpStatusBasic(EmpStatus);
             //   ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Update Sucessfully');", true);
             //   txtEmployeeStatus.Text = "";

            }
            catch (Exception)
            {


            }
        }

        protected void gvwEmployeeStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwEmployeeStatus.SelectedRow;
                Session["EmpStatusID"] = row.Cells[1].Text;
                txtEmployeeStatus.Text = row.Cells[2].Text;
            }
            catch (Exception)
            {

            }
        }

        protected void gvwEmployeeStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
}