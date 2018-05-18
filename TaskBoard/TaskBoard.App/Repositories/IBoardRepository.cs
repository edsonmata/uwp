using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Repositories
{
    public interface IBoardRepository
    {
        /// <summary>
        /// Returns the board with the given id. 
        /// </summary>
        Task<Board> GetAsync(Guid id);

        /// <summary>
        /// Adds a new board if the board does not exist, updates the 
        /// existing board otherwise.
        /// </summary>
        Task<Board> UpsertAsync(Board board);

        /// <summary>
        /// Deletes a board.
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Returns all the given board Group's Board. 
        /// </summary>
        Task<IEnumerable<Board>> GetForBoardsByBoardIdAsync(Guid boardGroupId);
    }
}
