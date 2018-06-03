using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models
{
    interface ITicket
    {
        IEnumerable<Ticket> GetAll();
        Ticket Get(int id);
        Ticket Add(Ticket item);
        void Remove(int id);
        bool Update(Ticket item);
    }
}
