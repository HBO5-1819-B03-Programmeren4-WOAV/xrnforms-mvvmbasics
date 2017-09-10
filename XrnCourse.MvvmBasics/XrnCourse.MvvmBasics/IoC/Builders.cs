using Autofac;
using System;
using XrnCourse.MvvmBasics.Domain.Services;
using XrnCourse.MvvmBasics.ViewModels;

namespace XrnCourse.MvvmBasics.IoC
{
    public static class Builders
    {
        public static ContainerBuilder GetDefaultContainerBuilder()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<ClassmateViewModel>();
            containerBuilder.RegisterType<ClassmateInMemoryService>().As<IClassmateService>();
            return containerBuilder;
        }
    }
}
