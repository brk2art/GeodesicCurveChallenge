using System;
using System.Collections.Generic;

namespace GeodesicCurveChallenge.Infrastructure.Response
{
    public static class ResponseBaseExtensions
    {
        public static ResponseBase<T> Ok<T>(this T model)
        {
            return new() { IsSuccess = true, Result = model };
        }

        public static ResponseBase<T> Error<T>(this Enum messageEnum)
        {
            return new()
            {
                IsSuccess = false,
                MessageList = new List<Message>
                {
                    new()
                    {
                        Code = Convert.ToInt32(messageEnum).ToString(),
                        Description = messageEnum.ToString(),
                        Type = MessageType.Error
                    }
                }
            };
        }
    }
}
