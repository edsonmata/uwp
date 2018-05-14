using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace MyTrello.Models
{
    public class Board : BindableBase
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private ObservableCollection<CardsList> cardsList;
        public ObservableCollection<CardsList> CardsList
        {
            get { return cardsList; }
            set { SetProperty(ref cardsList, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
