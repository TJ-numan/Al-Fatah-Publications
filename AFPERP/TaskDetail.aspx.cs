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
    public partial class TaskDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
     
                    loadTaskInformationToGrid();
                    LitBookID.Text = Request.QueryString["BookID"];
                    litBookName.Text = Request.QueryString["BookName"];
                    txtClass.Text = Request.QueryString["Class"];
                    LitBookSize.Text = Request.QueryString["BookSize"];
                    LitEdition.Text = Request.QueryString["Edition"];


                }
            }
            catch (Exception)
            {

            }

        }


        protected void ddlTaskStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlTaskStatus = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlTaskStatus.NamingContainer;

            string workPlanID = row.Cells[0].Text;  // Adjust the cell index based on your GridView's structure
            string employeeID = Session["UserID"].ToString();   // Adjust the cell index based on your GridView's structure
           DateTime updatedDate = DateTime.Now;
            string selectedTaskStatus = ddlTaskStatus.SelectedValue;
            TaskDetailManager.InsertTaskDetail(workPlanID, employeeID, updatedDate, selectedTaskStatus);
            //string message = "Task Update Successfully";
            //string script = "window.onload = function(){ alert('";
            //script += message;
            //script += "'); };";
            //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
            loadTaskInformationToGrid();



        }


        protected void gvwTaskList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string taskStatus = (DataBinder.Eval(e.Row.DataItem, "TaskStatus") != null) ? DataBinder.Eval(e.Row.DataItem, "TaskStatus").ToString() : string.Empty;


                // Assuming the cell index of "Task Status" is 11 (adjust if needed)
                TableCell statusCell = e.Row.Cells[12];

                // Set color based on Task Status
                if (taskStatus == "Done")
                {
                    statusCell.BackColor = System.Drawing.Color.LimeGreen;
                }
                else if (taskStatus == "ToDo")
                {
                    statusCell.BackColor = System.Drawing.Color.Yellow;
                }
                else if (taskStatus == "InProgress")
                {
                    statusCell.BackColor = System.Drawing.Color.SkyBlue;
                   
                }
            }
        }




        private void loadTaskInformationToGrid()
        {
            try
            {

                if (Request.QueryString["BookID"] != null)
                {
                    // Retrieve the BookID from the query string
                    string bookID = Request.QueryString["BookID"];

                    // Use the bookID in your logic
                    gvwTaskList.DataSource = BookWiseTaskListManager.GetALLTaskBooKWise(bookID).Tables[0];
                    gvwTaskList.DataBind();
                }
                else
                {
                    // Handle the case where the BookID parameter is not present in the query string
                    // You might want to show an error message or handle it based on your application's requirements.
                }


            }
            catch (Exception ex)
            {

            }
        }



    }
}