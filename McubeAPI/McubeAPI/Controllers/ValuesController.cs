using McubeAPI.api;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace McubeAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //string data = "%7B%22callid%22%3A%2281230001991417091507%22%2C%22calid%22%3A%226061%22%2C%22refid%22%3A%226061%22%2C%22bid%22%3A%22MQ%3D%3D%22%2C%22gid%22%3A%22Test+for+API%22%2C%22eid%22%3A%22Padma%22%2C%22source%22%3A%22calltrack%22%2C%22hid%22%3A%22%22%2C%22callfrom%22%3A%228123000199%22%2C%22callto%22%3A%228197314282%22%2C%22starttime%22%3A%222014-11-27+18%3A01%3A47%22%2C%22endtime%22%3A%222014-11-27+18%3A01%3A47%22%2C%22pulse%22%3A%220%22%2C%22callername%22%3A%22%22%2C%22callerbusiness%22%3A%22%22%2C%22calleraddress%22%3A%22%22%2C%22remark%22%3A%22%22%2C%22sms_content%22%3A%22%22%2C%22caller_email%22%3A%22%22%2C%22status%22%3A%221%22%2C%22keyword%22%3A%22%22%2C%22filename%22%3A%2281230001991417091507.wav%22%2C%22exefeedback%22%3A%22%22%2C%22custfeedback%22%3A%22%22%2C%22dialstatus%22%3A%22CONNECTING%22%2C%22rate%22%3A%220%22%2C%22assignto%22%3A%22Padma%22%2C%22callback%22%3A%220%22%2C%22leadid%22%3A%220%22%2C%22tktid%22%3A%220%22%2C%22last_modified%22%3A%220000-00-00+00%3A00%3A00%22%2C%22lead%22%3A%22%22%2C%22suptkt%22%3A%22%22%2C%22businessname%22%3A%22VMC+Demo%22%2C%22asto%22%3A%2285%22%2C%22duration%22%3A%220%22%2C%22empnumber%22%3A%228197314282%22%2C%22empid%22%3A%2285%22%2C%22geid%22%3A%220%22%2C%22grid%22%3A%22129%22%2C%22empemail%22%3A%22boddu.padma%40gmail.com%22%2C%22region%22%3A%22KA%22%2C%22apikey%22%3A%228aed310fbb81a876c587b0561e489ce9%22%7D";
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
//        [HttpPost]
//public string TestMethod(Person person)
//{
//    return "Hello from http post web api controller: " + person.Name;
//}
        //public HttpResponseMessage PostComplex([FromBody]string update)
        //{
        //    update = data;
        //    if (ModelState.IsValid && update != null)
        //    {
        //        // Convert any HTML markup in the status text.
        //        update = HttpUtility.HtmlEncode(update);

        //        // Assign a new ID.
        //        var id = Guid.NewGuid();
        //       // updates[id] = update;

        //        // Create a 201 response.
        //        var response = new HttpResponseMessage(HttpStatusCode.Created)
        //        {
        //            Content = new StringContent(update)
        //        };
        //        response.Headers.Location = 
        //            new Uri(Url.Link("DefaultApi", new { action = "status", id = id }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

        // GET api/values/5
    //    public void TestMethodnew(string value)
    //    {
    //        // NameValueCollection nvc = Request.Form;

    //        Helper objHelper = new Helper();
    //        objHelper.PostData(value);

    //    }
    //    public async Task Post()
    //    {
    //        dynamic obj = await Request.Content.ReadAsAsync<JObject>();
    //        var y = obj.var1;
    //    }
    //    // POST api/values
        [HttpPost]
        [ActionName("Complex")]
        public void TestMethod(GetPostvalue values)
        {
            // value=data;
            // NameValueCollection nvc = Request.Form;

            Helper objHelper = new Helper();
            objHelper.PostData(values.value);

        }
        //public HttpResponseMessage Post([FromBody]FormDataCollection formbody)
        //{
        //    // Process the formbody 
        //    var field1Values = formbody.GetValues("field1");
        //    var field2Values = formbody.GetValues("field2");

        //    return new HttpResponseMessage(HttpStatusCode.Created);
        //}
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Helper objHelper = new Helper();
            objHelper.PostData(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}