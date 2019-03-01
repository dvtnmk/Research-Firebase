using System;
using System.Threading;
using FirebaseSharp.Portable;

namespace Poc_Firebase_OnchildChanged
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var app = new FirebaseApp(new Uri("https://poc-firebase-7735b.firebaseio.com/"),
                "dJVmRiqZnCsBFyJd9EQ64xOv9cINBCHrYhl6Jv9v");

            JobQueue<Job> queue = new JobQueue<Job>(app.Child("jobs/job"), job =>
            {
                Console.WriteLine("[{0}]: {1}", job.Priority, job.Description);
                return true;
            });

            var feederStart = new ParameterizedThreadStart(Feeder);
            Thread feeder = new Thread(feederStart);
            feeder.Start(queue);

            Console.ReadLine();
        }

        private static void Feeder(object queueObj)
        {
            JobQueue<Job> queue = (JobQueue<Job>)queueObj;

            Random rng = new Random();

            for (int i = 0; i < 100; i++)
            {
                queue.Enqueue(new Job
                {
                    Description = String.Format("Job {0}", i),
                    Priority = rng.Next(),
                });

                // Add delay
                Thread.Sleep(TimeSpan.FromSeconds(rng.Next(0, 5)));
            }
        }
    }
}
