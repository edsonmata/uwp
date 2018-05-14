using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyTrello.Models;

namespace MyTrello.Services
{
    public class DataService : IDataService
    {
        private int identifier = 1;

        public Board GetBoard()
        {
            Board board = new Board();

            board.ID = 1;
            board.Title = "First Board";
            board.CardsList = new ObservableCollection<CardsList>();

            CardsList cardList = new CardsList();
            cardList.Title = "First CardList";
            cardList.ID = 1;
            cardList.Cards = new ObservableCollection<Card>();
            cardList.Cards.Add(new Card() { ID = 1, Title = "Fisrt Card", Description = "Description Fisrt Card" });

            board.CardsList.Add(cardList);

            CardsList cardList2 = new CardsList();
            cardList2.Title = "Second CardList";
            cardList2.ID = 2;
            cardList2.Cards = new ObservableCollection<Card>();
            cardList2.Cards.Add(new Card() { ID = 3, Title = "Third Card", Description = "Description Third Card" });

            board.CardsList.Add(cardList2);

            return board;
        }

        public List<Card> SearchCard(string query)
        {
            throw new NotImplementedException();
        }

        public Board SearchBoard(string query)
        {
            throw new NotImplementedException();
        }

        public CardsList GetNewCardsList(string title)
        {
            CardsList cardList = new CardsList();
            cardList.ID = identifier;
            cardList.Title = title;            
            cardList.Cards = new ObservableCollection<Card>();
            return cardList;
        }
    }
}
