using McubeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI;
using ExceptionLibrary;
namespace McubeAPI.Controllers
{
    public class UpdatesController : ApiController
    {
         static readonly Dictionary<Guid, Update> updates = new Dictionary<Guid, Update>();

        [HttpPost]
        [ActionName("simple")]
        public HttpResponseMessage PostComplex(Update update)
        {
            try
            {
                JSONHelper objHelper = new JSONHelper();
                objHelper.PostData(update.data);
            }
            catch(Exception ex)
            {
                ExceptionHelper.LogFileWrite(ex.Message.ToString());
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,ex.Message.ToString());
                   
            }
          
                // Convert any HTML markup in the status text.
            update.data = HttpUtility.HtmlEncode(update.data);

                // Assign a new ID.
                var id = Guid.NewGuid();
                updates[id] = update;

                // Create a 201 response.
                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent("Data Inserted Successfully")
                };
             
                return response;
          
        }

        [HttpGet]
        public Update data(Guid id)
        {
            Update update;
            if (updates.TryGetValue(id, out update))
            {
                return update;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

    }
    
}
