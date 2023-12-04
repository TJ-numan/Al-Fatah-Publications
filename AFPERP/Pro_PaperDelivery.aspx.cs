using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PaperDelivery : System.Web.UI.Page
    {
        string FormID = "PF015";
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
                    LoadPartyName();

                    LoadPress();


                    LoadPaperType();

                    LoadPaperBrand();

                    LoadPaperOrigin();

                    dtpPaperBillDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

                    dtpPaperSupplyDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

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
            dt.TableName = "tblDelivery";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("PurchaseOrder", typeof(string));
            dt.Columns.Add("PressRNo", typeof(string));
            dt.Columns.Add("RollQty", typeof(Decimal));
            dt.Columns.Add("Press", typeof(string));
            dt.Columns.Add("PressID", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("TypeID", typeof(string));
            dt.Columns.Add("Size", typeof(string));
            dt.Columns.Add("SizeID", typeof(string));
            dt.Columns.Add("GSM", typeof(string));
            dt.Columns.Add("GSMID", typeof(string));
            dt.Columns.Add("Brand", typeof(string));
            dt.Columns.Add("BrandID", typeof(string));
            dt.Columns.Add("Origin", typeof(string));
            dt.Columns.Add("OriginID", typeof(string));
            dt.Columns.Add("SupplyDate", typeof(DateTime));
            dt.Columns.Add("Qty", typeof(Decimal));
            dt.Columns.Add("Unit", typeof(string));
            dt.Columns.Add("Price", typeof(Decimal));
            dt.Columns.Add("Amount", typeof(Decimal));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblDelivery"] = dt;
            //bind Gridview  
            gvwPaperAddedData.DataSource = dt;
            gvwPaperAddedData.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {

            DataTable dtCurrentTable = (DataTable)ViewState["tblDelivery"];
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

                    drCurrentRow["PurchaseOrder"] = ddlPaperPurchaseOrder.SelectedItem.Text;
                    drCurrentRow["PressRNo"] = txtReceiptNo . Text;

                    drCurrentRow["RollQty"] = RollQty;
                    drCurrentRow["Press"] = ddlPress.SelectedItem.Text;
                    drCurrentRow["PressID"] = ddlPress.SelectedValue;
                    drCurrentRow["Type"] = ddlPaperType.SelectedItem.Text;
                    drCurrentRow["TypeID"] = ddlPaperType.SelectedValue;
                    drCurrentRow["Size"] = ddlPaperSize.SelectedItem.Text;
                    drCurrentRow["SizeID"] = ddlPaperSize.SelectedValue;
                    drCurrentRow["GSM"] = ddlPaperGSM.SelectedItem.Text;
                    drCurrentRow["GSMID"] = ddlPaperGSM.SelectedValue;

                    drCurrentRow["Brand"] = ddlPaperBrand.SelectedItem.Text;
                    drCurrentRow["BrandID"] = ddlPaperBrand.SelectedValue;

                    drCurrentRow["Origin"] = ddlPaperOrigin.SelectedItem.Text;
                    drCurrentRow["OriginID"] = ddlPaperOrigin.SelectedValue;
                    drCurrentRow["SupplyDate"] = Convert.ToDateTime(dtpPaperSupplyDate.Text);
                    drCurrentRow["Qty"] = decimal.Parse(txtDeliveryQty.Text);
                    drCurrentRow["Unit"] = ddlPaperUnit.SelectedItem.Text;
                    drCurrentRow["Price"] = decimal.Parse(txtPaperPrice.Text);
                    drCurrentRow["Amount"] = decimal.Round((decimal.Parse(txtPaperPrice.Text) * decimal.Parse(txtDeliveryQty.Text)), 2);






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

                ViewState["tblDelivery"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwPaperAddedData.DataSource = dtCurrentTable;
                gvwPaperAddedData.DataBind();

                UpdateTotalAmount(dtCurrentTable);



            }
        }

        private void UpdateTotalAmount(DataTable dtCurrentTable)
        {
            decimal TotalAmnt = 0.0m;
            decimal lay_Cost = 0.0m;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {
                    decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                    TotalAmnt += unitTotal;
                }
            }
            lay_Cost = decimal.Parse(txtPaperLabourCost.Text);

            txtPaperTotalAmount.Text = String.Format("{0:0.##}", TotalAmnt);
            txtPaperNetAmount.Text = String.Format("{0:0.##}", TotalAmnt + lay_Cost);
        }

        private void LoadPaperOrigin()
        {
            ddlPaperOrigin.DataSource = Li_PaperOriginBasicManager.GetAllLi_PaperOriginBasics();
            ddlPaperOrigin.DataTextField = "Origin";
            ddlPaperOrigin.DataValueField = "ID";
            ddlPaperOrigin.DataBind();
            ddlPaperOrigin.Items.Insert(0, new ListItem("--select--", "0"));
        }



        private void LoadPress()
        {
            ddlPress.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlPress.DataTextField = "PressName";
            ddlPress.DataValueField = "PressID";
            ddlPress.DataBind();
            ddlPress.Items.Insert(0, new ListItem("--select--", "0"));

        }


        private void LoadPartyName()
        {
            ddlPaperSuplier.DataSource = Li_PaperPartyManager.GetAllLi_PaperParties();
            ddlPaperSuplier.DataTextField = "Name";
            ddlPaperSuplier.DataValueField = "ID";
            ddlPaperSuplier.DataBind();
            ddlPaperSuplier.Items.Insert(0, new ListItem("--select--", "0"));

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

        private void LoadPaperSize()
        {
            ddlPaperSize.DataSource = Li_PaperSizeBasicManager.GetAllLi_PaperSizeBasics();
            ddlPaperSize.DataTextField = "Size";
            ddlPaperSize.DataValueField = "SizeID";
            ddlPaperSize.DataBind();
            ddlPaperSize.Items.Insert(0, new ListItem("--select--", "0"));
        }

        protected void ddlPaperSuplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = Li_PaperPhurchaseManager.Get_UndeliveredPurchaseOrder(ddlPaperSuplier.SelectedValue);
                List<string> ls = new List<string>();
                if (ds.Tables[0].Rows.Count > 0)
                {




                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        ls.Add(ds.Tables[0].Rows[i]["OrderNo"].ToString());
                    }





                    ddlPaperPurchaseOrder.DataSource = ls;
                    ddlPaperPurchaseOrder.DataBind();
                    ddlPaperPurchaseOrder.Items.Insert(0, new ListItem("--select--", ""));
                    //cmbPurchaseOrderNo .DisplayMember =

                    ddlPaperType.SelectedValue = ds.Tables[0].Rows[0]["PaperType"].ToString();

                    ddlPaperSize.DataSource = Li_PaperSizeBasicManager.GetLi_PaperSizeBasicByID(ds.Tables[0].Rows[0]["PaperType"].ToString());
                    ddlPaperSize.DataTextField = "Size";
                    ddlPaperSize.DataValueField = "SizeID";
                    ddlPaperSize.DataBind();

                    ddlPaperSize.SelectedValue = ds.Tables[0].Rows[0]["PaperSize"].ToString();


                    ddlPaperGSM.DataSource = Li_PaperWeightBasicManager.GetAllLi_PaperWeightBasics(ds.Tables[0].Rows[0]["PaperSize"].ToString());
                    ddlPaperGSM.DataTextField = "Weight";
                    ddlPaperGSM.DataValueField = "ID";
                    ddlPaperGSM.DataBind();

                    ddlPaperGSM.SelectedValue = ds.Tables[0].Rows[0]["GSM"].ToString();
                    ddlPaperBrand.SelectedValue = ds.Tables[0].Rows[0]["PaperBrand"].ToString();
                    ddlPaperOrigin.SelectedValue = ds.Tables[0].Rows[0]["PaperOrigin"].ToString();
                }


                else
                {
                    ddlPaperPurchaseOrder.DataSource = null;
                }
            }
            catch { }
        }

        protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPaperSize.DataSource = Li_PaperSizeBasicManager.GetLi_PaperSizeBasicByID(ddlPaperType.SelectedValue.ToString());
                ddlPaperSize.DataTextField = "Size";
                ddlPaperSize.DataValueField = "SizeID";
                ddlPaperSize.DataBind();
                ddlPaperSize.Items.Insert(0, new ListItem("--select--", ""));


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

        protected void ddlPaperPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = new DataSet();
                //ds = Li_PaperPhurchaseManager.Get_UndeliveredPurchaseItemByOrder(ddlPaperPurchaseOrder.SelectedValue.ToString());
                ds = Li_PaperPhurchaseManager.Get_UndeliveredPurchaseItemByOrderAndParty(ddlPaperPurchaseOrder.SelectedValue.ToString(),ddlPaperSuplier.SelectedValue.ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {


                    ddlPaperType.SelectedValue = ds.Tables[0].Rows[0]["PaperType"].ToString();

                    ddlPaperSize.DataSource = Li_PaperSizeBasicManager.GetLi_PaperSizeBasicByID(ds.Tables[0].Rows[0]["PaperType"].ToString());
                    ddlPaperSize.DataTextField = "Size";
                    ddlPaperSize.DataValueField = "SizeID";
                    ddlPaperSize.DataBind();


                    ddlPaperUnit.DataSource = Li_Paper_M_UManager.GetAllLi_Paper_M_Us(ds.Tables[0].Rows[0]["PaperType"].ToString());
                    ddlPaperUnit.DataTextField = "Pap_U_Name";
                    ddlPaperUnit.DataValueField = "Pap_U_ID";
                    ddlPaperUnit.DataBind();

                    if (ddlPaperUnit.SelectedItem.Text == "Kg")
                    {
                        lblRoll.Visible = true;
                        txtRoll.Visible = true;

                    }

                    else
                    {
                        lblRoll.Visible = false;
                        txtRoll.Visible = false;
                    }

                    ddlPaperSize.SelectedValue = ds.Tables[0].Rows[0]["PaperSize"].ToString();
                    ddlPaperGSM.DataSource = Li_PaperWeightBasicManager.GetAllLi_PaperWeightBasics(ds.Tables[0].Rows[0]["PaperSize"].ToString());
                    ddlPaperGSM.DataTextField = "Weight";
                    ddlPaperGSM.DataValueField = "ID";
                    ddlPaperGSM.DataBind();
                    ddlPaperGSM.SelectedValue = ds.Tables[0].Rows[0]["GSM"].ToString();
                    ddlPaperBrand.SelectedValue = ds.Tables[0].Rows[0]["PaperBrand"].ToString();
                    ddlPaperOrigin.SelectedValue = ds.Tables[0].Rows[0]["PaperOrigin"].ToString();
                    txtPaperQty.Text = ds.Tables[0].Rows[0]["Qty"].ToString();
                    txtPaperPrice.Text = ds.Tables[0].Rows[0]["UnitPrice"].ToString();

                }
            }
            catch { }
        }

        protected void btnPaperAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (ddlPress.SelectedIndex < 0 || ddlPress.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a Press Name.');", true);
                    ddlPress.Focus();
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
                    ddlPaperSize.Focus();
                    return;
                }



                if (ddlPaperUnit.SelectedItem.Text == "Kg")
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


                if (txtPaperQty.Text == "" || decimal.Parse(txtPaperQty.Text) == 0.0m)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give book code and qty.');", true);
                    txtPaperQty.Focus();
                    return;
                }

                AddNewRecordRowToGrid();

            }



            catch (Exception ex)
            {

            }

        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblDelivery"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }

        protected void btnPaperSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtPaperBillNo.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give a valid  bill number');", true);
                    txtPaperBillNo.Focus();
                    return;
                }

                if (txtPaperTotalAmount.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please entry the delivery receipt');", true);

                    return;
                }

                DataTable dtCurrentTable = (DataTable)ViewState["tblDelivery"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    Li_Paper_Delivery pap_del = new Li_Paper_Delivery();
                    pap_del.Amount = decimal.Parse(txtPaperTotalAmount.Text);
                    pap_del.BillDate = Convert.ToDateTime(dtpPaperBillDate.Text);
                    pap_del.BillNo = txtPaperBillNo.Text;
                    pap_del.CauseOFDel = "";
                    pap_del.CreatedBy = int.Parse(Session["UserID"].ToString());
                    pap_del.CreatedDate = DateTime.Now;
                    pap_del.DeletBy = 0;
                    pap_del.DeleteDate = DateTime.Now;
                    pap_del.Remark = txtPaperRemark.Text;
                    pap_del.Status_D = 'C';
                    pap_del.SupplierID = ddlPaperSuplier.SelectedValue.ToString();
                    pap_del.Lay_Cost = txtPaperLabourCost.Text == "" ? 0.0m : decimal.Parse(txtPaperLabourCost.Text);
                    string DelID = Li_Paper_DeliveryManager.InsertLi_Paper_Delivery(pap_del);


                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        Li_Paper_Delivery_Detail del_Detail = new Li_Paper_Delivery_Detail();

                        del_Detail.InvID = DelID;
                        del_Detail.CreatedBy = int.Parse(Session["UserID"].ToString());
                        del_Detail.CreatedDate = DateTime.Now;
                        del_Detail.DeliveryDate = DateTime.Parse(dtCurrentTable.Rows[i]["SupplyDate"].ToString());
                        del_Detail.GSM = dtCurrentTable.Rows[i]["GSMID"].ToString();


                        del_Detail.PaperBrand = dtCurrentTable.Rows[i]["BrandID"].ToString();
                        del_Detail.PaperOrigin = dtCurrentTable.Rows[i]["OriginID"].ToString();
                        del_Detail.PressID = dtCurrentTable.Rows[i]["PressID"].ToString();
                        del_Detail.PressRefNo = dtCurrentTable.Rows[i]["PressRNo"].ToString();
                        del_Detail.Qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                        del_Detail.SizeID = dtCurrentTable.Rows[i]["SizeID"].ToString();


                        del_Detail.Status_D = 'C';
                        del_Detail.TypeID = dtCurrentTable.Rows[i]["TypeID"].ToString();
                        del_Detail.UnitPrice = decimal.Parse(dtCurrentTable.Rows[i]["Price"].ToString());
                        del_Detail.PurchaseOrder = dtCurrentTable.Rows[i]["PurchaseOrder"].ToString();
                        del_Detail.RollQty = decimal.Parse(dtCurrentTable.Rows[i]["RollQty"].ToString());
                        Li_Paper_Delivery_DetailManager.InsertLi_Paper_Delivery_Detail(del_Detail);


                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfull');", true);
                    txtPaperDeliveryID.Text = DelID;
                    //ClearAllData();
                    ViewState["tblDelivery"] = null;
                    AddDefaultFirstRecord();
                    ddlPaperSuplier.Focus();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}