using DBookStore.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBookStore.Common.Contracts
{
    public class BookCreated : ICommand
    {
        public Guid Id { get; set; }
        public string ResourceUrl { get; set; }
    }
}
