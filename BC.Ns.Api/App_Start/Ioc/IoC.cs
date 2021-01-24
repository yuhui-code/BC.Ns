using StructureMap;

namespace BC.Ns.Api.App_Start.Ioc
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}