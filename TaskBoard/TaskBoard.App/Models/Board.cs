using System;
using System.Collections.ObjectModel;

namespace TaskBoard.App.Models
{
    public class Board : DbObject
    {
        /// <summary>
        /// Creates a new board.
        /// </summary>
        public Board()
        {
                
        }

        /// <summary>
        /// Creates a new task for the board group.
        /// </summary>
        public Board(BoardGroup boardGroup)
        {
            this.BoardGroup = boardGroup;
        }

        /// <summary>
        /// Gets or sets the title of the card
        /// </summary>
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        /// <summary>
        /// Gets or sets the card Groups
        /// </summary>
        private ObservableCollection<CardGroup> cardGroups;
        public ObservableCollection<CardGroup> CardGroups
        {
            get { return cardGroups; }
            set { SetProperty(ref cardGroups, value); }
        }

        /// <summary>
        /// Gets or sets the id of the board group.
        /// </summary>
        public Guid BoardGroupId { get; set; }

        /// <summary>
        /// Gets or sets the board group.
        /// </summary>
        public BoardGroup BoardGroup { get; set; }
    }
}
