using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Services
{
    public class BoardService : IBoardService
    {
        void IBoardService.AddNewBoard(Board board)
        {
            App.Repository.Boards.UpsertAsync(board);
        }
    }
}
