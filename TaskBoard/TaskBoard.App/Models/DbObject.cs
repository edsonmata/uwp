using Prism.Mvvm;
using System;

namespace TaskBoard.App.Models
{
    /// <summary>
    /// Base class for database entities.
    /// </summary>
    public class DbObject : BindableBase
    {
        /// <summary>
        /// Gets or sets the database id.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
