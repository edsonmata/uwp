using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Services
{
    public class CardGroupService : ICardGroupService
    {
        public async Task AddNewCardGroupAsync(CardGroup cardGroup)
        {
            await App.Repository.CardGroups.UpsertAsync(cardGroup);
        }
    }
}
