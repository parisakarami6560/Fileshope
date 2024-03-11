using System.Runtime.Serialization;

namespace Kavenegar
{
    internal class Core
    {
        internal class Exceptions
        {
            [Serializable]
            internal class ApiException : Exception
            {
                public ApiException()
                {
                }

                public ApiException(string? message) : base(message)
                {
                }

                public ApiException(string? message, Exception? innerException) : base(message, innerException)
                {
                }

                protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
                {
                }
            }

            [Serializable]
            internal class HttpException : Exception
            {
                public HttpException()
                {
                }

                public HttpException(string? message) : base(message)
                {
                }

                public HttpException(string? message, Exception? innerException) : base(message, innerException)
                {
                }

                protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context)
                {
                }
            }
        }
    }
}