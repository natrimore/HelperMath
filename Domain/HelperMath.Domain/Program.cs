using Autofac;
using System;
using System.Reflection;

namespace HelperMath.Domain
{
    public class Program
    {
        public static void Start(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(w => w.Name.EndsWith("Command"))
                   .AsImplementedInterfaces()
                   .PreserveExistingDefaults();

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(w => w.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();
        }
    }
}
