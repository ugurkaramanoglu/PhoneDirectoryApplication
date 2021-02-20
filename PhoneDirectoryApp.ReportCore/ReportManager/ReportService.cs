using PhoneDirectoryApp.ReportCore.ReportDTO;
using PhoneDirectoryApp.ReportData.Model;
using PhoneDirectoryApp.ReportData.ReportContext;
using PhoneDirectoryApp.ReportData.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.ReportCore.ReportManager
{
    public class ReportService : IReportService
    {
        ReportRepository reportRepository = new ReportRepository(new DatabaseContext());

        public Report ConvertToReport(ReportDto reportDto)
        {
            Report report = new Report();
            report.ID = reportDto.ID;
            report.ReportName = reportDto.ReportName;
            report.CreatedDate = reportDto.CreatedDate;
            report.Location = reportDto.Location;
            report.status = reportDto.Status;
            report.RecordUserCount = reportDto.RecordUserCount;
            report.RecordPhoneCount = reportDto.RecordPhoneCount;
            return report;
        }
        public ReportDto ConvertToReportDTO(Report report)
        {
            ReportDto reportDto = new ReportDto();
            reportDto.ID = report.ID;
            reportDto.ReportName = report.ReportName;
            reportDto.CreatedDate = report.CreatedDate;
            reportDto.Location = report.Location;
            //reportDto.status = report.status;
            //reportDto.RecordUserCount = report.RecordUserCount;
            //reportDto.RecordPhoneCount = report.RecordPhoneCount;
            return reportDto;
        }
        public ReportDto ReportPost(ReportDto reportDto)
        {
            Report rep = ConvertToReport(reportDto);
            Report newrep = reportRepository.ReportPost(rep);
            return ConvertToReportDTO(newrep);
        }
        public List<ReportDto> GetListReport(string locationName)
        {
            List<Report> reports = reportRepository.GetListReport(locationName);
            List<ReportDto> reportList = new List<ReportDto>();
                foreach( var item in reports)
            {
                 reportList.Add( ConvertToReportDTO(item));
            }

            return reportList;
        }
        public void RemoveReport(Guid id)
        {
            Report reportItem = reportRepository.GetReportItemById(id);            
            reportRepository.ReportRemove(reportItem);
        }

        public List<ReportDto> GetAllReport()
        {
            List<ReportDto> reportsDtos = new List<ReportDto>();
            
            List<Report> report = new List<Report>();

            report = reportRepository.GetAllReport();

            foreach (var item in report)
            {
                ReportDto rep = new ReportDto();
                rep.ID = item.ID;
                rep.Location = item.Location;
                rep.ReportName = item.ReportName;
                rep.RecordUserCount = item.RecordUserCount;
                rep.RecordPhoneCount = item.RecordPhoneCount;
                rep.CreatedDateTime = item.CreatedDate.ToShortDateString()+"-"+item.CreatedDate.ToShortTimeString();
                rep.Status = item.status;

                reportsDtos.Add(rep);
            }

            return reportsDtos;
        }
        
    }
    
}
