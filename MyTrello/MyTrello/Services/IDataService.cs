using System.Collections.Generic;
using MyTrello.Models;

namespace MyTrello.Services
{
    public interface IDataService
    {
        Board GetBoard();

        List<Card> SearchCard(string query);

        Board SearchBoard(string query);

        CardsList GetNewCardsList(string title);
    }
}
