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
            _mediator.Publish(new PingEvent($"Ping Service publishes notification PingEvent ({ip})"));

            Console.WriteLine($"MediatR command LookupRequest returned: {_mediator.Send(new LookupRequest()).Result}");

            LookupResult lookupResult = _mediator.Send(new LookupRequest2(ip)).Result;
            if(lookupResult.Success)
                Console.WriteLine($"MediatR command LookupRequest2 returned: {lookupResult.Name}");
            else
                Console.WriteLine($"MediatR command LookupRequest2 error: {lookupResult.ErrorMessage}");
        }
    }
}
