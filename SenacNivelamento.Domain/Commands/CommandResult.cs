using SenacNivelamento.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Domain.Commands
{
    public class CommandResult : Notification, ICommandResult
    {
        public DateTime Executed { get; set; }
        protected CommandResult()
        {
            Executed = DateTime.UtcNow;
        }
    }
}
