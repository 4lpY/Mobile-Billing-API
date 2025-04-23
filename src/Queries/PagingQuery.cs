using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Queries
{
    public class PagingQuery
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}