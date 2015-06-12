using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
//using System.ServiceModel;
using System.ServiceModel;
using System.IO;
using System.Collections.Specialized;
using Newtonsoft.Json;
using ExceptionLibrary;
namespace McubeAPI.Controllers
{

    /// <summary>
    /// Summary description for JSONHelper
    /// </summary>
    /// 
    public class JSONHelper
    {
        ExceptionHelper objHelper = new ExceptionHelper();
        
        public void PostData(string data)
        {

            StringWriter writer = new StringWriter();

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

        }
        public SqlConnection get_con()
        {
            SqlConnection con = new SqlConnection("Data Source=54.254.196.50;Initial Catalog=FUGUE_DB;User ID=sa;Password=Fugue@123");
            con.Open();
            return con;
        }
        public string value_cube_json(string val, JObject data_arry)
        {
            try
            {
                val = data_arry["" + val + ""].ToString();
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
            string logic_flag = string.Empty;
            SqlConnection con = get_con();

            ProvidedJson = JsonConvert.SerializeObject(HttpUtility.UrlDecode
                    (ProvidedJson)).TrimStart('"').TrimEnd('"');
            char[] escapeChars = new[] { '\n', '\a', '\r' };

             ProvidedJson = new string(ProvidedJson.Where(c => !escapeChars.Contains(c)).ToArray());
            ProvidedJson = ProvidedJson.Replace(@"\", "");
            ProvidedJson = ProvidedJson.Replace("r%0", "");
            ProvidedJson = ProvidedJson.Replace("rn", "");
           
            try
            {

                JObject obj_jason_responce = JObject.Parse(ProvidedJson);
                McubeDataWriter.LogDataWrite(obj_jason_responce.ToString()); 

                string callid_parsed = value_cube_json("callid", obj_jason_responce);
                string callfrom_parsed = value_cube_json("callfrom", obj_jason_responce);
                string starttime_parsed = value_cube_json("starttime", obj_jason_responce);
                DateTime starttime_parsed_dt;
                if (starttime_parsed == "0000-00-00 00:00:00")
                {
                    starttime_parsed_dt = DateTime.Now;
                }
                else
                {
                    starttime_parsed_dt = Convert.ToDateTime(starttime_parsed);
                }

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
                DateTime endtime_parsed_dt;
                if (endtime_parsed == "0000-00-00 00:00:00")
                {
                    endtime_parsed_dt = DateTime.Now;
                }
                else
                {
                    endtime_parsed_dt = Convert.ToDateTime(endtime_parsed);
                }

                string eid_parsed = value_cube_json("eid", obj_jason_responce);
                string empid_parsed = value_cube_json("empid", obj_jason_responce);
                string gid_parsed = value_cube_json("gid", obj_jason_responce);
                string empemail_parsed = value_cube_json("empemail", obj_jason_responce);
                string regoin_parsed = value_cube_json("regoin", obj_jason_responce);
                string custom2_parsed = value_cube_json("custom[2]", obj_jason_responce);
                string custom4_parsed = value_cube_json(" custom[4]", obj_jason_responce);
                string custom7_parsed = value_cube_json("custom[7]", obj_jason_responce);
                string custom8_parsed = value_cube_json("custom[8]", obj_jason_responce);
                string assignedto_parsed = value_cube_json("assignto", obj_jason_responce);

                //checking the data...
                McubeDataWriter.LogDataWrite(callid_parsed + "callid_parsed" + callfrom_parsed + "callfrom_parsed" + starttime_parsed + "starttime_parsed" + filename_parsed + "filename_parsed" + calid_parsed + "calid_parsed" + pulse_parsed + "pulse_parsed" + source_parsed + "source_parsed" + custfeedback_parsed + "custfeedback_parsed" + exefeedback_parsed + "exefeedback_parsed" + dialstatus_parsed + "dialstatus_parsed" + callerbusiness_parsed + "callerbusiness_parsed" + callername_parsed + "callername_parsed" + remark_parsed + "remark_parsed" + calleraddress_parsed + "calleraddress_parsed" + caller_email_parsed + "caller_email_parsed" + rate_parsed + "rate_parsed" + empnumber_parsed + "empnumber_parsed" + endtime_parsed + "endtime_parsed" + eid_parsed + "eid_parsed" + empid_parsed + "empid_parsed" + gid_parsed + "gid_parsed" + empemail_parsed + "empemail_parsed" + regoin_parsed + "regoin_parsed");

                //storing the data;

                //checking for the existence of the uniqueid...
                string query_mcubeuniquecallid = "select lastmodifiedon from tewebsitee where mobileno = @mcubeuniquecallid";
                SqlCommand cmd_mcubeuniquecallid = new SqlCommand(query_mcubeuniquecallid, con);
                cmd_mcubeuniquecallid.Parameters.AddWithValue("@mcubeuniquecallid", callfrom_parsed);
                SqlDataReader readCUID = cmd_mcubeuniquecallid.ExecuteReader();
                McubeDataWriter.LogDataWrite("Existing phone Number : " + Convert.ToString(readCUID.HasRows));
                if (readCUID.HasRows && readCUID.Read())
                {
                    DateTime lastModification = Convert.ToDateTime(readCUID[0]);
                    if(lastModification.AddDays(30) < endtime_parsed_dt)
                    {
                        logic_flag = "create";
                    }
                }
                else
                {
                    logic_flag = "create";
                }

                //if the mcube Unique Call Id doesnot exist then insert the new data...
                if (logic_flag == "create")//&& readCUID.Read())
                {
                    McubeDataWriter.LogDataWrite("New Row to Create...");
                    readCUID.Close();
                    //for Developement 
                    /*string enterpriseName = "TEF_User";
                    string baseUrl = "http://192.168.1.244/bizapp/";
                    string Username = "chandrakala";
                    string Pswd = "totalenv123"; */

                    //for UAT
                    string enterpriseName = "TEF_UAT";
                    string baseUrl = "http://fugue.total-environment.com/";
                    string Username = "systemadmin";
                    string Pswd = "systemadmin";

                    BizAPP.WebServices.Authentication.Authenticate authenticate = new BizAPP.WebServices.Authentication.Authenticate();
                    authenticate.Url = baseUrl + "webservice/authentication/authenticate.asmx";
                    authenticate.Login(Username, Pswd, enterpriseName, "BizAPP");

                    BizAPP.WebServices.Authentication.AuthenticationTicketHeader cookie = authenticate.AuthenticationTicketHeaderValue;

                    BizAPP.WebServices.Object.ObjectServices os = new BizAPP.WebServices.Object.ObjectServices();
                    os.Url = baseUrl + "webservice/object/objectservices.asmx";
                    os.SessionCookieHeaderValue = cookie;

                    BizAPP.WebServices.Object.RuntimeClientObject rcoget = new BizAPP.WebServices.Object.RuntimeClientObject();

                    rcoget.ObjectType = "SalesCRM.EnquiryManagement.TEWebsiteEnquiry";
                    rcoget.IsVirtual = false;
                    //rco1.StepName = "Modify";
                    rcoget.StepName = "Create";
                    rcoget.FieldValues = new BizAPP.WebServices.Object.NameValue[]
                                               {
                                                    new BizAPP.WebServices.Object.NameValue{ Name="CustomerName", Value= callername_parsed},                            
                                                    new BizAPP.WebServices.Object.NameValue{ Name="MobileNo", Value = callfrom_parsed },
                                                    new BizAPP.WebServices.Object.NameValue{ Name="EmailID", Value = caller_email_parsed },
                                                    new BizAPP.WebServices.Object.NameValue{ Name="Region", Value = regoin_parsed },                                                    
                                                    new BizAPP.WebServices.Object.NameValue{ Name="Address", Value = calleraddress_parsed },
                                                    new BizAPP.WebServices.Object.NameValue{ Name="EnquiryMode", Value = "Phone" },
                                                    new BizAPP.WebServices.Object.NameValue{ Name="FugueEnquiry", Value = "Open"},
                                                    new BizAPP.WebServices.Object.NameValue{ Name="Remarks", Value = remark_parsed },
                                                    new BizAPP.WebServices.Object.NameValue{ Name="McubeUniqueCallID", Value = callid_parsed},
                                                    new BizAPP.WebServices.Object.NameValue{ Name="CallStartTime", Value = starttime_parsed_dt},
                                                    new BizAPP.WebServices.Object.NameValue{ Name="CallEndTime", Value = endtime_parsed_dt },
                                                    new BizAPP.WebServices.Object.NameValue{ Name="CallID",Value = calid_parsed},
                                                    new BizAPP.WebServices.Object.NameValue{ Name="CallPulse", Value = pulse_parsed},
                                                    new BizAPP.WebServices.Object.NameValue{ Name="CallerBusinessName", Value = callerbusiness_parsed },
                                                    new BizAPP.WebServices.Object.NameValue{ Name="CallRate", Value = rate_parsed },
                                                    new BizAPP.WebServices.Object.NameValue{ Name="CalleeEmployeeNo",Value= empnumber_parsed},
                                                    new BizAPP.WebServices.Object.NameValue{ Name="CalleeName", Value=assignedto_parsed},													
													new BizAPP.WebServices.Object.NameValue{ Name="CalleeEmployeeID", Value= empid_parsed},
                                                    new BizAPP.WebServices.Object.NameValue{ Name="CalleeGroupownername", Value= eid_parsed},
                                                    new BizAPP.WebServices.Object.NameValue{ Name="Diallstatus", Value=dialstatus_parsed},
													new BizAPP.WebServices.Object.NameValue{ Name="CalleeEmployeeMailID", Value= empemail_parsed}
                           
                                               };
                    BizAPP.WebServices.Object.RuntimeClientObject[] rcos = os.UpdateObjects(new BizAPP.WebServices.Object.RuntimeClientObject[] { rcoget }, true);
                }

            //If exist then update the the record
                else
                {
                    McubeDataWriter.LogDataWrite("Existing phone number which is to be Updated");
                    readCUID.Close();
                    try
                    {
                        string query_update = "update tewebsitee set customernam2 = @customernam2,mcubeuniquecallid = @mcubeuniquecallid,emaili4=@emaili4,regio1=@regio1,addres4=@addres4,enquirymod1=@enquirymod1,fugueenquir3=@fugueenquir3,remark5=@remark5,callstarttime=@callstarttime,callendtime=@callendtime,callid=@callid,callpulse=@callpulse,callerbusinessname=@callerbusinessname,callrate=@callrate,calleeemployeeno=@calleeemployeeno,calleename=@calleename,calleeemployeeid=@calleeemployeeid,calleeemployeemailid=@calleeemployeemailid,diallstatus=@dailstatus,calleegroupownername=@calleegroupownername where mobileno=@mobileno";

                        // string query = " insert into MCubeData ( callid,callfrom,starttime,filename,calid,pulse,source,custfeedback,exefeedback,dialstatus,callerbusiness,callername,remark,calleraddress,caller_email,rate,empnumber,endtime,eid,empid,gid,empemail,regoin,custom2,custom4,custom7,custom8) values (@callid_parsed, @callfrom_parsed,@starttime_parsed,@filename_parsed,@calid_parsed, @pulse_parsed, @source_parsed,@custfeedback_parsed,@exefeedback_parsed,@dialstatus_parsed,@callerbusiness_parsed,@callername_parsed,@remark_parsed,@calleraddress_parsed,@caller_email_parsed,@rate_parsed,@empnumber_parsed,@endtime_parsed,@eid_parsed,@empid_parsed,@gid_parsed, @empemail_parsed,@regoin_parsed,@custom2_parsed,@custom4_parsed,@custom7_parsed,@custom8_parsed)";
                        SqlCommand cmd_update_we = new SqlCommand(query_update, con);
                        cmd_update_we.Parameters.AddWithValue("@customernam2", callername_parsed);
                        cmd_update_we.Parameters.AddWithValue("@mcubeuniquecallid", callid_parsed);                        
                        cmd_update_we.Parameters.AddWithValue("@emaili4", caller_email_parsed);
                        cmd_update_we.Parameters.AddWithValue("@regio1", regoin_parsed);
                        cmd_update_we.Parameters.AddWithValue("@addres4", calleraddress_parsed);
                        cmd_update_we.Parameters.AddWithValue("@enquirymod1", "Phone");
                        cmd_update_we.Parameters.AddWithValue("@fugueenquir3", "Open");//dialstatus_parsed);
                        cmd_update_we.Parameters.AddWithValue("@remark5", remark_parsed);
                        cmd_update_we.Parameters.AddWithValue("@callstarttime", starttime_parsed_dt);
                        cmd_update_we.Parameters.AddWithValue("@callendtime", endtime_parsed_dt);
                        cmd_update_we.Parameters.AddWithValue("@callid", calid_parsed);
                        cmd_update_we.Parameters.AddWithValue("@callpulse", pulse_parsed);
                        cmd_update_we.Parameters.AddWithValue("@callerbusinessname", callerbusiness_parsed);
                        cmd_update_we.Parameters.AddWithValue("@callrate", rate_parsed);
                        cmd_update_we.Parameters.AddWithValue("@calleeemployeeno", empnumber_parsed);
                        cmd_update_we.Parameters.AddWithValue("@calleename", assignedto_parsed);
                        cmd_update_we.Parameters.AddWithValue("@calleeemployeeid", empid_parsed);
                        cmd_update_we.Parameters.AddWithValue("@calleeemployeemailid", empemail_parsed);
                        cmd_update_we.Parameters.AddWithValue("@dailstatus", dialstatus_parsed);
                        cmd_update_we.Parameters.AddWithValue("@calleegroupownername", eid_parsed);
                        cmd_update_we.Parameters.AddWithValue("@mobileno", callfrom_parsed);

                        int database_result = cmd_update_we.ExecuteNonQuery();
                        if (database_result != 0)
                        {
                            //Put your Log here
                            con.Close();
                        }
                        else
                        {
                            //  Put your Log here
                            con.Close();
                        }

                    }
                    catch (Exception ex_update)
                    {
                        ExceptionHelper.LogFileWrite(ex_update.Message.ToString());
                        //Put your Log here
                    }
                }

            }

            catch (Exception msg)
            {
                ExceptionHelper.LogFileWrite(msg.Message.ToString());

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }
    }
}
