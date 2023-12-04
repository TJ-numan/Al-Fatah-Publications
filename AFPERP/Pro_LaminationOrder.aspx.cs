using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_LaminationOrder : System.Web.UI.Page
    {
        string FormID = "PF011";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    LoadPress();
                    LoadBook();
                    LoadLemiParty();
                    LoadLemiType();

                    AddDefaultFirstRecord();

                    txtOrderDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
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
                        Response.Redirect("~/ProHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void LoadPress()
        {
            ddlPressName.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlPressName.DataTextField = "PressName";
            ddlPressName.DataValueField = "PressID";
            ddlPressName.DataBind();
            ddlPressName.Items.Insert(0, new ListItem("--Select--", ""));
        }



        private void LoadBook()
        {
            ddlBookName.DataSource = li_BookInformationManager.Get_BookInformations_ComboSourceData();
            ddlBookName.DataTextField = "BookName";
            ddlBookName.DataValueField = "BookID";
            ddlBookName.DataBind();
            ddlBookName.Items.Insert(0, new ListItem("--Select--", ""));
        }

        private void LoadLemiParty()
        {
            ddlLemiParty.DataSource = Li_LeminatioPartyInfoManager.GetAllLi_LeminatioPartyInfos();
            ddlLemiParty. DataTextField= "Name";
            ddlLemiParty. DataValueField= "ID";
            ddlLemiParty.DataBind();
            ddlLemiParty.Items.Insert(0, new ListItem("--Select--", ""));
        }

        private void LoadLemiType()
        {
            ddlLemiType.DataSource = Li_LaminationTypeBasicManager.GetAllLi_LaminationTypeBasics();
            ddlLemiType.DataTextField = "Type";
            ddlLemiType.DataValueField = "ID";
            ddlLemiType.DataBind();
            ddlLemiType.Items.Insert(0, new ListItem("--Select--", ""));
        }

        protected void txtOrderNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //gvLemination.Rows.Clear();

                DataSet ds = new DataSet();
                ds = Li_Print_Order_FormaManager.GetPrintOrderInforByOrderNo(txtOrderNo.Text);

                ddlBookName.SelectedValue = ds.Tables[0].Rows[0]["BookID"].ToString();
                txtGroup.Text = ds.Tables[0].Rows[0]["GName"].ToString();
                txtClassName.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                txtTypeName.Text = ds.Tables[0].Rows[0]["TypeName"].ToString();
                txtEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                ddlPressName.SelectedValue = ds.Tables[0].Rows[0]["PressID"].ToString();
                txtPrintQty.Text = ds.Tables[0].Rows[0]["PrintQty"].ToString();

            }
            catch (Exception)
            {


            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrintQty.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a cover print order for lemination order');", true);
                    return;
                }

                AddNewRecordRowToGrid(); 
            }
            catch (Exception)
            {


            }
        }

        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblLemiInfo";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("TypeId", typeof(string));
            dt.Columns.Add("PartyName", typeof(string));
            dt.Columns.Add("PartyId", typeof(string));
            dt.Columns.Add("Qty", typeof(int));


            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblLemiInfo"] = dt;
            //bind Gridview  
            gvwLamiOrder.DataSource = dt;
            gvwLamiOrder.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {


            DataTable dtCurrentTable = (DataTable)ViewState["tblLemiInfo"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count == 0)
            {
                AddDefaultFirstRecord();

            }
            else
            {
                if ((bool)ViewState["LinkClick"] == true)
                {


                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        dtCurrentTable.Rows[i][0] = i + 1;
                        dtCurrentTable.AcceptChanges();
                    }

                    ViewState["LinkClick"] = false;
                }
                else
                {


                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {



                        //add each row into data table  
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count + 1;

                        //if ( decimal .Parse  ( txtChlNewQty.Text )_== 0.0m ) 
                        //{
                        //    return;
                        //}

                    }

                    // New row for data table

                    drCurrentRow["Type"] = ddlLemiType.SelectedItem.Text;
                    drCurrentRow["TypeId"] = ddlLemiType.SelectedValue;
                    drCurrentRow["PartyName"] = ddlLemiParty.SelectedItem.Text;
                    drCurrentRow["PartyId"] = ddlLemiParty.SelectedValue;
                    drCurrentRow["Qty"] = txtQty.Text;





                    //Remove initial blank row  
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count;
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }

                    //add created Rows into dataTable  
                    dtCurrentTable.Rows.Add(drCurrentRow);
                }

                //Save Data table into view state after creating each row  

                ViewState["tblLemiInfo"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwLamiOrder.DataSource = dtCurrentTable;
                gvwLamiOrder.DataBind();


                UpdateTotalPrice(dtCurrentTable);
            }


        }


        private void UpdateTotalPrice(DataTable dtCurrentTable)
        {
            int totalQty = 0;

            for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
            {

                int _lemiQty = dtCurrentTable.Rows[i]["Qty"].ToString() != "" ? Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString()) : 0;
                totalQty += _lemiQty;

            }


            txtTotalQty.Text = totalQty.ToString();

        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblLemiInfo"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtCurrentTable = (DataTable)ViewState["tblLemiInfo"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    Li_LeminationOrder li_LeminationOrder = new Li_LeminationOrder();

                    li_LeminationOrder.OrderNo = txtOrderNo.Text;
                    li_LeminationOrder.OrderDate = DateTime.Parse(txtOrderDate.Text);
                    li_LeminationOrder.PrintOrderNo = txtOrderDate.Text;
                    li_LeminationOrder.BookCode = ddlBookName.SelectedValue.ToString() + "/" + txtEdition.Text;
                    li_LeminationOrder.TotalQty = Int32.Parse(txtTotalQty.Text);
                    li_LeminationOrder.CreatedDate = DateTime.Now;
                    li_LeminationOrder.CreatedBy = int.Parse(Session["UserID"].ToString());
                    li_LeminationOrder.DeleDate = DateTime.Now;
                    li_LeminationOrder.CauseOfDel = "";
                    li_LeminationOrder.DeleBy = int.Parse(Session["UserID"].ToString());
                    string resutl = Li_LeminationOrderManager.InsertLi_LeminationOrder(li_LeminationOrder);


                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {

                        Li_LeminationOrderDetail li_LeminationOrderDetail = new Li_LeminationOrderDetail();


                        li_LeminationOrderDetail.OrderID = resutl;
                        li_LeminationOrderDetail.LemiPartyID = dtCurrentTable.Rows[i]["PartyId"].ToString();
                        li_LeminationOrderDetail.LemiTypeID = dtCurrentTable.Rows[i]["TypeId"].ToString();
                        li_LeminationOrderDetail.Qty = Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());

                        Li_LeminationOrderDetailManager.InsertLi_LeminationOrderDetail(li_LeminationOrderDetail);

                    }

                    txtLemiOrderNo.Text = resutl;
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                    dtCurrentTable.Rows.Clear();
                    ViewState["tblLemiInfo"] = null;
                    AddDefaultFirstRecord();

                    Clear();
                }
            }
            catch (Exception)
            {


            }
        }

        private void Clear()
        {
            txtOrderDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
            txtOrderNo.Text = "";
            ddlPressName.SelectedIndex = -1;
            txtPrintQty.Text = "";
            txtGroup.Text = "";
            txtClassName.Text = "";
            txtTypeName.Text = "";
            txtEdition.Text = "";
            ddlBookName.SelectedIndex = -1;

            ddlLemiType.SelectedIndex = -1;
            ddlLemiParty.SelectedIndex = -1;
            txtQty.Text = "";
            txtTotalQty.Text = "";
        }

        
    }
}