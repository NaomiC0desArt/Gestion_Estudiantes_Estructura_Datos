using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_estudiantes.Helpers
{
    public class OperationResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }

        public OperationResult(bool success, string message, dynamic data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
