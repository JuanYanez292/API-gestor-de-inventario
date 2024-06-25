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
        private const string AccountSid = "ACbd7fa196baf26722498e0687c6896886";
        private const string AuthToken = "99c7b08cd87d8151fb34468026ab31eb";

        public static void EnviarMensaje()
        {
            TwilioClient.Init(AccountSid, AuthToken);

            var toPhoneNumber = "+528136183555";
            var fromPhoneNumber = "+19386661795";
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
