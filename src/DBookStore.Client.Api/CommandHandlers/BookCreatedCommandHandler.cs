using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Client.Api.CommandHandlers
{
    public class BookCreatedCommandHandler : ICommandHandler<BookCreated>
    {
        public Task Handle(BookCreated command)
        {
            throw new NotImplementedException();
        }
    }
}
