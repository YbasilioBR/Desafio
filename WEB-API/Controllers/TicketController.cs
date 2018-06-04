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
        public IEnumerable<Ticket> GetAll()
        {
            return repositorio.GetAll();
        }

        [HttpGet("GetByCreate")]
        public IEnumerable<Ticket> GetByCreate()
        {
            return repositorio.GetByCreate();
        }

        [HttpGet("GetByUpdate")]
        public IEnumerable<Ticket> GetByUpdate()
        {
            return repositorio.GetByUpdate();
        }
        
        [HttpGet("GetByPriority")]
        public IEnumerable<Ticket> GetByPriority()
        {
            return repositorio.GetByPriority();
        }

        [HttpGet("GetInDate/{inicial}/{final}")]
        public IEnumerable<Ticket> GetInDate(string inicial, string final)
        {
            return repositorio.GetInDate(inicial, final);
        }

        [HttpGet("{id}")]
        public Ticket Get(int id)
        {
            Ticket item = repositorio.Get(id);
            if (item == null)
            {
                return null;
            }
            return item;
        }

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