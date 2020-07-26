using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segfy.Youtube.WebApi.Commom
{
    public interface IPagingQueryParams
    {
        int? Page { get; set; }
        int? MaxResults { get; set; }
    }
}
