﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Util.Classes
{
    class TicketUtil
    {
        [JsonProperty("TicketID")]
        public long TicketId { get; set; }

        [JsonProperty("CategoryID")]
        public long CategoryId { get; set; }

        [JsonProperty("CustomerID")]
        public long CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        public string CustomerName { get; set; }

        [JsonProperty("CustomerEmail")]
        public string CustomerEmail { get; set; }

        [JsonProperty("DateCreate")]
        public DateTimeOffset DateCreate { get; set; }

        [JsonProperty("DateUpdate")]
        public DateTimeOffset DateUpdate { get; set; }

        [JsonProperty("Interactions")]
        public List<object> Interactions { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }
      
    }
}
