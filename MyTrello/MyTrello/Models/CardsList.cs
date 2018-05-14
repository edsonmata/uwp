using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyTrello.Models
{
    public class CardsList : BindableBase
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private ObservableCollection<Card> cards;
        public ObservableCollection<Card> Cards
        {
            get { return cards; }
            set { SetProperty(ref cards, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
