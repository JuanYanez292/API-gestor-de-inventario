using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace BLL
{
    public class SMS
    {
        private const string AccountSid = "";
        private const string AuthToken = "";

        public static void EnviarMensaje()
        {
            TwilioClient.Init(AccountSid, AuthToken);

            var toPhoneNumber = "";
            var fromPhoneNumber = "";
            var messageBody = "Un producto ha sido eliminado";

            var messageOptions = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
            {
                From = new PhoneNumber(fromPhoneNumber),
                Body = messageBody
            };

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
        }
    }
}
