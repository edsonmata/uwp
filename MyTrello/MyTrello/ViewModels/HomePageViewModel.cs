using MyTrello.Models;
using MyTrello.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;

namespace MyTrello.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private INavigationService navigation;
        private IDataService dataService;
        private Board board;
        public Board Board
        {
            get { return board; }
            set { SetProperty(ref board, value); }
        }

        public HomePageViewModel(INavigationService navigation, IDataService dataService)
        {
            this.navigation = navigation;
            this.dataService = dataService;
            board = dataService.GetBoard();
            InitializeCommands();
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }

        #region Commands

        public DelegateCommand AddNewCardListCommand { get; private set; }
        public DelegateCommand DragEnterCommand { get; private set; }
        public DelegateCommand DragLeaveCommand { get; private set; }
        public DelegateCommand DropCommand { get; private set; }
        public DelegateCommand DragStartingCommand { get; private set; }

        private void InitializeCommands()
        {
            AddNewCardListCommand = new DelegateCommand(AddNewCardList);
            DragEnterCommand = new DelegateCommand(DragEnter);
            DragLeaveCommand = new DelegateCommand(DragLeave);
            DropCommand = new DelegateCommand(Drop);
            DragStartingCommand = new DelegateCommand(DragStarting);
        }

        private void DragStarting()
        {
            throw new NotImplementedException();
        }

        private void Drop()
        {
            throw new NotImplementedException();
        }

        private void DragLeave()
        {
            throw new NotImplementedException();
        }

        private void DragEnter()
        {
            throw new NotImplementedException();
        }

        private void AddNewCardList()
        {
            CardsList newCardsList = dataService.GetNewCardsList("Nova Lista de Cards");
            Board.CardsList.Add(newCardsList);
        }

        #endregion
    }
}
