using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.ReportData.Model
{
   public  class Report
    {
        public Guid ID { get; set; }
        public string ReportName { get; set; }
        public string Location { get; set; }
        public int RecordUserCount { get; set; }
        public int RecordPhoneCount { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ReportEnum status { get; set; }
    }
}
