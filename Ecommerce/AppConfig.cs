using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class AppConfig
    {
        public StatusCodeHelpRefrence? StatusCodeHelpRefrence { get; set; }
    }

    public class StatusCodeHelpRefrence
    {
        public string? BadRequest { get; set; }
        public string? Unauthorized { get; set; }
        public string? Forbidden { get; set; }
        public string? NotFound { get; set; }
        public string? NoContent { get; set; }
        public string? InternalserverError { get; set; }
        public string? Conflict { get; set; }
    }
}
