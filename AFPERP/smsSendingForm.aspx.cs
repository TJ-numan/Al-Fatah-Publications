using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AFPSMS
{
    public partial class smsSendingForm : System.Web.UI.Page
    {
        //public string ConnectionString = ConfigurationManager.ConnectionStrings["SMSConnection"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sms_sending();
            //Response.Redirect("Login.aspx");
        }

        //public static void Sms_sending()
        //{
            

        //    string result = "";
        //    WebRequest request = null;
        //    HttpWebResponse response = null;
        //    try
        //    { // testing team

        //        DataTable dt = new DataTable();
        //        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
        //        {
        //            SqlCommand command = new SqlCommand("SMPM_li_GetAgentSMS", connection);
        //            command.CommandType = CommandType.StoredProcedure;
        //            connection.Open();
        //            SqlDataAdapter myadapter = new SqlDataAdapter(command);
        //            myadapter.Fill(dt);
        //            myadapter.Dispose();
        //            connection.Close();

        //        }
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                //// For Greenweb SMS System 17/06/2019

        //                ////String to = dt.Rows[i]["MobileNumber"].ToString(); //Recipient Phone Number multiple number must be separated by comma
        //                ////String token = "6858472196e8b68d22e15fc741f9d8d1"; //generate token from the control panel
        //                ////String message = System.Uri.EscapeUriString(dt.Rows[i]["SMSText"].ToString()); //do not use single quotation (') in the message to avoid forbidden result
        //                ////String url = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;
        //                ////request = WebRequest.Create(url);

        //                ////// Send the 'HttpWebRequest' and wait for response.
        //                ////response = (HttpWebResponse)request.GetResponse();
        //                ////Stream stream = response.GetResponseStream();
        //                ////Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
        //                ////StreamReader reader = new
        //                ////System.IO.StreamReader(stream, ec);
        //                ////result = reader.ReadToEnd();
        //                //////MessageBox.Show(result);
        //                ////reader.Close();
        //                ////stream.Close();


        //                //// For BulkSMS Bd System 17/06/2019

        //                //String userid = "01733210500"; //Your Login ID
        //                //String password = "Fd%71&sd23!"; //Your Password
        //                //String number = dt.Rows[i]["MobileNumber"].ToString(); //Recipient Phone Number multiple number must be separated by comma
        //                //String message = System.Uri.EscapeUriString(dt.Rows[i]["SMSText"].ToString()); //do not use single quotation (') in the message to avoid forbidden result
        //                //String url = "http://66.45.237.70/api.php?username=" + userid + "&password=" + password + "&number=" + number + "&message=" + message;                        
        //                ////String url = "http://66.45.237.70/maskingapi.php?username=" + userid + "&password=" + password + "&number=" + number + "&senderid=AL%20FATAH&message=" + message;


        //                //request = WebRequest.Create(url);

        //                //// Send the 'HttpWebRequest' and wait for response.
        //                //response = (HttpWebResponse)request.GetResponse();
        //                //Stream stream = response.GetResponseStream();
        //                //Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
        //                //StreamReader reader = new
        //                //System.IO.StreamReader(stream, ec);
        //                //result = reader.ReadToEnd();
        //                ////Console.WriteLine(result);
        //                //reader.Close();
        //                //stream.Close();

        //                //For Greenweb SMS 19/01/2022
        //                String to = dt.Rows[i]["MobileNumber"].ToString(); //Recipient Phone Number multiple number must be separated by comma
        //                String token = "7d99d50a1f4cad8b8c64fe468b83623c"; //generate token from the control panel
        //                String message = System.Uri.EscapeUriString(dt.Rows[i]["SMSText"].ToString()); //do not use single quotation (') in the message to avoid forbidden result
        //                String url = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;
        //                request = WebRequest.Create(url);

        //                // Send the 'HttpWebRequest' and wait for response.
        //                response = (HttpWebResponse)request.GetResponse();
        //                Stream stream = response.GetResponseStream();
        //                Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
        //                StreamReader reader = new
        //                System.IO.StreamReader(stream, ec);
        //                result = reader.ReadToEnd();
        //                Console.WriteLine(result);
        //                reader.Close();
        //                stream.Close();

        //                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
        //                {
        //                    SqlCommand cmd = new SqlCommand("SMPM_li_Update_GetAgentSMS", connection);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add("@SmsId", SqlDbType.Int).Value = int.Parse(dt.Rows[i]["SMSID"].ToString());

        //                    connection.Open();
        //                    cmd.ExecuteNonQuery();
        //                }

        //            }
        //        }
            
        //    }
        //    catch (Exception exp)
        //    {
        //        //MessageBox.Show(exp.ToString());
        //    }
        //}
    }
}