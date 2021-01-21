using System.Threading.Tasks;

namespace BC.Ns.Domain.Interface
{
    public interface ICanaryDomain
    {
        Task<bool> GetTest();
    }
}
