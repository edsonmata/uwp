using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Repositories.Sql
{
    public class SqlCardRepository : ICardRepository
    {
        private readonly TaskBoardContext _db;

        public SqlCardRepository(TaskBoardContext db)
        {
            _db = db;
        }

        public async Task<Card> UpsertAsync(Card card)
        {
            var existing = await _db.Cards.FirstOrDefaultAsync(x => x.Id == card.Id);
            if (null == existing)
            {
                _db.Cards.Add(card);
            }
            else
            {
                _db.Entry(existing).CurrentValues.SetValues(card);
            }
            await _db.SaveChangesAsync();
            return card;
        }

        public async Task DeleteAsync(Guid cardId)
        {
            var match = await _db.Cards.FindAsync(cardId);
            if (match != null)
            {
                _db.Cards.Remove(match);
            }
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Card>> GetForCardsByCardGroupIdAsync(Guid cardGroupId)
        {
            return await _db.Cards
                .Where(x => x.CardGroupId == cardGroupId)
                .ToListAsync();
        }

        public async Task<Card> GetAsync(Guid id)
        {
            return await _db.Cards
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
