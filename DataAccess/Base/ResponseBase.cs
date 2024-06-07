using System.Net;

namespace DataAccess.Base
{
    public class ResponseBase<T>
    {
        public int Code { get; set; }
        public string Message { get; set; } = null!;
        public T? Data;
        public ResponseBase(T data, string message, int code)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public ResponseBase(T data, string message)
        {
            Code = (int)HttpStatusCode.OK;
            Message = message;
            Data = data;
        }

        public ResponseBase(string message, int code)
        {
            Code = code;
            Message = message;
        }
    }
}
