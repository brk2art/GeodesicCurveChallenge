using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesicCurveChallenge.Infrastructure.Response
{
    public class ResponseBase<T>
    {
        public bool IsSuccess { get; set; }
        public List<Message> MessageList { get; set; }
        public T Result { get; set; }
    }
}
