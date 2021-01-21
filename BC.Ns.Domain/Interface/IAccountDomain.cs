using BC.Ns.Models.Request;
using BC.Ns.Models.Response;
using System.Threading.Tasks;

namespace BC.Ns.Domain.Interface
{
    public interface IAccountDomain
    {
        Task<AccountResponse> Login(string username, string password);
    }
}
