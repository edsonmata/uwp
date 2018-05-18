using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Repositories.Sql
{
    public class SqlBoardGroupRepository : IBoardGroupRepository
    {
        private readonly TaskBoardContext _db;

        public SqlBoardGroupRepository(TaskBoardContext db)
        {
            _db = db;
        }

        public async Task<BoardGroup> GetAsync(Guid id)
        {
            return await _db.BoardGroups
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BoardGroup> UpsertAsync(BoardGroup boardGroup)
        {
            var current = await _db.BoardGroups.FirstOrDefaultAsync(x => x.Id == boardGroup.Id);
            if (null == current)
            {
                _db.BoardGroups.Add(boardGroup);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(boardGroup);
            }
            await _db.SaveChangesAsync();
            return boardGroup;
        }

        public async Task DeleteAsync(Guid id)
        {
            var boardGroup = await _db.BoardGroups.FirstOrDefaultAsync(x => x.Id == id);
            if (null != boardGroup)
            {
                var boards = await _db.Boards.Where(x => x.BoardGroupId == id).ToListAsync();
                _db.Boards.RemoveRange(boards);
                _db.BoardGroups.Remove(boardGroup);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BoardGroup>> GetForBoardGroupsByUserIdAsync(Guid userId)
        {
            return await _db.BoardGroups
                .Where(x => x.User == userId)
                .ToListAsync();
        }
    }
}
