using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Repositories
{
    public interface IBoardGroupRepository
    {
        /// <summary>
        /// Returns the board Group with the given id. 
        /// </summary>
        Task<BoardGroup> GetAsync(Guid id);

        /// <summary>
        /// Adds a new board Group if the board Group does not exist, updates the 
        /// existing board Group otherwise.
        /// </summary>
        Task<BoardGroup> UpsertAsync(BoardGroup boardGroup);

        /// <summary>
        /// Deletes a board Group.
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Returns all the given board's BoardGroup. 
        /// </summary>
        Task<IEnumerable<BoardGroup>> GetForBoardGroupsByUserIdAsync(Guid userId);
    }
}
