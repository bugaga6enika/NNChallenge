using System.Reflection;
using Autofac;

namespace NNChallenge.Configuration.IoC
{
    public static class IoC
    {
        private static readonly IContainer _container;

        static IoC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AssemblyRegistrationModule(Assembly.GetAssembly(typeof(Infrastructure.Anchor))));
            builder.RegisterModule(new AssemblyRegistrationModule(Assembly.GetCallingAssembly()));

            _container = builder.Build();
        }

        public static T Resolve<T>() => _container.Resolve<T>();
    }
}