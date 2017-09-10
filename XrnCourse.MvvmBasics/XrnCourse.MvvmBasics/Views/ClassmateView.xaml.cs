using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XrnCourse.MvvmBasics.Domain.Models;
using XrnCourse.MvvmBasics.Domain.Services;
using XrnCourse.MvvmBasics.IoC;
using XrnCourse.MvvmBasics.ViewModels;

namespace XrnCourse.MvvmBasics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassmateView : ContentPage
    {
        public ClassmateView(Classmate classmate)
        {
            InitializeComponent();
            IClassmateService cmService = IocRegistry.Container.Resolve<IClassmateService>();
            BindingContext = new ClassmateViewModel(classmate, this.Navigation, cmService);
        }
    }
}