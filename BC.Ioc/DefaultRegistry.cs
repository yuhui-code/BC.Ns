using BC.Ns.Data;
using BC.WebApi.Logger;
using StructureMap.Configuration.DSL;

namespace BC.Ioc
{
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.Assembly("BC.Ns.Domain");
                    scan.Assembly("BC.WebApi");
                    scan.WithDefaultConventions();
                });
            For(typeof(ILogger<>)).Use(typeof(Logger<>));
            For<NsDbContext>().Use<NsDbContext>();
        }

        #endregion
    }
}