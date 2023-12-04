using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PlateTransfer : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "";
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

                    LoadPlatetype();

                    LoadPlateSize();

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
        private void LoadPlatetype()
        {
            ddlPlateType.DataSource = Li_PlateTypeBasicManager.GetAllLi_PlateTypeBasics();
            ddlPlateType.DataTextField = "Type";
            ddlPlateType.DataValueField = "ID";
            ddlPlateType.DataBind();
        }
        private void LoadPlateSize()
        {
            ddlPlateSize.DataSource = Li_PlateSizeBasicManager.GetAllLi_PlateSizeBasics();
            ddlPlateSize.DataTextField = "Size";
            ddlPlateSize.DataValueField = "ID";
            ddlPlateSize.DataBind();
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
            dt.Columns.Add("Brand", typeof(string));
            dt.Columns.Add("BrandID", typeof(string));
            dt.Columns.Add("Qty", typeof(Decimal));
            dt.Columns.Add("Rate", typeof(Decimal));
            dt.Columns.Add("Bill", typeof(Decimal));
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
                    drCurrentRow["ReceiptNo"] = txtPlateReceiptNo.Text;
                    drCurrentRow["Type"] = ddlPlateType.SelectedItem.Text;
                    drCurrentRow["TypeID"] = ddlPlateType.SelectedValue;
                    drCurrentRow["Size"] = ddlPlateSize.SelectedItem.Text;
                    drCurrentRow["SizeID"] = ddlPlateSize.SelectedValue;
                    drCurrentRow["Brand"] = ddlPlateFor.SelectedItem.Text;
                    drCurrentRow["BrandID"] = ddlPlateFor.SelectedValue;
                    drCurrentRow["Qty"] = decimal.Parse(txtPlateQty.Text);
                    drCurrentRow["Rate"] = decimal.Parse(txtPlateRate.Text);
                    drCurrentRow["Bill"] = decimal.Round((decimal.Parse(txtPlateRate.Text) * decimal.Parse(txtPlateQty.Text)), 2);



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
            decimal TotalAmnt = 0.0m;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {
                    decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["Bill"].ToString());
                    TotalAmnt += unitTotal;
                }
            }
 

            txtPaperTotalAmount.Text = String.Format("{0:0.##}", TotalAmnt);
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

                if (ddlPlateType.SelectedIndex < 0 || ddlPlateType.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a  Paper Type.');", true);

                    ddlPlateType.Focus();
                    return;
                }


                if (ddlPlateSize.SelectedIndex < 0 || ddlPlateSize.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a  Size.');", true);

                    ddlPlateSize.Focus();
                    return;
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

                    Li_PlateTransfer li_PlateTransfer = new Li_PlateTransfer();
                    li_PlateTransfer.RefNo = txtPaperRefNo.Text;
                    li_PlateTransfer.TotalBill = decimal.Parse(txtPaperTotalAmount.Text);
                    li_PlateTransfer.CreatedBy = int.Parse(Session["UserID"].ToString());
                    li_PlateTransfer.CreatedDate = DateTime.Now;
                    li_PlateTransfer.TransDate = Convert.ToDateTime(dtpPaperTransferDate.Text);
                    li_PlateTransfer.PrssFrom = ddlPaperPressGodownFrom.SelectedValue.ToString();
                    li_PlateTransfer.PressTo = ddlPaperPressGodownTo.SelectedValue.ToString();
                    li_PlateTransfer.Remark = txtPaperRemark.Text;
                    li_PlateTransfer.Status_D = 'C';
                    li_PlateTransfer.DeleteDate = DateTime.Now;


                    int result = li_PlateTransferManager.InsertLi_PlateTransfer(li_PlateTransfer);

                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        li_PlateTransferDetail li_PlateTransferDetail = new li_PlateTransferDetail();
                        li_PlateTransferDetail.TransNo = result;
                        li_PlateTransferDetail.PlateType = dtCurrentTable.Rows[i]["TypeID"].ToString();
                        li_PlateTransferDetail.PlateSize = dtCurrentTable.Rows[i]["SizeID"].ToString();
                        li_PlateTransferDetail.PlateBrand = dtCurrentTable.Rows[i]["BrandID"].ToString();
                        li_PlateTransferDetail.UnitPrice = decimal.Parse(dtCurrentTable.Rows[i]["Rate"].ToString());
                        li_PlateTransferDetail.Qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                        li_PlateTransferDetail.SupplyDate = DateTime.Parse(dtCurrentTable.Rows[i]["SupplyDate"].ToString());
                        li_PlateTransferDetail.Receipt = dtCurrentTable.Rows[i]["ReceiptNo"].ToString();

                        li_PlateTransferDetailManager.InsertLi_PlateTransferDetail(li_PlateTransferDetail);
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
            ddlPlateSize.SelectedIndex = 0;
            ddlPlateType.SelectedIndex = 0;
            ddlPlateFor.SelectedIndex = 0;
            txtPlateQty.Text = "";



        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string trsNo = txtPaperTransferNo.Text;
            try
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath(@"~/Reports/PRO/rptPrintPlateTransfer.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@TransferNo", trsNo);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Print Plate Transfer");
            }
            catch (Exception ex)
            {

            }
        }

    }
}