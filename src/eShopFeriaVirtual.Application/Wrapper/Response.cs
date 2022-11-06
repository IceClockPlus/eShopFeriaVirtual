using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Wrapper
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Response()
        {

        }

        /// <summary>
        /// Instantiate a successful response
        /// </summary>
        /// <param name="data">Data of the response</param>
        public Response(T data)
        {
            Success = true;
            Data = data;
        }

        /// <summary>
        /// Instantiate an failed response
        /// </summary>
        /// <param name="message">Main message of failed response</param>
        /// <param name="errors">List of error of failed response</param>
        public Response(string message, List<string> errors = null)
        {
            Success = false;
            Errors = errors;
            Message = message;
        }

    }
}
