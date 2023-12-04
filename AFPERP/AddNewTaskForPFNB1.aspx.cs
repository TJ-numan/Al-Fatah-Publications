using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BLL.Classes;

namespace BLL
{
    public partial class AddNewTaskForPFNB1 : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            try
            {

                if (!IsPostBack)
                {
                    GetAllTask();
                  //  AddDefaultFirstRecord();
            

                }

            }
            catch (Exception)
            {

            }

        }

        protected void btn_addanother(object sender, EventArgs e)
        {
            // AddNewRecordRowToGrid();
            try
            {
                Li_AddTask AddTask = new Li_AddTask();
                AddTask.TaskName = txtTaskName.Text;
                AddTask.IsHourly = Convert.ToInt32( txtisHourly.Text);
                li_NewTaskManager.InsertTask(AddTask);
                GetAllTask();

            }
            catch
            {

            }
            

        }
        private void GetAllTask()
        {
            try
            {
                gvwNewTask.DataSource = li_NewTaskManager.GetALLTaskInformation();
                gvwNewTask.DataBind();
            }
            catch (Exception ex)
            {

            }
        }


        //private void AddDefaultFirstRecord()
        //{
        //    bool fromLinkButton = false;
        //    int result = 0;
        //    //creating dataTable   
        //    DataTable dt = new DataTable();
        //    DataRow dr;
        //    dt.TableName = "tblNewTask";
        //    dt.Columns.Add("TaskID", typeof(string));
        //    dt.Columns.Add("TaskName", typeof(string));
        //    dt.Columns.Add("IsHourly", typeof(string));

        //    dr = dt.NewRow();
        //    dt.Rows.Add(dr);
        //    //saving databale into viewstate   
        //    ViewState["tblNewTask"] = dt;
        //    //bind Gridview  
        //    gvwNewTask.DataSource = dt;
        //    gvwNewTask.DataBind();
        //    ViewState["LinkClick"] = fromLinkButton;
        //    Session["NewTaskforPFNB"] = result;
        //}
        //private void AddNewRecordRowToGrid()
        //{
        //    // check view state is not null  
        //    if (ViewState["tblNewTask"] != null)
        //    {
        //        //get datatable from view state

        //        DataTable dtCurrentTable = (DataTable)ViewState["tblNewTask"];
        //        DataRow drCurrentRow = null;


        //        if (dtCurrentTable.Rows.Count == 0)
        //        {
        //            AddDefaultFirstRecord();
        //        }
        //        else
        //        {
        //            if ((bool)ViewState["LinkClick"] == true)
        //            {


        //                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
        //                {
        //                    dtCurrentTable.Rows[i][0] = i + 1;
        //                    dtCurrentTable.AcceptChanges();
        //                }

        //                ViewState["LinkClick"] = false;
        //            }
        //            else
        //            {
        //                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        //                {
        //                    //add each row into data table  
        //                    drCurrentRow = dtCurrentTable.NewRow();
        //                    drCurrentRow["TaskID"] = dtCurrentTable.Rows.Count + 1;



        //                }

        //                // New row for data table

        //                drCurrentRow["TaskName"] = TaskName.Text;
        //                drCurrentRow["IsHourly"] = isHourly.Text;




        //                //Remove initial blank row  
        //                if (dtCurrentTable.Rows[0][0].ToString() == "")
        //                {
        //                    drCurrentRow["TaskID"] = dtCurrentTable.Rows.Count;
        //                    dtCurrentTable.Rows[0].Delete();
        //                    dtCurrentTable.AcceptChanges();

        //                }

        //                //add created Rows into dataTable  
        //                dtCurrentTable.Rows.Add(drCurrentRow);

        //            }

        //            //Save Data table into view state after creating each row  

        //            ViewState["tblNewTask"] = dtCurrentTable;
        //            //Bind Gridview with latest Row  
        //            gvwNewTask.DataSource = dtCurrentTable;
        //            gvwNewTask.DataBind();

        //        }
        //    }

        //}


        protected void gvwTaskInfromationSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = gvwNewTask.SelectedRow;
                ViewState["TaskID"] = row.Cells[1].Text;

                DataTable dtTask = li_NewTaskManager.GetTaskInformationByTaskIDForEdit(int.Parse(ViewState["TaskID"].ToString())).Tables[0];

                txtTaskID.Text = dtTask.Rows[0]["Edit"].ToString();

                txtTaskName.Text = dtTask.Rows[0]["TaskName"].ToString();
                txtisHourly.Text = dtTask.Rows[0]["IsHourly"].ToString();


 
                btnTaskUpdate.Enabled = true;
                AddAnother.Enabled = false;
            }
            catch (Exception)
            {

            }
        }


        protected void btnTaskUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Li_AddTask addtask = new Li_AddTask();
                addtask.TaskID = int.Parse(txtTaskID.Text);
                addtask.TaskName = txtTaskName.Text;
                addtask.IsHourly = int.Parse(txtisHourly.Text);
              
                li_NewTaskManager.Update_TaskInformation(addtask);



                string message = "Task Update Successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                script, true);

                GetAllTask();

                ClearTaskData();
                btnTaskUpdate.Enabled = false;  

            }
            catch (Exception)
            {


            }
        }


        private void ClearTaskData()
        {
            txtTaskName.Text = string.Empty;
            txtisHourly.Text = string.Empty;
            txtTaskID.Text = string.Empty;
    
        }


        protected void lbDelete_Click(object sender, EventArgs e)
        {
            //if (Session["UserID"] != null)
            //{

            //    try
            //    {

            


            //    }
            //    catch (Exception)
            //    {


            //    }
            //}
            //else
            //{
                try
                {

                    LinkButton linkButton = new LinkButton();
                    linkButton = (LinkButton)sender;
                    //DataTable dtCurrentTable = (DataTable)ViewState["tblNewTask"];
                    //dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                    //dtCurrentTable.AcceptChanges();
                    //ViewState["LinkClick"] = true;
                    //GetAllTask();
                   // AddNewRecordRowToGrid();

                    li_NewTaskManager.DeleteTaskFromDatabase(Convert.ToInt32(linkButton.CommandArgument));
                    GetAllTask();

                }
                catch (Exception)
                {


                }
           // }
        }

    }
}