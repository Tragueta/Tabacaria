using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tabacaria.Domain.Interfaces;

namespace Tabacaria.Domain.Utils.NotificationPattern
{
    public class Notification : INotification
    {
        public List<NotificationBase> Notifications { get; }


        public Notification()
        {
            Notifications = new List<NotificationBase>();
        }

        public bool HasNotifications() => Notifications.Any();

        public bool IsInvalid() => Notifications.Any();

        public IOrderedEnumerable<NotificationBase> GetNotifications() => Notifications.OrderBy(x => x.Key);

        public void AddNotification(string propertyName, string messageError) => Notifications.Add(new NotificationBase(propertyName, messageError));

        public void AddNotifications(List<NotificationBase> notifications) => Notifications.AddRange(notifications);

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors.OrderBy(x => x.PropertyName))
            {
                AddNotification(error.PropertyName, error.ErrorMessage);
            }
        }

        public string GetErrorMessages()
        {
            var errors = new StringBuilder();

            foreach (var error in GetNotifications())
            {
                errors.Append($"Property Name: {error.Key}, Error Message: {error.MessageError}. \r\n");
            }
            return errors.ToString();
        }
    }
}
