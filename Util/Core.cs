using System;
using System.Collections.Generic;
using Util.Classes;
using System.IO;

namespace Util
{
    public class Core
    {

        public void ClassificaTickets()
        {
            
            Ticket classe = new Ticket();
            var ticketsClassificados = new List<Ticket>();
            List<Ticket> ticket = new List<Ticket>();
            ticket = classe.RetornaTickets();

            for (int i = 0; i < ticket.Count; i++)
            {
                int classificacao = 0;

                classificacao++;
            }



        }

    }
}
