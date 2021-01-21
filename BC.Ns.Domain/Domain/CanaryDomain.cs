using BC.Ns.Domain.Interface;
using System.Threading.Tasks;

namespace BC.Ns.Domain.Domain
{
    public class CanaryDomain : ICanaryDomain
    {
        public async Task<bool> GetTest()
        {
            var a = new Product();
            if (a.P.P == null)
            { }

            return await Task.FromResult<bool>(true);
        }
    }

    public class Product
    {
        public Product P { get; set; }
    }
}
