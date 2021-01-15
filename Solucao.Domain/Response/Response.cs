using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Solucao.Domain.Response
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
