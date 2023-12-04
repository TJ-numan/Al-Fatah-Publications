using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PaperTransfer : System.Web.UI.Page
    {
        string FormID = "PF018";
        decimal RollQty = 0.0m;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    LoadPressFrom();

                    LoadPressTo();

                    LoadPaperType();

                    LoadPaperBrand();

                    dtpPaperTransferDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

                    dtpSupplyDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

                    AddDefaultFirstRecord();
                }
            }
            catch (Exception ex)
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

        private void LoadPressTo()
        {
            ddlPaperPressGodownTo.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlPaperPressGodownTo.DataTextField = "PressName";
            ddlPaperPressGodownTo.DataValueField = "PressID";
            ddlPaperPressGodownTo.DataBind();
            ddlPaperPressGodownTo.Items.Insert(0, new ListItem("--select--", "0"));
        }
        private void LoadPressFrom()
        {
            ddlPaperPressGodownFrom.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlPaperPressGodownFrom.DataTextField = "PressName";
            ddlPaperPressGodownFrom.DataValueField = "PressID";
            ddlPaperPressGodownFrom.DataBind();
            ddlPaperPressGodownFrom.Items.Insert(0, new ListItem("--select--", "0"));

        }
        private void LoadPaperBrand()
        {
            ddlPaperBrand.DataSource = Li_PaperBrandBasicManager.GetAllLi_PaperBrandBasics();
            ddlPaperBrand.DataTextField = "Brand";
            ddlPaperBrand.DataValueField = "ID";
            ddlPaperBrand.DataBind();
            ddlPaperBrand.Items.Insert(0, new ListItem("--select--", "0"));

        }
        private void LoadPaperType()
        {
            ddlPaperType.DataSource = Li_PaperTypeBasicManager.GetAllLi_PaperTypeBasics();
            ddlPaperType.DataTextField = "Type";
            ddlPaperType.DataValueField = "ID";
            ddlPaperType.DataBind();
            ddlPaperType.Items.Insert(0, new ListItem("--select--", "0"));
        }

        protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPaperSize.DataSource = Li_PaperSizeBasicManager.GetLi_PaperSizeBasicByID(ddlPaperType.SelectedValue.ToString());
                ddlPaperSize.DataTextField = "Size";
                ddlPaperSize.DataValueField = "SizeID";
                ddlPaperSize.DataBind();


                ddlPaperUnit.DataSource = Li_Paper_M_UManager.GetAllLi_Paper_M_Us(ddlPaperType.SelectedValue.ToString());
                ddlPaperUnit.DataTextField = "Pap_U_Name";
                ddlPaperUnit.DataValueField = "Pap_U_ID";
                ddlPaperUnit.DataBind();


                if (ddlPaperType.SelectedValue.ToString() == "PAT-0005")
                {
                    lblRoll.Visible = true;
                    txtRoll.Visible = true;

                }

                else
                {
                    lblRoll.Visible = false;
                    txtRoll.Visible = false;
                }

            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlPaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddlPaperGSM.DataSource = Li_PaperWeightBasicManager.GetAllLi_PaperWeightBasics(ddlPaperSize.SelectedValue.ToString());
                ddlPaperGSM.DataTextField = "Weight";
                ddlPaperGSM.DataValueField = "ID";
                ddlPaperGSM.DataBind();
            }
            catch (Exception ex)
            {
            }
        }


        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblTransfer";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("SupplyDate", typeof(DateTime));
            dt.Columns.Add("ReceiptNo", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("TypeID", typeof(string));
            dt.Columns.Add("Size", typeof(string));
            dt.Columns.Add("SizeID", typeof(string));
            dt.Columns.Add("GSM", typeof(string));
            dt.Columns.Add("GSMID", typeof(string));
            dt.Columns.Add("Brand", typeof(string));
            dt.Columns.Add("BrandID", typeof(string));
            dt.Columns.Add("Qty", typeof(Decimal));
            dt.Columns.Add("Unit", typeof(string));
            dt.Columns.Add("Price", typeof(Decimal));
            dt.Columns.Add("Bill", typeof(Decimal));
            dt.Columns.Add("RollQty", typeof(Decimal));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblTransfer"] = dt;
            //bind Gridview  
            gvwPaperTrAddedData.DataSource = dt;
            gvwPaperTrAddedData.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {

            DataTable dtCurrentTable = (DataTable)ViewState["tblTransfer"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count == 0)
            {
                AddDefaultFirstRecord();
                txtPaperTotalAmount.Text = "0.00";
                txtPaperNetAmount.Text = "0.00";
                txtPaperLabourCost.Text = "0";

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


                    drCurrentRow["SupplyDate"] = Convert.ToDateTime(dtpSupplyDate.Text);
                    drCurrentRow["ReceiptNo"] = txtPaperReceiptNo.Text;
                    drCurrentRow["Type"] = ddlPaperType.SelectedItem.Text;
                    drCurrentRow["TypeID"] = ddlPaperType.SelectedValue;
                    drCurrentRow["Size"] = ddlPaperSize.SelectedItem.Text;
                    drCurrentRow["SizeID"] = ddlPaperSize.SelectedValue;
                    drCurrentRow["GSM"] = ddlPaperGSM.SelectedItem.Text;
                    drCurrentRow["GSMID"] = ddlPaperGSM.SelectedValue;
                    drCurrentRow["Brand"] = ddlPaperBrand.SelectedItem.Text;
                    drCurrentRow["BrandID"] = ddlPaperBrand.SelectedValue;
                    drCurrentRow["Qty"] = decimal.Parse(txtPaperQty.Text);
                    drCurrentRow["Unit"] = ddlPaperUnit.SelectedItem.Text;
                    drCurrentRow["Price"] = decimal.Parse(txtPaperPrice.Text);
                    drCurrentRow["Bill"] = decimal.Round((decimal.Parse(txtPaperPrice.Text) * decimal.Parse(txtPaperQty.Text)), 2);
                    drCurrentRow["RollQty"] = RollQty;






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

                ViewState["tblTransfer"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwPaperTrAddedData.DataSource = dtCurrentTable;
                gvwPaperTrAddedData.DataBind();

                UpdateTotalAmount(dtCurrentTable);



            }
        }

        private void UpdateTotalAmount(DataTable dtCurrentTable)
        {
            decimal TotalAmnt = 0.00m;
            decimal lay_Cost = 0.00m;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {
                    decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["Bill"].ToString());
                    TotalAmnt += unitTotal;
                }
            }
            lay_Cost = txtPaperLabourCost.Text.Trim() == "" ? 0.00m : decimal.Parse(txtPaperLabourCost.Text.Trim());

            txtPaperTotalAmount.Text = String.Format("{0:0.##}", TotalAmnt);
            txtPaperNetAmount.Text = String.Format("{0:0.##}", TotalAmnt + lay_Cost);
        }

        protected void btnPaperAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPaperPressGodownFrom.SelectedIndex < 0 || ddlPaperPressGodownFrom.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a Press as source');", true);
                    ddlPaperPressGodownFrom.Focus();
                    return;
                }
                if (ddlPaperPressGodownTo.SelectedIndex < 0 || ddlPaperPressGodownTo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a Press as detination.');", true);
                    ddlPaperPressGodownTo.Focus();
                    return;
                }

                if (ddlPaperType.SelectedIndex < 0 || ddlPaperType.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a  Paper Type.');", true);

                    ddlPaperType.Focus();
                    return;
                }


                if (ddlPaperSize.SelectedIndex < 0 || ddlPaperSize.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a  Size.');", true);

                    ddlPaperSize.Focus();
                    return;
                }


                if (ddlPaperGSM.SelectedIndex < 0 || ddlPaperGSM.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a  GSM.');", true);
                    ddlPaperGSM.Focus();
                    return;
                }

                if (ddlPaperType.SelectedValue.ToString() == "PAT-0005")
                {
                    lblRoll.Visible = true;
                    txtRoll.Visible = true;
                    RollQty = txtRoll.Text != "" ? decimal.Parse(txtRoll.Text) : 0.0m;

                }

                else
                {
                    lblRoll.Visible = false;
                    txtRoll.Visible = false;
                    RollQty = 0.0m;
                }

                AddNewRecordRowToGrid();
            }
            catch (Exception)
            {


            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblTransfer"];
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
                DataTable dtCurrentTable = (DataTable)ViewState["tblTransfer"];
                if (dtCurrentTable.Rows.Count > 0)
                {

                    Li_PaperTransfer li_PaperTransfer = new Li_PaperTransfer();
                    li_PaperTransfer.RefNo = txtPaperRefNo.Text;
                    li_PaperTransfer.TotalBill = decimal.Parse(txtPaperTotalAmount.Text);
                    li_PaperTransfer.LabourBill = decimal.Parse(txtPaperLabourCost.Text);
                    li_PaperTransfer.CreatedBy = int.Parse(Session["UserID"].ToString());
                    li_PaperTransfer.CreatedDate = DateTime.Now;
                    li_PaperTransfer.TransDate = Convert.ToDateTime(dtpPaperTransferDate.Text);
                    li_PaperTransfer.PrssFrom = ddlPaperPressGodownFrom.SelectedValue.ToString();
                    li_PaperTransfer.PressTo = ddlPaperPressGodownTo.SelectedValue.ToString();
                    li_PaperTransfer.Remark = txtPaperRemark.Text;
                    li_PaperTransfer.Status_D = 'C';
                    li_PaperTransfer.DeleteDate = DateTime.Now;


                    int result = Li_PaperTransferManager.InsertLi_PaperTransfer(li_PaperTransfer);

                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        Li_PaperTransferDetail li_PaperTransferDetail = new Li_PaperTransferDetail();
                        li_PaperTransferDetail.TransNo = result;
                        li_PaperTransferDetail.PaperType = dtCurrentTable.Rows[i]["TypeID"].ToString();
                        li_PaperTransferDetail.PaperSize = dtCurrentTable.Rows[i]["SizeID"].ToString();
                        li_PaperTransferDetail.PaperGSM = dtCurrentTable.Rows[i]["GSMID"].ToString();
                        li_PaperTransferDetail.PaperBrand = dtCurrentTable.Rows[i]["BrandID"].ToString();

                        li_PaperTransferDetail.UnitPrice = decimal.Parse(dtCurrentTable.Rows[i]["Price"].ToString());

                        li_PaperTransferDetail.Qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                        li_PaperTransferDetail.RollQty = decimal.Parse(dtCurrentTable.Rows[i]["RollQty"].ToString());
                        li_PaperTransferDetail.SupplyDate = DateTime.Parse(dtCurrentTable.Rows[i]["SupplyDate"].ToString());
                        li_PaperTransferDetail.Receipt = dtCurrentTable.Rows[i]["ReceiptNo"].ToString();

                        Li_PaperTransferDetailManager.InsertLi_PaperTransferDetail(li_PaperTransferDetail);
                    }
                    txtPaperTransferNo.Text = result.ToString();

                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfull');", true);

                    dtCurrentTable.Rows.Clear();
                    ViewState["tblTransfer"] = null;
                    AddDefaultFirstRecord();
                    ClearData();
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void ClearData()
        {

            ddlPaperPressGodownFrom.SelectedIndex = 0;
            ddlPaperPressGodownTo.SelectedIndex = 0;
            ddlPaperSize.SelectedIndex = 0;
            ddlPaperType.SelectedIndex = 0;
            ddlPaperBrand.SelectedIndex = 0;
            ddlPaperGSM.SelectedIndex = 0;
            txtPaperQty.Text = "";
            ddlPaperUnit.SelectedIndex = 0;


        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string trsNo=txtPaperTransferNo.Text;
            Response.Redirect("~/Pro_PrintPaperTransfer.aspx?No=" + trsNo);
        }

    }
}