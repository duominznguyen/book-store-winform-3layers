using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Represents the result of an operation. use for returning success or failure information from lower layers to upper layers.
    /// </summary>
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
