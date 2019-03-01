using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Poc_Firebase_Solution2
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                DateTime date = DateTime.Now;
                string Date = date.ToString("yyyy:MM:dd");
                string Time = date.ToString("HH:mm:ss");

                var json = JsonConvert.SerializeObject(new
                {
                    Name = Date,
                    Value = Time
                });

                var request = WebRequest.CreateHttp("https://poc-firebase-7735b.firebaseio.com/.json?auth=dJVmRiqZnCsBFyJd9EQ64xOv9cINBCHrYhl6Jv9v");
                request.Method = "PATCH";
                request.ContentType = "JSON";
                var buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                var response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

            }
        }
    }
}
