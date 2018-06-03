using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models;

namespace WEB_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Ticket")]
    public class TicketController : Controller
    {

        static readonly ITicket repositorio = new TicketRepository();

        [HttpGet]
        public IEnumerable<Ticket> GetAllTickets()
        {
            return repositorio.GetAll();
        }

        public Ticket GetTicket(int id)
        {
            Ticket item = repositorio.Get(id);
            if (item == null)
            {
                return null;
            }
            return item;
        }


        /* public IEnumerable<Ticket> GetTicketsPorCategoria(string categoria)
         {
             return repositorio.GetAll().Where(
                 p => string.Equals(p.CategoryId, categoria, StringComparison.OrdinalIgnoreCase));
         }*/


        public bool PostTicket(Ticket item)
        {
            item = repositorio.Add(item);
           
            string uri = Url.Link("DefaultApi", new { id = item.TicketId });
            
            return true;
        }


        public void PutTicket(int id, Ticket Ticket)
        {
            Ticket.TicketId = id;
            if (!repositorio.Update(Ticket))
            {
                throw new HttpResponseException();
            }
        }
        public void DeleteTicket(int id)
        {
            Ticket item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }

    }
}