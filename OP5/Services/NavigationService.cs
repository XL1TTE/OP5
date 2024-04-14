using OP5.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP5.Services
{

    public interface INavigationService
    {
        public ViewModelBase CurrentViewModel { get; }
        public void NavigateTo<ViewModel>() where ViewModel : ViewModelBase;
    }
    public class NavigationService : ObservableObject, INavigationService
    {
        private Func<Type, ViewModelBase> _viewModelFactory;


        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }


        public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<ViewModel>() where ViewModel : ViewModelBase
        {
            ViewModelBase _viewModel = _viewModelFactory.Invoke(typeof(ViewModel));
            CurrentViewModel = _viewModel;
        }
    }
}
