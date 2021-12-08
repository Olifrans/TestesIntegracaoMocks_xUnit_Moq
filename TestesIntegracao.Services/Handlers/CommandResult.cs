using System;
using System.Collections.Generic;
using System.Text;

namespace TestesIntegracao.Services.Handlers
{
    public class CommandResult
    {
        public CommandResult(bool success)
        {
            IsSuccess = success;
        }

        public bool IsSuccess { get; }
    }
}
