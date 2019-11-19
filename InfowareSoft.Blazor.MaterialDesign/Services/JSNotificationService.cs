using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfowareSoft.Blazor.MaterialDesign
{
    public class JSNotificationService : IJSNotificationService
    {
        public JSNotificationService()
        {
        }

        [JSInvokable]
        public static void EventListened(
            string refId,
            string action)
        {
            Console.WriteLine("refId");
            Console.WriteLine(refId);
        }
    }
}
