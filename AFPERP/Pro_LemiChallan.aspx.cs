using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_LemiChallan : System.Web.UI.Page
    {
        string FormID = "PF014";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    LoadPartyName();

                    LoadPaperType();

                    LoadPaperBrand();

                    LoadPaperOrigin();
                    AddDefaultFirstRecord();
                
                }

                if (Session["lemiMemo"] != null)
                {
                    txtMemoNo.Text = Session["lemiMemo"].ToString();
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
                        btnPaperSave.Enabled = true;
                    }
                    else
                    {
                        btnPaperSave.Enabled = false;
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
        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblLemiChallan";

            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("RollNo", typeof(string));
            dt.Columns["RollNo"].Unique = true;
            dt.Columns.Add("SizeID", typeof(string));
            dt.Columns.Add("Qty", typeof(Decimal));
            dt.Columns.Add("Measure", typeof(string));
            dt.Columns.Add("CQty", typeof(Decimal));
            dt.Columns.Add("CMeasure", typeof(string));
            dt.Columns.Add("UnitPrice", typeof(Decimal));
            dt.Columns.Add("Total", typeof(Decimal));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblLemiChallan"] = dt;
            //bind Gridview  
            gvwPaperAddedData.DataSource = dt;
            gvwPaperAddedData.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }
        private void AddNewRecordRowToGrid()
        {

            DataTable dtCurrentTable = (DataTable)ViewState["tblLemiChallan"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count == 0)
            {
                AddDefaultFirstRecord();
                txtTotalAmount.Text = "0.00";


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

                    drCurrentRow["RollNo"] = ddlRollNo.SelectedItem.Text;
                    drCurrentRow["SizeID"] = ddlPaperSize.SelectedValue;
                    drCurrentRow["Qty"] = txtQty.Text != "" ? decimal.Parse(txtQty.Text) : 0.0m;

                    drCurrentRow["Measure"] = txtMeasure.Text;
                    drCurrentRow["CQty"] = txtCQty.Text != "" ? decimal.Parse(txtCQty.Text) : 0.0m;
                    drCurrentRow["CMeasure"] = txtCMeasureUnit.Text;
                    drCurrentRow["UnitPrice"] = txtRate.Text != "" ? decimal.Parse(txtRate.Text) : 0.0m;

                    drCurrentRow["Total"] = decimal.Round((decimal.Parse(txtCQty.Text) * decimal.Parse(txtRate.Text)), 2);






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

                ViewState["tblLemiChallan"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwPaperAddedData.DataSource = dtCurrentTable;
                gvwPaperAddedData.DataBind();

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
                    decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["Total"].ToString());
                    TotalAmnt += unitTotal;
                }
            }


            txtTotalAmount.Text = String.Format("{0:0.##}", TotalAmnt);

        }

        private void LoadPaperOrigin()
        {
            ddlPaperOrigin.DataSource = Li_PaperOriginBasicManager.GetAllLi_PaperOriginBasics();
            ddlPaperOrigin.DataTextField = "Origin";
            ddlPaperOrigin.DataValueField = "ID";
            ddlPaperOrigin.DataBind();
            ddlPaperOrigin.Items.Insert(0, new ListItem("--select--", ""));
        }

        private void LoadPaperBrand()
        {
            ddlPaperBrand.DataSource = Li_PaperBrandBasicManager.GetAllLi_PaperBrandBasics();
            ddlPaperBrand.DataTextField = "Brand";
            ddlPaperBrand.DataValueField = "ID";
            ddlPaperBrand.DataBind();
            ddlPaperBrand.Items.Insert(0, new ListItem("--select--", ""));
        }

        private void LoadPaperType()
        {
            ddlPaperType.DataSource = Li_PaperTypeBasicManager.GetAllLi_PaperTypeBasics();
            ddlPaperType.DataTextField = "Type";
            ddlPaperType.DataValueField = "ID";
            ddlPaperType.DataBind();
            ddlPaperType.Items.Insert(0, new ListItem("--select--", ""));
        }

        private void LoadPartyName()
        {

            ddlPartyName.DataSource = Li_LeminatioPartyInfoManager.GetAllLi_LeminatioPartyInfos();
            ddlPartyName.DataTextField = "Name";
            ddlPartyName.DataValueField = "ID";
            ddlPartyName.DataBind();
            ddlPartyName.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        protected void ddlPaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearQty();
                ddlPaperGSM.DataSource = Li_PaperWeightBasicManager.GetAllLi_PaperWeightBasics(ddlPaperSize.SelectedValue.ToString());
                ddlPaperGSM.DataTextField = "Weight";
                ddlPaperGSM.DataValueField = "ID";
                ddlPaperGSM.DataBind();
                ddlPaperGSM.Items.Insert(0, new ListItem("--select--", ""));
            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearQty();
                ddlPaperSize.DataSource = Li_PaperSizeBasicManager.GetLi_PaperSizeBasicByID(ddlPaperType.SelectedValue.ToString());
                ddlPaperSize.DataTextField = "Size";
                ddlPaperSize.DataValueField = "SizeID";
                ddlPaperSize.DataBind();
                ddlPaperSize.Items.Insert(0, new ListItem("--select--", ""));



            }
            catch (Exception ex)
            {
            }
        }

        protected void btnPaperSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (decimal.Parse(txtTotalAmount.Text) <= 0.0m)
                {

                    return;
                }
                DataTable dtCurrentTable = (DataTable)ViewState["tblLemiChallan"];

                Li_LemiChallan lemiChallan = new Li_LemiChallan();
                lemiChallan.AgentID = ddlPartyName.SelectedValue;
                lemiChallan.AmountReceivable = decimal.Parse(txtTotalAmount.Text);
                lemiChallan.CanceledBy = Int32.Parse(Session["UserID"].ToString());
                lemiChallan.CauseOfCanel = "";
                lemiChallan.ChallanDate = Convert.ToDateTime(dtpOrderDate.Text);
                lemiChallan.ChallanID = "";
                lemiChallan.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                lemiChallan.CreatedDate = DateTime.Now;
                lemiChallan.IsDelivered = false;
                lemiChallan.IsPrinted = false;
                lemiChallan.MemoNo = 0;
                lemiChallan.PacketNo = 0;
                lemiChallan.PerPacketCost = 0;
                lemiChallan.Status_D = "C";
                lemiChallan.TotalAmount = decimal.Parse(txtTotalAmount.Text);
                lemiChallan.TotalDiscount = decimal.Parse(txtTotalAmount.Text);
                Session["lemiMemo"] = Li_LemiChallanManager.InsertLi_LemiChallan(lemiChallan);

                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {
                    Li_LemiChallanDetail lemiDetailChallan = new Li_LemiChallanDetail();
                    lemiDetailChallan.ChallanDetailID = 0;
                    lemiDetailChallan.CQty = decimal.Parse(dtCurrentTable.Rows[i]["CQty"].ToString());
                    lemiDetailChallan.DisAmt = 0.0m;
                    lemiDetailChallan.DiscountPercent = 0.0m;
                    lemiDetailChallan.MemoNo = Int32.Parse(Session["lemiMemo"].ToString());
                    lemiDetailChallan.P_S_ID =dtCurrentTable.Rows[i]["SizeID"].ToString();  ;
                    lemiDetailChallan.Qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                    lemiDetailChallan.RollNo = dtCurrentTable.Rows[i]["RollNo"].ToString();
                    lemiDetailChallan.Status_D = "C";
                    lemiDetailChallan.Total = decimal.Parse(dtCurrentTable.Rows[i]["Total"].ToString());
                    lemiDetailChallan.UnitPrice = decimal.Parse(dtCurrentTable.Rows[i]["UnitPrice"].ToString());
                    Li_LemiChallanDetailManager.InsertLi_LemiChallanDetail(lemiDetailChallan);



                }

                ClearData();
                string message = "Saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

                

                ddlPartyName.Focus();

            }
            catch (Exception ex)
            {

            }
        }

        private void ClearData()
        {


            ddlPartyName.SelectedIndex = 0;
            ddlPaperSize.SelectedIndex = 0;
            ddlPaperType.SelectedIndex = 0;
            ddlPaperBrand.SelectedIndex = 0;
            ddlPaperOrigin.SelectedIndex = 0;
            ddlPaperGSM.SelectedIndex = 0;
            txtTotalAmount.Text = "0";

            txtRemark.Text = "";


        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRollNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCQty.Text = "0.00";
                ddlPaperReceipt.SelectedValue = ddlRollNo.SelectedValue;
                txtQty.Text = ddlPaperReceipt.SelectedItem.Text;
                if (ddlPaperSize.SelectedValue == "PS-38")
                {
                    txtCQty.Text = string.Format("{0:0.##}", txtQty.Text != "" ? decimal.Parse(txtQty.Text) * 94587.50m : 0.0m);
                }

                else if (ddlPaperSize.SelectedValue == "PS-39")
                {
                    txtCQty.Text = string.Format("{0:0.##}", txtQty.Text != "" ? decimal.Parse(txtQty.Text) * 95000.00m : 0.0m);
                }
                else if (ddlPaperSize.SelectedValue == "PS-47")
                {
                    txtCQty.Text = string.Format("{0:0.##}", txtQty.Text != "" ? decimal.Parse(txtQty.Text) * 93236.25m : 0.0m);
                }
                else if (ddlPaperSize.SelectedValue == "PS-48")
                {
                    txtCQty.Text = string.Format("{0:0.##}", txtQty.Text != "" ? decimal.Parse(txtQty.Text) * 76492.50m : 0.0m);
                }
                else
                {
                    txtCQty.Text = "0.00";
                }
            }
            catch (Exception)
            {


            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = new LinkButton();
            linkButton = (LinkButton)sender;
            DataTable dtCurrentTable = (DataTable)ViewState["tblLemiChallan"];
            dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
            dtCurrentTable.AcceptChanges();
            ViewState["LinkClick"] = true;
            AddNewRecordRowToGrid();

        }

        protected void ddlPaperGSM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearQty();
                ListItem li = new ListItem("Select Any", "0");
                ddlRollNo.Items.Add(li);

                DataTable dt = new DataTable();
                dt = Li_Paper_Delivery_DetailManager.GetQtyAndReceiptByPaperCode(ddlPaperType.SelectedValue, ddlPaperSize.SelectedValue, ddlPaperGSM.SelectedValue);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem item = new ListItem(dt.Rows[i]["PressRefNo"].ToString(), dt.Rows[i]["PressRefNo"].ToString());
                    ddlRollNo.Items.Add(item);

                    ListItem item2 = new ListItem(dt.Rows[i]["Qty"].ToString(), dt.Rows[i]["PressRefNo"].ToString());
                    ddlPaperReceipt.Items.Add(item2);

                }
            }
            catch (Exception)
            {


            }


        }


        private void ClearQty()
        {
            ddlRollNo.Items.Clear();
            ddlPaperReceipt.Items.Clear();
            txtCQty.Text = "0.00";
            txtQty.Text = "0.00";
        }

        protected void btnPaperAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCQty.Text == "" || txtQty.Text == "" || decimal.Parse(txtCQty.Text) == 0.0m || decimal.Parse(txtQty.Text) == 0.0m)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a valid Roll No.');", true);
                    txtCQty.Focus();
                    return;
                }

                AddNewRecordRowToGrid();
            }
            catch (Exception)
            {


            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string Memono = txtMemoNo.Text;
            Response.Redirect("~/Pro_Rpt_LeminationChallanMemo.aspx?No=" + Memono);
        }
    }
}