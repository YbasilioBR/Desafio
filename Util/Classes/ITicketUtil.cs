using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Classes
{
    interface ITicketUtil
    {

        List<TicketUtil> RetornaTickets();
        bool GravaTickets(List<TicketUtil> objTicket);
        string RetornaJson();
     

    }
}
