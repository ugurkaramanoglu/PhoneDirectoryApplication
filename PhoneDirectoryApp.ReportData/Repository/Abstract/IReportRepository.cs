using PhoneDirectoryApp.ReportData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.ReportData.Repository.Abstract
{
    public interface IReportRepository
    {
        Report ReportPost(Report report);
        List<Report> GetListReport(string locationName);
        Report GetReportItemById(Guid guid);
        void ReportRemove(Report report);
        List<Report> GetAllReport();

    }
}
