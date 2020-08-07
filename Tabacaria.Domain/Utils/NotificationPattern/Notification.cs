using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tabacaria.Domain.Utils.NotificationPattern
{
    public class Notification
    {
        private readonly List<NotificationBase> _notifications;


        public Notification()
        {
            _notifications = new List<NotificationBase>();
        }

        public List<NotificationBase> Notifications() => _notifications;

        public bool IsInvalid() => _notifications.Any();

        public void AddNotification(string propertyName, string messageError) => _notifications.Add(new NotificationBase(propertyName, messageError));
        
        public void AddNotifications(List<NotificationBase> notifications) => _notifications.AddRange(notifications);

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
