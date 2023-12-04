using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace BLL
{

    public partial class DoMoneyReceipt : System.Web.UI.Page
    {
        string FormID = "AF008";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();
            if (!IsPostBack)
            {
                LoadDepositFor();
            }

        }


        private void LoadDepositFor()
        {
            ListItem li = new ListItem("Select Any..", "0");
            ddlDepositFor.Items.Add(li);

            List<Li_DepositFor> DepositFor = new List<Li_DepositFor>();
            DepositFor = Li_DepositForManager.GetAllLi_DepositFors();
            foreach (Li_DepositFor dep in DepositFor)
            {
                ListItem item = new ListItem(dep.DepForName, dep.DepForId.ToString());
                ddlDepositFor.Items.Add(item);
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
                        Response.Redirect("~/AccountsHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string message = "", script = "";



            if (Convert.ToBoolean(Session["MRPosted"].ToString()) == true && chkHeldUp.Checked == false)
            {
                message = "This is already saved.";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                return;
            }

            else if (Convert.ToBoolean(Session["IsReSend"].ToString()) == false && chkHeldUp.Checked == false)
            {
                message = "This is not allowed for MR yet";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                return;
            }

            else
            {


                if (gvMRSheetDetailsUpdate.Rows.Count > 0)
                {


                    for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                    {
                        int MRdetID = Convert.ToInt32(gvMRSheetDetailsUpdate.Rows[i].Cells[0].Text);
                        DataTable dtMrDetail = new DataTable();
                        dtMrDetail = Li_MRSheetDetailManager.Get_MRSheetDetails(MRdetID);


                        Li_Deposit deposit = new Li_Deposit();
                        deposit.Alim = false;
                        deposit.AmountOfMoney = decimal.Parse(dtMrDetail.Rows[0]["Amount"].ToString());
                        deposit.BankAddress = dtMrDetail.Rows[0]["BankAddress"].ToString();
                        deposit.BankCode = dtMrDetail.Rows[0]["BankCode"].ToString();
                        deposit.BankSlipNo = dtMrDetail.Rows[0]["BankSlipNo"].ToString();
                        deposit.Boishaki = false;
                        deposit.CauseOfDelete = "";
                        deposit.ClearDate = Convert.ToDateTime(dtMrDetail.Rows[0]["CollectionDate"].ToString());
                        deposit.CreatedBy = int.Parse(Session["UserID"].ToString());
                        deposit.Dele_By = 0;
                        deposit.Deledate = DateTime.Now;
                        deposit.DepositedDate = Convert.ToDateTime(dtMrDetail.Rows[0]["CollectionDate"].ToString());
                        deposit.DepositeTpe = Int32.Parse(dtMrDetail.Rows[0]["DepositType"].ToString());
                        deposit.LibraryID = dtMrDetail.Rows[0]["LibraryID"].ToString();
                        deposit.MRDate = Convert.ToDateTime(dtMrDetail.Rows[0]["MRDate"].ToString());
                        deposit.Remark = dtMrDetail.Rows[0]["Remark"].ToString();
                        deposit.Status_D = 'C';
                        deposit.VrifiedBy = MRdetID.ToString();
                        deposit.Dam_BookSale = false;
                        deposit.Dam_Other = false;
                        deposit.HouseRent = false;
                        deposit.Others = false;
                        deposit.Comp = dtMrDetail.Rows[0]["Com"].ToString();
                        deposit.DepositForId = Int32.Parse(dtMrDetail.Rows[0]["DepositForId"].ToString());
                        deposit.AssetList = 0;
                        Li_DepositManager.InsertLi_Deposit(deposit);

                    }

                    message = "Saved successful.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                }
            }


        }

        protected void btnLock_Click(object sender, EventArgs e)
        {

        }

        protected void txtMRId_TextChanged(object sender, EventArgs e)
        {

            try
            {

                DataTable dt = new DataTable();
                dt = Li_MRSheetManager.Get_MRSheetNoWiseDetailsForDoMR(Int32.Parse(txtMRId.Text), chkHeldUp.Checked, Int32.Parse(ddlDepositFor.SelectedValue));




                decimal totalAmount = 0.0m;
                if (dt.Rows.Count > 0)
                {

                    Session["MRPosted"] = dt.Rows[0]["IsLocked"];
                    Session["IsReSend"] = dt.Rows[0]["IsReSend"];

                    DateTime mr = Convert.ToDateTime(dt.Rows[0]["MRDate"].ToString());
                    txtMRDate.Text = mr.ToString("yyyy-MM-dd");

                    gvMRSheetDetailsUpdate.DataSource = dt;
                    gvMRSheetDetailsUpdate.DataBind();

                    for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                    {
                        decimal totalAmtRow = Convert.ToDecimal(gvMRSheetDetailsUpdate.Rows[i].Cells[11].Text);
                        totalAmount += totalAmtRow;
                    }

                    txtTotalAmount.Text = totalAmount.ToString();
                }
                else
                {
                    txtTotalAmount.Text = totalAmount.ToString();
                    gvMRSheetDetailsUpdate.DataSource = null;
                    gvMRSheetDetailsUpdate.DataBind();
                }

                if (chkHeldUp.Checked == true)
                {
                    txtMRDate.Enabled = true;
                }
                else
                {
                    txtMRDate.Enabled = false;
                }
            }
            catch (Exception)
            {


            }


        }

        protected void btnDownloadXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvMRSheetDetailsUpdate.Rows.Count > 0)
                {

                    DataTable dt = new DataTable();
                    dt = Li_MRSheetManager.Get_MRSheetNoWiseDetailsForDoMR(Int32.Parse(txtMRId.Text), chkHeldUp.Checked, Int32.Parse(ddlDepositFor.SelectedValue));



                    string path = Server.MapPath("~/ReceiptJournal.xml");

                    using (XmlWriter writer = XmlWriter.Create(path))
                    {
                        writer.WriteStartElement("ENVELOPE");

                        writer.WriteStartElement("HEADER");
                        writer.WriteElementString("TALLYREQUEST", "Import Data");
                        writer.WriteEndElement();

                        writer.WriteStartElement("BODY");
                        writer.WriteStartElement("IMPORTDATA");

                        writer.WriteStartElement("REQUESTDESC");
                        writer.WriteElementString("REPORTNAME", "Vouchers");
                        writer.WriteEndElement(); // REQUESTDESC End 	


                        writer.WriteStartElement("REQUESTDATA");


                        writer.WriteStartElement("TALLYMESSAGE");

                        writer.WriteAttributeString("xmlns", "UDF", null, "TallyUDF");

                        
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {

                                writer.WriteStartElement("VOUCHER");
                                writer.WriteAttributeString("REMOTEID", dt.Rows[i]["MRNo"].ToString());
                                writer.WriteAttributeString("VCHTYPE", ddlVoucherType.SelectedValue);
                                writer.WriteAttributeString("ACTION", "Create");
                                writer.WriteAttributeString("OBJVIEW", "Accounting Voucher View");

                                writer.WriteElementString("DATE", Convert.ToDateTime(dt.Rows[i]["MRDate"].ToString()).ToString("yyyyMMdd"));
                                writer.WriteElementString("NARRATION",  dt.Rows[i]["Remark"].ToString() );

                                writer.WriteElementString("VOUCHERTYPENAME", ddlVoucherType.SelectedValue);
                                writer.WriteElementString("VOUCHERNUMBER", dt.Rows[i]["BankSlipNo"].ToString() != "" ? dt.Rows[i]["MRNo"].ToString() + "/" + dt.Rows[i]["BankSlipNo"].ToString() : dt.Rows[i]["MRNo"].ToString());

                                writer.WriteElementString("PARTYLEDGERNAME", dt.Rows[i]["AccountNo"].ToString());
                                writer.WriteElementString("PERSISTEDVIEW", "Accounting Voucher View");


                                writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                                writer.WriteElementString("LEDGERNAME", dt.Rows[i]["AccountNo"].ToString());
                                writer.WriteElementString("ISDEEMEDPOSITIVE", "Yes");
                                writer.WriteElementString("AMOUNT", Math.Round((0 - Convert.ToDecimal(dt.Rows[i]["Amount"].ToString())), 0).ToString());
                                writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                                writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                                writer.WriteElementString("LEDGERNAME", dt.Rows[i]["Com"].ToString() == "A" ? dt.Rows[i]["LibraryID"].ToString() : dt.Rows[i]["LibraryID"].ToString() + "Q");
                                writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                                writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["Amount"].ToString()), 0).ToString());
                                writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 	

                                writer.WriteEndElement();// VOUCHER End 	
                            }
                         



                        writer.WriteEndElement();// TALLYMESSAGE End 		
                        writer.WriteEndElement();// REQUESTDATA End 	
                        writer.WriteEndElement();// IMPORTDATA End 		
                        writer.WriteEndElement();// Body End 
                        writer.WriteEndElement();// ENVELOPE End 
                        writer.Flush();

                        string message = "Saved successfully.";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "');";
                        script += "window.location = '";
                        script += Request.Url.AbsoluteUri;
                        script += "'; }";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                        script, true);
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        protected void DownloadXML_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("~/ReceiptJournal.xml");

                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/xml";
                response.AddHeader("Content-Disposition", "attachment; filename=" + path + ";");
                response.TransmitFile(path);
                response.Flush();
                response.End();
            }
            catch (Exception)
            {


            }
        }

    }
}