using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesicCurveChallenge.Infrastructure.Response
{
    public class Message
    {
        public MessageType Type { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string PropertyName { get; set; }
    }
}
