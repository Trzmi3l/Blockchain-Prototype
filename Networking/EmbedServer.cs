using EmbedIO;
using EmbedIO.Actions;
using EmbedIO.WebApi;
using Swan.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Networking
{
    class EmbedServer
    {

        public EmbedServer(EmbedServerConfig config)
        {
            using(var server = CreateWebServer(config.url))
            {
                server.RunAsync();

                var browser = new System.Diagnostics.Process()
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo(config.url) { UseShellExecute = true }
                };
                // browser.Start();
                Console.ReadKey();
            }

        }

        private static WebServer CreateWebServer(string url)
        {
            var webServer = new WebServer(o => o
                .WithUrlPrefix(url)
                .WithMode(HttpListenerMode.EmbedIO))
            .WithLocalSessionManager()
          .WithWebApi("/api", m => m
                    .WithController<Controllers.ChainController>())
            .WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendDataAsync(new { Message = "Error" })));
            webServer.StateChanged += (s, e) => $"WebServer New State - {e.NewState}".Info();

            return webServer;

        }

    }
}
