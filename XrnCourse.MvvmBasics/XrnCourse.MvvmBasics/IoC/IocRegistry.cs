using Autofac;
using XrnCourse.MvvmBasics.Domain.Services;

namespace XrnCourse.MvvmBasics.IoC
{
    public class IocRegistry
    {
        private static IContainer container;
        public static IContainer Container { get
            {
                if(container == null)
                {
                    //create container if not existing
                    var builder = Builders.GetDefaultContainerBuilder();
                    container = builder.Build();
                }
                return container;
            }
        }
    }
}
