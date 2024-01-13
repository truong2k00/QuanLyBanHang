using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPT2.Commons.Responces
{
    public class ResponcesObject<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ResponcesObject()
        {
        }

        public ResponcesObject(int status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
        public ResponcesObject<T> ResponcesSuccess(string message, T Data)
        {
            return new ResponcesObject<T>(StatusCodes.Status200OK, message, Data);
        }
        public ResponcesObject<T> ResponcesError(int status, string message, T Data)
        {
            return new ResponcesObject<T>(status, message, Data);
        }
    }
}
