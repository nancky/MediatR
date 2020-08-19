using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_Console
{
    public class LookupResult2
    {
        public bool Success { get; set; }

        public string Name { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class LookupRequest2 : IRequest<LookupResult2>
    {
        string Ip { get; }

        public LookupRequest2(string ip)
        {
            Ip = ip;
        }
    }

    public class LookupHandler2 : IRequestHandler<LookupRequest2, LookupResult2>
    {
        public Task<LookupResult2> Handle(LookupRequest2 request, CancellationToken cancellationToken)
        {
            LookupResult2 lookupResult = new LookupResult2 { Success = true, Name = "Google" };
            return Task.FromResult(lookupResult);
        }
    }
}
