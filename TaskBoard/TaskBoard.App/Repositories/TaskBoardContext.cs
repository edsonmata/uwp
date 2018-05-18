using Microsoft.EntityFrameworkCore;
using TaskBoard.App.Models;

namespace TaskBoard.App.Repositories
{
    public class TaskBoardContext : DbContext
    {
        /// <summary>
        /// Creates a new Contoso DbContext.
        /// </summary>
        public TaskBoardContext(DbContextOptions<TaskBoardContext> options) : base(options)
        { }

        /// <summary>
        /// Gets the cards DbSet.
        /// </summary>
        public DbSet<Card> Cards { get; set; }

        /// <summary>
        /// Gets the card groups DbSet.
        /// </summary>
        public DbSet<CardGroup> CardGroups { get; set; }

        /// <summary>
        /// Gets the board DbSet.
        /// </summary>
        public DbSet<Board> Boards { get; set; }

        /// <summary>
        /// Gets the board groups DbSet.
        /// </summary>
        public DbSet<BoardGroup> BoardGroups { get; set; }
    }
}
