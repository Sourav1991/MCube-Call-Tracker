using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Specialized;
using System.Web.Mvc;
using ExceptionLibrary;
using System.Diagnostics;

namespace McubeAPI.Controllers
{
   
    public class Helper
    {
        ExceptionHelper objHelper = new ExceptionHelper();
        public void PostData(string data)
        {
          //  NameValueCollection nvc = Request.Form;
          //  System.Text.StringBuilder displayValues =
          //new System.Text.StringBuilder();
          //  System.Collections.Specialized.NameValueCollection
          //      postedValues = Request.Form;
          //  String nextKey;
          //  for (int i = 0; i < postedValues.AllKeys.Length; i++)
          //  {
          //      nextKey = postedValues.AllKeys[i];

          //  }


          //  string newdata = ConstructQueryString(nvc);
         //   string s = data;
            StringWriter writer = new StringWriter();
          //  ViewStateParser p = new ViewStateParser(writer);
          //  string json = s;
            //string[][] newKeys = s.Select(x => new string[] { x }).ToArray();
           // string myJson = McubeSerialize(data.ToString());
           // string json1 = JsonConvert.SerializeObject(HttpUtility.UrlDecode
          //      (data));
           // string json2 = json1.Substring(0, json1.IndexOf(',') + 1);
           // string urlDecode2 = json1.Replace(json2, "");
           // urlDecode2 = urlDecode2.TrimEnd('"');
            // json1 = json1.Remove(index2);
            ParseJson(data);
        }
        public static string ConstructQueryString(NameValueCollection parameters)
        {
            List<String> items = new List<String>();

            foreach (String name in parameters)
                items.Add(String.Concat(name, "=", System.Web.HttpUtility.UrlEncode(parameters[name])));

            return String.Join("&", items.ToArray());
        }
        public string McubeSerialize(string urlstr)
        {
           // JSONHelper jh = new JSONHelper();

            //Dictionary<string, object> values = ((object[])urlDecode1) as Dictionary<string, object>;
            string urlDecode1 = urlstr.Substring(0, urlstr.IndexOf('=') + 1);
            string urlDecode2 = urlstr.Replace(urlDecode1, "");
            int index1 = urlDecode2.IndexOf('&');
            
            string result2 = urlDecode2.Remove(index1);
           
            return result2;
            // string urlDecode2 = urlDecode1.Substring(urlDecode1.IndexOf('='),urlDecode1.Length-2);
            /*  MCubeData[] persons = js.Deserialize<MCubeData[]>(urlDecode2);
              MCubeData objMcube = new MCubeData();
              //objMcube.callid = "";
              //objMcube.urlDecode = urlDecode1;
              string str = js.Serialize(objMcube);
              return str;*/
        }
        public SqlConnection get_con()
        {
            SqlConnection con = new SqlConnection("Data Source=54.254.196.50;Initial Catalog=ReportServerTempDB;User ID=sa;Password=Fugue@123");
            con.Open();
            return con;
        }
        public string value_cube_json(string val, JObject data_arry)
        {
            try
            {
                val = data_arry["" + val + ""].ToString();
                /*  if (val == "" || val == string.Empty)
                  {
                      val = null;
                  }*/
            }
            catch (Exception msge)
            {
                ExceptionHelper.LogFileWrite(msge.Message.ToString());
                val = "";
            }
            return val;

        }
        public string value_cube(string val, int k, JArray data_arry)
        {
            try
            {
                val = data_arry[k]["" + val + ""].ToString();
            }
            catch (Exception msge)
            {
                ExceptionHelper.LogFileWrite(msge.Message.ToString());
                val = "";
            }
            return val;
        }
        public void ParseJson(string ProvidedJson)
        {
            SqlConnection con = get_con();
           // ProvidedJson = '{'+ProvidedJson+'}';
           // ProvidedJson = JsonConvert.SerializeObject(Uri.EscapeUriString(ProvidedJson));
            ProvidedJson = JsonConvert.SerializeObject(HttpUtility.UrlDecode
                    (ProvidedJson)).TrimStart('"').TrimEnd('"');
            ProvidedJson = ProvidedJson.Replace(System.Environment.NewLine, string.Empty);
          //  ProvidedJson = ProvidedJson.Substring(ProvidedJson.IndexOf('{'));
            //ProvidedJson = JsonConvert.SerializeObject(Uri.EscapeUriString(ProvidedJson));
           // ProvidedJson = ProvidedJson.Replace(@"{", "");
           // ProvidedJson = ProvidedJson.Replace(@"}", "");
            ProvidedJson = ProvidedJson.Replace(@"\", "");
            //ProvidedJson = ProvidedJson.Replace("%", ":");
            //try
            //{
               // JArray a = JArray.Parse(ProvidedJson);
                //  JsonConvert.DeserializeObject<string>(ProvidedJson);
                JObject obj_jason_responce = JObject.Parse(ProvidedJson);
               
                        string callid_parsed = value_cube_json("callid", obj_jason_responce);
                        string callfrom_parsed = value_cube_json("callfrom", obj_jason_responce);
                        string starttime_parsed = value_cube_json("starttime", obj_jason_responce);
                        string filename_parsed = value_cube_json("filename", obj_jason_responce);
                        string calid_parsed = value_cube_json("calid", obj_jason_responce);
                        string pulse_parsed = value_cube_json("pulse", obj_jason_responce);
                        string source_parsed = value_cube_json("source", obj_jason_responce);
                        string custfeedback_parsed = value_cube_json("custfeedback", obj_jason_responce);
                        string exefeedback_parsed = value_cube_json("exefeedback", obj_jason_responce);
                        string dialstatus_parsed = value_cube_json("dialstatus", obj_jason_responce);
                        string callerbusiness_parsed = value_cube_json("callerbusiness", obj_jason_responce);
                        string callername_parsed = value_cube_json("callername", obj_jason_responce);
                        string remark_parsed = value_cube_json("remark", obj_jason_responce);
                        string calleraddress_parsed = value_cube_json("calleraddress", obj_jason_responce);
                        string caller_email_parsed = value_cube_json("caller_email", obj_jason_responce);
                        string rate_parsed = value_cube_json("rate", obj_jason_responce);
                        string empnumber_parsed = value_cube_json("empnumber", obj_jason_responce);
                        string endtime_parsed = value_cube_json("endtime", obj_jason_responce);
                        string eid_parsed = value_cube_json("eid", obj_jason_responce);
                        string empid_parsed = value_cube_json("empid", obj_jason_responce);
                        string gid_parsed = value_cube_json("gid", obj_jason_responce);
                        string empemail_parsed = value_cube_json("empemail", obj_jason_responce);
                        string regoin_parsed = value_cube_json("regoin", obj_jason_responce);
                        string custom2_parsed = value_cube_json("custom[2]", obj_jason_responce);
                        string custom4_parsed = value_cube_json(" custom[4]", obj_jason_responce);
                        string custom7_parsed = value_cube_json("custom[7]", obj_jason_responce);
                        string custom8_parsed = value_cube_json("custom[8]", obj_jason_responce);

                        //storing the data;

                        string query = " insert into MCubeData ( callid,callfrom,starttime,filename,calid,pulse,source,custfeedback,exefeedback,dialstatus,callerbusiness,callername,remark,calleraddress,caller_email,rate,empnumber,endtime,eid,empid,gid,empemail,regoin,custom2,custom4,custom7,custom8) values (@callid_parsed, @callfrom_parsed,@starttime_parsed,@filename_parsed,@calid_parsed, @pulse_parsed, @source_parsed,@custfeedback_parsed,@exefeedback_parsed,@dialstatus_parsed,@callerbusiness_parsed,@callername_parsed,@remark_parsed,@calleraddress_parsed,@caller_email_parsed,@rate_parsed,@empnumber_parsed,@endtime_parsed,@eid_parsed,@empid_parsed,@gid_parsed, @empemail_parsed,@regoin_parsed,@custom2_parsed,@custom4_parsed,@custom7_parsed,@custom8_parsed)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        // cmd.Parameters.AddWithValue();
                        cmd.Parameters.AddWithValue("@callid_parsed", callid_parsed);
                        cmd.Parameters.AddWithValue("@callfrom_parsed", callfrom_parsed);
                        cmd.Parameters.AddWithValue("@starttime_parsed", starttime_parsed);
                        cmd.Parameters.AddWithValue("@filename_parsed", filename_parsed);
                        cmd.Parameters.AddWithValue("@calid_parsed", calid_parsed);
                        cmd.Parameters.AddWithValue("@pulse_parsed", pulse_parsed);
                        cmd.Parameters.AddWithValue("@source_parsed", source_parsed);
                        cmd.Parameters.AddWithValue("@custfeedback_parsed", custfeedback_parsed);
                        cmd.Parameters.AddWithValue("@exefeedback_parsed", exefeedback_parsed);
                        cmd.Parameters.AddWithValue("@dialstatus_parsed", dialstatus_parsed);
                        cmd.Parameters.AddWithValue("@callerbusiness_parsed", callerbusiness_parsed);
                        cmd.Parameters.AddWithValue("@callername_parsed", callername_parsed);
                        cmd.Parameters.AddWithValue("@remark_parsed", remark_parsed);
                        cmd.Parameters.AddWithValue("@calleraddress_parsed", calleraddress_parsed);
                        cmd.Parameters.AddWithValue("@caller_email_parsed", caller_email_parsed);
                        cmd.Parameters.AddWithValue("@rate_parsed", rate_parsed);
                        cmd.Parameters.AddWithValue("@empnumber_parsed", empnumber_parsed);
                        cmd.Parameters.AddWithValue("@endtime_parsed", endtime_parsed);
                        cmd.Parameters.AddWithValue("@eid_parsed", eid_parsed);
                        cmd.Parameters.AddWithValue("@empid_parsed", empid_parsed);
                        cmd.Parameters.AddWithValue("@gid_parsed", gid_parsed);
                        cmd.Parameters.AddWithValue("@empemail_parsed", empemail_parsed);
                        cmd.Parameters.AddWithValue("@regoin_parsed", regoin_parsed);
                        cmd.Parameters.AddWithValue("@custom2_parsed", custom2_parsed);
                        cmd.Parameters.AddWithValue("@custom4_parsed", custom4_parsed);
                        cmd.Parameters.AddWithValue("@custom7_parsed", custom7_parsed);
                        cmd.Parameters.AddWithValue("@custom8_parsed", custom8_parsed);
                        int database_result = cmd.ExecuteNonQuery();
                        if (database_result != 0)
                        {
                            // ScriptManager.RegisterStartupScript(this, GetType(), "Key", alertScript, true);
                            //MessageBox.Show("Hello World");
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Data Insert Successfully...');", true);
                            con.Close();
                        }
                        else
                        {
                            //Response.Write("Error Occured, Data insertion UnsuccessFully");
                            con.Close();
                        }
                    }
                }
            }
            //catch (Exception msg)
            //{
            //    // ExceptionHelper.LogFileWrite(msg..ToString());
            //    var st = new StackTrace(msg, true);
            //    // Get the top stack frame
            //    var frame = st.GetFrame(0);
            //    // Get the line number from the stack frame
            //    var line = frame.GetFileLineNumber();
            //    ExceptionHelper.LogFileWrite(msg.Message.ToString() + line.ToString());
            //    //Response.Write("Exception Occured: " + msg.Message.ToString());
            //}
            //finally
            //{
                //if (con.State == ConnectionState.Open)
                //{
                    //con.Close();
            //    }
            //}
        
