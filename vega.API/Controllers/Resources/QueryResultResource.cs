using System.Collections.Generic;

namespace vega.API.Controllers.Resources
{
    public class QueryResultResource<T>
    {
        public int TotalItems { get; set; }
        public IList<T> Items { get; set; }
    }
}
