using System;

namespace TaskBoard.App.Models
{
    public class Card : DbObject
    {
        /// <summary>
        /// Creates a new task.
        /// </summary>
        public Card()
        {
                
        }

        /// <summary>
        /// Creates a new task for the task group.
        /// </summary>
        public Card(CardGroup cardGroup)
        {
            this.CardGroup = cardGroup;
        }

        /// <summary>
        /// Gets or sets the title of the task
        /// </summary>
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        /// <summary>
        /// Gets or sets the description of the task.
        /// </summary>
        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        /// <summary>
        /// Gets or sets the id of the task group.
        /// </summary>
        public Guid CardGroupId { get; set; }

        /// <summary>
        /// Gets or sets the task group the line item is associated with.
        /// </summary>
        public CardGroup CardGroup { get; set; }
    }
}
