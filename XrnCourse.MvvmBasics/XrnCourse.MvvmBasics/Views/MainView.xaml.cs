using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XrnCourse.MvvmBasics.Domain.Services;
using XrnCourse.MvvmBasics.IoC;
using XrnCourse.MvvmBasics.ViewModels;

namespace XrnCourse.MvvmBasics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            IClassmateService cmService = IocRegistry.Container.Resolve<IClassmateService>();
            BindingContext = new MainViewModel(this.Navigation, cmService);
        }
    }
}