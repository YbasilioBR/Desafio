﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Classes;

namespace Util
{
    public class Core
    {
        static readonly ITicketUtil repositorio = new TicketRepositoryUtil();

        public void ClassificaTickets()
        {
            var ticketsClassificados = new List<TicketUtil>();
            List<TicketUtil> ticket = new List<TicketUtil>();
            ticket = repositorio.RetornaTickets();

            foreach (var listaAnalisada in ticket)
            {
                int alta = 0;
                int normal = 0;

                if (listaAnalisada.Interactions.Count > 2)
                {
                    alta += 1;
                }
                else
                {
                    normal += 1;
                }

                if (listaAnalisada.DateUpdate.Subtract(listaAnalisada.DateCreate).Days >= 30)
                {
                    alta += 1;
                }

                if (listaAnalisada.Interactions.Count != 0)
                {
                    int reclamacao = 0;
                    int elogio = 0;

                    foreach (var interacoes in listaAnalisada.Interactions)
                    {
                        if (interacoes.ToString().Contains("Reclamação"))
                        {
                            reclamacao += 1;
                        }

                        if (interacoes.ToString().Contains("Elogios"))
                        {
                            elogio += 1;
                        }
                    }

                    if (reclamacao > 0)
                        alta += 1;
                    if (elogio > 0)
                        normal += 1;
                }

                if (alta > normal)
                {
                    listaAnalisada.Priority = "alta";
                }
                else
                {
                    listaAnalisada.Priority = "normal";
                }

                ticketsClassificados.Add(listaAnalisada);

            }

            repositorio.GravaTickets(ticketsClassificados);
            
        }
    }
}