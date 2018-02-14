using System.Collections.Generic;
using System.Threading.Tasks;
using vega.API.Core.Models;

namespace vega.API.Core
{
    public interface IFeatureRepository
    {
        Task<IEnumerable<Feature>> GetFeatures();
        void Add(Feature feature);
        Task<Feature> GetFeatureById(int makeId);
    }
}
