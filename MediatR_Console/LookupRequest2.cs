using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_Console
{

    public class LookupResult
    {
        public bool Success { get; set; }
        public string Name { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class LookupRequest2 : IRequest<LookupResult>
    {
        string Ip { get; }
        public LookupRequest2(string ip)
        {
            Ip = ip;
        }
    }
    public class LookupHandler2 : IRequestHandler<LookupRequest2, LookupResult>
    {
        public Task<LookupResult> Handle(LookupRequest2 request, CancellationToken cancellationToken)
        {
            LookupResult lookupResult = new LookupResult { Success = true, Name = "Google" };  
            return Task.FromResult(lookupResult);
        }
    }
}
