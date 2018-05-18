using Microsoft.EntityFrameworkCore;

namespace TaskBoard.App.Repositories.Sql
{
    public class SqlTaskBoardRepository : ITaskBoardRepository
    {
        private readonly DbContextOptions<TaskBoardContext> _dbOptions;

        public SqlTaskBoardRepository(DbContextOptionsBuilder<TaskBoardContext>
            dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new TaskBoardContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public ICardRepository Cards => new SqlCardRepository(
            new TaskBoardContext(_dbOptions));

        public ICardGroupRepository CardGroups => new SqlCardGroupRepository(
            new TaskBoardContext(_dbOptions));

        public IBoardRepository Boards => new SqlBoardRepository(
            new TaskBoardContext(_dbOptions));

        public IBoardGroupRepository BoardGroups => new SqlBoardGroupRepository(
            new TaskBoardContext(_dbOptions));
    }
}
