using System;
using System.Collections.Generic;
using System.Text;


namespace MediatR_Console
{
    class ConsoleApplication
    {
        private readonly IPingService _pingService;
        public ConsoleApplication(IPingService pingService)
        {
            _pingService = pingService;
        }

        public void Run()
        {
            _pingService.Ping("8.8.8.8");
        }
    }
}
