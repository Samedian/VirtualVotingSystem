using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using VirtualVotingSystemEntities;

namespace VirtualVotingDemo
{
    public class SMS :TwilioController, ISMS
    {

        public string SendOTP(string MobileNumber)
        {
            string accountSid = "AC82ff01713e70291bb73582ae69445d96";
            string authToken = "41d40cc19372b51b77e414cd484a4a73";

            TwilioClient.Init(accountSid, authToken);

            Random random = new Random();
            string verifyCode = random.Next(10000, 99999).ToString();
            string data = "OTP for registering to cast the vote" + verifyCode;

            try
            {
                var message = MessageResource.Create(
                body: data,
                from: new Twilio.Types.PhoneNumber("+12058461346"),
                to: new Twilio.Types.PhoneNumber("+91" + MobileNumber)
            );
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
            return verifyCode;
        }


        public void SendPassword(string MobileNumber, UserIdEntity userIdEntity)
        {
            string accountSid = "AC82ff01713e70291bb73582ae69445d96";
            string authToken = "41d40cc19372b51b77e414cd484a4a73";

            TwilioClient.Init(accountSid, authToken);

            string data = "Congratulations!"+"\n You have successfully registered "+"\n Login Credentials"+"\n VVID: " + userIdEntity.Vvid + "\n Password: " + userIdEntity.Pass +"\n Thank You";

            try
            {
                var message = MessageResource.Create(
                body: data,
                from: new Twilio.Types.PhoneNumber("+12058461346"),
                to: new Twilio.Types.PhoneNumber("+91" + MobileNumber)
            );
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
           
        }
    }

}
