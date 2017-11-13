using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evidence_osob_server.Interface;
using Newtonsoft.Json;

namespace Evidence_osob_server.JsonParsse
{
    class JsonParser : IParse
    {
        public async Task<T> ParseString<T>(string response)
        {
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response));
        }
    }
}
