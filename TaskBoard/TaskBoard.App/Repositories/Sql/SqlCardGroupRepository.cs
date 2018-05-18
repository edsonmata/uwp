using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Repositories.Sql
{
    public class SqlCardGroupRepository : ICardGroupRepository
    {
        private readonly TaskBoardContext _db;

        public SqlCardGroupRepository(TaskBoardContext db)
        {
            _db = db;
        }

        public async Task<CardGroup> GetAsync(Guid id)
        {
            return await _db.CardGroups
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CardGroup> UpsertAsync(CardGroup cardGroup)
        {
            var current = await _db.CardGroups.FirstOrDefaultAsync(x => x.Id == cardGroup.Id);
            if (null == current)
            {
                _db.CardGroups.Add(cardGroup);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(cardGroup);
            }
            await _db.SaveChangesAsync();
            return cardGroup;
        }

        public async Task DeleteAsync(Guid id)
        {
            var cardGroup = await _db.CardGroups.FirstOrDefaultAsync(x => x.Id == id);
            if (null != cardGroup)
            {
                var cards = await _db.Cards.Where(x => x.CardGroupId == id).ToListAsync();
                _db.Cards.RemoveRange(cards);
                _db.CardGroups.Remove(cardGroup);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CardGroup>> GetForCardGroupsByBoardIdAsync(Guid boardId)
        {
            return await _db.CardGroups
                .Where(x => x.BoardId == boardId)
                .ToListAsync();
        }
    }
}
