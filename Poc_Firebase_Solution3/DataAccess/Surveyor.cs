using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_Firebase_Solution3.DataAccess
{
    public class Surveyor
    {

    }
    public class SurveyorModel
    {
        public Guid accId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string tel { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string picture { get; set; }
        public string distance { get; set; }
        public double? dist { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public bool? IsOnline { get; set; }
        public bool IsWorking { get; set; }
        public string lastUpdate { get; set; }
        public string depName { get; set; }
        public string rankId { get; set; }
        public int? roleId { get; set; }
        public List<SurveyorJobModel> Task { get; set; }
        public string roleName { get; set; }
        public DateTime? createDate { get; set; }
    }
    public class SurveyorJobModel
    {
        public string taskId { get; set; }
        public string informerName { get; set; }
        public string informerTel { get; set; }
        public string note { get; set; }
        public DateTime? scheduleDate { get; set; }
        public string schedulePlance { get; set; }
        public string scheduleLatitude { get; set; }
        public string scheduleLongitude { get; set; }
        public string taskType { get; set; }
        public string taskProcessName { get; set; }
        public DateTime? taskProcessCreateDate { get; set; }
        public bool isWorking { get; set; }
    }
}
