using BLL.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PrintOrderForma : System.Web.UI.Page
    {
        string FormID = "PF036";
        string part_Book = "";
        decimal PBill = 0.0m;
        decimal PapQty = 0.0m;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    LoadCategory();

                    LoadPrintOrderBasic();


                    LoadPress();


                    LoadBookSize();


                    LoadPaperType();

                    LoadPaperBrand();

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
                        btnPrintingFSave.Enabled = true;
                    }
                    else
                    {
                        btnPrintingFSave.Enabled = false;
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
            dt.TableName = "tblPrintingOrder";
            dt.Columns.Add("Serial", typeof(string));
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

            dt.Columns.Add("part_Book", typeof(string));
            dt.Columns.Add("FormaQty", typeof(string));
            dt.Columns.Add("PaperQty", typeof(string));
            dt.Columns.Add("Unit", typeof(string));
            dt.Columns.Add("ColorNo", typeof(string));
            dt.Columns.Add("ColorBillRate", typeof(string));
            dt.Columns.Add("Amount", typeof(Decimal));
            dt.Columns.Add("FormaDes", typeof(string));
            dt.Columns.Add("PaperNote", typeof(string));
            dt.Columns.Add("PressPrintQty", typeof(string));
            dt.Columns.Add("OneSide", typeof(string));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblPrintingOrder"] = dt;
            //bind Gridview  
            gvwPrintingFShowData.DataSource = dt;
            gvwPrintingFShowData.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {


            DataTable dtCurrentTable = (DataTable)ViewState["tblPrintingOrder"];
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

                    drCurrentRow["Press"] = ddlPressName.SelectedItem.Text;
                    drCurrentRow["PressID"] = ddlPressName.SelectedValue;
                    drCurrentRow["Type"] = ddlPaperType.SelectedItem.Text;
                    drCurrentRow["TypeID"] = ddlPaperType.SelectedValue;
                    drCurrentRow["Size"] = ddlPaperSize.SelectedItem.Text;
                    drCurrentRow["SizeID"] = ddlPaperSize.SelectedValue;
                    drCurrentRow["GSM"] = ddlGSM.SelectedItem.Text;
                    drCurrentRow["GSMID"] = ddlGSM.SelectedValue;
                    drCurrentRow["Brand"] = ddlBrand.SelectedItem.Text;
                    drCurrentRow["BrandID"] = ddlBrand.SelectedValue;

                    drCurrentRow["part_Book"] = part_Book;
                    drCurrentRow["FormaQty"] = txtPressFormQty.Text;
                    drCurrentRow["PaperQty"] = txtPaperQty.Text;
                    drCurrentRow["Unit"] = ddlPaperUnit.SelectedItem.Text;

                    drCurrentRow["ColorNo"] = txtColorNo.Text;
                    drCurrentRow["ColorBillRate"] = txtBillRate.Text;
                    drCurrentRow["Amount"] = PBill;
                    drCurrentRow["FormaDes"] = txtPrintingFFormaDetail.Text;

                    drCurrentRow["PaperNote"] = txtPrintingFNotes.Text;
                    drCurrentRow["PressPrintQty"] = txtPrintQty.Text;
                    drCurrentRow["OneSide"] = ddlPrintType.SelectedIndex;






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

                ViewState["tblPrintingOrder"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwPrintingFShowData.DataSource = dtCurrentTable;
                gvwPrintingFShowData.DataBind();

                UpdateTotalAmount(dtCurrentTable);



            }
        }

        private void UpdateTotalAmount(DataTable dtCurrentTable)
        {

            decimal totalAmount = 0.0m;
            decimal totalForma = 0.0m;
            int totalGivenQty = 0;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {


                    decimal Amount = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                    decimal formaQty = decimal.Parse(dtCurrentTable.Rows[i]["FormaQty"].ToString());
                    int pressGivenQty = Int32.Parse(dtCurrentTable.Rows[i]["PressPrintQty"].ToString());

                    totalAmount += Amount;

                    totalForma += formaQty;
                    totalGivenQty += pressGivenQty;


                }
            }

            txtPrintingFTotalForma.Text = String.Format("{0:0.##}", totalForma);

            txtPrintingFTotalBill.Text = String.Format("{0:0.##}", totalAmount);

            //   lblPressPrintGivenQty.Text = totalGivenQty.ToString();            

        }

        private void LoadPrintOrderBasic()
        {
            ddlPrintSl.DataSource = Li_PrintOrderBasicManager.GetAllLi_PrintOrderBasics();
            ddlPrintSl.DataTextField = "Print_N";
            ddlPrintSl.DataValueField = "Print_Sl";
            ddlPrintSl.DataBind();
        }

        private void LoadPress()
        {
            ddlPressName.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlPressName.DataTextField = "PressName";
            ddlPressName.DataValueField = "PressID";
            ddlPressName.DataBind();
        }

        private void LoadBookSize()
        {
            ddlBookSize.DataSource = Li_BookSizeBasicManager.GetAllLi_BookSizeBasics();
            ddlBookSize.DataTextField = "SizeType";
            ddlBookSize.DataValueField = "BookSizeID";
            ddlBookSize.DataBind();
        }

        private void LoadPaperType()
        {
            ddlPaperType.DataSource = Li_PaperTypeBasicManager.GetAllLi_PaperTypeBasics_ForInnerForma(false);
            ddlPaperType.DataTextField = "Type";
            ddlPaperType.DataValueField = "ID";
            ddlPaperType.DataBind();

        }

        private void LoadPaperBrand()
        {
            ddlBrand.DataSource = Li_PaperBrandBasicManager.GetAllLi_PaperBrandBasics();
            ddlBrand.DataTextField = "Brand";
            ddlBrand.DataValueField = "ID";
            ddlBrand.DataBind();
        }

        private void LoadCategory()
        {
            ddlCategory.DataSource = Li_CategoryManager.GetAllCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlGroup.DataSource = Li_Book_GManager.GetLi_Book_GByID(ddlCategory.SelectedValue.ToString());
                ddlGroup.DataTextField = "GName";
                ddlGroup.DataValueField = "GID";
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlClass.Items.Clear();
                ddlType.Items.Clear();
                ddlBookName.Items.Clear();
                ddlEdition.Items.Clear();
            }
            catch (Exception)
            {
            }
        }

        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Classes.LoadCategory.LoadBookCalssByBookGroup(ddlClass, ddlCategory, ddlGroup);
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, new ListItem("--Select--", ""));
                ddlType.Items.Clear();
                ddlBookName.Items.Clear();
                ddlEdition.Items.Clear();
            }
            catch (Exception)
            {
            }

        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Classes.LoadCategory.LoadBookTypeByClass(ddlType, ddlClass, ddlCategory);
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("--Select--", ""));
                ddlBookName.Items.Clear();
                ddlEdition.Items.Clear();
            }
            catch (Exception)
            {
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Classes.LoadCategory.LoadBookByType(ddlBookName, ddlCategory, ddlClass, ddlType);
                ddlBookName.DataBind();
                ddlBookName.Items.Insert(0, new ListItem("--Select--", ""));
                ddlEdition.Items.Clear();
            }
            catch (Exception)
            {
            }
        }

        protected void ddlBookName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Li_PestingManager.getPestingOrderInfoByBookID(ddlBookName.SelectedValue).Tables[0];

                ddlEdition.DataSource = dt;
                ddlEdition.DataTextField = "Edition";
                ddlEdition.DataValueField = "Pest_OrderNo";
                ddlEdition.DataBind();
                ddlEdition.Items.Insert(0, new ListItem("--Select--", ""));
                
                ddlPestingType.DataSource = dt;
                ddlPestingType.DataTextField = "PestingType";
                ddlPestingType.DataValueField = "Pest_OrderNo";
                ddlPestingType.DataBind();

            }
            catch (Exception)
            {
            }
        }

        protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPaperSize.DataSource = Li_PaperSizeBasicManager.GetLi_PaperSizeBasicByID(ddlPaperType.SelectedValue.ToString());
                ddlPaperSize.DataTextField = "Size";
                ddlPaperSize.DataValueField = "SizeID";
                ddlPaperSize.DataBind();


                ddlGSM.DataSource = Li_PaperWeightBasicManager.GetAllLi_PaperWeightBasics(ddlPaperSize.SelectedValue.ToString());
                ddlGSM.DataTextField = "Weight";
                ddlGSM.DataValueField = "ID";
                ddlGSM.DataBind();

                ddlPaperUnit.DataSource = Li_Paper_M_UManager.GetAllLi_Paper_M_Us(ddlPaperType.SelectedValue.ToString());
                ddlPaperUnit.DataTextField = "Pap_U_Name";
                ddlPaperUnit.DataValueField = "Pap_U_ID";
                ddlPaperUnit.DataBind();


                if (ddlGSM.SelectedIndex != -1)
                {

                    if (ddlPaperType.SelectedValue.ToString() == "PAT-0005")
                    {
                        lblDBy.Visible = true;
                        txtDBy.Visible = true;

                        // Paper qty 

                        //( forma * print qty * 500 )/((45/43) * 1000)



                        string text = "";
                        text = ddlPaperSize.SelectedItem.Text;
                        string[] arr = text.Split(new char[] { '×' });//'×'
                        string a = arr[0];
                        string b = arr[1];
                        decimal size1 = decimal.Parse(a);
                        decimal size2 = decimal.Parse(b);
                        decimal weight = ddlGSM.SelectedItem.Text == "" ? 0.0m : decimal.Parse(ddlGSM.SelectedItem.Text);

                        decimal DBY = ddlPaperSize.SelectedItem.Text == "" ? 0.0m : (1000 / (3100000 / (size1 * size2 * weight)));
                        txtDBy.Text = string.Format("{0:0.##}", DBY);

                        decimal PQty = txtPrintQty.Text == "" ? 0.0m : decimal.Parse(txtPrintQty.Text);
                        decimal FormaPQty = txtPressFormQty.Text == "" ? 0.0m : decimal.Parse(txtPressFormQty.Text);

                        txtPaperQty.Text = string.Format("{0:0.##}", ((FormaPQty * PQty * decimal.Parse(txtDBy.Text)) / 1000));



                    }

                    else
                    {
                        lblDBy.Visible = false;
                        txtDBy.Visible = false;

                        //( forma * print qty * 500 )/(  1000)

                        decimal PQty = txtPrintQty.Text == "" ? 0.0m : decimal.Parse(txtPrintQty.Text);
                        decimal FormaPQty = txtPressFormQty.Text == "" ? 0.0m : decimal.Parse(txtPressFormQty.Text);

                        txtPaperQty.Text = string.Format("{0:0.##}", ((FormaPQty * PQty) / 1000));






                    }
                }

                //  Print Bill Amount


                int PrintQty = txtPrintQty.Text != "" ? int.Parse(txtPrintQty.Text) : 0;
                if (PrintQty > 3000)
                {
                    decimal formaQty = txtPressFormQty.Text != "" ? decimal.Parse(txtPressFormQty.Text) : 0.0m;

                    int colorNo = txtColorNo.Text != "" ? int.Parse(txtColorNo.Text) : 0;

                    decimal Price = txtBillRate.Text != "" ? decimal.Parse(txtBillRate.Text) : 0.0m;
                    decimal total = (PrintQty * formaQty * colorNo * Price) / 1000;

                    txtBillAmount.Text = string.Format("{0:0.##}", total);
                }
                else
                    txtBillAmount.Text = "Minimum Bill";

            }
            catch (Exception ex)
            {
                txtPaperQty.Text = "0";
            }
        }

        protected void ddlPaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddlGSM.DataSource = Li_PaperWeightBasicManager.GetAllLi_PaperWeightBasics(ddlPaperSize.SelectedValue.ToString());
                ddlGSM.DataTextField = "Weight";
                ddlGSM.DataValueField = "ID";
                ddlGSM.DataBind();

                if (ddlGSM.SelectedIndex != -1)
                {

                    if (ddlPaperType.SelectedValue.ToString() == "PAT-0005")
                    {
                        lblDBy.Visible = true;
                        txtDBy.Visible = true;

                        // Paper qty 

                        //( forma * print qty * 500 )/((45/43) * 1000)



                        string text = "";
                        text = ddlPaperSize.SelectedItem.Text;
                        string[] arr = text.Split(new char[] { '×' });//'×'
                        string a = arr[0];
                        string b = arr[1];
                        decimal size1 = decimal.Parse(a);
                        decimal size2 = decimal.Parse(b);
                        decimal weight = ddlGSM.SelectedItem.Text == "" ? 0.0m : decimal.Parse(ddlGSM.SelectedItem.Text);

                        decimal DBY = ddlPaperSize.SelectedItem.Text == "" ? 0.0m : (1000 / (3100000 / (size1 * size2 * weight)));
                        txtDBy.Text = string.Format("{0:0.##}", DBY);

                        decimal PQty = txtPrintQty.Text == "" ? 0.0m : decimal.Parse(txtPrintQty.Text);
                        decimal FormaPQty = txtPressFormQty.Text == "" ? 0.0m : decimal.Parse(txtPressFormQty.Text);

                        txtPaperQty.Text = string.Format("{0:0.##}", ((FormaPQty * PQty * decimal.Parse(txtDBy.Text)) / 1000));



                    }

                    else
                    {
                        lblDBy.Visible = false;
                        txtDBy.Visible = false;

                        //( forma * print qty * 500 )/(  1000)

                        decimal PQty = txtPrintQty.Text == "" ? 0.0m : decimal.Parse(txtPrintQty.Text);
                        decimal FormaPQty = txtPressFormQty.Text == "" ? 0.0m : decimal.Parse(txtPressFormQty.Text);

                        txtPaperQty.Text = string.Format("{0:0.##}", ((FormaPQty * PQty) / 1000));


                    }
                }


            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlEdition_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {


                DataSet ds = new DataSet();
                ds = Li_PestingManager.getPestingOrderInfoByBookIDEditionOrder(ddlBookName.SelectedValue.ToString(), ddlEdition.SelectedItem.Text, ddlEdition.SelectedValue.ToString(), 'F');
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Panel1.Visible = true;

                    ddlBookSize.SelectedValue = ds.Tables[0].Rows[0]["BookSizeID"].ToString();

                    ddlPrintSl.SelectedValue = ds.Tables[0].Rows[0]["PrintSl"].ToString();

                    lblFormaQty.Text = ds.Tables[0].Rows[0]["FormaTotal"].ToString();

                    DataSet dsInner = new DataSet();
                    dsInner = Li_Pesting_InnerManager.getPestingInnerDetailByOrder(ddlEdition.SelectedValue.ToString());
                    if (dsInner.Tables[0].Rows.Count > 0)
                    {

                        txtIn5.Text = dsInner.Tables[0].Rows[0]["Fi_Color"].ToString();
                        txtIn4.Text = dsInner.Tables[0].Rows[0]["Fo_Color"].ToString();
                        txtIn3.Text = dsInner.Tables[0].Rows[0]["Thr_Color"].ToString();
                        txtIn2.Text = dsInner.Tables[0].Rows[0]["Tw_Color"].ToString();
                        txtIn1.Text = dsInner.Tables[0].Rows[0]["Si_Color"].ToString();
                        txtInBW.Text = dsInner.Tables[0].Rows[0]["B_W"].ToString();

                        IsHide(txtIn5, chkIn5);
                        IsHide(txtIn4, chkIn4);
                        IsHide(txtIn3, chkIn3);
                        IsHide(txtIn2, chkIn2);
                        IsHide(txtIn1, chkIn1);
                        IsHide(txtInBW, chkInBw);




                    }


                    DataSet dsForma = new DataSet();

                    dsForma = Li_Pesting_FormaManager.getPestingFormaDetailByOrder(ddlEdition.SelectedValue.ToString());

                    if (dsForma.Tables[0].Rows.Count > 0)
                    {

                        txtForma5.Text = dsForma.Tables[0].Rows[0]["Fi_Color"].ToString();
                        txtForma4.Text = dsForma.Tables[0].Rows[0]["Fo_Color"].ToString();
                        txtForma3.Text = dsForma.Tables[0].Rows[0]["Thr_Color"].ToString();
                        txtForma2.Text = dsForma.Tables[0].Rows[0]["Tw_Color"].ToString();
                        txtForma1.Text = dsForma.Tables[0].Rows[0]["Si_Color"].ToString();
                        txtFormaBW.Text = dsForma.Tables[0].Rows[0]["B_W"].ToString();

                        IsHide(txtForma5, chkForma5);
                        IsHide(txtForma4, chkForma4);
                        IsHide(txtForma3, chkForma3);
                        IsHide(txtForma2, chkForma2);
                        IsHide(txtForma1, chkForma1);
                        IsHide(txtFormaBW, chkFormaBW);




                    }


                    DataSet dsPostani = new DataSet();

                    dsPostani = Li_Pesting_PostaniManager.getPestingPostaniDetailByOrder(ddlEdition.SelectedValue.ToString());

                    if (dsPostani.Tables[0].Rows.Count > 0)
                    {

                        txtPostani5.Text = dsPostani.Tables[0].Rows[0]["Fi_Color"].ToString();
                        txtPostani4.Text = dsPostani.Tables[0].Rows[0]["Fo_Color"].ToString();
                        txtPostani3.Text = dsPostani.Tables[0].Rows[0]["Thr_Color"].ToString();
                        txtPostani2.Text = dsPostani.Tables[0].Rows[0]["Tw_Color"].ToString();
                        txtPostani1.Text = dsPostani.Tables[0].Rows[0]["Si_Color"].ToString();
                        txtPostaniBW.Text = dsPostani.Tables[0].Rows[0]["B_W"].ToString();

                        IsHide(txtPostani5, chkPostani5);
                        IsHide(txtPostani4, chkPostani4);
                        IsHide(txtPostani3, chkPostani3);
                        IsHide(txtPostani2, chkPostani2);
                        IsHide(txtPostani1, chkPostani1);
                        IsHide(txtPostaniBW, chkPostaniBW);




                    }

                }
                else
                {
                    Panel1.Visible = false;
                }



            }

            catch (Exception ex)
            {


            }
        }

        public void IsHide(TextBox txt, CheckBox chk)
        {
            if (decimal.Parse(txt.Text) == 0.0m)
            {
                txt.Visible = false;
                chk.Visible = false;
                //txt.Hide();
                //chk.Hide();
            }
            else
            {
                txt.Visible = true;
                chk.Visible = true;

                //txt.Show();
                //chk.Show();
            }
        }

        protected void btnPrintingFAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (chkIn5.Checked || chkIn4.Checked || chkIn3.Checked || chkIn2.Checked || chkIn1.Checked || chkInBw.Checked)
                {
                    part_Book = "Inner";
                }

                else if (chkForma5.Checked || chkForma4.Checked || chkForma3.Checked || chkForma2.Checked || chkForma1.Checked || chkFormaBW.Checked)
                {
                    part_Book = "Main Forma";

                }

                else if (chkPostani5.Checked || chkPostani4.Checked || chkPostani3.Checked || chkPostani2.Checked || chkPostani1.Checked || chkPostaniBW.Checked)
                {
                    part_Book = "Postani";

                }

                else
                {
                }
                // Print Bill 

                
                try
                {
                    PBill = txtBillAmount.Text == "" ? 0.0m : decimal.Parse(txtBillAmount.Text);
                }
                catch (Exception)
                {

                    PBill = 0.0m;
                }

                if (PBill == 0.0m)
                {
                    //DialogResult response = MessageBox.Show("Print Bill is zero. Do you want to continue with this bill ?", "Al Fatah Soft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //if (response == DialogResult.No)
                    //{
                    //    return;
                    //}

                }
                
                PapQty = txtPaperQty.Text == "" ? 0.0m : decimal.Parse(txtPaperQty.Text);

                if (PapQty == 0.0m)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Paper Qty can not be zero');", true);
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
                DataTable dtCurrentTable = (DataTable)ViewState["tblPrintingOrder"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }

        protected void btnPrintingFSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkCombindQty.Checked)
                {
                    Li_Print_Order_Forma li_Print_Order_Forma = new Li_Print_Order_Forma();

                    li_Print_Order_Forma.Print_OrderNo = txtOrderNo.Text;
                    li_Print_Order_Forma.OrderDate = Convert.ToDateTime(dtpOrderDate.Text);
                    li_Print_Order_Forma.BookID = ddlBookName.SelectedValue.ToString();
                    li_Print_Order_Forma.Edition = ddlEdition.SelectedItem.Text;
                    li_Print_Order_Forma.PrintQty = Int32.Parse(txtPrintQty.Text);
                    li_Print_Order_Forma.PrintSl = Int32.Parse(ddlPrintSl.SelectedValue.ToString());
                    li_Print_Order_Forma.FormaTotal = 0.0m;
                    li_Print_Order_Forma.TotalBill = 0.0m;
                    li_Print_Order_Forma.Remark = txtRemark.Text;
                    li_Print_Order_Forma.CreatedBy = int.Parse(Session["UserID"].ToString());
                    li_Print_Order_Forma.CreatedDate = DateTime.Now;
                    li_Print_Order_Forma.Status_D = 'C';
                    li_Print_Order_Forma.DeleBy = 0;
                    li_Print_Order_Forma.DeleDate = DateTime.Now;
                    li_Print_Order_Forma.CauseOfDel = string.Empty;

                    li_Print_Order_Forma.P_Type = ddlPestingType.SelectedItem.Text;

                    li_Print_Order_Forma.S_Print = chkShortForma.Checked ? true : false;
                    li_Print_Order_Forma.O_Print = chkOtherPrint.Checked ? true : false;


                    string resutl = Li_Print_Order_FormaManager.InsertLi_Print_Order_Forma(li_Print_Order_Forma);
                    txtOrderNo.Text = resutl;
                }
                else
                {
                    if (chkOtherPrint.Checked && chkShortForma.Checked)
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please check any one of short forma  or Other print');", true);
                        return;

                    }



                    decimal givenFormaQty = txtPrintingFTotalForma.Text == "" ? 0.0m : decimal.Parse(txtPrintingFTotalForma.Text);




                    if (givenFormaQty == 0.0m)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please entry the pesting information first \r or select any  the part of the book for print order ');", true);
                        return;
                    }



                    //decimal totActualForma = lblFormaQty.Text == "." ? 0.0m : decimal.Parse(lblFormaQty.Text);
                    //if (chkShortForma.Checked || chkOtherPrint.Checked)
                    //{

                    //}
                    //else
                    //{
                    //    if (givenFormaQty != totActualForma)
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Print order incorrect.\r Please check   press wise print forma qty.');", true);
                    //        return;
                    //    }
                    //}
                    //if (txtTotalPrintQty.Text != lblPressPrintGivenQty.Text )
                    //{
                    //    MessageBox.Show("Print order incorrect. \r Please check press wise printing qty.");
                    //    return;

                    //}





                    //if (gvPap_Supply.Rows.Count != CountChkBox)
                    //{
                    //    MessageBox.Show("Book Printing order is incomplete. \n Please select missing part of the Book for Printing order.");
                    //    return;
                    //}



                    DataTable dtCurrentTable = (DataTable)ViewState["tblPrintingOrder"];
                    if (dtCurrentTable.Rows.Count > 0)
                    {

                        Li_Print_Order_Forma li_Print_Order_Forma = new Li_Print_Order_Forma();

                        li_Print_Order_Forma.Print_OrderNo = txtOrderNo.Text;
                        li_Print_Order_Forma.OrderDate = Convert.ToDateTime(dtpOrderDate.Text);
                        li_Print_Order_Forma.BookID = ddlBookName.SelectedValue.ToString();
                        li_Print_Order_Forma.Edition = ddlEdition.SelectedItem.Text;
                        li_Print_Order_Forma.PrintQty = Int32.Parse(txtPrintQty.Text);
                        li_Print_Order_Forma.PrintSl = Int32.Parse(ddlPrintSl.SelectedValue.ToString());
                        li_Print_Order_Forma.FormaTotal = Decimal.Parse(txtPrintingFTotalForma.Text);
                        li_Print_Order_Forma.TotalBill = Decimal.Parse(txtPrintingFTotalBill.Text);
                        li_Print_Order_Forma.Remark = txtRemark.Text;
                        li_Print_Order_Forma.CreatedBy = int.Parse(Session["UserID"].ToString());
                        li_Print_Order_Forma.CreatedDate = DateTime.Now;
                        li_Print_Order_Forma.Status_D = 'C';
                        li_Print_Order_Forma.DeleBy = 0;
                        li_Print_Order_Forma.DeleDate = DateTime.Now;
                        li_Print_Order_Forma.CauseOfDel = string.Empty;

                        li_Print_Order_Forma.P_Type = ddlPestingType.SelectedItem.Text;

                        li_Print_Order_Forma.S_Print = chkShortForma.Checked ? true : false;
                        li_Print_Order_Forma.O_Print = chkOtherPrint.Checked ? true : false;


                        string resutl = Li_Print_Order_FormaManager.InsertLi_Print_Order_Forma(li_Print_Order_Forma);

                        txtOrderNo.Text = resutl;

                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {


                            Li_Print_Order_FormaDetails li_Print_Order_FormaDetails = new Li_Print_Order_FormaDetails();
                            li_Print_Order_FormaDetails.Print_OrderNo = txtOrderNo.Text;
                            li_Print_Order_FormaDetails.BookPart = dtCurrentTable.Rows[i]["part_Book"].ToString();
                            li_Print_Order_FormaDetails.PressID = dtCurrentTable.Rows[i]["PressID"].ToString();
                            li_Print_Order_FormaDetails.P_TypeID = dtCurrentTable.Rows[i]["TypeID"].ToString();
                            li_Print_Order_FormaDetails.P_SizeID = dtCurrentTable.Rows[i]["SizeID"].ToString();
                            li_Print_Order_FormaDetails.P_GSMID = dtCurrentTable.Rows[i]["GSMID"].ToString();
                            li_Print_Order_FormaDetails.P_BrandID = dtCurrentTable.Rows[i]["BrandID"].ToString();
                            li_Print_Order_FormaDetails.ColorNo = Int32.Parse(dtCurrentTable.Rows[i]["ColorNo"].ToString());
                            li_Print_Order_FormaDetails.FormaQty = Decimal.Parse(dtCurrentTable.Rows[i]["FormaQty"].ToString());
                            li_Print_Order_FormaDetails.BillRate = Decimal.Parse(dtCurrentTable.Rows[i]["ColorBillRate"].ToString());
                            li_Print_Order_FormaDetails.App_Paper = Decimal.Parse(dtCurrentTable.Rows[i]["PaperQty"].ToString());
                            li_Print_Order_FormaDetails.TotalBill = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                            li_Print_Order_FormaDetails.FormaDis = dtCurrentTable.Rows[i]["FormaDes"].ToString();
                            li_Print_Order_FormaDetails.PaperNote = dtCurrentTable.Rows[i]["PaperNote"].ToString();
                            li_Print_Order_FormaDetails.PressPrintQty = Int32.Parse(dtCurrentTable.Rows[i]["PressPrintQty"].ToString());
                            li_Print_Order_FormaDetails.Side = dtCurrentTable.Rows[i]["OneSide"].ToString() == "1" ? true : false;


                            Li_Print_Order_FormaDetailsManager.InsertLi_Print_Order_FormaDetails(li_Print_Order_FormaDetails);
                        }
                    }

                    dtCurrentTable.Rows.Clear();
                    ViewState["tblPrintingOrder"] = null;
                    AddDefaultFirstRecord();
                }
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                ViewState["tblPrintingOrder"] = null;

                DataSet ds = new DataSet();
                ds = Li_PestingManager.getPestingOrderInfoByBookIDEditionOrder(ddlBookName.SelectedValue.ToString(), ddlEdition.SelectedItem.Text, ddlEdition.SelectedValue.ToString(), 'F');
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Panel1.Visible = true;


                    ddlPrintSl.SelectedValue = ds.Tables[0].Rows[0]["PrintSl"].ToString();
                }
                ClearData();

            }
            catch (Exception)
            {


            }

        }

        private void ClearData()
        {
            txtPrintingFTotalBill.Text = "";
            chkIn5.Checked = false;
            chkIn4.Checked = false;
            chkIn3.Checked = false;
            chkIn2.Checked = false;
            chkIn1.Checked = false;
            txtIn5.Text = "";
            txtIn4.Text = "";
            txtIn3.Text = "";
            txtIn2.Text = "";
            txtIn1.Text = "";
        }

        protected void btnPrintingFSupPlate_Click(object sender, EventArgs e)
        {
            string OrderNo = txtOrderNo.Text;
            //Response.Redirect("~/Pro_PlateSupply.aspx?No="+OrderNo);

            string url = "Pro_PlateSupply.aspx?No="+OrderNo;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.open('");
            sb.Append(url);
            sb.Append("');");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(),
                    "script", sb.ToString());
        }

        protected void txtPrintQty_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlPaperType.SelectedValue == "PAT-0005")
                {
                    lblDBy.Visible = true;
                    txtDBy.Visible = true;

                    // Paper qty 

                    //( forma * print qty * 500 )/((45/43) * 1000)

                    decimal DBY = txtDBy.Text == "" ? 0.0m : decimal.Parse(txtDBy.Text);
                    decimal PQty = txtPrintQty.Text == "" ? 0.0m : decimal.Parse(txtPrintQty.Text);
                    decimal FormaPQty = txtPressFormQty.Text == "" ? 0.0m : decimal.Parse(txtPressFormQty.Text);

                    decimal AppPaper = 0.0m;

                    if (ddlPrintType.SelectedIndex == 0)
                    {
                        AppPaper = ((FormaPQty * PQty * DBY) / 1000);

                    }

                    else
                    {
                        AppPaper = 2 * ((FormaPQty * PQty * DBY) / 1000);
                    }

                    txtPaperQty.Text = string.Format("{0:0.##}", AppPaper);



                }

                else
                {



                    lblDBy.Visible = false;
                    txtDBy.Visible = false;

                    decimal AppPaper = 0.0m;

                    //( forma * print qty * 500 )/(  1000)

                    decimal PQty = txtPrintQty.Text == "" ? 0.0m : decimal.Parse(txtPrintQty.Text);
                    decimal FormaPQty = txtPressFormQty.Text == "" ? 0.0m : decimal.Parse(txtPressFormQty.Text);


                    if (ddlPrintType.SelectedIndex == 0)
                    {
                        AppPaper = ((FormaPQty * PQty) / 1000);

                    }

                    else
                    {
                        AppPaper = 2 * ((FormaPQty * PQty) / 1000);
                    }

                    txtPaperQty.Text = string.Format("{0:0.##}", AppPaper);


                }

                //  Print Bill Amount


                int PrintQty = txtPrintQty.Text != "" ? int.Parse(txtPrintQty.Text) : 0;
                if (PrintQty > 3000)
                {
                    decimal papApQty = txtPaperQty.Text.Trim() != "" ? decimal.Parse(txtPaperQty.Text) : 0.0m;

                    if (papApQty >= 3.0m)
                    {
                        decimal formaQty = txtPressFormQty.Text != "" ? decimal.Parse(txtPressFormQty.Text) : 0.0m;

                        int colorNo = txtColorNo.Text != "" ? int.Parse(txtColorNo.Text) : 0;

                        decimal Price = txtBillRate.Text != "" ? decimal.Parse(txtBillRate.Text) : 0.0m;
                        decimal total = (PrintQty * formaQty * colorNo * Price) / 1000;

                        txtBillAmount.Text = string.Format("{0:0.##}", total);
                    }
                    else
                        txtBillAmount.Text = "Minimum Bill";

                }
                else
                    txtBillAmount.Text = "Minimum Bill";
            }
            catch (Exception)
            {
                txtPaperQty.Text = "0";

            }
        }

        //public void showValueAndColor(TextBox txt, CheckBox chk)
        //{
        //    if (chk.ID == chkIn4.ID || chk.ID == chkForma4.ID || chk.ID == chkPostani4.ID)
        //    {
        //        txtColorNo.Text = "4";
        //        txtColorNo.BackColor = Color.Brown;
        //        txtColorNo.ForeColor = Color.Blue;
        //        //txtColorNo.Font = new System.Drawing.Font("Arial", 13F);

        //    }

        //    else if (chk.ID == chkIn2.ID || chk.ID == chkForma2.ID || chk.ID == chkPostani2.ID)
        //    {
        //        txtColorNo.Text = "2";
        //        txtColorNo.BackColor = Color.GreenYellow;


        //    }

        //    else if (chk.ID == chkIn1.ID || chk.ID == chkForma1.ID || chk.ID == chkPostani1.ID)
        //    {
        //        txtColorNo.Text = "1";
        //        txtColorNo.BackColor = Color.LightCoral;

        //    }
        //    else
        //    {
        //        txtColorNo.Text = "1";
        //        txtColorNo.BackColor = Color.Gray;

        //    }


        //}

        //public void ShowRelateValue(CheckBox chk)
        //{

        //    if (chk.ID == chkIn4.ID)
        //    {
        //        txtPressFormQty.Text = txtIn4.Text;
        //    }
        //    else if (chk.ID == chkForma4.ID)
        //    {
        //        txtPressFormQty.Text = txtForma4.Text;
        //    }

        //    else if (chk.ID == chkPostani4.ID)
        //    {
        //        txtPressFormQty.Text = txtPostani4.Text;
        //    }

        //    else if (chk.ID == chkIn2.ID)
        //    {
        //        txtPressFormQty.Text = txtIn2.Text;
        //    }


        //    else if (chk.ID == chkForma2.ID)
        //    {
        //        txtPressFormQty.Text = txtForma2.Text;
        //    }

        //    else if (chk.ID == chkPostani2.ID)
        //    {
        //        txtPressFormQty.Text = txtPostani2.Text;
        //    }

        //    else if (chk.ID == chkIn1.ID)
        //    {
        //        txtPressFormQty.Text = txtIn1.Text;
        //    }

        //    else if (chk.ID == chkForma1.ID)
        //    {
        //        txtPressFormQty.Text = txtForma1.Text;
        //    }

        //    else if (chk.ID == chkPostani1.ID)
        //    {
        //        txtPressFormQty.Text = txtPostani1.Text;
        //    }
        //    else if (chk.ID == chkInBw.ID)
        //    {
        //        txtPressFormQty.Text = txtInBW.Text;
        //    }
        //    else if (chk.ID == chkFormaBW.ID)
        //    {
        //        txtPressFormQty.Text = txtFormaBW.Text;

        //    }
        //    else if (chk.ID == chkPostaniBW.ID)
        //    {
        //        txtPressFormQty.Text = txtPostaniBW.Text;
        //    }
        //    else
        //    {
        //    }

        //}

        protected void chkIn4_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string curName;
            //    // select only one checked from a group of check box.
            //    var Curchk = (CheckBox)sender;



            //    curName = Curchk.Checked == true ? Curchk.ID : "";

            //    foreach (Control c in Panel1.Controls)
            //    {
            //        if (c is CheckBox)
            //        {
            //            //do something
            //            CheckBox temp = (CheckBox)c;
            //            if (temp.ID == curName)
            //            {
            //                temp.Checked = true;
            //                showValueAndColor(txtIn4, temp);
            //                ShowRelateValue(temp);

            //            }

            //            else
            //            {
            //                temp.Checked = false;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        protected void ddlGSM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlGSM.SelectedIndex != -1)
                {
                    if (ddlPaperType.SelectedValue.ToString() == "PAT-0005")
                    {
                        lblDBy.Visible = true;
                        txtDBy.Visible = true;

                        // Paper qty 

                        //( forma * print qty * 500 )/((45/43) * 1000)



                        string text = "";
                        text = ddlPaperSize.SelectedItem.Text;
                        string[] arr = text.Split(new char[] { '×' });//'×'
                        string a = arr[0];
                        string b = arr[1];
                        decimal size1 = decimal.Parse(a);
                        decimal size2 = decimal.Parse(b);
                        decimal weight = ddlGSM.SelectedItem.Text == "" ? 0.0m : decimal.Parse(ddlGSM.SelectedItem.Text);

                        decimal DBY = ddlPaperSize.SelectedItem.Text == "" ? 0.0m : (1000 / (3100000 / (size1 * size2 * weight)));
                        txtDBy.Text = string.Format("{0:0.##}", DBY);

                        decimal PQty = txtPrintQty.Text == "" ? 0.0m : decimal.Parse(txtPrintQty.Text);
                        decimal FormaPQty = txtPressFormQty.Text == "" ? 0.0m : decimal.Parse(txtPressFormQty.Text);

                        txtPaperQty.Text = string.Format("{0:0.##}", ((FormaPQty * PQty * decimal.Parse(txtDBy.Text)) / 1000));



                    }

                    else
                    {
                        lblDBy.Visible = false;
                        txtDBy.Visible = false;

                        //( forma * print qty * 500 )/(  1000)

                        decimal PQty = txtPrintQty.Text == "" ? 0.0m : decimal.Parse(txtPrintQty.Text);
                        decimal FormaPQty = txtPressFormQty.Text == "" ? 0.0m : decimal.Parse(txtPressFormQty.Text);

                        txtPaperQty.Text = string.Format("{0:0.##}", ((FormaPQty * PQty) / 1000));






                    }
                }
            }
            catch (Exception)
            {


            }

        }

    }
}