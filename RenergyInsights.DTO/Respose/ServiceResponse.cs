using System;
using System.Collections.Generic;
using System.Text;

namespace RenergyInsights.DTO.Respose
{
    public class ServiceResponse<T> where T : class
    {
        public bool Status { get; set; }
        public Dictionary<string, string> Error { get; set; }
        public T Data { get; set; }
        public T DataList { get; set; }
        public string Message { get; set; }

        public ServiceResponse()
        {
            Error = new Dictionary<string, string>();
        }

        public static ServiceResponse<T> Success(bool status, T data, string message)
        {
            return new ServiceResponse<T>
            {
                Status = status,
                Data = data
            };
        }

        public static ServiceResponse<T> Failure(bool status, T data, string message, Dictionary<string, string> error)
        {
            return new ServiceResponse<T>
            {
                Error = error,
                Status = status,
                Data = data
            };
        }

    }
}
