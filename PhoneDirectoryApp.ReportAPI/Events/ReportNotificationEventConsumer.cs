using MassTransit;
using Microsoft.AspNetCore.SignalR.Client;
using PhoneDirectoryApp.MessageContracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectoryApp.ReportAPI.Events
{
    public class ReportNotificationEventConsumer : IConsumer<IReportEvent>
    {
        public async Task Consume(ConsumeContext<IReportEvent> context)
        {
            Console.WriteLine($"{context.Message.ReportName} isimli ürün yayınlanarak müşteriler bilgilendirilmiştir.");
            HubConnection connection = new HubConnectionBuilder().WithUrl("https://localhost:44300/UIHub").Build();
            await connection.StartAsync();

            await connection.InvokeAsync("SendMessageAsync", context.Message);

            await connection.StopAsync();
        }
    }
}
