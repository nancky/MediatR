using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_Console
{
    public class PingEvent : INotification
    {
        public string Message { get; }

        public PingEvent(string message)
        {
            Message = message;
        }
    }

    public class PingEventHandler : INotificationHandler<PingEvent>
    {
        private readonly ILogger<PingEventHandler> _logger;

        public PingEventHandler(ILogger<PingEventHandler> logger)
        {
            _logger = logger;
        }
        public void Handle(PingEvent notification)
        {
            _logger.LogWarning($"PingEvent Handled: {notification.Message}");
        }

        public Task Handle(PingEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"PingEvent Handled: {notification.Message}");
            return Task.CompletedTask;
        }
    }
}
