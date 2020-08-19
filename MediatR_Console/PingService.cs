using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatR_Console
{
    class PingService : IPingService
    {
        private readonly IMediator _mediator;
        public PingService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Ping(string ip)
        {
            Console.WriteLine($"Pinging: {ip}");
            PingEvent pingEvent = new PingEvent($"Ping Service publishes notification PingEvent ({ip})");
            _mediator.Publish(pingEvent);

            Console.WriteLine($"MediatR command LookupRequest returned: {_mediator.Send(new LookupRequest()).Result}");

            LookupResult2 lookupResult = _mediator.Send(new LookupRequest2(ip)).Result;
            if(lookupResult.Success)
                Console.WriteLine($"MediatR command LookupRequest2 returned: {lookupResult.Name}");
            else
                Console.WriteLine($"MediatR command LookupRequest2 error: {lookupResult.ErrorMessage}");
        }
    }
}
