using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Util.Classes
{
    class TicketRepositoryUtil : ITicketUtil
    {

        public List<TicketUtil> RetornaTickets()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"../tickets.json");
            var result = JsonConvert.DeserializeObject<List<TicketUtil>>(json);

            return result;

        }

        public bool GravaTickets(List<TicketUtil> objTicket)
        {
            var json = JsonConvert.SerializeObject(objTicket, Formatting.Indented);

            TextWriter writer;
            using (writer = new StreamWriter(@"../tickets.json", append: false))
            {
                writer.WriteLine(json);
            }

            return true;

        }

        public string RetornaJson()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"../tickets.json");

            return json;
        }
    }
}
