using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Attributes.Exceptions
{
    public class ExceptionResponse
    {
        #region Constructor
        public ExceptionResponse(string? id, string code, string status, string message, object data, string helprefrence)
        {
            Data = data;
            Code = code;
            Message = message;
            Id = id;
            Helprefrence = helprefrence;
            Status = status;
        }
        #endregion

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public object Data { get; set; }
        [JsonProperty("help_refrence")]
        public string Helprefrence { get; set; }
    }
}
