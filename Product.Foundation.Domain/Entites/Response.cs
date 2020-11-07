using System;
using System.Collections.Generic;
using System.Text;

namespace Tabacaria.Foundation.Domain.Entites
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object ResponseObject { get; set; }

        public Response() { }

        public Response(bool success, string message, object responseObject)
        {
            Success = success;
            Message = message;
            ResponseObject = responseObject;
        }
    }
}
