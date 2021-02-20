using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using PhoneDirectoryApp.MessageContracts;
//using PhoneDirectoryApp.MessageContracts.Commands;
//using PhoneDirectoryApp.MessageContracts.Models;
using PhoneDirectoryApp.ReportCore.ReportDTO;
using PhoneDirectoryApp.ReportCore.ReportManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectoryApp.ReportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReportController : Controller
    {
        IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        //[HttpPost]
        //public async Task<IActionResult> PostReport(ReportDto reportDto)
        //{
        //    Guid ID = Guid.NewGuid();
        //    reportDto.ID = ID;
        //    reportDto.CreatedDate = DateTime.Now;
        //    reportDto.Location = reportDto.Location;
        //    reportDto.ReportName = reportDto.ReportName;

        //    _reportService.ReportPost(reportDto);


        //    Ürün karşılanır.
        //    Gerekli ön çalışmalar yapılır.

        //    var bus = BusConfigurator.ConfigureBus();
        //    var sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}/{RabbitMqConstants.RegistrationServiceQueue}");
        //    var endPoint = await bus.GetSendEndpoint(sendToUri);
        //    await endPoint.Send<IReportRegistrationCommand>(reportDto);
        //    string message = "Rapor talebiniz başarılı bir şekilde tarafımıza ulaşmıştır. ";
        //    return Ok(message);
            
        //}


        public void RemoveReport(ReportDto reportDTO)
        {
            Guid ID = reportDTO.ID;       
            _reportService.RemoveReport(ID);       
   
        }

        public List<ReportDto> GetAllReport()
        {
            List<ReportDto> reportDtos = new List<ReportDto>();
            reportDtos = _reportService.GetAllReport();
            return reportDtos;
        }
           

    }
}
