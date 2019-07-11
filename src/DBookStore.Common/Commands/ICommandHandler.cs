using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBookStore.Common.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}
