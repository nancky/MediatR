using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_Console
{
    public class LookupRequest : IRequest<string> {}
    public class LookupHandler : IRequestHandler<LookupRequest, string>
    {
        public Task<string> Handle(LookupRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Google");
        }
    }
}
