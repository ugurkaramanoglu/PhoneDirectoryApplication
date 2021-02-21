using MassTransit;
using PhoneDirectoryApp.MessageContracts;
using PhoneDirectoryApp.ReportAPI.Events;
using System;
using System.Threading.Tasks;

namespace PhoneDirectoryApp.Registration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bus = BusConfigurator.ConfigureBus(factory =>
            {
                factory.ReceiveEndpoint(RabbitMqConstants.RegistrationServiceQueue, endpoint =>
                {
                    endpoint.Consumer<ReportRegistrationCommandConsumer>();
                });
            });

            await bus.StartAsync();
            await Task.Run(() => Console.ReadLine());
            await bus.StopAsync();
        }
    }
}
