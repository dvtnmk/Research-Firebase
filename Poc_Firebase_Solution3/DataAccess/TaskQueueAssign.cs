using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Poc_Firebase_Solution3.DataAccess
{
    public class TaskQueueAssign
    {
        //public Guid Acc_id { get; set; }
        public Tasks task;
    }
    public class Tasks
    {
        public string taskId { get; set; }
        public string taskType { get; set; }
        public string scheduleDateText { get; set; }
        public string scheduleTimeText { get; set; }
        public string distance { get; set; }
        public string schedulePlace { get; set; }
        public string scheduleAmphurName { get; set; }
        public string scheduleProvinceName { get; set; }
        public int countTime { get; set; }
        public bool isAccept { get; set; }
        public bool isReject { get; set; }
        public bool isTimeOut { get; set; }
    }
}
