using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Poc_Firebase
{
    
    public class Program
    {
        public static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "dJVmRiqZnCsBFyJd9EQ64xOv9cINBCHrYhl6Jv9v",
            BasePath = "https://poc-firebase-7735b.firebaseio.com/"
        };

        public static IFirebaseClient client;

        public static void Main(string[] args)
        {
            client = new FireSharp.FirebaseClient(config);

            if(client != null)
            {
                Console.WriteLine("Connection is established");
            }
            else
            {
                Console.WriteLine("Fail to Connection");
            }
            Console.ReadKey();

        }
    }
}
