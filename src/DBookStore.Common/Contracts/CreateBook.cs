using DBookStore.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBookStore.Common.Contracts
{
    public class CreateBook : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Release { get; set; }
    }
}
