using PhoneDirectoryApp.ReportData.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.MessageContracts.Commands
{
    public interface IReportRegistrationCommand
    {
        Guid ID { get; set; }
        string ReportName { get; set; }
        string Location { get; set; }
        int RecordUserCount { get; set; }
        int RecordPhoneCount { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedDateTime { get; set; }
        ReportEnum status { get; set; }
    }
}
