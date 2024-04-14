using OP5.MVVM.Core;
using OP5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace OP5.MVVM.ViewModel
{
    public class MainWindowViewModel: ViewModelBase
    {

		private INavigationService _navigation;
		public INavigationService Navigation
		{
			get => _navigation;
			set
			{
				_navigation = value;
				OnPropertyChanged();
			}
		}

		public RelayCommand NavigateToTableCommand { get; set; }

        public MainWindowViewModel(INavigationService navigationService)
		{
			Navigation = navigationService;

            Navigation.NavigateTo<TableViewModel>();

        }

	}
}
