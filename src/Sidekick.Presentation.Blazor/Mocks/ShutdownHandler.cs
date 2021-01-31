using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sidekick.Domain.App.Commands;

namespace Sidekick.Presentation.Blazor.Mocks
{
    public class ShutdownHandler : ICommandHandler<ShutdownCommand>
    {
        public Task<Unit> Handle(ShutdownCommand request, CancellationToken cancellationToken)
        {
            Environment.Exit(Environment.ExitCode);
            return Unit.Task;
        }
    }
}
