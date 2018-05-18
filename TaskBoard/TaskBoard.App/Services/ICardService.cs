using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.App.Models;

namespace TaskBoard.App.Services
{
    public interface ICardService
    {
        void AddNewCard(Card card);
    }
}
