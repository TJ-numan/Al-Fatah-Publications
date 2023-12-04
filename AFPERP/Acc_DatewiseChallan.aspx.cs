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
    public partial class Acc_DatewiseChallan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = li_ChallanManager.DatewiseChallan(dtpFromDate.Text, dtpToDate.Text, ddlVoucherType.SelectedIndex == 1 ? true : false, ddlVoucherType.SelectedIndex == 2 ? true : false, ddlVoucherType.SelectedIndex == 3 ? true : false, int.Parse(Session["UserID"].ToString()));
                gvDatewiseChallan.DataSource = dt;
                gvDatewiseChallan.DataBind();
            }
            catch (Exception)
            {


            }

        }

        protected void btnConvertXML_Click(object sender, EventArgs e)
        {
            try
            {
                gvDatewiseChallan.DataSource =  null;
                DataTable dt = new DataTable();
                dt = li_ChallanManager.DatewiseChallan(dtpFromDate.Text, dtpToDate.Text, ddlVoucherType.SelectedIndex==1 ? true :false , ddlVoucherType.SelectedIndex==2 ? true :false , ddlVoucherType.SelectedIndex==3 ? true :false , int.Parse(Session["UserID"].ToString()));
                gvDatewiseChallan.DataSource = dt;
                gvDatewiseChallan.DataBind();

                string ChallanID = dt.Rows[0]["ChallanID"].ToString();
                string memo = dt.Rows[0]["MemoNo"].ToString();
                string LibraryID = dt.Rows[0]["LibraryID"].ToString();
                string amount = Math.Round((0 - Convert.ToDecimal(dt.Rows[0]["AmountReceivable"].ToString())), 0).ToString();

                string TotalAmount = Math.Round(Convert.ToDecimal(dt.Rows[0]["TotalAmount"].ToString()), 0).ToString();

                string TotalPacCost = Math.Round(Convert.ToDecimal(dt.Rows[0]["TotalPacCost"].ToString()), 0).ToString();

                string path = Server.MapPath("~/SalesJournal.xml");

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

                    if (ddlVoucherType.SelectedIndex == 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            writer.WriteStartElement("VOUCHER");
                            writer.WriteAttributeString("REMOTEID", dt.Rows[i]["ChallanID"].ToString());
                            writer.WriteAttributeString("VCHTYPE", "Challan Memo");
                            writer.WriteAttributeString("ACTION", "Create");
                            writer.WriteAttributeString("OBJVIEW", "Accounting Voucher View");

                            writer.WriteElementString("DATE", Convert.ToDateTime(dt.Rows[i]["CreatedDate"].ToString()).ToString("yyyyMMdd"));
                            writer.WriteElementString("VOUCHERTYPENAME", "Challan Memo");
                            writer.WriteElementString("VOUCHERNUMBER", dt.Rows[i]["MemoNo"].ToString());

                            writer.WriteElementString("PARTYLEDGERNAME", dt.Rows[i]["LibraryID"].ToString());
                            writer.WriteElementString("PERSISTEDVIEW", "Accounting Voucher View");


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", dt.Rows[i]["LibraryID"].ToString());
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "Yes");
                            writer.WriteElementString("AMOUNT", Math.Round((0 - Convert.ToDecimal(dt.Rows[i]["AmountReceivable"].ToString())), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "11");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 	

                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "33");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalPacCost"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteEndElement();// VOUCHER End 	
                        }
                    }

                    else   if (ddlVoucherType.SelectedIndex == 1)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            writer.WriteStartElement("VOUCHER");
                            writer.WriteAttributeString("REMOTEID", dt.Rows[i]["ChallanID"].ToString());
                            writer.WriteAttributeString("VCHTYPE", "Boishaki Challan");
                            writer.WriteAttributeString("ACTION", "Create");
                            writer.WriteAttributeString("OBJVIEW", "Accounting Voucher View");

                            writer.WriteElementString("DATE", Convert.ToDateTime(dt.Rows[i]["CreatedDate"].ToString()).ToString("yyyyMMdd"));
                            writer.WriteElementString("VOUCHERTYPENAME", "Boishaki Challan");
                            writer.WriteElementString("VOUCHERNUMBER", dt.Rows[i]["MemoNo"].ToString());

                            writer.WriteElementString("PARTYLEDGERNAME", dt.Rows[i]["LibraryID"].ToString());
                            writer.WriteElementString("PERSISTEDVIEW", "Accounting Voucher View");


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", dt.Rows[i]["LibraryID"].ToString());
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "Yes");
                            writer.WriteElementString("AMOUNT", Math.Round((0 - Convert.ToDecimal(dt.Rows[i]["AmountReceivable"].ToString())), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "00");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 	

                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "33");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalPacCost"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteEndElement();// VOUCHER End 	
                        }
                    }
                    else if (ddlVoucherType.SelectedIndex == 2)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            writer.WriteStartElement("VOUCHER");
                            writer.WriteAttributeString("REMOTEID", dt.Rows[i]["ChallanID"].ToString());
                            writer.WriteAttributeString("VCHTYPE", "Boishaki Bonus -M");
                            writer.WriteAttributeString("ACTION", "Create");
                            writer.WriteAttributeString("OBJVIEW", "Accounting Voucher View");

                            writer.WriteElementString("DATE", Convert.ToDateTime(dt.Rows[i]["CreatedDate"].ToString()).ToString("yyyyMMdd"));
                            writer.WriteElementString("VOUCHERTYPENAME", "Boishaki Bonus -M");
                            writer.WriteElementString("VOUCHERNUMBER", dt.Rows[i]["MemoNo"].ToString());

                            writer.WriteElementString("PARTYLEDGERNAME", dt.Rows[i]["LibraryID"].ToString());
                            writer.WriteElementString("PERSISTEDVIEW", "Accounting Voucher View");


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", dt.Rows[i]["LibraryID"].ToString());
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "Yes");
                            writer.WriteElementString("AMOUNT", Math.Round((0 - Convert.ToDecimal(dt.Rows[i]["AmountReceivable"].ToString())), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "101");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "Yes");
                            writer.WriteElementString("AMOUNT", Math.Round((0 - Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString())), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "102");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 	

                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "33");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalPacCost"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 

                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", dt.Rows[i]["LibraryID"].ToString());
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("ISLASTDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round((Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString())), 0).ToString());

                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 

                            writer.WriteEndElement();// VOUCHER End 	
                        }
                    }


                    else if (ddlVoucherType.SelectedIndex == 3)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            writer.WriteStartElement("VOUCHER");
                            writer.WriteAttributeString("REMOTEID", dt.Rows[i]["ChallanID"].ToString());
                            writer.WriteAttributeString("VCHTYPE", "Challan Memo");
                            writer.WriteAttributeString("ACTION", "Create");
                            writer.WriteAttributeString("OBJVIEW", "Accounting Voucher View");

                            writer.WriteElementString("DATE", Convert.ToDateTime(dt.Rows[i]["CreatedDate"].ToString()).ToString("yyyyMMdd"));
                            writer.WriteElementString("VOUCHERTYPENAME", "Challan Memo");
                            writer.WriteElementString("VOUCHERNUMBER", dt.Rows[i]["MemoNo"].ToString());

                            writer.WriteElementString("PARTYLEDGERNAME", dt.Rows[i]["LibraryID"].ToString()+"Q");
                            writer.WriteElementString("PERSISTEDVIEW", "Accounting Voucher View");


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME",   dt.Rows[i]["LibraryID"].ToString()+"Q");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "Yes");
                            writer.WriteElementString("AMOUNT", Math.Round((0 - Convert.ToDecimal(dt.Rows[i]["AmountReceivable"].ToString())), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "10");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 	

                            writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                            writer.WriteElementString("LEDGERNAME", "33");
                            writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                            writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["TotalPacCost"].ToString()), 0).ToString());
                            writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                            writer.WriteEndElement();// VOUCHER End 	
                        }
                    }

                  

                    else
                    {

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
            catch (Exception)
            {


            }
        }

        protected void DownloadXML_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("~/SalesJournal.xml");
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