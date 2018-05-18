using System;
using System.Collections.ObjectModel;

namespace TaskBoard.App.Models
{
    public class CardGroup : DbObject
    {

        public CardGroup()
        {

        }

        public CardGroup(Board board)
        {
            this.Board = board;
        }

        /// <summary>
        /// Gets or sets the description of the task group.
        /// </summary>
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        /// <summary>
        /// Gets or sets the cards.
        /// </summary>
        private ObservableCollection<Card> cards;
        public virtual ObservableCollection<Card> Cards
        {
            get { return cards; }
            set { SetProperty(ref cards, value); }
        }

        /// <summary>
        /// Gets or sets the id of the board.
        /// </summary>
        public Guid BoardId { get; set; }

        /// <summary>
        /// Gets or sets the board.
        /// </summary>
        public Board Board { get; set; }
    }
}
