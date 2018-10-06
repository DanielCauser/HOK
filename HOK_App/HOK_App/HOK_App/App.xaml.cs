using HOK_App.Commands;
using HOK_App.Services;
using Prism;
using Prism.Ioc;
using HOK_App.ViewModels;
using HOK_App.Views;
using MonkeyCache.SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Autofac;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HOK_App
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            Barrel.ApplicationId = AppInfo.PackageName;
            await NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<AboutPage>();
            containerRegistry.RegisterForNavigation<FeedPage>();
            
            containerRegistry.RegisterSingleton<IErrorManagementService, ErrorManagementService>();

            
            containerRegistry.Register<ILoadFeedCommand, LoadFeedCommand>();
        }
    }
}
