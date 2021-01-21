using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solucao.Domain.Response
{
    public class Page<T>
    {
        public Page()
        {
        }

        public IQueryable<T> Content {get; set;}
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public int Size { get; set; }
    }
}
