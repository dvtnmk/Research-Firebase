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
                string datetime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                //var json = JsonConvert.SerializeObject({TaskQueueAssign})
                string acc = "7E1B30A2-DC27-4A00-B42C-67CDA7DAADC9";
                Guid newGuid = Guid.Parse(acc);
                var obj = new TaskQueueAssign()
                {
                        task = new Tasks
                        {
                            taskId = "121",
                            distance = "10KM",
                            scheduleProvinceName= "กรุงเทพ",
                            schedulePlace ="ทดสอบ Place",
                            scheduleAmphurName = "อำเภอ 1234",
                            isAccept = false,
                            isReject = false,
                            isTimeOut = false,
                            countTime = 10,
                            scheduleTimeText = datetime
                        }
                };

                var json = JsonConvert.SerializeObject(obj);

                //var request = WebRequest.CreateHttp("https://poc-firebase-7735b.firebaseio.com/.json?auth=dJVmRiqZnCsBFyJd9EQ64xOv9cINBCHrYhl6Jv9v");
                var request = WebRequest.CreateHttp("https://claimdibike-1f48a.firebaseio.com/queue_auto_assign/staging/235276fd-8b1e-43fc-8e3e-ae480cba7777/.json?auth=tUi7rbuh4tHhjrz1HEfMlATKtCu4oli02wIIza4I");

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
        //        var firebaseClient = new Firebase("https://poc-firebase-7735b.firebaseio.com/", _accessToken);
        //        var response = firebaseClient.GetStreaming("Acc_id",
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
