using System;
using System.Collections.Generic;
using System.Text;

namespace Tabacaria.Domain.Utils.NotificationPattern
{
    public class NotificationBase
    {
        public string Key { get; set; }
        public string MessageError { get; set; }

        public NotificationBase(string key, string messageError)
        {
            Key = key;
            MessageError = messageError;
        }
    }
}
