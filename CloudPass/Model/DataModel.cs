using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPass.Model
{
    public class DataModel
    {
        // Properties to store data for a specific entry:
        public string Url { get; set; }       // URL of a website or service.
        public string Username { get; set; }  // Username or account name.
        public string Password { get; set; }  // Password associated with the account.
    }
}
