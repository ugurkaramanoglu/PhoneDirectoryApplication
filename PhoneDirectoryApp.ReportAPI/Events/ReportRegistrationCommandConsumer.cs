using MassTransit;
using Newtonsoft.Json;
using PhoneDirectoryApp.MessageContracts;
using PhoneDirectoryApp.MessageContracts.Commands;
using PhoneDirectoryApp.MessageContracts.Events;
using PhoneDirectoryApp.ReportCore.UserReportDto;
using PhoneDirectoryApp.ReportData.Model;
using PhoneDirectoryApp.ReportData.ReportContext;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectoryApp.ReportAPI.Events
{
    public class ReportRegistrationCommandConsumer : IConsumer<IReportRegistrationCommand>
    {
        public ReportRegistrationCommandConsumer()
        {
            var bus = BusConfigurator.ConfigureBus(factory =>
            {
                factory.ReceiveEndpoint(RabbitMqConstants.RegistrationServiceQueue, endpoint =>
                {
                    endpoint.Consumer<ReportRegistrationCommandConsumer>();
                });
            });

            bus.StartAsync();
        }

        public async Task Consume(ConsumeContext<IReportRegistrationCommand> context)
        {
            Console.WriteLine($"{context.Message.ReportName} isimli Location Report :");
            Console.WriteLine($"Veritabanına kayıt edilmiştir.");

            using (var dbContext = new DatabaseContext())
            {
                var report = dbContext.Reports.FirstOrDefault(x => x.ID == context.Message.ID);

                if (report != null)
                {
                    var client = new RestClient("https://localhost:44386/api/user/user/PostRecordCounts");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/json");
                    var data = new UserReportDTO();
                    data.Address = report.Location;
                    request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    var responsedata = JsonConvert.DeserializeObject<RecordDto>(response.Content);

                    report.RecordPhoneCount = responsedata.recordNumberCount;
                    report.RecordUserCount = responsedata.recordUsersCount;
                    report.status = ReportData.Enum.ReportEnum.Tamamlandı;
                    dbContext.Reports.Update(report);
                    await dbContext.SaveChangesAsync();
                }
            }
        }


    }
}

