using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRateNetCore.Shared
{
    public class MqttMessageDto
    {
        public string? Topic { get; set; }
        public string? Payload { get; set; }
    }
}
