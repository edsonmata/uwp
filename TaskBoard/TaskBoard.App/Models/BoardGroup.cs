using System;
using System.Collections.ObjectModel;

namespace TaskBoard.App.Models
{
    public class BoardGroup : DbObject
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        private Guid user;
        public Guid User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        /// <summary>
        /// Gets or sets the description of the board group.
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
        private ObservableCollection<Board> boards;
        public virtual ObservableCollection<Board> Boards
        {
            get { return boards; }
            set { SetProperty(ref boards, value); }
        }
    }
}
