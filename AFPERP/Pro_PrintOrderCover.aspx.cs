using BLL.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PrintOrderCover : System.Web.UI.Page
    {
        string FormID = "PF035";
        decimal BookFormaQty = 0.0m;
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
                        btnPrintingCSave.Enabled = true;
                        btnPrintingCSupPlate.Enabled = true;
                    }
                    else
                    {
                        btnPrintingCSave.Enabled = false;
                        btnPrintingCSupPlate.Enabled = false;
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
        private void LoadCategory()
        {
            ddlCategory.DataSource = Li_CategoryManager.GetAllCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));

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
            ddlPaperType.DataSource = Li_PaperTypeBasicManager.GetAllLi_PaperTypeBasics_ForInnerForma(true);
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

        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblCoverPrintOrder";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("Ups", typeof(string));
            dt.Columns.Add("Impression", typeof(string));
            dt.Columns.Add("ColorNo", typeof(string));
            dt.Columns.Add("BillRate", typeof(Decimal));
            dt.Columns.Add("Amount", typeof(Decimal));
            dt.Columns.Add("CoverQty", typeof(string));
            dt.Columns.Add("OtherPrint", typeof(string));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblCoverPrintOrder"] = dt;
            //bind Gridview  
            gvwPrintingCShowData.DataSource = dt;
            gvwPrintingCShowData.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {


            DataTable dtCurrentTable = (DataTable)ViewState["tblCoverPrintOrder"];
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

                    drCurrentRow["Ups"] = txtUps.Text;
                    drCurrentRow["Impression"] = txtImpression.Text;
                    drCurrentRow["ColorNo"] = txtColorNo.Text;
                    drCurrentRow["BillRate"] = txtBillRate.Text;
                    drCurrentRow["Amount"] = PBill;

                    drCurrentRow["CoverQty"] = txtColorNo.Text;
                    drCurrentRow["OtherPrint"] = txtBillRate.Text;






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

                ViewState["tblCoverPrintOrder"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwPrintingCShowData.DataSource = dtCurrentTable;
                gvwPrintingCShowData.DataBind();

                UpdateTotalPrice(dtCurrentTable);



            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblCoverPrintOrder"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }

        protected void btnPrintingFAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Print Bill 
                decimal PBill = 0.0m;
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

                    //string str = "Are you sure, you want to Approve this Record?";
                    //this.ClientScript.RegisterStartupScript(typeof(Page), "Popup", "ConfirmApproval('" + str + "');", true);
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Confirm()", true);
                    //string confirmValue = Request.Form["confirm_value"];
                    //if (confirmValue == "Yes")
                    //{
                    //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                    //}
                    //else
                    //{
                    //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
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

        private void UpdateTotalPrice(DataTable dtCurrentTable)
        {

            decimal totalAmount = 0.0m;
            int totalImpression = 0;
            int totalCoverQty = 0;


            for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
            {


                decimal Amount = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                int impression = Int32.Parse(dtCurrentTable.Rows[i]["Impression"].ToString());
                int coverQty = Int32.Parse(dtCurrentTable.Rows[i]["CoverQty"].ToString());

                totalAmount += Amount;

                totalImpression += impression;
                totalCoverQty += coverQty;


            }

            txtTotalImpression.Text = String.Format("{0:0.##}", totalImpression);

            txtTotalBill.Text = String.Format("{0:0.##}", totalAmount);

            txtTotalCover.Text = totalCoverQty.ToString();



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



                BookFormaQty = txtFormaQty.Text == "" ? 0.0m : decimal.Parse(txtFormaQty.Text);

                ddlPaperSize.DataSource = Li_PaperSizeBasicManager.GetLi_PaperSizeBasicByID(ddlPaperType.SelectedValue.ToString());
                ddlPaperSize.DataTextField = "Size";
                ddlPaperSize.DataValueField = "SizeID";
                ddlPaperSize.DataBind();



                ddlPaperUnit.DataSource = Li_Paper_M_UManager.GetAllLi_Paper_M_Us(ddlPaperType.SelectedValue.ToString());
                ddlPaperUnit.DataTextField = "Pap_U_Name";
                ddlPaperUnit.DataValueField = "Pap_U_ID";
                ddlPaperUnit.DataBind();


                int Setting = txtSettingPerSheet.Text != "" ? Int32.Parse(txtSettingPerSheet.Text) : 0;
                // if paper is board selected

                if (ddlPaperType.SelectedValue.ToString() == "PAT-0001")
                {
                    // for DC 1/8 
                    if (ddlBookSize.SelectedValue.ToString() == "BS-001")
                    {
                        Setting = 8;
                    }
                    // for DD 1/16 
                    else if (ddlBookSize.SelectedValue.ToString() == "BS-002")
                    {
                        Setting = 8;
                    }
                    // for SDD 1/8 
                    else if (ddlBookSize.SelectedValue.ToString() == "BS-003")
                    {
                        Setting = 5;
                    }

                     // for RL 1/12

                    else if (ddlBookSize.SelectedValue.ToString() == "BS-007")
                    {
                        Setting = 9;
                    }

                    else
                    {
                    }


                    decimal PQty = txtPressPrintQty.Text == "" ? 0.0m : decimal.Parse(txtPressPrintQty.Text);

                    txtSettingPerSheet.Text = Setting.ToString();

                    txtPaperQty.Text = string.Format("{0:0.##}", ((PQty / Setting) / 100));

                    txtPaperSheetQty.Text = string.Format("{0:0.##}", (PQty / Setting));


                }

                else if (ddlPaperType.SelectedValue.ToString() == "PAT-0002")
                {



                    // for DC 1/8 


                    if (ddlBookSize.SelectedValue.ToString() == "BS-001")
                    {
                        Setting = 4;
                    }

                    // for DD 1/16 

                    else if (ddlBookSize.SelectedValue.ToString() == "BS-002")
                    {  // calculate forma qty 
                        if (BookFormaQty <= 34.0m)
                        {
                            Setting = 8;
                            ddlPaperSize.SelectedValue = "PS-03";
                        }
                        else
                        {
                            Setting = 4;
                            ddlPaperSize.SelectedValue = "PS-02";
                        }


                    }
                    // for SDD 1/8 
                    else if (ddlBookSize.SelectedValue.ToString() == "BS-003")
                    {

                        Setting = 4;
                        ddlPaperSize.SelectedValue = "PS-03";

                    }

                     // for RL 1/12

                    //else if (cmbBookSize.SelectedValue.ToString() == "BS-007")
                    //{
                    //    Setting = 9;
                    //}
                    else
                    {
                    }


                    decimal PQty = txtPressPrintQty.Text == "" ? 0.0m : decimal.Parse(txtPressPrintQty.Text);

                    txtSettingPerSheet.Text = Setting.ToString();

                    txtPaperQty.Text = string.Format("{0:0.##}", ((PQty / Setting) / 500));

                    txtPaperSheetQty.Text = string.Format("{0:0.##}", (PQty / Setting));






                }
                //PAT-0007
                else
                {
                    int DivisibleBy = 0;
                    if (ddlPaperUnit.SelectedItem.Text == "Packet")
                    {
                        DivisibleBy = 100;

                    }
                    else if (ddlPaperUnit.SelectedItem.Text == "Rim")
                    {
                        DivisibleBy = 500;
                    }
                    else
                    {
                    }
                    Setting = txtSettingPerSheet.Text != "" ? Int32.Parse(txtSettingPerSheet.Text) : 0;

                    decimal PQty = txtPressPrintQty.Text == "" ? 0.0m : decimal.Parse(txtPressPrintQty.Text);

                    txtPaperQty.Text = string.Format("{0:0.##}", ((PQty / Setting) / DivisibleBy));

                    txtPaperSheetQty.Text = string.Format("{0:0.##}", (PQty / Setting));
                }



                //  Print Bill Amount


                int PrintQty = txtPressPrintQty.Text != "" ? int.Parse(txtPressPrintQty.Text) : 0;

                if (PrintQty > 3000)
                {
                    //decimal formaQty = txtPaperSheetQty.Text != "" ? decimal.Parse(txtPaperSheetQty.Text) : 0.0m;

                    //int colorNo = txtColorNo.Text != "" ? int.Parse(txtColorNo.Text) : 0;

                    //decimal Price = txtBillRate.Text != "" ? decimal.Parse(txtBillRate.Text) : 0.0m;
                    //decimal total = (PrintQty * formaQty * colorNo * Price) / 1000;

                    //txtBillAmount.Text = string.Format("{0:0.##}", total);
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

                ddlPaperGsm.DataSource = Li_PaperWeightBasicManager.GetAllLi_PaperWeightBasics(ddlPaperSize.SelectedValue.ToString());
                ddlPaperGsm.DataTextField = "Weight";
                ddlPaperGsm.DataValueField = "ID";
                ddlPaperGsm.DataBind();

                /*

                                   if (cmbPaperName.SelectedValue.ToString() == "PAT-0001")
                                   {
 
                                   }
                                   else if (cmbPaperName.SelectedValue.ToString() == "PAT-0002")
                                   {

                                       string text = "";
                                       text = cmbPaperSize.Text;
                                       string[] arr = text.Split(new char[] { '×' });//'×'
                                       string a = arr[0];
                                       string b = arr[1];
                                       decimal size1 = decimal.Parse(a);
                                       decimal size2 = decimal.Parse(b);
                                       decimal weight = cmbPaperGsm.Text == "" ? 0.0m : decimal.Parse(cmbPaperGsm.Text);

                                       decimal DBY = cmbPaperSize.Text == "" ? 0.0m : (1000 / (3100000 / (size1 * size2 * weight)));
                                       txtSettingPerSheet.Text = string.Format("{0:0.##}", DBY);

                                       decimal PQty = txtTotalPrintQty.Text == "" ? 0.0m : decimal.Parse(txtTotalPrintQty.Text);
                                       decimal FormaPQty = txtPaperSheetQty.Text == "" ? 0.0m : decimal.Parse(txtPaperSheetQty.Text);

                                       txtPaperQty.Text = string.Format("{0:0.##}", ((FormaPQty * PQty * decimal.Parse(txtSettingPerSheet.Text)) / 1000));



                                   }

                                   else
                                   {

 





                                   }
                
               */

            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlEdition_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            ds = Li_PestingManager.getPestingOrderInfoByBookIDEditionOrder(ddlBookName.SelectedValue, ddlEdition.SelectedItem.Text, ddlEdition.SelectedValue, 'C');// c for cover print 
            if (ds.Tables[0].Rows.Count > 0)
            {


                ddlBookSize.SelectedValue = ds.Tables[0].Rows[0]["BookSizeID"].ToString();

                ddlPrintSl.SelectedValue = ds.Tables[0].Rows[0]["PrintSl"].ToString();

                BookFormaQty = decimal.Parse(ds.Tables[0].Rows[0]["FormaTotal"].ToString());


                txtFormaQty.Text = ds.Tables[0].Rows[0]["FormaTotal"].ToString();



            }
            else
            {

            }


        }

        protected void chkShortForma_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                //System.Windows.Forms.Control chkBox;

                //chkBox = ((System.Windows.Forms.CheckBox)sender);

                //if (chkBox.Name == "chkShortForma")
                //{
                //if (chkShortForma.Checked)
                //{
                //    chkOtherPrint.Checked = false;
                //    txtPressPrintQty.ReadOnly = true;
                //    lblPressPrintGivenQty.Text = "Short Forma";
                //    int selectIn = cmbPrintSl.SelectedIndex;
                //    cmbPrintSl.SelectedIndex = selectIn - 1;
                //    cmbPestingType.Enabled = false;
                //    cmbEddition.Enabled = false;
                //    cmbBookName.Enabled = false;
                //}

                //else //if (chkOtherPrint.Checked)
                //{
                //    chkShortForma.Checked = false;
                //    txtPressPrintQty.ReadOnly = false;
                //    lblPressPrintGivenQty.Text = ".";
                //    int selectIn = cmbPrintSl.SelectedIndex;
                //    cmbPrintSl.SelectedIndex = selectIn + 1;
                //    cmbPestingType.Enabled = true;
                //    cmbEddition.Enabled = true;
                //    cmbBookName.Enabled = true;

                //}
                //}



                //else
                //{
                //    if (chkShortForma.Checked)
                //    {
                //        chkShortForma.Checked = false;
                //        txtPressPrintQty.ReadOnly = false;
                //        lblPressPrintGivenQty.Text = ".";
                //        int selectIn = cmbPrintSl.SelectedIndex;
                //        cmbPrintSl.SelectedIndex = selectIn + 1;
                //        cmbPestingType.Enabled = true;
                //        cmbEddition.Enabled = true;
                //        cmbBookName.Enabled = true;
                //    }

                //    else //if (chkOtherPrint.Checked)
                //    {



                //    }

                //}
            }
            catch (Exception)
            {


            }
        }

        protected void txtPcsPerSheet_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // get impression number

                decimal SheetQty = txtPaperSheetQty.Text == "" ? 0.0m : decimal.Parse(txtPaperSheetQty.Text);
                decimal PcsPerSheet = txtPcsPerSheet.Text == "" ? 0.0m : decimal.Parse(txtPcsPerSheet.Text);
                decimal Impression = txtImpression.Text == "" ? 0.0m : decimal.Parse(txtImpression.Text);


                txtTotalSheet.Text = (SheetQty * PcsPerSheet).ToString();

                // get print bill 



                int colorNo = txtColorNo.Text == "" ? 0 : Int32.Parse(txtColorNo.Text);
                decimal printRate = txtBillRate.Text == "" ? 0.0m : decimal.Parse(txtBillRate.Text);

                if (Impression < 3000)
                {

                    txtBillAmount.Text = "Minimum Bill";
                }
                else
                {
                    txtBillAmount.Text = ((Impression * colorNo * printRate) / 1000).ToString();

                }


            }
            catch (Exception)
            {


            }
        }

        protected void btnPrintingCSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (chkOther.Checked && chkShortForma.Checked)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please check any one of short forma  or Other print');", true);
                    return;

                }



                decimal givenFormaQty = txtTotalCover.Text == "" ? 0.0m : decimal.Parse(txtTotalCover.Text);




                if (givenFormaQty == 0.0m)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please entry the pesting information first \r or select any  the part of the book for print order');", true);
                    return;
                }



                if (chkShortForma.Checked || chkOther.Checked)
                {

                }
                else
                {

                }
                DataTable dtCurrentTable = (DataTable)ViewState["tblCoverPrintOrder"];
                if (dtCurrentTable.Rows.Count > 0)
                {

                    Li_Print_Order_Cover li_Print_Order_Cover = new Li_Print_Order_Cover();
                    li_Print_Order_Cover.Print_OrderNo = txtOrderNo.Text;
                    li_Print_Order_Cover.OrderDate = DateTime.Parse(dtpOrderDate.Text);
                    li_Print_Order_Cover.BookCode = ddlBookName.SelectedValue;
                    li_Print_Order_Cover.PressID = ddlPressName.SelectedValue;
                    li_Print_Order_Cover.PrintQty = Int32.Parse(txtPressPrintQty.Text);
                    li_Print_Order_Cover.PrintSl = Int32.Parse(ddlPrintSl.SelectedValue);
                    li_Print_Order_Cover.FormaTotal = txtFormaQty.Text != "" ? Decimal.Parse(txtFormaQty.Text) : 0.0m;
                    li_Print_Order_Cover.PaperType = ddlPaperType.SelectedValue;
                    li_Print_Order_Cover.PaperSize = ddlPaperSize.SelectedValue;
                    li_Print_Order_Cover.PaperGsm = ddlPaperGsm.SelectedValue;
                    li_Print_Order_Cover.BrandID = ddlBrand.SelectedValue;
                    li_Print_Order_Cover.Sett_Sheet = Int32.Parse(txtSettingPerSheet.Text);
                    li_Print_Order_Cover.App_Paper = Decimal.Parse(txtPaperQty.Text);
                    li_Print_Order_Cover.Pcs_Sheet = Decimal.Parse(txtPcsPerSheet.Text);
                    li_Print_Order_Cover.TotalPcs = Decimal.Parse(txtTotalSheet.Text);
                    li_Print_Order_Cover.Total_Impress = Int32.Parse(txtTotalImpression.Text);
                    li_Print_Order_Cover.Total_Cover = Int32.Parse(txtTotalCover.Text);
                    li_Print_Order_Cover.TotalBill = Decimal.Parse(txtTotalBill.Text);
                    li_Print_Order_Cover.Remark = txtRemark.Text;
                    li_Print_Order_Cover.CreatedBy = int.Parse(Session["UserID"].ToString());
                    li_Print_Order_Cover.CreatedDate = DateTime.Now;
                    li_Print_Order_Cover.DeleBy = 0;
                    li_Print_Order_Cover.DeleDate = DateTime.Now;
                    li_Print_Order_Cover.CauseOfDel = string.Empty;
                    li_Print_Order_Cover.ShortForma = chkShortForma.Checked ? true : false;
                    li_Print_Order_Cover.OtherPrint = chkOther.Checked ? true : false;
                    li_Print_Order_Cover.Edition = ddlEdition.Text;

                    string resutl = Li_Print_Order_CoverManager.InsertLi_Print_Order_Cover(li_Print_Order_Cover);

                    txtOrderNo.Text = resutl;


                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {

                        Li_Print_Order_CoverDetails li_Print_Order_CoverDetails = new Li_Print_Order_CoverDetails();

                        li_Print_Order_CoverDetails.Print_OrderNo = resutl;
                        li_Print_Order_CoverDetails.Ups = Int32.Parse(dtCurrentTable.Rows[i]["Ups"].ToString());
                        li_Print_Order_CoverDetails.Impression = Int32.Parse(dtCurrentTable.Rows[i]["Impression"].ToString());
                        li_Print_Order_CoverDetails.ColorNo = Int32.Parse(dtCurrentTable.Rows[i]["ColorNo"].ToString());
                        li_Print_Order_CoverDetails.BillRate = decimal.Parse(dtCurrentTable.Rows[i]["BillRate"].ToString());
                        li_Print_Order_CoverDetails.TotalBill = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                        li_Print_Order_CoverDetails.CoverQty = Int32.Parse(dtCurrentTable.Rows[i]["CoverQty"].ToString());
                        li_Print_Order_CoverDetails.ExPrintNote = dtCurrentTable.Rows[i]["OtherPrint"].ToString();
                        Li_Print_Order_CoverDetailsManager.InsertLi_Print_Order_CoverDetails(li_Print_Order_CoverDetails);

                    }
                }

                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                dtCurrentTable.Rows.Clear();
                ViewState["tblCoverPrintOrder"] = null;
                AddDefaultFirstRecord();
                ClearData();

                DataSet ds = new DataSet();
                ds = Li_PestingManager.getPestingOrderInfoByBookIDEditionOrder(ddlBookName.SelectedValue.ToString(), ddlEdition.SelectedItem.Text, ddlEdition.SelectedValue.ToString(), 'C');// c for cover print 
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlPrintSl.SelectedValue = ds.Tables[0].Rows[0]["PrintSl"].ToString();
                }
            }


            catch (Exception ex)
            {

            }


        }

        private void ClearData()
        {
            txtTotalBill.Text = "";

        }

        protected void btnPrintingCSupPlate_Click(object sender, EventArgs e)
        {
            string OrderNo = txtOrderNo.Text;
            Response.Redirect("~/Pro_PlateSupply.aspx?No=" + OrderNo);
        }

    }
}