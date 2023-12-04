using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class MktTsoWiseBookTarget : System.Web.UI.Page
    {
        string FormID = "MF005";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    txtStartingDate.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                    txtEndingDate.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                    AddDefaultRowToGrid();
                    LoadTerritory();
                    LoadBookEdition();
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
        private void AddDefaultRowToGrid()
        {
            bool linkClick = false;
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblBookTarget";
            dt.Columns.Add("Serial", typeof (int));
            dt.Columns.Add("BookCode", typeof (string));
            dt.Columns.Add("BookName", typeof (string));
            dt.Columns.Add("Class", typeof (string));
            dt.Columns.Add("Type", typeof (string));
            dt.Columns.Add("Edition", typeof (string));
            dt.Columns.Add("Qty", typeof (decimal));
            dt.Columns.Add("Price", typeof (decimal));
            dt.Columns.Add("Amount", typeof (decimal));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            gvwBookTarget.DataSource = dt;
            gvwBookTarget.DataBind();
            ViewState["tblBookTarget"] = dt;
            ViewState["LinkClick"] = linkClick;
        }

        private void LoadTerritory()
        {

            ddlTerritory.DataSource = Li_TeritoryManager.GetAllLi_Teritories(string.Empty);
            ddlTerritory.DataTextField = "TeritoryName";
            ddlTerritory.DataValueField = "TeritoryCode";
            ddlTerritory.DataBind();
            ddlTerritory.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        private void LoadBookEdition()
        {
            ddlEdition.DataSource = li_ChallanManager.LoadYear().Tables[0];
            ddlEdition.DataTextField = "Edition";
            ddlEdition.DataBind();
            ddlEdition.Items.Insert(0, new ListItem("-Select-", "0"));

        }
       
        protected void btnEnter_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (txtBookCode.Text != "")
                {

                    DataSet ds = new DataSet();
                    ds = li_BookVersionInfoManager.GetAll_BookVersionInfosWithRelation(txtBookCode.Text);
                    txtBookName.Text = ds.Tables[0].Rows[0]["BookName"].ToString();
                    txtType.Text = ds.Tables[0].Rows[0]["BookType"].ToString();
                    txtClass.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                    ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                    txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    txtQty.Focus();
                }
                else if (txtBookCode.Text == string.Empty)
                {
                    string message = "Please provide correct Book Code";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script,
                        true);
                }
            }
            catch (Exception)
            {


            }
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
            ClearTextData();

        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblBookTarget"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }

        private void ClearTextData()
        {
            txtBookCode.Text = string.Empty;
            txtBookName.Text = string.Empty;
            txtClass.Text = string.Empty;
            txtType.Text = string.Empty;
            ddlEdition.SelectedIndex = 0;
            txtPrice.Text = string.Empty;
            txtQty.Text = string.Empty;
        }

        private void AddNewRecordRowToGrid()
        {

            // check view state is not null  
            if (ViewState["tblBookTarget"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable) ViewState["tblBookTarget"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultRowToGrid();
                    txtTotalAmount.Text = "0.00";
                    txtTotalQuantity.Text = "0.00";

                }
                else
                {
                    if ((bool) ViewState["LinkClick"] == true)
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

                        // New row for data table

                        drCurrentRow["BookCode"] = txtBookCode.Text;
                        drCurrentRow["BookName"] = txtBookName.Text;
                        drCurrentRow["Class"] = txtClass.Text;
                        drCurrentRow["Type"] = txtClass.Text;
                        drCurrentRow["Edition"] = ddlEdition.SelectedValue;
                        drCurrentRow["Price"] = txtPrice.Text.Trim() == "" ? 0.0m: decimal.Parse(txtPrice.Text);
                        drCurrentRow["Qty"] = decimal.Parse(txtQty.Text);
                        drCurrentRow["Amount"] = decimal.Parse(txtPrice.Text)*decimal.Parse(txtQty.Text);

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

                    ViewState["tblBookTarget"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvwBookTarget.DataSource = dtCurrentTable;
                    gvwBookTarget.DataBind();


                    decimal totalQuantity = 0.0m;
                    decimal totalAmount = 0.0m;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            decimal qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                            totalQuantity += qty;
                            decimal amount = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                            totalAmount += amount;
                        }
                        txtTotalQuantity.Text = string.Format("{0:0.##}", totalQuantity);
                        txtTotalAmount.Text = String.Format("{0:0.##}", totalAmount);
                    }

                }
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            DataTable dtCurrentTable = (DataTable) ViewState["tblBookTarget"];
            if (txtTotalAmount.Text != null)
            {

                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {
                    Li_BookTarget aBookTarget = new Li_BookTarget();
                    aBookTarget.BookCode = dtCurrentTable.Rows[i]["BookCode"].ToString();
                    aBookTarget.CreatedBy = int.Parse(Session["UserID"].ToString());
                    aBookTarget.CreatedDate = DateTime.Now;
                    aBookTarget.SDate = DateTime.Parse(txtStartingDate.Text);
                    aBookTarget.EDate = DateTime.Parse(txtEndingDate.Text);
                    aBookTarget.TerritoryCode = ddlTerritory.SelectedValue;
                    aBookTarget.TSOCode = " ";
                    aBookTarget.Edition = dtCurrentTable.Rows[i]["Edition"].ToString();
                    aBookTarget.Price = decimal.Parse(dtCurrentTable.Rows[i]["Price"].ToString());
                    aBookTarget.Qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                    var affectedRow = Li_BookTargetManager.InsertLi_BookTarget(aBookTarget);

                }

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                dtCurrentTable.Rows.Clear();
                ViewState["tblBookTarget"] = null;
                gvwBookTarget.DataSource = null;
                txtTotalQuantity.Text = string.Empty;
                txtTotalAmount.Text = string.Empty;
            }

        }
    }
}