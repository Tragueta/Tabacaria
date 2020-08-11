using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Tabacaria.Domain.Utils.NotificationPattern;

namespace Tabacaria.Domain.Interfaces
{
    public interface INotification
    {
        bool HasNotifications();
        bool IsInvalid();
        IOrderedEnumerable<NotificationBase> GetNotifications();
        void AddNotification(string propertyName, string messageError);
        void AddNotifications(List<NotificationBase> notifications);
        void AddNotifications(ValidationResult validationResult);
        string GetErrorMessages();
    }
}
