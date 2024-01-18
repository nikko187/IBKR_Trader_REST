using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBKR_Trader_REST
{
    public class Auth_Status
    {
        public class Rootobject
        {
            public bool authenticated { get; set; }
            public bool competing { get; set; }
            public bool connected { get; set; }
            public string message { get; set; }
            public string MAC { get; set; }
            public Serverinfo serverInfo { get; set; }
            public string hardware_info { get; set; }
            public string fail { get; set; }
        }

        public class Serverinfo
        {
            public string serverName { get; set; }
            public string serverVersion { get; set; }
        }

    }
}
