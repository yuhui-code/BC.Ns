using BC.Ns.Models.Request;
using System.Threading.Tasks;

namespace BC.Ns.Domain.Interface
{
    public interface IAccountDomain
    {
        Task<bool> Login(AccountRequest account);
    }
}
