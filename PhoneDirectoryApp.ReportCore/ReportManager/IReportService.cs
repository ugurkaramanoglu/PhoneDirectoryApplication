using PhoneDirectoryApp.ReportCore.ReportDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.ReportCore.ReportManager
{
    public interface IReportService
    {
        ReportDto ReportPost(ReportDto reportDto);
        List<ReportDto> GetListReport(string locationName);
        List<ReportDto> GetAllReport();
        void RemoveReport(Guid id);
    }

}
