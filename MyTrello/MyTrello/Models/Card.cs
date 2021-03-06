﻿using Prism.Mvvm;

namespace MyTrello.Models
{
    public class Card: BindableBase
    {

        //public Card(CardsList cardsList)
        //{
        //   CardsList = cardsList;
        //}

        private CardsList cardsList;
        public CardsList CardsList
        {
            get { return cardsList; }
            set { SetProperty(ref cardsList, value); }
        }

        private int id;
        public int ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
    }
}
