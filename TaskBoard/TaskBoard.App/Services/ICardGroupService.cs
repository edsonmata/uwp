using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Services
{
    public interface ICardGroupService
    {
        Task AddNewCardGroupAsync(CardGroup cardGroup);
    }
}
