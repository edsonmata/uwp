using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Repositories
{
    public interface ICardGroupRepository
    {
        /// <summary>
        /// Returns the card Group with the given id. 
        /// </summary>
        Task<CardGroup> GetAsync(Guid id);

        /// <summary>
        /// Adds a new card Group if the card Group does not exist, updates the 
        /// existing card Group otherwise.
        /// </summary>
        Task<CardGroup> UpsertAsync(CardGroup cardGroup);

        /// <summary>
        /// Deletes a card Group.
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Returns all the given board's CardGroup. 
        /// </summary>
        Task<IEnumerable<CardGroup>> GetForCardGroupsByBoardIdAsync(Guid boardId);
    }
}
