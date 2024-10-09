using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.DTOs.Responses
{
    public class ResultResponse<T>
    {
        public T? Data { get; set; }
        public bool? Error { get; set; }
        public bool? IsSucess { get; set; }
        public string? Message { get; set; }

        public ResultResponse(T ? data, bool? error, bool? isSucess, string? message)
        {
            Data = data;
            Error = error;
            IsSucess = isSucess;
            Message = message;
        }

        public static ResultResponse<T> Success(T data, string? message) => new ResultResponse<T>(data, false, true, message);
        public static ResultResponse<T> Failure(string message) => new ResultResponse<T>(default, true, false, message);
    }
}
