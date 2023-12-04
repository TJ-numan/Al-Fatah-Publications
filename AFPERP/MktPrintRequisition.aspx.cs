using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL.Classes;
using BLL.Marketing;
using CrystalDecisions.Shared.Json;

namespace BLL
{
    public partial class MktPrintRequisition : System.Web.UI.Page
    {
        string FormID = "MF006";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");

                if (!IsPostBack)
                {
                    getUserAccess();


                    LoadAllCategory();
                    LoadReqInstruction();
                    LoadPrintOrderBasic();



                }

                if (ViewState["result"] != null)
                {
                    txtRequisitionNumber.Text = ViewState["result"].ToString();
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
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadReqInstruction()
        {

            DataSet ds = new DataSet();
            ds = Li_PrintReqManager.GetPrintReqBasic();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                chkReqInstruction.Items.Add(ds.Tables[0].Rows[i]["ReqFor"].ToString());
            }

        }
        protected void LoadAllCategory()
        {

            try
            {
                ddlCategory.DataSource = Li_CategoryManager.GetAllCategories();
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "ID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception)
            {

            }
        }


        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategory.LoadBookGroupBycategory(ddlBookGroup, ddlCategory);
            ddlBookGroup.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCategory.LoadBookCalssByBookGroup(ddlClass, ddlCategory, ddlBookGroup);
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, new ListItem("--Select--", ""));
                ddlBookType.Items.Clear();
                ddlBookName_1st.Items.Clear();
                ddlEdition_1st.Items.Clear();
            }
            catch (Exception)
            {
            }

        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCategory.LoadBookTypeByClass(ddlBookType, ddlClass, ddlCategory);
                ddlBookType.DataBind();
                ddlBookType.Items.Insert(0, new ListItem("--Select--", ""));

            }
            catch (Exception)
            {
            }
        }


        protected void ddlBookType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCategory.LoadBookByType(ddlBookName_1st, ddlCategory, ddlClass, ddlBookType);
                ddlBookName_1st.Items.Insert(0, new ListItem("--Select--", ""));
                ddlBookName_1st.DataBind();
                LoadCategory.LoadBookByType(ddlBookName_Last, ddlCategory, ddlClass, ddlBookType);
                ddlBookName_Last.Items.Insert(0, new ListItem("--Select--", ""));
                ddlBookName_Last.DataBind();

            }
            catch (Exception)
            {


            }
        }
        protected void ddlBookName_1st_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPestingType.Items.Clear();
                ddlEdition_1st.Items.Clear();
                gvwCurrentYearSell.DataSource = null; //Getting Empty the current year sales table
                gvwCurrentYearSell.DataBind();
                DataSet ds = new DataSet();
                ds = Li_PestingManager.getPestingOrderInfoByBookID(ddlBookName_1st.SelectedValue.ToString());

                //Dictionary<string, string> dls = new Dictionary<string, string>();
                //Dictionary<string, string> dlsEdition = new Dictionary<string, string>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ListItem li = new ListItem("Select Any", "0");
                    ddlPestingType.Items.Add(li);
                    ddlEdition_1st.Items.Add(li);


                    /*
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dls.Add(ds.Tables[0].Rows[i]["Pest_OrderNo"].ToString(), ds.Tables[0].Rows[i]["PestingType"].ToString());
                    }

                    ddlPestingType.DataSource = new BindingSource(dls, null);
                    ddlPestingType.DataTextField = "Value";
                    ddlPestingType.DataValueField = "Key";
                    ddlPestingType.DataBind();


                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dlsEdition.Add(ds.Tables[0].Rows[i]["Pest_OrderNo"].ToString(), ds.Tables[0].Rows[i]["Edition"].ToString());
                    }


                    ddlEdition_1st.DataSource = new BindingSource(dlsEdition, null);
                    ddlEdition_1st.DataTextField = "Value";
                    ddlEdition_1st.DataValueField = "Key";
                    ddlEdition_1st.DataBind();
                    */

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ListItem itemPesting = new ListItem(ds.Tables[0].Rows[i]["PestingType"].ToString(), ds.Tables[0].Rows[i]["Pest_OrderNo"].ToString());
                        ddlPestingType.Items.Add(itemPesting);
                        ListItem itemEdition = new ListItem(ds.Tables[0].Rows[i]["Edition"].ToString(), ds.Tables[0].Rows[i]["Pest_OrderNo"].ToString());
                        ddlEdition_1st.Items.Add(itemEdition);
                    }

                }
                else
                {
                    //LoadCategory.LoadEditionByBookID(ddlEdition_1st, ddlBookName_1st);
                    //ddlEdition_1st.DataBind();
                }
            }
            catch (Exception)
            {

            }

        }
        protected void ddlBookName_Last_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadPrintOrderBasic()
        {
            ddlPrintSl.DataSource = Li_PrintOrderBasicManager.GetAllLi_PrintOrderBasics();
            ddlPrintSl.DataTextField = "Print_N";
            ddlPrintSl.DataValueField = "Print_Sl";
            ddlPrintSl.DataBind();
            ddlPrintSl.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        protected void ddlEdition_1st_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                DataSet ds = new DataSet();
                ds = li_StockManager.GetCurrentYearSalesStatus(ddlBookName_1st.SelectedValue.ToString() + "/" + ddlEdition_1st.SelectedItem.Text);
                gvwCurrentYearSell.DataSource = ds;
                gvwCurrentYearSell.DataBind();
            }
            catch (Exception)
            {


            }

        }

        protected void ddlBookName_Last_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCategory.LoadEditionByBookID(ddlEdition_Last, ddlBookName_Last);
                ddlEdition_Last.DataBind();

            }
            catch (Exception)
            {

            }
        }

        protected void btnLoadFirst_OnClick(object sender, EventArgs e)
        {
            try
            {
               

                DropDownList ddlSelected;
                ddlSelected = (DropDownList)sender;

                if (ddlSelected.ID == "ddlPestingType")
                {
                    //if (Int32.Parse(ddlPestingType.SelectedValue) < 1)
                    {
                        gvwCurrentYearSell.DataSource = null;
                        gvwCurrentYearSell.DataBind();
                        ddlEdition_1st.SelectedValue = ddlPestingType.SelectedValue;
                       // return;
                    }
                   
                    ddlEdition_1st.SelectedValue = ddlPestingType.SelectedValue;
                    
                }
                else if (ddlSelected.ID == "ddlEdition_1st")
                {
                    //if (Int32.Parse(ddlEdition_1st .SelectedValue) < 1)
                    {
                        gvwCurrentYearSell.DataSource = null;
                        gvwCurrentYearSell.DataBind();
                        ddlPestingType.SelectedValue = ddlEdition_1st.SelectedValue;
                      //  return;
                    }

                    ddlPestingType.SelectedValue = ddlEdition_1st.SelectedValue;
                }
                else
                {

                }



                DataSet dss = new DataSet();
                dss = Li_PestingManager.getPestingOrderInfoByBookIDEditionOrder(ddlBookName_1st.SelectedValue.ToString(), ddlEdition_1st.SelectedItem.Text, ddlEdition_1st.SelectedValue.ToString(), 'F');

                ddlPrintSl.SelectedValue = dss.Tables[0].Rows[0]["PrintSl"].ToString();

                lblFormaQty.Text = "Forma Qty :" + dss.Tables[0].Rows[0]["FormaTotal"].ToString();

                gvwCurrentYearSell.DataSource = null;
                gvwCurrentYearSell.DataBind();

                DataSet ds = new DataSet();
                ds = li_StockManager.GetCurrentYearSalesStatus(ddlBookName_1st.SelectedValue.ToString() + "/" + ddlEdition_1st.SelectedItem.Text);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvwCurrentYearSell.DataSource = ds.Tables[0];
                    gvwCurrentYearSell.DataBind();
                }




            }
            catch (Exception)
            {


            }
        }

        protected void btnLoadLast_Click(object sender, EventArgs e)
        {
            try
            {

                //if (Int32.Parse(ddlEdition_Last.SelectedValue) < 1)
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                //    gvwLastYear.DataSource = null;
                //    gvwLastYear.DataBind();
                //    return;
                //}
              

                    if (ddlEdition_Last.SelectedItem.Text == ddlEdition_1st.SelectedItem.Text)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This is Current Edition. \n Please select edition from others.');", true);
                        return;
                       
                    }

                DataSet ds = new DataSet();
                ds = li_StockManager.GetLastYearSalesStatus(ddlBookName_Last.SelectedValue.ToString() + "/" + ddlEdition_Last.SelectedItem.Text);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvwLastYear.DataSource = ds.Tables[0];
                    gvwLastYear.DataBind();
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
                if (ddlBookName_1st.SelectedValue != ddlBookName_Last.SelectedValue)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Book Selection for Last Year');", true);
                    return;
                }

                ViewState["result"] = "";

                if (chkReqInstruction.SelectedItem.Selected == false)
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Print Instruction');", true);
                    return;
                }



                int printSl = Int32.Parse(ddlPrintSl.SelectedValue.ToString());

                if (txtFormaQty.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give a proposed print qty');", true);

                    return;
                }

                else
                {
                    string ExistPrintReq = Li_PrintReqManager.IsExistPrintReq(Int32.Parse(ddlPrintSl.SelectedValue.ToString()), ddlBookName_1st.SelectedValue.ToString() + "/" + ddlEdition_1st.Text);

                    if (ExistPrintReq != "")
                    {
                        DialogResult response = MessageBox.Show("This Book Print Requisition " + ddlPrintSl.Text + " as " + ExistPrintReq + " is already in pending status. \b Do you want to continue with next print serial ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (response == DialogResult.No)
                        {
                            return;
                        }

                        else
                        {

                            ddlPrintSl.SelectedValue = (printSl + 1).ToString();
                        }
                    }


                    Li_PrintReq li_printreq = new Li_PrintReq();
                    li_printreq.CauseOfDel = "";
                    li_printreq.CreatedBy = int.Parse(Session["UserID"].ToString());
                    li_printreq.CreatedDate = DateTime.Now;
                    li_printreq.DelDate = DateTime.Now;
                    li_printreq.GoRecDate = DateTime.Parse(dtpGodownRcvDate.Text);
                    li_printreq.PestType = ddlPestingType.Text;
                    li_printreq.ProposedQty = Int32.Parse(txtFormaQty.Text);
                    li_printreq.Remark = txtRemark.Text;
                    li_printreq.Req_Date = DateTime.Parse(dtpDate.Text);
                    li_printreq.Statud_D = 'C';
                    ViewState["result"] = Li_PrintReqManager.InsertLi_PrintReq(li_printreq);


                    for (int i = 0; i < gvwCurrentYearSell.Rows.Count; i++)
                    {
                        Li_PrintReq_Cur li_reqcur = new Li_PrintReq_Cur();
                        li_reqcur.BookCode = ddlBookName_1st.SelectedValue + "/" + ddlEdition_1st.SelectedItem.Text;
                        li_reqcur.PrintSl = Convert .ToInt32( ddlPrintSl.SelectedValue);
                        li_reqcur.Target = Convert.ToInt32(gvwCurrentYearSell.Rows[i].Cells[0].Text);
                        li_reqcur.PrintReq = Convert.ToInt32(gvwCurrentYearSell.Rows[i].Cells[1].Text);
                        li_reqcur.Printed = Convert.ToInt32(gvwCurrentYearSell.Rows[i].Cells[2].Text);
                        li_reqcur.Receive = Convert.ToInt32(gvwCurrentYearSell.Rows[i].Cells[3].Text);
                        li_reqcur.Challan = Convert.ToInt32(string.Format("{0}", gvwCurrentYearSell.Rows[i].Cells[4].Text));
                        li_reqcur.RetQty = Convert.ToInt32(gvwCurrentYearSell.Rows[i].Cells[5].Text);
                        li_reqcur.Specimen = Convert.ToInt32(gvwCurrentYearSell.Rows[i].Cells[7].Text);
                        li_reqcur.StockQty = Convert.ToInt32(gvwCurrentYearSell.Rows[i].Cells[8].Text);
                        li_reqcur.RetStkQty = Convert.ToInt32(gvwCurrentYearSell.Rows[i].Cells[9].Text);
                        li_reqcur.StockInHand = Convert.ToInt32(gvwCurrentYearSell.Rows[i].Cells[10].Text);

                        li_reqcur.ReqNo = ViewState["result"].ToString();
                        Li_PrintReq_CurManager.InsertLi_PrintReq_Cur(li_reqcur);
                    }





                    if (gvwLastYear.Rows.Count > 0)
                    {
                        for (int i = 0; i < gvwLastYear.Rows.Count; i++)
                        {
                            Li_PrintReq_Last lireqlast = new Li_PrintReq_Last();
                            lireqlast.BookCode = gvwLastYear.Rows[i].Cells[0].Text;
                            lireqlast.Challan = Int32.Parse(gvwLastYear.Rows[i].Cells[3].Text);
                            lireqlast.Damage = Int32.Parse(gvwLastYear.Rows[i].Cells[6].Text);

                            lireqlast.Printed = Int32.Parse(gvwLastYear.Rows[i].Cells[1].Text);
                            lireqlast.Rebinding = Int32.Parse(gvwLastYear.Rows[i].Cells[5].Text);
                            lireqlast.Rec_Qty = Int32.Parse(gvwLastYear.Rows[i].Cells[2].Text);
                            lireqlast.ReqNo = ViewState["result"].ToString();
                            lireqlast.Specimen = Int32.Parse(gvwLastYear.Rows[i].Cells[4].Text);
                            lireqlast.StartDate = DateTime.Parse(gvwLastYear.Rows[i].Cells[8].Text);
                            lireqlast.EndDate = DateTime.Parse(gvwLastYear.Rows[i].Cells[9].Text);
                            lireqlast.StockInHand = Int32.Parse(gvwLastYear.Rows[i].Cells[7].Text);
                            Li_PrintReq_LastManager.InsertLi_PrintReq_Last(lireqlast);
                        }
                    }
                    else
                    {

                        Li_PrintReq_Last lireqlast = new Li_PrintReq_Last();
                        lireqlast.BookCode = "New Book";
                        lireqlast.Challan = 0;
                        lireqlast.Damage = 0;
                        lireqlast.Printed = 0;
                        lireqlast.Rebinding = 0;
                        lireqlast.Rec_Qty = 0;
                        lireqlast.ReqNo = ViewState["result"].ToString();
                        lireqlast.Specimen = 0;
                        lireqlast.StartDate = DateTime.Now;
                        lireqlast.EndDate = DateTime.Now;
                        lireqlast.StockInHand = 0;
                        Li_PrintReq_LastManager.InsertLi_PrintReq_Last(lireqlast);

                    }


                    for (int i = 0; i < chkReqInstruction.Items.Count; i++)
                    {

                        Li_PrintReqApplied reqfor = new Li_PrintReqApplied();
                        reqfor.IsApplied = false;
                        reqfor.ReqForID = i + 1;
                        reqfor.ReqNo = ViewState["result"].ToString();
                        Li_PrintReqAppliedManager.InsertLi_PrintReqApplied(reqfor);

                    }



                    // Display in a message box all the items that are checked. 




                    for (int i = 0; i < chkReqInstruction.Items.Count; i++)
                    {
                        Li_PrintReqApplied reqfor = new Li_PrintReqApplied();

                        if (chkReqInstruction.Items[i].Selected)
                        {
                            reqfor.IsApplied = true;
                            reqfor.ReqForID = i + 1;
                            reqfor.ReqNo = ViewState["result"].ToString();
                            Li_PrintReqAppliedManager.UpdateLi_PrintReqApplied(reqfor);
                        }



                    }







                    txtRequisitionNumber.Text = ViewState["result"].ToString();

                    string message = "Saved successfully.";

                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);






                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string RequisitionNo = txtRequisitionNumber.Text;
                Response.Redirect("~/Mkt_Rpt_PrintOrderRequisition.aspx");
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnUpdte_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvwCurrentYearSell.Rows.Count; i++)
            {
                Li_PrintReq_Cur li_reqcur = new Li_PrintReq_Cur();
                li_reqcur.BookCode = ddlBookName_1st.SelectedValue + "/" + ddlEdition_1st.SelectedItem.Text;
                li_reqcur.Target =Convert.ToInt32( gvwCurrentYearSell.Rows[i].Cells[0].Text);
                li_reqcur. PrintReq  = Convert.ToInt32 (gvwCurrentYearSell.Rows[i].Cells[1].Text);
                li_reqcur.Printed =Convert.ToInt32 (gvwCurrentYearSell.Rows[i].Cells[2].Text);
                li_reqcur.Receive =Convert.ToInt32  (gvwCurrentYearSell.Rows[i].Cells[3].Text);
                li_reqcur.Challan =Convert.ToInt32  (string.Format("{0}", gvwCurrentYearSell.Rows[i].Cells[4].Text)); 
                li_reqcur.RetQty = Convert.ToInt32 (gvwCurrentYearSell.Rows[i].Cells[5].Text);
                li_reqcur.Specimen =Convert.ToInt32  (gvwCurrentYearSell.Rows[i].Cells[7].Text);
                li_reqcur.StockInHand =Convert.ToInt32  (gvwCurrentYearSell.Rows[i].Cells[10].Text);
                li_reqcur.ReqNo =  txtRequisitionNumber.Text;
                Li_PrintReq_CurManager. UpdateLi_PrintReq_Cur(li_reqcur);

                string message = "Updated successfully.";

                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);



            }
        }

    }

}




