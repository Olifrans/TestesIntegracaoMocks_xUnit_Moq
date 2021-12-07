using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesIntegracao.Services.Handlers
{
    public class ComandResult
    {
        public ComandResult(bool success)
        {
            IsSuccess = success;
        }
        public bool IsSuccess { get; }
    }
}
