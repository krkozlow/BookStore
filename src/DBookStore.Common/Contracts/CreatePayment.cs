﻿using DBookStore.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBookStore.Common.Contracts
{
    public class CreatePayment : ICommand
    {
        public Guid OrderId { get; set; }
    }
}
