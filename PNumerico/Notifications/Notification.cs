using System;

namespace PNumerico.Notifications
{
    public class Notification
    {
        public string Message { get; set; }
        public string MetaData { get; set; }
        public string Caller { get; set; }
        public Exception Error { get; set; }


        public Notification(string caller, string message)
        {
            Caller = caller;
            Message = message;
        }
    }
}
