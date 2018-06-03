using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Util;

namespace WEB_API.Models
{
    public class TicketRepository : ITicket
    {

        private List<Ticket> Tickets = new List<Ticket>();
        private int _nextId = 1;

        public TicketRepository()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"../tickets.json");
            var result = JsonConvert.DeserializeObject<List<Ticket>>(json);

            foreach (var lista in result) {

                Add(new Ticket {
                    TicketId = lista.TicketId,
                    CategoryId = lista.CategoryId,
                    CustomerId = lista.CustomerId,
                    CustomerName = lista.CustomerName,
                    CustomerEmail = lista.CustomerEmail,
                    DateCreate = lista.DateCreate,
                    DateUpdate = lista.DateUpdate,
                    Interactions = lista.Interactions,
                    Priority = lista.Priority
                });

            }
        }
        public Ticket Add(Ticket item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.TicketId = _nextId++;
            Tickets.Add(item);
            return item;
        }
        public Ticket Get(int id)
        {
            return Tickets.Find(p => p.TicketId == id);
        }
        public IEnumerable<Ticket> GetAll()
        {
            return Tickets;
        }
        public void Remove(int id)
        {
            Tickets.RemoveAll(p => p.TicketId == id);
        }
        public bool Update(Ticket item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Tickets.FindIndex(p => p.TicketId == item.TicketId);
            if (index == -1)
            {
                return false;
            }
            Tickets.RemoveAt(index);
            Tickets.Add(item);
            return true;
        }
    }
}
