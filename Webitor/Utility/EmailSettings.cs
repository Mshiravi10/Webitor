using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webitor.Utility
{
    public class EmailSettings
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string DisplayName { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool UseSSL { get; set; }
        public List<int> StatusCodesToNotify { get; set; }
    }
}
