using MyTrello.Models;
using MyTrello.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

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

        private void InitializeCommands()
        {
            AddNewCardListCommand = new DelegateCommand(AddNewCardList);
        }

        private void DragStarting()
        {
            throw new NotImplementedException();
        }

        public CardsList GetCardsListById(int id)
        {
            return board.CardsList.First(item => item.ID == id);
        }

        public void MoveCardToNewCardsList(int idCard, int idCardsListSource)
        {

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
