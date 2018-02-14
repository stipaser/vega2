using System.Threading.Tasks;

namespace vega.API.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
