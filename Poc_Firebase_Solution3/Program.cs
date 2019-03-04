using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Poc_Firebase_Solution3.DataAccess;
using FirebaseSharp.Portable;
using FirebaseSharp.Portable.Interfaces;

namespace Poc_Firebase_Solution2
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
                //SubscribeToNestDeviceDataUpdates();
                //var json = new JavaScriptSerializer().Serialize(obj);
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                string time = DateTime.Now.ToString("HH:mm:ss");
                //var json = JsonConvert.SerializeObject({TaskQueueAssign})
                string acc = "7e1b30a2-dc27-4a00-b42c-67cda7daadc9";
                string auth = "tUi7rbuh4tHhjrz1HEfMlATKtCu4oli02wIIza4I";
                string host = "https://claimdibike-1f48a.firebaseio.com/";
                string parent = "queue_auto_assign";
                string env = "staging";
                Guid newGuid = Guid.Parse(acc);
                var obj = new TaskQueueAssign()
                {
                        task = new Tasks
                        {
                            taskId = "121",
                            distance = "10KM",
                            scheduleProvinceName= "กรุงเทพ",
                            schedulePlace ="ทดสอบ Place",
                            scheduleDateText = date,
                            scheduleTimeText = time,
                            scheduleAmphurName = "อำเภอ 1234",
                            isAccept = false,
                            isReject = false,
                            isTimeOut = false,
                            countTime = 10,
                        }
                };

                var json = JsonConvert.SerializeObject(obj);

                //var request = WebRequest.CreateHttp("https://poc-firebase-7735b.firebaseio.com/.json?auth=dJVmRiqZnCsBFyJd9EQ64xOv9cINBCHrYhl6Jv9v");
                //https://claimdibike-1f48a.firebaseio.com/queue_auto_assign/staging

                var request = WebRequest.CreateHttp(host+"/"+ parent +"/"+ env +"/"+ acc +"/.json?auth="+auth);

                request.Method = "PATCH";
                request.ContentType = "JSON";
                var buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                var response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

            //}
        }

        //internal static void SubscribeToTasksDataUpdates(string accessToken)
        //{
        //    _accessToken = accessToken;

        //    Console.WriteLine("Press any key to start listening for Nest Device data updates.");
        //}

        //private static void SubscribeToTasksDataUpdates()
        //{
        //    try
        //    {
        //        _accessToken = "dJVmRiqZnCsBFyJd9EQ64xOv9cINBCHrYhl6Jv9v";
        //        var firebaseClient = new FirebaseApp("https://poc-firebase-7735b.firebaseio.com/", _accessToken);
        //        var response = firebaseClient.Child("Acc_id",
        //                changed: (s, e) =>
        //                {
        //                    if (e.Path.Contains("ambient_temperature_f"))
        //                        Console.WriteLine("Current temperature has been updated to: {0}.", e.Data);
        //                });

        //        Console.WriteLine("Change the current temperature of the Nest Thermostat in the Nest Developer Chrome Extension to see the real-time updates.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
    }
}
