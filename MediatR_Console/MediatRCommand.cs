using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediatR_Console
{

    public class DataReturnedByHandler
    {
        public bool Success { get; set; }
        public string Data { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class MediatRCommand :  IRequest<DataReturnedByHandler>
    {
        public string S { get; }
        public MediatRCommand(string s)
        {
            S = s;
        }
    }
    public class MediatRCommandHandler : IRequestHandler<MediatRCommand, DataReturnedByHandler>
    {
        public Task<DataReturnedByHandler> Handle(MediatRCommand request, CancellationToken cancellationToken)
        {
            DataReturnedByHandler result = new DataReturnedByHandler { Success = true, Data = request.S };  
            return Task.FromResult(result);
        }
    }
}
