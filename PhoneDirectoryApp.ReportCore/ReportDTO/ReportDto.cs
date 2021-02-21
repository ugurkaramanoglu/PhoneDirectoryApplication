using PhoneDirectoryApp.ReportData.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.ReportCore.ReportDTO
{
    public class ReportDto
    {
        public Guid ID { get; set; }
        public string ReportName { get; set; }
        public string Location { get; set; }
        public int RecordUserCount { get; set; }
        public int RecordPhoneCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateTime { get; set; }
        public ReportEnum Status { get; set; }
    }
}
