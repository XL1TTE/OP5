using Microsoft.Extensions.DependencyInjection;
using OP5.MVVM.Core;
using OP5.MVVM.View;
using OP5.MVVM.ViewModel;
using OP5.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OP5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow()
            {
                DataContext = _serviceProvider.GetRequiredService<MainWindowViewModel>()
            });

            services.AddSingleton<TableViewModel>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<Func<Type, ViewModelBase>>(provider => viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));

            services.AddSingleton<INavigationService, NavigationService>();
            

            _serviceProvider =  services.BuildServiceProvider();

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }

    }
}
