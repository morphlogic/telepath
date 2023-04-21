using Autofac;
using Morphware.Telepath.DataAccess;

namespace Morphware.Telepath.Api
{
    internal class ApiContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new TelepathContext());
            //  TODO:   register components
        }
    }
}