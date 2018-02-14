using System.Collections.Generic;
using System.Threading.Tasks;
using vega.API.Core.Models;

namespace vega.API.Core
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetPhotos(int vehicleId);
    }
}
