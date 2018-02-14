using System.Collections.Generic;

namespace vega.API.Core.Models
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }
        public IList<T> Items { get; set; }
    }
}
