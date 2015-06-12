using McubeAPI.api;
using McubeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace McubeAPI.Controllers
{
    public class ContactController : ApiController
    {
        static readonly Dictionary<Guid, Change> changes = new Dictionary<Guid, Change>();
        [HttpPost]
        [ActionName("Code")]

        public void TestMethod([FromBody]dynamic data)
        {
            Helper objHelper = new Helper();
            objHelper.PostData(data);
          
        }
        public HttpResponseMessage PostComplex([FromBody]Change change)
        {
            if (ModelState.IsValid && change != null)
            {
                change.value = HttpUtility.HtmlEncode(change.value);

                var Id = Guid.NewGuid();
                changes[Id] = change;

                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(change.value)
                };
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { action = "value", Id = Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
