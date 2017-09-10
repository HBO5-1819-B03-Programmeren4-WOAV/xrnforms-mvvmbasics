using Autofac;
using System;
using XrnCourse.MvvmBasics.Domain.Services;

namespace XrnCourse.MvvmBasics.IoC
{
    public static class Builders
    {
        public static ContainerBuilder GetDefaultContainerBuilder()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ClassmateInMemoryService>().As<IClassmateService>();
            return containerBuilder;
        }
    }
}
