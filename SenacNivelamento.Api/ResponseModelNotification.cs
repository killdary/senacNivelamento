using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenacNivelamento.Api
{
    public class ResponseModelNotification
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public object Data { get; set; }
    }
}
