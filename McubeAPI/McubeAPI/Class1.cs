using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace McubeAPI
{
    public class Class1
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var data = "=Short test...";
                var result = client.UploadString("http://localhost:63904/api/values", "POST", data);
                Console.WriteLine(result);
            }
        }
    }
}