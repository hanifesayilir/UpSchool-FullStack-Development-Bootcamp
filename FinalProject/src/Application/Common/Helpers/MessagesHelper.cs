using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Helpers
{
    public static class MessagesHelper
    {
        public static class Email
        {
            public static class Notification
            {
                public static string Subject => "Notification Message After Crawling Ends";
                public static string ActivationMessage => "The crawl is successfully completed.";

                public static string Name(string firstName) =>$"Hi {firstName}";

             /*   public static string ButtonText => "Activate My Account";

                public static string Buttonlink(string email, string emailToken) =>
                    $"https://upstorage.app/account/account-activation?email={email}&token={emailToken}";*/

                /*public static string Buttonlink(string email, string emailToken)
                {
                    return $"https://upstorage.app/account/account-activation?email={email}&token={emailToken}";
                }*/

            }
        }

    }
}
