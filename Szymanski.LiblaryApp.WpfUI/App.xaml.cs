using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Szymanski.LiblaryApp.WpfUI.Core;
using Szymanski.LiblaryApp.WpfUI.MVVM.View;
using Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;
using Szymanski.LiblaryApp.WpfUI.Services;
using Szymanski.LibraryApp.BL;

namespace Szymanski.LiblaryApp.WpfUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddSingleton<MainWindow>(provider => new MainWindow()
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            });
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<BooksViewModel>(provider => new BooksViewModel(provider.GetRequiredService<BL>()));
            services.AddSingleton<AuthorsViewModel>(provider => new AuthorsViewModel(provider.GetRequiredService<BL>()));
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton(new BL(ConfigurationManager.AppSettings["DAOLibraryName"]));

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider =>
                viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));
            
            _serviceProvider = services.BuildServiceProvider();
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
        
        
        //
        // public App()
        // {
        //     ServiceCollection services = new ServiceCollection();
        //     ConfigureServices(services);
        //     serviceProvider = services.BuildServiceProvider();
        // }
        //
        // private void ConfigureServices(ServiceCollection services)
        // {
        //     services.AddSingleton<MainWindowViewModel>();
        //     services.AddSingleton<MainWindow>();
        // }
        //
        
    }
}