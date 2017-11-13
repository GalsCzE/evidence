using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_osob_server.Interface
{
    interface IParse
    {
        Task<T> ParseString<T>(string response);
    }
}
