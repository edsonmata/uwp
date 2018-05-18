using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Repositories.Sql
{
    public class SqlBoardRepository : IBoardRepository
    {
        private readonly TaskBoardContext _db;

        public SqlBoardRepository(TaskBoardContext db)
        {
            _db = db;
        }

        public async Task<Board> GetAsync(Guid id)
        {
            return await _db.Boards
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Board> UpsertAsync(Board board)
        {
            var current = await _db.Boards.FirstOrDefaultAsync(x => x.Id == board.Id);
            if (null == current)
            {
                _db.Boards.Add(board);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(board);
            }
            await _db.SaveChangesAsync();
            return board;
        }

        public async Task DeleteAsync(Guid id)
        {
            var board = await _db.Boards.FirstOrDefaultAsync(x => x.Id == id);
            if (null != board)
            {
                var cardGroups = await _db.CardGroups.Where(x => x.BoardId == id).ToListAsync();
                _db.CardGroups.RemoveRange(cardGroups);
                _db.Boards.Remove(board);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Board>> GetForBoardsByBoardIdAsync(Guid boardGroupId)
        {
            return await _db.Boards
                .Where(x => x.BoardGroupId == boardGroupId)
                .ToListAsync();
        }
    }
}
