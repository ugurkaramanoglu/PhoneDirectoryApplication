using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectoryApp.MessageContracts
{
    public class RabbitMqConstants
    {
        public const string RabbitMqUri = "rabbitmq://localhost/";
        public const string Username = "guest";
        public const string Password = "guest";
        public const string RegistrationServiceQueue = "registration.service";
        public const string NotificationServiceQueue = "UI.service";
     
    }
}
