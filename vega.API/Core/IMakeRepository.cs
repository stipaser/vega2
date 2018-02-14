using System.Collections.Generic;
using System.Threading.Tasks;
using vega.API.Core.Models;

namespace vega.API.Core
{
    public interface IMakeRepository
    {
        Task<IEnumerable<Make>> GetMakes();
        void Add(Make make);
        Task<Make> GetMakeById(int makeId);
    }
}
