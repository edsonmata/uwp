using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Services
{
    public class CardService : ICardService
    {
        public void AddNewCard(Card card)
        {
            Task.Run(async () =>
            {
                await App.Repository.Cards.UpsertAsync(card);
            });
        }
    }
}
