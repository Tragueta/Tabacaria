using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Foundation.Domain.Entites;

namespace Tabacaria.Foundation.Domain.Handler
{
    public abstract class RequestHandlerBase<T> : IRequestHandler<T, Response> where T : IRequest<Response>
    {
        public Task<Response> Handle(T request, CancellationToken cancellationToken)
        {
            try
            {
                return this.SafeExecuteHandler(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return Task.FromResult<Response>(new Response(false, ex.Message, null));
            }

        }

        public abstract Task<Response> SafeExecuteHandler(T request, CancellationToken cancellationToken);
    }
}
