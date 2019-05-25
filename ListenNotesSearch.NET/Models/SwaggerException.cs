using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using RestSharp;

namespace ListenNotesSearch.NET.Models
{
    public class SwaggerException : Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public IEnumerable<Parameter> Headers { get; private set; }

        public SwaggerException(string message, int statusCode, string response,
            IEnumerable<Parameter> headers, Exception innerException)
            : base(
                message + "\n\nStatus: " + statusCode + "\nResponse: \n" +
                response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return $"HTTP Response: \n\n{Response}\n\n{base.ToString()}";
        }
    }

    [GeneratedCode("NSwag", "12.3.1.0 (NJsonSchema v9.14.1.0 (Newtonsoft.Json v11.0.0.0))")]
    public class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; private set; }

        public SwaggerException(string message, int statusCode, string response,
            IEnumerable<Parameter> headers, TResult result, Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }
}