using EmbedIO.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmbedIO;
using EmbedIO.Routing;
using System.Text.Json;

namespace BlockchainPrototype.Networking.Controllers
{
    public sealed class ChainController : WebApiController
    {
        [Route(HttpVerbs.Get, "/Test")]
        public String Test()
        {
            Response.ContentType = "application/json";
            return JsonSerializer.Serialize(new Models.Api.Test() { Content = "sraka", TestValue = 213742069 });
        }











    }
            


 }

