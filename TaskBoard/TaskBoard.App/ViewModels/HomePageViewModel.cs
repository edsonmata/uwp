using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TaskBoard.App.Models;
using TaskBoard.App.Services;

namespace TaskBoard.App.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private INavigationService navigation;
        private ICardService cardService;
        private ICardGroupService cardGroupService;
        private IBoardService boardService;
        private Board board;
        public Board Board
        {
            get { return board; }
            set { SetProperty(ref board, value); }
        }

        public HomePageViewModel(INavigationService navigation, ICardService cardService, ICardGroupService cardGroupService, IBoardService boardService)
        {
            this.navigation = navigation;
            this.cardService = cardService;
            this.cardGroupService = cardGroupService;
            this.boardService = boardService;
            InitializeCommands();
        }

        private void CreateStructure()
        {
            Board newBoard = new Board();

            newBoard.Title = "Primeiro Quadro";
            newBoard.CardGroups = new ObservableCollection<CardGroup>();

            CardGroup newCardGroup = new CardGroup(newBoard);
            newCardGroup.Title = "Lista de Cards";
            newCardGroup.Cards = new ObservableCollection<Card>();

            Card newCard = new Card(newCardGroup);
            newCard.Title = "Novo Card";

            newBoard.CardGroups.Add(newCardGroup);

            boardService.AddNewBoard(newBoard);
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

        private void AddNewCardList()
        {
            CardGroup newCardGroup = new CardGroup();


            Task.Run(async () =>
            {
                await cardGroupService.AddNewCardGroupAsync(newCardGroup);
            });
        }

        #endregion

    }
}
