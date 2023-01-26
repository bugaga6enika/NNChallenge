using System;
using System.Linq;
using System.Reflection;
using Autofac;

namespace NNChallenge.Configuration.IoC
{
    internal class AssemblyRegistrationModule : Autofac.Module
    {
        private readonly Assembly _assembly;

        public AssemblyRegistrationModule(Assembly assembly)
        {
            _assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(_assembly)
               .Where(x => !x.IsAbstract)
               .Where(x => x.GetInterfaces()?.Any() ?? false)
               .AsImplementedInterfaces()
               .SingleInstance();
        }
    }
}

