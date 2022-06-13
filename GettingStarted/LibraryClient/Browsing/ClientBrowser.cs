using LibraryClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClient.Browsing
{
    internal class ClientBrowser
    {
        private CalculatorClient client;
        public ClientBrowser(CalculatorClient client)
        {
            this.client = client;
        }
        
        
    }
}
