using System.Threading.Tasks;
using vega.API.Core.Models;

namespace vega.API.Core
{
    public interface IModelRepository
    {
        void CreateModel(Model model);
        Task<Model> GetModelById(int modelId);
    }
}
