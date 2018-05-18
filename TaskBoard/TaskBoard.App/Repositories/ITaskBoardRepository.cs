namespace TaskBoard.App.Repositories
{
    /// <summary>
    /// Defines methods for interacting with the app backend.
    /// </summary>
    public interface ITaskBoardRepository
    {
        /// <summary>
        /// Returns the cards repository.
        /// </summary>
        ICardRepository Cards { get; }

        /// <summary>
        /// Returns the card Groups repository.
        /// </summary>
        ICardGroupRepository CardGroups { get; }

        /// <summary>
        /// Returns the board repository.
        /// </summary>
        IBoardRepository Boards { get; }

        /// <summary>
        /// Returns the board Group repository.
        /// </summary>
        IBoardGroupRepository BoardGroups { get; }
    }
}
