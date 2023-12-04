using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;

namespace BLL
{
    public partial class Login : System.Web.UI.Page
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ////For SMS sending                               
                //Sms_sending();
               
                string userip = Request.UserHostAddress;
                string strClientIP = Request.UserHostAddress.ToString().Trim();
                Int32 ldest = inet_addr(strClientIP);
                Int32 lhost = inet_addr("");
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");
                if (mac_src == "0")
                {
                    if (userip == "127.0.0.1")
                        Response.Write("visited Localhost!");
                    else
                        Response.Write("the IP from" + userip + "" + "<br>");
                    return;
                }

                while (mac_src.Length < 12)
                {
                    mac_src = mac_src.Insert(0, "0");
                }

                string mac_dest = "";

                for (int i = 0; i < 11; i++)
                {
                    if (0 == (i % 2))
                    {
                        if (i == 10)
                        {
                            mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                        else
                        {
                            mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }

                lblMacAdd.Text = mac_dest;
                lblIpAdd.Text = userip;

                //Response.Write("welcome" + userip + "<br>" + ",the mac address is" + mac_dest + "."

                // + "<br>");
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }
        }


        private void Sms_sending()
        {


            string result = "";
            WebRequest request = null;
            HttpWebResponse response = null;
            try
            { // testing team

                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SMPM_li_GetAgentSMS", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataAdapter myadapter = new SqlDataAdapter(command);
                    myadapter.Fill(dt);
                    myadapter.Dispose();
                    connection.Close();

                }
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //// For Greenweb SMS System 17/06/2019

                        ////String to = dt.Rows[i]["MobileNumber"].ToString(); //Recipient Phone Number multiple number must be separated by comma
                        ////String token = "6858472196e8b68d22e15fc741f9d8d1"; //generate token from the control panel
                        ////String message = System.Uri.EscapeUriString(dt.Rows[i]["SMSText"].ToString()); //do not use single quotation (') in the message to avoid forbidden result
                        ////String url = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;
                        ////request = WebRequest.Create(url);

                        ////// Send the 'HttpWebRequest' and wait for response.
                        ////response = (HttpWebResponse)request.GetResponse();
                        ////Stream stream = response.GetResponseStream();
                        ////Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                        ////StreamReader reader = new
                        ////System.IO.StreamReader(stream, ec);
                        ////result = reader.ReadToEnd();
                        //////MessageBox.Show(result);
                        ////reader.Close();
                        ////stream.Close();


                        //// For BulkSMS Bd System 17/06/2019

                        //String userid = "01733210500"; //Your Login ID
                        //String password = "Fd%71&sd23!"; //Your Password
                        //String number = dt.Rows[i]["MobileNumber"].ToString(); //Recipient Phone Number multiple number must be separated by comma
                        //String message = System.Uri.EscapeUriString(dt.Rows[i]["SMSText"].ToString()); //do not use single quotation (') in the message to avoid forbidden result
                        //String url = "http://66.45.237.70/api.php?username=" + userid + "&password=" + password + "&number=" + number + "&message=" + message;                        
                        ////String url = "http://66.45.237.70/maskingapi.php?username=" + userid + "&password=" + password + "&number=" + number + "&senderid=AL%20FATAH&message=" + message;


                        //request = WebRequest.Create(url);

                        //// Send the 'HttpWebRequest' and wait for response.
                        //response = (HttpWebResponse)request.GetResponse();
                        //Stream stream = response.GetResponseStream();
                        //Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                        //StreamReader reader = new
                        //System.IO.StreamReader(stream, ec);
                        //result = reader.ReadToEnd();
                        ////Console.WriteLine(result);
                        //reader.Close();
                        //stream.Close();

                        //For Greenweb SMS 19/01/2022
                        String to = dt.Rows[i]["MobileNumber"].ToString(); //Recipient Phone Number multiple number must be separated by comma
                        String token = "7d99d50a1f4cad8b8c64fe468b83623c"; //generate token from the control panel
                        String message = System.Uri.EscapeUriString(dt.Rows[i]["SMSText"].ToString()); //do not use single quotation (') in the message to avoid forbidden result
                        String url = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;
                        request = WebRequest.Create(url);

                        // Send the 'HttpWebRequest' and wait for response.
                        response = (HttpWebResponse)request.GetResponse();
                        Stream stream = response.GetResponseStream();
                        Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                        StreamReader reader = new
                        System.IO.StreamReader(stream, ec);
                        result = reader.ReadToEnd();
                        Console.WriteLine(result);
                        reader.Close();
                        stream.Close();

                        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand("SMPM_li_Update_GetAgentSMS", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@SmsId", SqlDbType.Int).Value = int.Parse(dt.Rows[i]["SMSID"].ToString());

                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }

                    }
                }

            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.ToString());
            }
        }
        private void LogInInfo()
        {
            DataTable dtUser = new DataTable();
            dtUser = Li_AdminUserManager.GetUserInfo(txtUserId.Text, txtPassword.Text).Tables[0];

            if (dtUser.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DataRow drLogin = default(DataRow);
                drLogin = dtUser.Rows[0];
                Session["UserID"] = drLogin["UserID"].ToString();
                Session["UserName"] = drLogin["Name"].ToString();
                Session["DepartmentID"] = drLogin["DepartmentID"];                              
            }
        }

        public static PhysicalAddress GetMacAddress()
        {
            var myInterfaceAddress = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .OrderByDescending(n => n.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                .Select(n => n.GetPhysicalAddress())
                .FirstOrDefault();

            return myInterfaceAddress;
        }
       
        protected void btnSignIn_OnClick(object sender, EventArgs e)
        {
            try
            {

                string hostName = Dns.GetHostName();
                Session["myIp"] = Dns.GetHostByName(hostName).AddressList[0].ToString();

                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                Session["myIp"] = localIPs[1].ToString();

                Session["PhyAdd"] = lblMacAdd.Text;//GetMacAddress().ToString();
                Session["LoginTime"] = DateTime.Now;
 
                
                LogInInfo();
                UserAccessLog();

                if (Session["DepartmentID"].Equals(2))
                {
                    Response.Redirect("~/HRHome.aspx");
                }
                if (Session["DepartmentID"].Equals(3))
                {
                    Response.Redirect("~/RandDHome.aspx");
                }
                else if (Session["DepartmentID"].Equals(5))
                {
                    Response.Redirect("~/MarketingHome.aspx");
                }
                else if (Session["DepartmentID"].Equals(6))
                {
                    Response.Redirect("~/DistributionHome.aspx");
                }
                else if (Session["DepartmentID"].Equals(7))
                {
                    Response.Redirect("~/AccountsHome.aspx");
                }
                else if (Session["DepartmentID"].Equals(9))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else if (Session["DepartmentID"].Equals(4))
                {
                    Response.Redirect("~/ProHome.aspx");
                }
                else if (Session["DepartmentID"].Equals(1))
                {
                    Response.Redirect("~/ManagementHome.aspx");
                }
               

            }
            catch (Exception)
            {

            }
        }

        private void UserAccessLog()
        {
            li_UserAccessLog li_UserAccessLog = new li_UserAccessLog();
            li_UserAccessLog.UserId = int.Parse(Session["UserID"].ToString());
            li_UserAccessLog.IPAdd = Session["myIp"].ToString();
            li_UserAccessLog.PhyAdd = Session["PhyAdd"].ToString();
            li_UserAccessLog.login_time = DateTime.Parse(Session["LoginTime"].ToString());
            li_UserAccessLog.logout_time = DateTime.Now;
            int SlNo= Li_AdminUserManager.InsertLi_UserAccessLog(li_UserAccessLog);
            Session["SlNo"] = SlNo;
        }


    }
}