using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Repositories
{
    public interface ICardRepository
    {
        /// <summary>
        /// Adds a new card if the card does not exist, updates the 
        /// existing card otherwise.
        /// </summary>
        Task<Card> UpsertAsync(Card card);

        /// <summary>
        /// Deletes a card.
        /// </summary>
        Task DeleteAsync(Guid cardId);

        /// <summary>
        /// Returns all the given cardGroup's Cards. 
        /// </summary>
        Task<IEnumerable<Card>> GetForCardsByCardGroupIdAsync(Guid cardGroupId);

        /// <summary>
        /// Returns the card with the given id. 
        /// </summary>
        Task<Card> GetAsync(Guid id);
    }        
}
