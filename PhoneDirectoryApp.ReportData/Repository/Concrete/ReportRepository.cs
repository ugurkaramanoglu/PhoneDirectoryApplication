using PhoneDirectoryApp.ReportData.Model;
using PhoneDirectoryApp.ReportData.ReportContext;
using PhoneDirectoryApp.ReportData.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneDirectoryApp.ReportData.Repository.Concrete
{
    public class ReportRepository : IReportRepository
    {
        protected DatabaseContext _context;

        public ReportRepository(DatabaseContext context)
        {
            _context = context;

        }

        public List<Report> GetListReport(string locationName)
        {
            return _context.Reports.Where(x => x.Location == locationName).ToList();
        }

        public Report ReportPost(Report report)
        {
            _context.Reports.Add(report);
            _context.SaveChanges();
            return report;
        }
        public void ReportRemove(Report report)
        {
            _context.Reports.Remove(report);
            _context.SaveChanges();
        } 


        public Report GetReportItemById(Guid guid)
        {
            return _context.Reports.FirstOrDefault(x => x.ID == guid);
        }

        public List<Report> GetAllReport()
        {
            List<Report> report = new List<Report>();
            report =_context.Reports.OrderByDescending(x=>x.CreatedDate).ToList();
            return report;
        }
        

    }
}
