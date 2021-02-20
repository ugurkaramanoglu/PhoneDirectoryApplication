using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using PhoneDirectoryApp.MessageContracts;
//using PhoneDirectoryApp.ReportAPI.Events;
using PhoneDirectoryApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectoryApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public  IActionResult Directory()
        {
            

            return View();
        }

        //public async Task<IActionResult> Report()
        //{
        //    var bus = BusConfigurator.ConfigureBus(factory =>
        //    {
        //        factory.ReceiveEndpoint(RabbitMqConstants.NotificationServiceQueue, endpoint =>
        //        {
        //            endpoint.Consumer<ReportNotificationEventConsumer>();
        //        });
        //    });

        //    await bus.StartAsync();

        //    return View();
           
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
