using Microsoft.AspNetCore.SignalR;
//using PhoneDirectoryApp.MessageContracts.Models;
using PhoneDirectoryApp.ReportData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectoryApp.UI.Hubs
{
    public class UIHub : Hub
    {
        public async Task SendMessageAsync(Report report)
        {
            await Clients.All.SendAsync("receiveProductNotification", report);
        }
    }
}
