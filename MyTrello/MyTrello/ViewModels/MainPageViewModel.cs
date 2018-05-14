using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using MyTrello.Services;
using System.Collections.Generic;

namespace MyTrello.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService navigation;
        private IDataService dataService;

        public MainPageViewModel(INavigationService navigation, IDataService dataService)
        {
            this.navigation = navigation;
            this.dataService = dataService;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }
    }
}
