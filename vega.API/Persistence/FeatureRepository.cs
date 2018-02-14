using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.API.Core;
using vega.API.Core.Models;

namespace vega.API.Persistence
{
    public class FeatureRepository: IFeatureRepository
    {
        private readonly VegaDbContext _context;

        public FeatureRepository(VegaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feature>> GetFeatures()
        {
            return await _context.Features.ToListAsync();
        }

        public void Add(Feature feature)
        {
            _context.Add(feature);
        }

        public async Task<Feature> GetFeatureById(int featureId)
        {
            return await _context.Features.SingleOrDefaultAsync(x => x.Id == featureId);
        }
    }
}
