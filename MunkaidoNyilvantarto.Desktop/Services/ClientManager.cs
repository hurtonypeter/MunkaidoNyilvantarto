using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.Desktop.Services
{
    public static class ClientManager
    {
        private static CookieAwareWebClient client;

        public static CookieAwareWebClient GetClient()
        {
            if(client == null)
            {
                client = new CookieAwareWebClient();
            }

            return client;
        }

    }
}
