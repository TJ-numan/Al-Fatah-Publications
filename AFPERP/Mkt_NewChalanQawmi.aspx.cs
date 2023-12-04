using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using BLL.Classes;

namespace BLL
{
    public partial class Mkt_NewChalanQawmi : System.Web.UI.Page
    {
        string FormID = "MF038";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();

                if (!Page.IsPostBack)
                {
                    getUserAccess();
                    dtpChalanDate.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                    LoadAgent();
                    LoadYear();
                }
                AddDefaultFirstRecord();
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
                        btnEnter.Enabled = true;
                    }
                    else
                    {
                        btnEnter.Enabled = false;
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

        private void AddDefaultFirstRecord()
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr;
                bool fromLinkButton = false;
                dt.TableName = "tblChallan";
                dt.Columns.Add("Serial", typeof(int));
                dt.Columns.Add("BookCode", typeof(string));
                dt.Columns.Add("BookName", typeof(string));
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("Class", typeof(string));
                dt.Columns.Add("Edition", typeof(string));
                dt.Columns.Add("UnitPrice", typeof(decimal));
                dt.Columns.Add("Qty", typeof(decimal));
                dt.Columns.Add("SellAmount", typeof(decimal));
                dr = dt.NewRow();
                dt.Rows.Add(dr);
                ViewState["tblChallan"] = dt;
                gvChalan.DataSource = dt;
                gvChalan.DataBind();
                ViewState["LinkClick"] = fromLinkButton;
            }
            catch (Exception)
            {

            }
        }

        private void LoadYear()
        {
            ddlEdition.DataSource = li_ChallanManager.LoadYear().Tables[0];
            ddlEdition.DataTextField = "Edition";
            ddlEdition.DataBind();

            ddlEdition.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        private void LoadAgent()
        {
            try
            {
                LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
                ddlLibraryName.DataBind();
                ddlLibraryName.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            catch (Exception)
            {

            }
        }

        protected void lblDelete_OnClick(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblChallan"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }

        }

        private void ClearTextBoxData()
        {
            txtQty.Text = string.Empty;
            txtBookName.Text = string.Empty;
            txtType.Text = string.Empty;
            txtClass.Text = string.Empty;
            ddlEdition.SelectedIndex = 0;
            txtUnitPrice.Text = string.Empty;
            txtCurrentStock.Text = string.Empty;
            txtQty.Text = string.Empty;
        }

        protected void btnChlNewAdd_OnClick(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
        }
        private void AddNewRecordRowToGrid()
        {
            // check view state is not null  
            if (ViewState["tblChallan"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblChallan"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count == 0)
                {

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

                        }
                        drCurrentRow["BookCode"] = txtBookCode.Text;
                        drCurrentRow["BookName"] = txtBookName.Text;
                        drCurrentRow["Class"] = txtClass.Text;
                        drCurrentRow["Type"] = txtType.Text;
                        drCurrentRow["Edition"] = ddlEdition.SelectedItem.Text;
                        drCurrentRow["UnitPrice"] = decimal.Parse(txtUnitPrice.Text);
                        drCurrentRow["Qty"] = decimal.Parse(txtQty.Text);
                        drCurrentRow["SellAmount"] = decimal.Parse(txtUnitPrice.Text) * Int32.Parse(txtQty.Text);
                        ClearTextBoxData();
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

                }

                //Save Data table into view state after creating each row  

                ViewState["tblChallan"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvChalan.DataSource = dtCurrentTable;
                gvChalan.DataBind();
                decimal subTotal = 0.0m;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["SellAmount"].ToString());
                        subTotal += unitTotal;
                    }
                }

                txtTotalAmount.Text = subTotal.ToString();

            }

        }
        protected void btnEnter_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = li_BookVersionInfoManager.GetAll_BookVersionInfosWithRelation_Alia(txtBookCode.Text);
                txtBookName.Text = ds.Tables[0].Rows[0]["BookName"].ToString();
                txtType.Text = ds.Tables[0].Rows[0]["BookType"].ToString();
                txtClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                txtCurrentStock.Text = ds.Tables[0].Rows[0]["StockQuantity"].ToString();
                txtUnitPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
            }
            catch (Exception)
            {


            }

        }
    }
}