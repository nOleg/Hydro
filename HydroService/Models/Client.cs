using System;
using System.ComponentModel.DataAnnotations;


namespace Gold.Vikings.Models{

    public class Client : IClient
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public DateTime ClientRegistred { get; set; }
    }

}